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
        public async Task<ActionResult<IReadOnlyList<MeteorologicalDataDto>>> GetAllAsync(
            [FromQuery(Name = "stationId")] IReadOnlyList<string> stations,
            [FromQuery(Name = "year")] IReadOnlyList<int> years,
            [FromQuery(Name = "month")] IReadOnlyList<int> months
        )
        {
            IReadOnlyList<MeteorologicalDataDto> weather = await _weatherService.GetAllAsync(stations, years, months);
            if(weather.Count == 0)
            {
                return NoContent();
            }
            return Ok(weather);
        }

        [HttpGet("years")]
        public async Task<ActionResult<IReadOnlyList<int>>> GetAllYears()
        {
            var years = await _weatherService.GetYearsAsync();
            if(years.Count == 0)
            {
                return NoContent();
            }
            return Ok(years);
        }
    }
}