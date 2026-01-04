using Incident.Api.Domain.Enums;

namespace Incident.Api.Domain.Entities;


public class IncidentSla
{
    public Guid Id { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public IncidentPriority Priority { get; private set; }

    public IncidentStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public string CreatedBy { get; private set; } = string.Empty;

    public DateTime? EscalatedAt { get; private set; }

    public string? EscalatedBy { get; private set; }

    private IncidentSla() { } // For EF Core later

    public IncidentSla(
        string title,
        string description,
        IncidentPriority priority,
        string createdBy)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Priority = priority;
        Status = IncidentStatus.Open;
        CreatedAt = DateTime.UtcNow;
        CreatedBy = createdBy;
    }

    public void UpdateDescription(string description)
    {
        Description = description;
        Status = IncidentStatus.InProgress;
    }

    public void Escalate(string escalatedBy)
    {
        if (Status == IncidentStatus.Escalated)
            throw new InvalidOperationException("Incident already escalated");

        Status = IncidentStatus.Escalated;
        EscalatedAt = DateTime.UtcNow;
        EscalatedBy = escalatedBy;
    }

    public void Resolve()
    {
        Status = IncidentStatus.Resolved;
    }
}
