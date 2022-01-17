using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularEndpoint.Modules.Weather.Core.Entities;

namespace ModularEndpoint.Modules.Weather.Core.DAL.Configurations
{
    public class MeteorologicalDataConfiguration : IEntityTypeConfiguration<MeteorologicalData>
    {
        public void Configure(EntityTypeBuilder<MeteorologicalData> builder)
        {
             builder
                .ToTable("weather")
                .HasKey(p => p.Id);
            builder
                .Property( p => p.Id)
                .HasColumnName("id");
            builder
                .Property( p => p.Date)
                .HasColumnName("date");
            builder
                .Property( p => p.StationId)
                .HasColumnName("station_id");
            builder
                .Property( p => p.MaximumDailyTemperature)
                .HasColumnName("maximum_daily_temperature");
            builder
                .Property( p => p.MinimumDailyTemperature)
                .HasColumnName("minimum_daily_temperature");
            builder
                .Property( p => p.DailyTemperature)
                .HasColumnName("daily_temperature");
        }
    }
}