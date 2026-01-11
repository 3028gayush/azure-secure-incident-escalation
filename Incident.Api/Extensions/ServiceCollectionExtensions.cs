using Incident.Api.Application.Interfaces;
using Incident.Api.Application.Services;
using Incident.Api.Infrastructure.Persistence;
using Incident.Api.Infrastructure.Persistence.InMemory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Incident.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        // Application services
        services.AddScoped<IncidentService>();
        services.AddScoped<AuditService>();

        return services;
    }

    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        // In-memory repositories (temporary)
        services.AddSingleton<IIncidentRepository, InMemoryIncidentRepository>();
         services.AddSingleton<IAuditLogRepository, InMemoryAuditLogRepository>();

        services.AddDbContext<IncidentDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("AzureSql")));

        // services.AddScoped<IIncidentRepository, EfIncidentRepository>();
        // services.AddScoped<IAuditLogRepository, EfAuditLogRepository>();

        return services;
    }
}

