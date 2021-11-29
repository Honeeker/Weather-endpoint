using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularEndpoint.Modules.Importer.Core.Entities;

namespace ModularEndpoint.Modules.Importer.Core.DAL.Configurations
{
    public class MeteorologicalDataConfiguration : IEntityTypeConfiguration<MeteorologicalData>
    {
        public void Configure(EntityTypeBuilder<MeteorologicalData> builder)
        {
            builder.ToTable("climate").HasKey(p => p.Id);
            builder.Property( p => p.Id).HasColumnName("id");
            builder.Property( p => p.Date).HasColumnName("date");
            builder.Property( p => p.StationName).HasColumnName("station_name");
            builder.Property( p => p.MaximumDailyTemperature).HasColumnName("maximum_daily_temperature");
            builder.Property( p => p.MinimumDailyTemperature).HasColumnName("minimum_daily_temperature");
            builder.Property( p => p.DailyTemperature).HasColumnName("daily_temperature");
        }
    }
}