using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        public IncidentRepository(IncidentContext context)
        {
            _context = context;
        }

        private readonly IncidentContext _context;

        public async Task CreateAsync(Incident incident, Account account, Contact contact)
        {
            if (!await _context.Accounts!.AnyAsync(a => a.Name == account.Name))
            {
                throw new NotFoundException("Account with this name does not exist.");
            }

            if (!await _context.Contacts!.AnyAsync(c => c.Email == contact.Email))
            {
                contact.AccountId = _context.Accounts!
                    .SingleOrDefault(a => a.Name == account.Name)!
                    .Id;

                await _context.Contacts!.AddAsync(contact);
            }
            else
            {
                _context.Contacts!
                    .SingleOrDefault(c => c.Email == contact.Email)!
                    .AccountId = _context.Accounts!
                    .SingleOrDefault(a => a.Name == account.Name)!
                    .Id;

            }
         
            await _context.Incidents!.AddAsync(incident);

            await _context.SaveChangesAsync();

            _context.Accounts!
                .SingleOrDefault(a => a.Name == account.Name)!
                .IncidentId = _context.Incidents!
                .SingleOrDefault(i => i.Name == incident.Name!)!
                .Name;

            await _context.SaveChangesAsync();
        }
    }
}
