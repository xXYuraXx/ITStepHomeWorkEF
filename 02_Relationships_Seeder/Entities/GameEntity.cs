using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Relationships_Seeder.Entities
{
    internal class GameEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int ReleaseYear { get; set; }
        public int DeveloperId { get; set; }
        public DeveloperEntity? Developer { get; set; }
        public List<OrderItemEntity> OrderItems { get; set; } = [];

        public override string ToString()
        {
            return $"Game: {Id} - {Title} ({ReleaseYear}) Price: {Price}";
        }
    }
}
