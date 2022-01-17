using CsvHelper.Configuration;

namespace ModularEndpoint.Modules.Importer.Core.CsvMappings
{
     public sealed class BaseClimateFormatMap: ClassMap<BaseClimateFormat>
        {
            public BaseClimateFormatMap()
            {
                Map(p => p.Id).Index(0);
                Map(p => p.Year).Index(2);
                Map(p => p.Month).Index(3);
                Map(p => p.Day).Index(4);
                Map(p => p.MaximumDailyTemperature).Index(5);
                Map(p => p.MinimumDailyTemperature).Index(7);
                Map(p => p.DailyTemperature).Index(9);
            }
        }
}