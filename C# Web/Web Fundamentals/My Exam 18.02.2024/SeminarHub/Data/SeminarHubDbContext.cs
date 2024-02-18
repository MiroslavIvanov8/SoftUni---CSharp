namespace SeminarHub.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class SeminarHubDbContext : IdentityDbContext
    {
        public SeminarHubDbContext(DbContextOptions<SeminarHubDbContext> options)
            : base(options)
        {
        }

        public  DbSet<Seminar> Seminars { get; set; } = null!;
        public  DbSet<Category> Categories { get; set; } = null!;

        public DbSet<SeminarParticipant> SeminarsParticipants { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
               .Entity<Category>()
               .HasData(new Category()
               {
                   Id = 1,
                   Name = "Technology & Innovation"
               },
               new Category()
               {
                   Id = 2,
                   Name = "Business & Entrepreneurship"
               },
               new Category()
               {
                   Id = 3,
                   Name = "Science & Research"
               },
               new Category()
               {
                   Id = 4,
                   Name = "Arts & Culture"
               });

            builder.Entity<SeminarParticipant>()
                .HasKey(ep => new { ep.SeminarId, ep.ParticipantId});

            builder.Entity<SeminarParticipant>()
                .ToTable("SeminarsParticipants")
                .HasOne(ep => ep.Seminar)
                .WithMany(ep => ep.SeminarsParticipants)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }
    }
}