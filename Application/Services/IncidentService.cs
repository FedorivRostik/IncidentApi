using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Application.Services
{
    public class IncidentService : IIncidentService
    {
        public IncidentService(
            IIncidentRepository incidentRepository,
            IAccountRepository accountRepository)
        {
            _incidentRepository = incidentRepository;
            _accountRepository = accountRepository;
        }

        private readonly IIncidentRepository _incidentRepository;
        private readonly IAccountRepository _accountRepository;

        public async Task CreateAsync(Incident incident, Account account, Contact contact)
        {
            if (!await _accountRepository.IsAccountExistAsync(account))
            {
                throw new NotFoundException("Account with this name does not exist.");
            }

            await _accountRepository.LinkContactAsync(account, contact);

            await _incidentRepository.CreateAsync(incident, account);
        }
    }
}
