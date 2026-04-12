using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Tracking_DataLoad.Entities
{
    internal class GenreEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<GameEntity> Games { get; set; } = [];

    }
}
