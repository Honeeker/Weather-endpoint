using System.Collections.Generic;
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
    }
}