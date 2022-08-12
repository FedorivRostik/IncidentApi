using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IIncidentService
    {
        public Task CreateAsync(Incident incident, Account account, Contact contact);
    }
}

