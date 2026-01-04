using Incident.Api.Domain.Entities;

namespace Incident.Api.Application.Interfaces;

public interface IIncidentRepository
{
    Incident Add(IncidentSla incident);
    Incident? GetById(Guid id);
    IEnumerable<IncidentSla> GetAll();
    void Update(IncidentSla incident);
}
