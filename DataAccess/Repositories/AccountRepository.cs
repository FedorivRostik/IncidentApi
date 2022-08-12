using Core.Entities;
using Core.Interfaces.Repositories;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public AccountRepository(IncidentContext context)
        {
            _context = context;
        }

        private readonly IncidentContext _context;

        public async Task CreateAsync(Account account, Contact contact)
        {
            if (!await _context.Accounts!.AnyAsync(a => a.Name == account.Name))
            {
                await _context.Accounts!.AddAsync(account);

                await _context.SaveChangesAsync();
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
            await _context.SaveChangesAsync();
        }
    }
}
