using _02_Relationships_Seeder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_Relationships_Seeder.data
{
    internal static class Seeder
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.Migrate();


            if (context.Developers.Any() || context.Games.Any() || context.Customers.Any() || context.Orders.Any() || context.OrderItems.Any())
            {
                return;
            }

            var developers = new List<DeveloperEntity>
            {
                new DeveloperEntity { Name = "Nebula Studio", Country = "USA" },
                new DeveloperEntity { Name = "Aurora Interactive", Country = "Canada" },
                new DeveloperEntity { Name = "Red Kite Games", Country = "UK" },
                new DeveloperEntity { Name = "Blue Orchard", Country = "Germany" },
                new DeveloperEntity { Name = "Silver Pixel", Country = "Japan" }
            };

            context.Developers.AddRange(developers);
            context.SaveChanges();

            var games = new List<GameEntity>
            {
                new GameEntity { Title = "Skyward Saga", Price = 40, ReleaseYear = 2022, Developer = developers[0] },
                new GameEntity { Title = "Midnight Runner", Price = 30, ReleaseYear = 2021, Developer = developers[1] },
                new GameEntity { Title = "Castlefall", Price = 50, ReleaseYear = 2020, Developer = developers[2] },
                new GameEntity { Title = "Neon Drift", Price = 25, ReleaseYear = 2023, Developer = developers[3] },
                new GameEntity { Title = "Quantum Tactics", Price = 60, ReleaseYear = 2024, Developer = developers[4] },
                new GameEntity { Title = "Rust & Roses", Price = 20, ReleaseYear = 2019, Developer = developers[0] },
                new GameEntity { Title = "Aetherbound", Price = 45, ReleaseYear = 2022, Developer = developers[1] },
                new GameEntity { Title = "Polar Expedition", Price = 35, ReleaseYear = 2021, Developer = developers[2] },
                new GameEntity { Title = "Hollow Echoes", Price = 55, ReleaseYear = 2020, Developer = developers[3] },
                new GameEntity { Title = "Solaris Fleet", Price = 50, ReleaseYear = 2023, Developer = developers[4] }
            };

            context.Games.AddRange(games);
            context.SaveChanges();

            var customers = new List<CustomerEntity>
            {
                new CustomerEntity { FullName = "Ivan Petrov", Email = "ivan.petrov@example.com" },
                new CustomerEntity { FullName = "Olena Kovalenko", Email = "olena.kovalenko@example.com" },
                new CustomerEntity { FullName = "Marta Shevchenko", Email = "marta.shevchenko@example.com" },
                new CustomerEntity { FullName = "Serhii Bondarenko", Email = "serhii.bondarenko@example.com" },
                new CustomerEntity { FullName = "Dmytro Ivanov", Email = "dmytro.ivanov@example.com" },
                new CustomerEntity { FullName = "Natalia Horbach", Email = "natalia.horbach@example.com" },
                new CustomerEntity { FullName = "Petro Mykhailenko", Email = "petro.mykhailenko@example.com" },
                new CustomerEntity { FullName = "Kateryna Lis", Email = "kateryna.lis@example.com" }
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();

            var rand = new Random();
            var orders = new List<OrderEntity>();
            for (int i = 0; i < 10; i++)
            {
                var customer = customers[rand.Next(customers.Count)];
                var minusDayys = rand.Next(0, 365 * 2);
                orders.Add(new OrderEntity
                {
                    Customer = customer,
                    OrderDate = DateTime.UtcNow.AddDays(-minusDayys)
                });
            }

            context.Orders.AddRange(orders);
            context.SaveChanges();

            var orderItems = new List<OrderItemEntity>();
            var usedPairs = new HashSet<(int orderId, int gameId)>();
            while (orderItems.Count < 20)
            {
                var order = orders[rand.Next(orders.Count)];
                var game = games[rand.Next(games.Count)];
                var pair = (order.Id, game.Id);
                if (!usedPairs.Add(pair))
                    continue;

                orderItems.Add(new OrderItemEntity
                {
                    Order = order,
                    Game = game,
                    Quantity = rand.Next(1, 6)
                });
            }

            context.OrderItems.AddRange(orderItems);
            context.SaveChanges();
        }
    }
}
