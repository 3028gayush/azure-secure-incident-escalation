using Incident.Api.Domain.Entities;

namespace Incident.Api.Application.Interfaces;

public interface IAuditLogRepository
{
    void Add(AuditLog log);
    IEnumerable<AuditLog> GetByIncidentId(Guid incidentId);
}
