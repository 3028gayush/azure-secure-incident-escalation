using Incident.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Incident.Api.Infrastructure.Persistence;

public class IncidentDbContext : DbContext
{
    public IncidentDbContext(DbContextOptions<IncidentDbContext> options)
        : base(options) { }

    public DbSet<IncidentSla> IncidentSlas => Set<IncidentSla>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
}
