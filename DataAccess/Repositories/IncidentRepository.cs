using Core.Entities;
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

        public async Task CreateAsync(Incident incident, Account account)
        {
   
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
