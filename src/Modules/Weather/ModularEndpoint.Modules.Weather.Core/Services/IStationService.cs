using System.Collections.Generic;
using System.Threading.Tasks;
using ModularEndpoint.Modules.Weather.Core.Entities;

namespace ModularEndpoint.Modules.Weather.Core.Services
{
    public interface IStationService
    {
        Task<IReadOnlyList<Station>> GetAllAsync();
    }
}