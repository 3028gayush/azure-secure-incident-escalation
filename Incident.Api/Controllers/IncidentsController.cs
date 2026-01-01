using Incident.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Incident.Api.Controllers;

[ApiController]
[Route("api/incidents")]
public class IncidentsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var incidents = new[]
        {
            new IncidentSla
            {
                Id = Guid.NewGuid(),
                Title = "Sample Incident",
                Severity = "High",
                CreatedAt = DateTime.UtcNow,
                IsEscalated = false
            }
        };

        return Ok(incidents);
    }
}
