using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularEndpoint.Modules.Weather.Core.DAL.Repositories;
using ModularEndpoint.Modules.Weather.Core.Entities;

namespace ModularEndpoint.Modules.Weather.Core.DAL.EF
{
    internal class WeatherRepository: IWeatherRepository
    {
        private readonly WeatherDbContext _context;

        private readonly DbSet<MeteorologicalData> _meteorologicalData;
        public WeatherRepository(WeatherDbContext context)
        {
            _context = context;
            _meteorologicalData = _context.MeteorologicalDatas;
        }

        public async Task<IReadOnlyList<MeteorologicalData>> GetAllAsync()
        {
            return await _meteorologicalData.ToListAsync();
        }

        public async Task<IReadOnlyList<MeteorologicalData>> GetAllAsync(IReadOnlyList<string> stations, IReadOnlyList<int> years, IReadOnlyList<int> months)
        {
            IQueryable<MeteorologicalData> query = _meteorologicalData.AsQueryable();
            if(stations.Count > 0)
            {
                query = query.Where(md => stations.Contains(md.StationId));
            }else
            {
                return new List<MeteorologicalData>();
            }

            if(years.Count > 0)
            {
                query = query.Where(md => years.Contains(md.Date.Year));
            }
            if(months.Count > 0)
            {
                query = query.Where(md => months.Contains(md.Date.Month));
            }
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<int>> GetYearsAsync()
        {
           return await _meteorologicalData.Select(s => s.Date.Year).Distinct().OrderByDescending(year => year).ToListAsync();
        }
    }
}