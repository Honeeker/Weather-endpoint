using System.Collections.Generic;
using System.Threading.Tasks;
using ModularEndpoint.Modules.Weather.Core.DTO;

namespace ModularEndpoint.Modules.Weather.Core.Services
{
    public interface IWeatherService
    {
        Task<IReadOnlyList<MeteorologicalDataDto>> GetAllAsync();
    }
}