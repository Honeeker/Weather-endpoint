using System.Collections.Generic;
using System.Threading.Tasks;
using ModularEndpoint.Modules.Importer.Core.Entities;
using ModularEndpoint.Modules.Importer.DAL.Repositories;

namespace ModularEndpoint.Modules.Importer.Core.DAL.Repositories
{
    public class WeatherHistoryRepository: IWeatherHistoryRepository
    {
        private readonly WeatherHistoryContext _weatherHistoryContext;
        public WeatherHistoryRepository(WeatherHistoryContext weatherHistoryContext)
        {
            _weatherHistoryContext = weatherHistoryContext;
        }

        public async Task AddAsync<T>(T data)
        {
            await _weatherHistoryContext.AddAsync(data);
            await _weatherHistoryContext.SaveChangesAsync();
        }

        public async Task AddRageAsync(List<MeteorologicalData> datas)
        {
            await _weatherHistoryContext.AddRangeAsync(datas);
            await _weatherHistoryContext.SaveChangesAsync();
        }
    }
}