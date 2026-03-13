using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _01_Intro_Migrations.Entities
{
    internal class GameEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public DateTime ReliseDate { get; set; } = DateTime.UtcNow;
        public string ConnectionType { get; set; }
        public int CountSales { get; set; }
        public override string ToString()
        {
            return $"{Id}: {Name}\nPublisher: {Publisher}\nGenre: {Genre}\nReliseDate: {ReliseDate}\nConnection Type: {ConnectionType}\nCount Sales: {CountSales}";
        }
    }
}
