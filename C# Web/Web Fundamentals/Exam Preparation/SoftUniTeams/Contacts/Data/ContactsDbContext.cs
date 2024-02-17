namespace Contacts.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Models;
    public class ContactsDbContext : IdentityDbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; } = null!;

        public DbSet<IdentityUserContact> IdentityUsersContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Contact>()
                .HasData(new Contact()
                {
                    Id = 1,
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    PhoneNumber = "+359881223344",
                    Address = "Gotham City",
                    CreatorId = "5e819879-3de3-4b39-ba9c-a208b98ee46a",
                    Email = "imbatman@batman.com",
                    Website = "www.batman.com"
                });

            builder.Entity<IdentityUserContact>()
                .HasKey(uc => new { uc.ContactId, uc.IdentityUserId });

            builder.Entity<IdentityUserContact>()

                .HasOne(e => e.Contact)
                .WithMany(e => e.ApplicationUsersContacts)
                .HasForeignKey(e => e.ContactId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            base.OnModelCreating(builder);
        }
    }
}