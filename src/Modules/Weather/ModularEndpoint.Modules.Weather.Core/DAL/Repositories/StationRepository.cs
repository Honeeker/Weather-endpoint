using System.Collections.Generic;
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
            return await _stations.ToListAsync();
        }
    }
}