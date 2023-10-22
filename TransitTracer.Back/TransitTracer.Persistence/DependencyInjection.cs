using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TransitTracer.Application.Infrastructure.Repositories;
using TransitTracer.Persistence.Database;
using TransitTracer.Persistence.Repositories;

namespace TransitTracer.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string dbConnectionString)
    {
        services.AddDbContext<TransitTrackerDbContext>(options =>
        {
            options.UseMySQL(dbConnectionString);
        });

        services.AddScoped<IBusStopDataRepository, BusStopDataRepository>();
        services.AddScoped<IRoutesRepository, RoutesRepository>();
        services.AddScoped<IBusStopRepository, BusStopRepository>();
        
        return services;
    }
}