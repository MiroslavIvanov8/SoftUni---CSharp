﻿namespace Homies.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Type = Models.Type;
    using Models;

    public class HomiesDbContext : IdentityDbContext
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Type> Types { get; set; }

        public DbSet<EventParticipant> EventsParticipants { get; set; } 
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Type>()
                .HasData(new Type()
                {
                    Id = 1,
                    Name = "Animals"
                },
                new Type()
                {
                    Id = 2,
                    Name = "Fun"
                },
                new Type()
                {
                    Id = 3,
                    Name = "Discussion"
                },
                new Type()
                {
                    Id = 4,
                    Name = "Work"
                });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventParticipant>()
                .HasKey(ep => new { ep.HelperId, ep.EventId });
            
            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.Event)
                .WithMany(ep => ep.EventsParticipants)
                .HasForeignKey(ep => ep.EventId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}