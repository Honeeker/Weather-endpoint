using System.Collections.Generic;
using System.Threading.Tasks;
using ModularEndpoint.Modules.Importer.Core.Entities;

namespace ModularEndpoint.Modules.Importer.Core.Services
{
    public interface IWeatherHistoryService
    {
        Task AddAsync<T>(T data);
        Task AddRangeAsync(List<MeteorologicalData> datas);
    }
}