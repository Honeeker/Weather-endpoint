using System;
using System.Collections.Generic;
using ModularEndpoint.Modules.Weather.Core.DAL.Repositories;
using ModularEndpoint.Modules.Weather.Core.Entities;
using Moq;
using Xunit;

namespace ModularEndpoint.Modules.Weather.Tests
{
    public class UnitTest1
    {
        private Mock<IWeatherRepository> _weatherRepository;
        public UnitTest1()
        {
            _weatherRepository = new Mock<IWeatherRepository>();
        }

        [Fact]
        public async void WeatherRepository_GetAllAsync_ReturnsAllWeather()
        {
            var meteoDataList = new List<MeteorologicalData>()
            {
                new MeteorologicalData()
                {
                    Id = 1,
                    DailyTemperature = 20,
                    MaximumDailyTemperature = 22,
                    MinimumDailyTemperature = 12,
                    Date = DateTime.Now,
                    StationId = "111"
                }
            };

            _weatherRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(meteoDataList);
            
            Assert.Equal(meteoDataList, _weatherRepository.Object.GetAllAsync().Result);
        }

        [Fact]
        public async void WeatherRepository_GetAllAsync_ReturnsWeatherFilteredByStation()
        {
            var meteoDataList = PrepareMeteorologicalData();
            var stations = new List<string>(){ "111"};
            var years = new List<int>();
            var months = new List<int>();

            _weatherRepository.Setup( x => x.GetAllAsync(stations, years, months)).ReturnsAsync()
        }
        private IReadOnlyList<MeteorologicalData> PrepareMeteorologicalData()
        {
            return new List<MeteorologicalData>()
            {
                new MeteorologicalData()
                {
                    Id = 1,
                    DailyTemperature = 20,
                    MaximumDailyTemperature = 22,
                    MinimumDailyTemperature = 12,
                    Date = DateTime.Now,
                    StationId = "111"
                },
                new MeteorologicalData()
                {
                    Id = 2,
                    DailyTemperature = 11,
                    MaximumDailyTemperature = 22,
                    MinimumDailyTemperature = 1,
                    Date = DateTime.Now,
                    StationId = "222"
                },
            };
        }
    }
}
