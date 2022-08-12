using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
           builder.HasKey(b => b.Id);

            builder
             .Property(b => b.FirstName)
             .IsRequired();

            builder
             .Property(b => b.LastName)
             .IsRequired();

            builder
               .Property(b => b.Email)
               .IsRequired();

            builder
             .HasIndex(b => b.Email)
             .IsUnique();

            builder
                .HasOne(c => c.Account)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.AccountId);

        }
    }
}
