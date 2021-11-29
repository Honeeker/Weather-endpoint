using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using ModularEndpoint.Modules.Importer.Core.DAL;
using ModularEndpoint.Modules.Importer.Core.Services;

namespace ModularEndpoint.Modules.Importer.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            
            services.AddDatabase();
            services.AddScoped<IWeatherHistoryService, WeatherHistoryService>();
            services.AddScoped<IWeatherHistoryImporter, WeatherHistoryImporter>();
            
            return services;
        }
    }
}
