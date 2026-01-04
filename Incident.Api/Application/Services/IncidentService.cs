using Incident.Api.Application.Interfaces;
using Incident.Api.Domain.Entities;
using Incident.Api.Domain.Enums;

namespace Incident.Api.Application.Services;

public class IncidentService
{
    private readonly IIncidentRepository _incidentRepository;
    private readonly AuditService _auditService;

    public IncidentService(
        IIncidentRepository incidentRepository,
        AuditService auditService)
    {
        _incidentRepository = incidentRepository;
        _auditService = auditService;
    }

    public Incident Create(
        string title,
        string description,
        IncidentPriority priority,
        string createdBy)
    {
        var incident = new Incident(title, description, priority, createdBy);
        _incidentRepository.Add(incident);

        _auditService.Log("INCIDENT_CREATED", createdBy, incident.Id);

        return incident;
    }

    public void Update(Guid id, string description, string updatedBy)
    {
        var incident = _incidentRepository.GetById(id)
            ?? throw new KeyNotFoundException("Incident not found");

        incident.UpdateDescription(description);
        _incidentRepository.Update(incident);

        _auditService.Log("INCIDENT_UPDATED", updatedBy, id);
    }

    public void Escalate(Guid id, string escalatedBy)
    {
        var incident = _incidentRepository.GetById(id)
            ?? throw new KeyNotFoundException("Incident not found");

        incident.Escalate(escalatedBy);
        _incidentRepository.Update(incident);

        _auditService.Log("INCIDENT_ESCALATED", escalatedBy, id);
    }

    public IEnumerable<Incident> GetAll()
    {
        return _incidentRepository.GetAll();
    }
}
