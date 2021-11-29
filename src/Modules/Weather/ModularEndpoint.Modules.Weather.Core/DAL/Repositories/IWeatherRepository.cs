using System.Collections.Generic;
using System.Threading.Tasks;
using ModularEndpoint.Modules.Weather.Core.Entities;

namespace ModularEndpoint.Modules.Weather.Core.DAL.Repositories
{
    public interface IWeatherRepository
    {
        Task<IReadOnlyList<MeteorologicalData>> GetAllAsync();
    }
}