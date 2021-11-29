using Microsoft.EntityFrameworkCore;
using ModularEndpoint.Modules.Importer.Core.DAL.Configurations;
using ModularEndpoint.Modules.Importer.Core.Entities;

namespace ModularEndpoint.Modules.Importer.Core
{
    public class WeatherHistoryContext: DbContext
    {
        public DbSet<MeteorologicalData> MeteorologicalDatas {get; set;}
        public WeatherHistoryContext(DbContextOptions<WeatherHistoryContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("public");
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}