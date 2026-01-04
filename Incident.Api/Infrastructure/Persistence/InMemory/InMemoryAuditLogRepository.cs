using Incident.Api.Application.Interfaces;
using Incident.Api.Domain.Entities;

namespace Incident.Api.Infrastructure.Persistence.InMemory;

public class InMemoryAuditLogRepository : IAuditLogRepository
{
    private static readonly List<AuditLog> _logs = new();

    public void Add(AuditLog log)
    {
        _logs.Add(log);
    }

    public IEnumerable<AuditLog> GetByIncidentId(Guid incidentId)
    {
        return _logs.Where(l => l.IncidentSlaId == incidentId);
    }
}
