using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IContactService
    {
        public Task CreateAsync(Contact contact);
    }
}
