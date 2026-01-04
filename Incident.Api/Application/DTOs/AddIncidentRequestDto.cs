using Incident.Api.Domain.Enums;

namespace Incident.Api.Application.DTOs;

public class AddIncidentRequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IncidentPriority Priority { get; set; }
}
