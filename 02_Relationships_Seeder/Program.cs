using _02_Relationships_Seeder.data;
using _02_Relationships_Seeder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _02_Relationships_Seeder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();
            Seeder.Seed(context);

            var q1 = context.Games
                .Include(g => g.Developer);
            Console.WriteLine("Query 1");
            foreach (var item in q1)
            {
                Console.WriteLine(item.ToString());
            }

            var q2 = context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Game);
            Console.WriteLine("Query 2");
            foreach (var order in q2)
            {
                Console.WriteLine(order.ToString());
                foreach (var oi in order.OrderItems)
                {
                    Console.WriteLine(oi.ToString());
                }
            }

            var q3 = q2
                .Select(o => new { o.Id, Total = o.OrderItems.Sum(oi => oi.Game != null ? oi.Game.Price * oi.Quantity : 0) });
            Console.WriteLine("Query 3");
            foreach (var s in q3)
            {
                Console.WriteLine($"Order {s.Id} sum: {s.Total}");
            }

            var q4 = context.Games
                .OrderByDescending(g => g.Price)
                .Take(3);
            Console.WriteLine("Query 4");
            foreach (var g in q4)
            {
                Console.WriteLine(g.ToString());
            }

            var q5 = context.Customers
                .Include(c => c.Orders)
                .Where(c => c.Orders.Count > 1);
            Console.WriteLine("Query 5");
            foreach (var c in q5)
            {
                Console.WriteLine(c.ToString());
            }

            var q6 = context.OrderItems
                .Include(oi => oi.Game)
                .Sum(oi => oi.Game != null ? oi.Game.Price * oi.Quantity : 0);
            Console.WriteLine($"Total income: {q6}");
        }
    }
}
