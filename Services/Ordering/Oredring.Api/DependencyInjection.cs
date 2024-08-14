using Carter;
using EShop.BuildingBlocks.Exceptions;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace Oredring.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiService(this IServiceCollection serviceCollection,IConfiguration configuration)
    {
        serviceCollection.AddCarter();
        serviceCollection.AddExceptionHandler<CustomExceptionHandling>();
        serviceCollection.AddHealthChecks().AddSqlServer(configuration.GetConnectionString("Database"));
        return serviceCollection;
    }

    public static WebApplication UseService(this WebApplication webApplication)
    {

        webApplication.MapCarter();
        webApplication.UseExceptionHandler(options => { });
        webApplication.UseHealthChecks("/health", new HealthCheckOptions
        {
            ResponseWriter=UIResponseWriter.WriteHealthCheckUIResponse,
        });
        return webApplication;
    }
}

