using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ModularEndpoint.Modules.Weather.Core;

[assembly:InternalsVisibleTo("ModularEndpoint.Bootstrapper")]
namespace ModularEndpoint.Modules.Weather.Api
{
    internal static class WeatherModule
    {
        public static IServiceCollection AddWeatherModule(this IServiceCollection services)
        {
            services.AddCore();

            return services;
        }
        public static IApplicationBuilder UseWeatherModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
