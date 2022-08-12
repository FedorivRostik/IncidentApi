using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        public Task CreateAsync(Account account, Contact contact);
    }
}
