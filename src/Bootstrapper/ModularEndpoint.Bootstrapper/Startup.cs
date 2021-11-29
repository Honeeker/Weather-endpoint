using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using ModularEndpoint.Modules.Importer.Api;
using ModularEndpoint.Modules.Weather.Api;
using Shared.Infrastructure;

namespace ModularEndpoint.Bootstrapper
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWeatherModule();
            services.AddImportModule();
            services.AddInfrastructure();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseInfrastructure();
            app.UseRouting();
            app.UseWeatherModule();
            app.UseImportModule();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", context => context.Response.WriteAsync("Modular Monolith API"));
            });
            
        }
    }
}
