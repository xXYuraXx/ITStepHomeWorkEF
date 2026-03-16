using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Relationships_Seeder.Entities
{
    internal class DeveloperEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<GameEntity> Games { get; set; } = [];
        public override string ToString()
        {
            return $"Developer: {Id} - {Name} ({Country})";
        }

    }
}
