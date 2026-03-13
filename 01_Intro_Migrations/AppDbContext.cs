using _01_Intro_Migrations.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Intro_Migrations
{
    internal class AppDbContext : DbContext
    {
        public DbSet<FootballTeamEntity> FootballTeams { get; set; }
        public DbSet<GameEntity> Games { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=SPR411;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);


            base.OnConfiguring(optionsBuilder);
        }
    }
}
