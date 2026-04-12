using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Tracking_DataLoad.Entities
{
    internal class GameEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Rating { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.UtcNow;
        public int PublisherId { get; set; }
        public PublisherEntity? Publisher { get; set; }
        public List<GenreEntity> Genres { get; set; } = [];
        


    }
}
