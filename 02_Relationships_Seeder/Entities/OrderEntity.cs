using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Relationships_Seeder.Entities
{
    internal class OrderEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public CustomerEntity? Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemEntity> OrderItems { get; set; } = [];
        public override string ToString()
        {
            return $"Order: {Id} - CustomerId: {CustomerId} Date: {OrderDate}";
        }

    }
}
