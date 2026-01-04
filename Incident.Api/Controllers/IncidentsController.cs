using Incident.Api.Application.DTOs;
using Incident.Api.Application.Services;
using Incident.Api.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Incident.Api.Controllers;

[ApiController]
[Route("api/incidents")]
[Authorize] // Authentication required for all endpoints
public class IncidentsController : ControllerBase
{
    private readonly IncidentService _incidentService;

    public IncidentsController(IncidentService incidentService)
    {
        _incidentService = incidentService;
    }

    // 🔹 Create Incident (Any authenticated user)
    [HttpPost]
    [Route("SubmitData")]
    public IActionResult Create([FromBody] AddIncidentRequestDto request)
    {
        var createdBy = User.Identity?.Name ?? "unknown";

        var incident = _incidentService.Create(
            request.Title,
            request.Description,
            request.Priority,
            createdBy);

        return CreatedAtAction(nameof(GetAll), incident);
    }

    // 🔹 View Incidents (Viewer, Operator, Admin)
    [HttpGet]
    [Authorize(Policy = "ReadOnly")]
    public IActionResult GetAll()
    {
        var incidents = _incidentService.GetAll();
        return Ok(incidents);
    }

    // 🔹 Update Incident (Operator, Admin)
    [HttpPut("{id:guid}")]
    [Authorize(Policy = "OperatorOrAdmin")]
    public IActionResult Update(Guid id, [FromBody] UpdateIncidentRequestDto request)
    {
        var updatedBy = User.Identity?.Name ?? "unknown";

        _incidentService.Update(id, request.Description, updatedBy);
        return NoContent();
    }

    // 🔹 Escalate Incident (Admin only)
    [HttpPost("{id:guid}/escalate")]
    [Authorize(Policy = "AdminOnly")]
    public IActionResult Escalate(Guid id)
    {
        var escalatedBy = User.Identity?.Name ?? "unknown";

        _incidentService.Escalate(id, escalatedBy);
        return NoContent();
    }
}
