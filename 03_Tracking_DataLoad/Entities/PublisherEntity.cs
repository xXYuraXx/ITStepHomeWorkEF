using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Tracking_DataLoad.Entities
{
    internal class PublisherEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public List<GameEntity> Games { get; set; } = [];

    }
}
