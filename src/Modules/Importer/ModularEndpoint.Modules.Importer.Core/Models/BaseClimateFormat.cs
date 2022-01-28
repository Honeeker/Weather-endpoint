namespace ModularEndpoint.Modules.Importer.Core.Models
{
    public class BaseClimateFormat
    {
        public string Id { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public double MaximumDailyTemperature { get; set; }
        public double MinimumDailyTemperature { get; set; }
        public double DailyTemperature { get; set; }
    }
}