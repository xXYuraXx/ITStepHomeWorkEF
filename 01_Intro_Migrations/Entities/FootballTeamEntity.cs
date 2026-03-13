using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _01_Intro_Migrations.Entities
{
    internal class FootballTeamEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        public int CountWins { get; set; }
        public int CountLooses { get; set; }
        public int CountDraw { get; set; }
        public int CountGoals { get; set; }
        public int CountMissedGoals { get; set; }
        public override string ToString()
        {
            return $"{Id}: {Name}\nCity: {City}\nWins: {CountWins}, Looses: {CountLooses}, Draws: {CountDraw}.\nGoals: {CountGoals}, Missed Goals: {CountMissedGoals}.";
        }
    }
}
