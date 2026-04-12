using _03_Tracking_DataLoad.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Tracking_DataLoad.data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<PublisherEntity> Publishers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = "Server=localhost;Database=03_Tracking_DataLoad;Trusted_Connection=True;TrustServerCertificate=True;";
            builder.UseSqlServer(connectionString);

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GameEntity>()
                .HasKey(g => g.Id);

            builder.Entity<GenreEntity>()
                .HasKey(g => g.Id);

            builder.Entity<PublisherEntity>()
                .HasKey(g => g.Id);




            // Relationships
            builder.Entity<GameEntity>()
                .HasMany(g => g.Genres)
                .WithMany(g => g.Games)
                .UsingEntity("GameGenres");

            builder.Entity<PublisherEntity>()
                .HasMany(p => p.Games)
                .WithOne(g => g.Publisher);




        }
    }
}
