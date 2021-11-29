using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModularEndpoint.Modules.Weather.Core.DTO;
using ModularEndpoint.Modules.Weather.Core.Services;

namespace ModularEndpoint.Modules.Weather.Api.Controllers
{
    internal class WeatherController: BaseController
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MeteorologicalDataDto>>> GetAllAsync()
        {
            return Ok(await _weatherService.GetAllAsync());
        }
    }
}