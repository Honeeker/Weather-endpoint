using System.Collections.Generic;
using System.Threading.Tasks;
using ModularEndpoint.Modules.Weather.Core.DAL.Repositories;
using ModularEndpoint.Modules.Weather.Core.Entities;

namespace ModularEndpoint.Modules.Weather.Core.Services
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;
        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }
        public async Task<IReadOnlyList<Station>> GetAllAsync()
        {
            return await _stationRepository.GetAllAsync();
        }
    }
}