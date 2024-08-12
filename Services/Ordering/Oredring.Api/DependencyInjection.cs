namespace Oredring.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiService(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }

    public static WebApplication UseService(this WebApplication webApplication)
    {


        return webApplication;
    }
}

