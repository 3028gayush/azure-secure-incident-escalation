using Incident.Api.Application.Interfaces;
using Incident.Api.Domain.Entities;

namespace Incident.Api.Infrastructure.Persistence.InMemory;

public class InMemoryIncidentRepository : IIncidentRepository
{
    private static readonly List<Incident> _incidents = new();

    public Incident Add(Incident incident)
    {
        _incidents.Add(incident);
        return incident;
    }

    public Incident? GetById(Guid id)
    {
        return _incidents.FirstOrDefault(i => i.Id == id);
    }

    public IEnumerable<Incident> GetAll()
    {
        return _incidents;
    }

    public void Update(Incident incident)
    {
        // No-op for in-memory
    }
}
