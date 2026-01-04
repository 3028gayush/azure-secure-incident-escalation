using Incident.Api.Domain.Entities;

namespace Incident.Api.Application.Interfaces;

public interface IIncidentRepository
{
    IncidentSla Add(IncidentSla incident);
    IncidentSla? GetById(Guid id);
    IEnumerable<IncidentSla> GetAll();
    void Update(IncidentSla incident);
}
