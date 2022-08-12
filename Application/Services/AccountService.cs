using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        private readonly IAccountRepository _repository;

        public async Task CreateAsync(Account account, Contact contact)
        {
            await _repository.CreateAsync(account, contact);
        }
    }
}
