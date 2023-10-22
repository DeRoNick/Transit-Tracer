using TransitTracer.Application;
using TransitTracer.Infrastructure;
using TransitTracer.Persistence;

namespace TransitTracer.API.Infrastructure;

public static class AddLayers
{
    public static IServiceCollection RegisterLayers(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication();
        services.AddPersistence(configuration.GetConnectionString("Database"));
        services.AddInfrastructure(configuration);
        return services;
    }
}