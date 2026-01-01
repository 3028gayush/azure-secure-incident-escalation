namespace Incident.Api.Domain;

public class IncidentSla
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public bool IsEscalated { get; set; }
}
