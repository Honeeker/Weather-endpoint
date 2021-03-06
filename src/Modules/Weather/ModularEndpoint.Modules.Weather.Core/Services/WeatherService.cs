using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ModularEndpoint.Modules.Weather.Core.DAL.Repositories;
using ModularEndpoint.Modules.Weather.Core.DTO;
using ModularEndpoint.Modules.Weather.Core.Entities;

namespace ModularEndpoint.Modules.Weather.Core.Services
{
    internal class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly ILogger<WeatherService> _logger;
        public WeatherService(IWeatherRepository weatherRepository, ILogger<WeatherService> logger)
        {
            _weatherRepository = weatherRepository;
            _logger = logger;
        }
        public async Task<IReadOnlyList<MeteorologicalDataDto>> GetAllAsync()
        {
            var meteorologicalData = await _weatherRepository.GetAllAsync();

            return  meteorologicalData.Select(Map<MeteorologicalDataDto>).ToList();
        }
        private static T Map<T>(MeteorologicalData meteorologicalData) where T:  MeteorologicalDataDto, new()
            => new()
            {
                Id = meteorologicalData.Id,
                StationId = meteorologicalData.StationId,
                Date = meteorologicalData.Date,
                MaximumDailyTemperature = meteorologicalData.MaximumDailyTemperature,
                MinimumDailyTemperature = meteorologicalData.MinimumDailyTemperature,
                DailyTemperature = meteorologicalData.DailyTemperature
            };

        public async Task<IReadOnlyList<MeteorologicalDataDto>> GetAllAsync(IReadOnlyList<string> stations, IReadOnlyList<int> years, IReadOnlyList<int> months)
        {
           var meteorologicalData = await _weatherRepository.GetAllAsync(stations, years, months);

           return meteorologicalData.Select(Map<MeteorologicalDataDto>).ToList();
        }

        public async Task<IReadOnlyList<int>> GetYearsAsync()
        {
            return await _weatherRepository.GetYearsAsync();
        }
    }
}