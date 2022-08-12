using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Application.Services
{
    public class IncidentService : IIncidentService
    {
        public IncidentService(IIncidentRepository repository)
        {
            _repository = repository;
        }

        private readonly IIncidentRepository _repository;

        public async Task CreateAsync(Incident incident, Account account, Contact contact)
        {
            await _repository.CreateAsync(incident, account, contact);
        }
    }
}
