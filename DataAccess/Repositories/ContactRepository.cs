using Core.Entities;
using Core.Interfaces.Repositories;
using DataAccess.Context;

namespace DataAccess.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public ContactRepository(IncidentContext context)
        {
            _context = context;
        }

        private readonly IncidentContext _context;
        public async Task CreateAsync(Contact contact)
        {
            await _context.Contacts!.AddAsync(contact);
            await _context.SaveChangesAsync();
        }
    }
}
