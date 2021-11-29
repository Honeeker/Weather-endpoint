using System.Collections.Generic;
using System.Threading.Tasks;
using ModularEndpoint.Modules.Importer.Core.Entities;

namespace ModularEndpoint.Modules.Importer.DAL.Repositories
{
    public interface IWeatherHistoryRepository
    {
        Task AddAsync<T>(T data);
        Task AddRageAsync(List<MeteorologicalData> datas);
    }
}