using System.Collections.Generic;
using System.Threading.Tasks;
using ModularEndpoint.Modules.Importer.Core.Entities;
using ModularEndpoint.Modules.Importer.DAL.Repositories;

namespace ModularEndpoint.Modules.Importer.Core.Services
{
    public class WeatherHistoryService : IWeatherHistoryService
    {
        private readonly IWeatherHistoryRepository _weatherHistoryRepository;

        public WeatherHistoryService(IWeatherHistoryRepository weatherHistoryRepositor)
        {
            _weatherHistoryRepository = weatherHistoryRepositor;
        }
        public async Task AddAsync<T>(T data)
        {
            await _weatherHistoryRepository.AddAsync<T>(data);
        }

        public async Task AddRangeAsync(List<MeteorologicalData> datas)
        {
            await _weatherHistoryRepository.AddRageAsync(datas);
        }
    }
}