using _01_Intro_Migrations.Entities;

namespace _01_Intro_Migrations
{
    internal class Program
    {
        static void AddData1(AppDbContext context)
        {
            FootballTeamEntity[] teams =
            {
                new FootballTeamEntity { Name = "Iron Wolves", City = "London", CountWins = 18, CountLooses = 5, CountDraw = 7 },
                new FootballTeamEntity { Name = "Red Dragons", City = "Madrid", CountWins = 22, CountLooses = 3, CountDraw = 4 },
                new FootballTeamEntity { Name = "Blue Sharks", City = "Lisbon", CountWins = 14, CountLooses = 9, CountDraw = 6 },
                new FootballTeamEntity { Name = "Golden Eagles", City = "Rome", CountWins = 20, CountLooses = 6, CountDraw = 5 },
                new FootballTeamEntity { Name = "Night Panthers", City = "Berlin", CountWins = 16, CountLooses = 8, CountDraw = 7 },
                new FootballTeamEntity { Name = "Storm Riders", City = "Paris", CountWins = 12, CountLooses = 11, CountDraw = 8 },
                new FootballTeamEntity { Name = "Shadow Foxes", City = "Amsterdam", CountWins = 19, CountLooses = 4, CountDraw = 6 },
                new FootballTeamEntity { Name = "Silver Falcons", City = "Prague", CountWins = 15, CountLooses = 10, CountDraw = 5 }
            };

            context.FootballTeams.AddRange(teams);
            context.SaveChanges();
        }
        static void AddData2(AppDbContext context)
        {
            GameEntity[] games =
            {
                new GameEntity { Name = "Sky Warriors", Publisher = "NovaSoft", Genre = "Action", ReliseDate = new DateTime(2020, 5, 12) },
                new GameEntity { Name = "Dungeon Quest", Publisher = "IronGames", Genre = "RPG", ReliseDate = new DateTime(2019, 11, 3) },
                new GameEntity { Name = "City Builder Pro", Publisher = "UrbanPlay", Genre = "Simulation", ReliseDate = new DateTime(2021, 2, 18) },
                new GameEntity { Name = "Racing Thunder", Publisher = "SpeedWorks", Genre = "Racing", ReliseDate = new DateTime(2018, 7, 25) },
                new GameEntity { Name = "Galaxy Tactics", Publisher = "StarForge", Genre = "Strategy", ReliseDate = new DateTime(2022, 1, 10) },
                new GameEntity { Name = "Zombie Survival", Publisher = "DarkStudio", Genre = "Horror", ReliseDate = new DateTime(2020, 10, 31) },
                new GameEntity { Name = "Fantasy Arena", Publisher = "MythicLab", Genre = "MOBA", ReliseDate = new DateTime(2023, 3, 14) },
                new GameEntity { Name = "Pixel Adventure", Publisher = "RetroByte", Genre = "Platformer", ReliseDate = new DateTime(2017, 9, 9) }
            };

            context.Games.AddRange(games);
            context.SaveChanges();
        }


        static void Main(string[] args)
        {
            using var context = new AppDbContext();

            // AddData1(context);
            var footballTeams = context.FootballTeams.ToList();
            foreach (var footballTeam in footballTeams)
            {
                Console.WriteLine(footballTeam);
            }

            Console.WriteLine("===================");

            // AddData2(context);
            var games = context.Games.ToList();
            foreach (var game in games)
            {
                Console.WriteLine(game);
            }

        }
    }
}
