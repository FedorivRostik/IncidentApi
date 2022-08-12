using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class AccountConfiguration:IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);

            builder
                .HasIndex(a=>a.Name)
                .IsUnique();

            builder
                .Property(a=>a.Name)
                .IsRequired();

            builder.HasOne(i => i.Incident)
                .WithMany(a => a.Accounts)
                .HasForeignKey(i => i.IncidentId);
        }
    }
}
