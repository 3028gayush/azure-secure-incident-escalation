using Incident.Api.Application.Interfaces;
using Incident.Api.Application.Services;
using Incident.Api.Infrastructure.Persistence.InMemory;
using Microsoft.Extensions.DependencyInjection;

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
        this IServiceCollection services)
    {
        // In-memory repositories (temporary)
        services.AddSingleton<IIncidentRepository, InMemoryIncidentRepository>();
        services.AddSingleton<IAuditLogRepository, InMemoryAuditLogRepository>();

        return services;
    }
}
