using Incident.Api.Application.Interfaces;
using Incident.Api.Domain.Entities;

namespace Incident.Api.Application.Services;

public class AuditService
{
    private readonly IAuditLogRepository _repository;

    public AuditService(IAuditLogRepository repository)
    {
        _repository = repository;
    }

    public void Log(string action, string user, Guid incidentId)
    {
        var log = new AuditLog(action, user, incidentId);
        _repository.Add(log);
    }
}
