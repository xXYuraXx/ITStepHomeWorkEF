using _02_Relationships_Seeder.Entities;
using Microsoft.EntityFrameworkCore;

namespace _02_Relationships_Seeder.data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<DeveloperEntity> Developers { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderItemEntity> OrderItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = "Server=localhost;Database=02_Relationships_Seeder;Trusted_Connection=True;TrustServerCertificate=True;";
            builder.UseSqlServer(connectionString);


            base.OnConfiguring(builder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GameEntity>()
                .HasKey(g => g.Id);

            builder.Entity<DeveloperEntity>()
                .HasKey(d => d.Id);

            builder.Entity<CustomerEntity>()
                .HasKey(c => c.Id);

            builder.Entity<OrderEntity>()
                .HasKey(o => o.Id);

            // Relationships
            builder.Entity<GameEntity>()
                .HasOne(d => d.Developer)
                .WithMany(g => g.Games)
                .HasForeignKey(g => g.DeveloperId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderEntity>()
                .HasOne(c => c.Customer)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderItemEntity>()
                .HasKey(oi => new { oi.OrderId, oi.GameId });

            builder.Entity<OrderItemEntity>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderItemEntity>()
                .HasOne(oi => oi.Game)
                .WithMany(g => g.OrderItems)
                .HasForeignKey(oi => oi.GameId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
