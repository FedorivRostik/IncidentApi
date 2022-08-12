using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IIncidentRepository
    {
        public Task CreateAsync(Incident incident, Account account, Contact contact);
    }
}
