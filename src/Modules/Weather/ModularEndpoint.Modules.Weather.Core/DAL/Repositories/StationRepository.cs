using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularEndpoint.Modules.Weather.Core.Entities;

namespace ModularEndpoint.Modules.Weather.Core.DAL.Repositories
{
    public class StationRepository : IStationRepository
    {
        private readonly WeatherDbContext _weatherDbContext;
        private readonly DbSet<Station> _stations;
        public StationRepository(WeatherDbContext weatherDbContext)
        {
            _weatherDbContext = weatherDbContext;
            _stations = _weatherDbContext.Stations;
        }
        public async Task<IReadOnlyList<Station>> GetAllAsync()
        {
            List<string> stationsWithWeather = await _weatherDbContext.MeteorologicalDatas.Select(md => md.StationId).Distinct().ToListAsync();
            return await _stations.Where(s => stationsWithWeather.Contains(s.Id)).ToListAsync();
        }
    }
}