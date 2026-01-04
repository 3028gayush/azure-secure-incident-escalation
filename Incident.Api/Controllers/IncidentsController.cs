using Incident.Api.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Incident.Api.Controllers;

[ApiController]
[Route("api/incidents")]
public class IncidentsController : ControllerBase
{
    [HttpGet]
    [Route("GetId")]
    public IActionResult GetId(int? id = null)
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

    [HttpGet]
    [Authorize(Policy = "ReadOnly")]
    public IActionResult Get()
    {
        return Ok("Read access granted");
    }

    // Update
    [HttpPut]
    [Authorize(Policy = "OperatorOrAdmin")]
    public IActionResult Update()
    {
        return Ok("Update access granted");
    }

    // Escalate (Admin only)
    [HttpPost("escalate")]
    [Authorize(Policy = "AdminOnly")]
    public IActionResult Escalate()
    {
        return Ok("Escalation successful");
    }

[HttpGet("claims")]
[Authorize]
public IActionResult Claims()
{
    return Ok(User.Claims.Select(c => new { c.Type, c.Value }));
}

}
