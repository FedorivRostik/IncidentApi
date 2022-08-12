using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Application.Services
{
    public class ContactService : IContactService
    {
        public ContactService(IContactRepository repository)
        {
            _repository= repository;
        }

        private readonly IContactRepository _repository;

        public async Task CreateAsync(Contact contact)
        {
            await _repository.CreateAsync(contact);
        }
    }
}
