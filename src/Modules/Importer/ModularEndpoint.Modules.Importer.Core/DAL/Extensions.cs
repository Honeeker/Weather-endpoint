using ModularEndpoint.Modules.Importer.Core.DAL.Repositories;
using ModularEndpoint.Modules.Importer.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Postgres;

namespace ModularEndpoint.Modules.Importer.Core.DAL
{
    public static class Extensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddPostgres<WeatherHistoryContext>();
            services.AddScoped<IWeatherHistoryRepository, WeatherHistoryRepository>();

            return services;
        }
    }
}