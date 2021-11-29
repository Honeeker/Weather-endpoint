using System;

namespace ModularEndpoint.Modules.Weather.Core.DTO
{
    public class MeteorologicalDataDto
    {
        public int Id { get; set; }
        public string StationName { get; set; }
        public DateTime Date { get; set; }
        public double MaximumDailyTemperature { get; set; }
        public double MinimumDailyTemperature { get; set; }
        public double DailyTemperature { get; set; }
    }
}