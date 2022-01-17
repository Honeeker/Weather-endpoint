using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModularEndpoint.Modules.Weather.Core.DTO;
using ModularEndpoint.Modules.Weather.Core.Services;

namespace ModularEndpoint.Modules.Weather.Api.Controllers
{
    internal class StationController: BaseController
    {
        private readonly IStationService _stationService;
        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<StationDto>>> GetAll() => Ok(await _stationService.GetAllAsync());
    }
}