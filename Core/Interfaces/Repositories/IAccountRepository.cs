using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        public Task CreateAsync(Account account, Contact contact);
        public Task<bool> IsAccountExistAsync(Account account);
        public Task LinkContactAsync(Account account, Contact contact);
    }
}
