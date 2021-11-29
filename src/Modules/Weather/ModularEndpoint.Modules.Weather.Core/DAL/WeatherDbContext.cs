using Microsoft.EntityFrameworkCore;
using ModularEndpoint.Modules.Weather.Core.Entities;

namespace ModularEndpoint.Modules.Weather.Core.DAL
{
    public class WeatherDbContext : DbContext
    {
        public DbSet<MeteorologicalData> MeteorologicalDatas { get; set; }
        public DbSet<Station> Stations { get; set; }

        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("public");
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}