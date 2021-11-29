using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ModularEndpoint.Modules.Importer.Core;

[assembly:InternalsVisibleTo("ModularEndpoint.Bootstrapper")]
namespace ModularEndpoint.Modules.Importer.Api
{
    internal static class ImportModule
    {
        public static IServiceCollection AddImportModule(this IServiceCollection services)
        {
            services.AddCore();

            return services;
        }
        public static IApplicationBuilder UseImportModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
