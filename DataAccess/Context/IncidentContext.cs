using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class IncidentContext : DbContext
    {
        public IncidentContext(DbContextOptions<IncidentContext> options) : base(options) { }
        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Incident>? Incidents { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
