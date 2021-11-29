using System;

namespace ModularEndpoint.Modules.Importer.Core.Entities
{
    public class MeteorologicalData
    {
        public int Id { get; set; }
        public string StationName { get; set; }
        public DateTime Date { get; set; }
        public double MaximumDailyTemperature { get; set; }
        public double MinimumDailyTemperature { get; set; }
        public double DailyTemperature { get; set; }
    }
}