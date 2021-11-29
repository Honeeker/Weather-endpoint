using Infrastructure.Postgres;
using Microsoft.Extensions.DependencyInjection;
using ModularEndpoint.Modules.Weather.Core.DAL.EF;
using ModularEndpoint.Modules.Weather.Core.DAL.Repositories;

namespace ModularEndpoint.Modules.Weather.Core.DAL
{
    public static class Extensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddPostgres<WeatherDbContext>();
            services.AddScoped<IWeatherRepository, WeatherRepository>();
            services.AddScoped<IStationRepository, StationRepository>();
            
            return services;
        }
    }
}