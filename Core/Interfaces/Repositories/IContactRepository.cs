using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IContactRepository
    {
        public Task CreateAsync(Contact contact);
    }
}
