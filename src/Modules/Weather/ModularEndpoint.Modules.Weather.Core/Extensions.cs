using Microsoft.Extensions.DependencyInjection;
using ModularEndpoint.Modules.Weather.Core.DAL;
using ModularEndpoint.Modules.Weather.Core.Services;

namespace ModularEndpoint.Modules.Weather.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<IStationService, StationService>();
            services.AddDatabase();
            
            return services;
        } 
    }
}
