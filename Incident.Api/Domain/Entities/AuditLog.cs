namespace Incident.Api.Domain.Entities;

public class AuditLog
{
    public Guid Id { get; private set; }

    public string Action { get; private set; } = string.Empty;

    public string PerformedBy { get; private set; } = string.Empty;

    public DateTime PerformedAt { get; private set; }

    public Guid IncidentSlaId { get; private set; }

    private AuditLog() { }

    public AuditLog(string action, string performedBy, Guid incidentId)
    {
        Id = Guid.NewGuid();
        Action = action;
        PerformedBy = performedBy;
        IncidentSlaId = incidentId;
        PerformedAt = DateTime.UtcNow;
    }
}
