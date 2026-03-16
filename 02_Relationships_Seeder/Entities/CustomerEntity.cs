using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Relationships_Seeder.Entities
{
    internal class CustomerEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<OrderEntity> Orders { get; set; } = [];

        override public string ToString()
        {
            return $"Customer: id: {Id}, {FullName}, {Email}";
        }
    }
}
