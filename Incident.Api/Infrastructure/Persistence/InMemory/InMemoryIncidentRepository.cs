using Incident.Api.Application.Interfaces;
using Incident.Api.Domain.Entities;

namespace Incident.Api.Infrastructure.Persistence.InMemory;

public class InMemoryIncidentRepository : IIncidentRepository
{
    private static readonly List<IncidentSla> _incidents = new();

    public IncidentSla Add(IncidentSla incident)
    {
        _incidents.Add(incident);
        return incident;
    }

    public IncidentSla? GetById(Guid id)
    {
        return _incidents.FirstOrDefault(i => i.Id == id);
    }

    public IEnumerable<IncidentSla> GetAll()
    {
        return _incidents;
    }

    public void Update(IncidentSla incident)
    {
        // No-op for in-memory
    }
}
