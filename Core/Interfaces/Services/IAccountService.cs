using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IAccountService
    {
        public Task CreateAsync(Account account, Contact contact);
    }
}
