using System;
using System.Collections.Generic;
using System.Text;
using _03_Tracking_DataLoad.Entities;
using Microsoft.EntityFrameworkCore;

namespace _03_Tracking_DataLoad.data
{
    internal class Seeder
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.Migrate();

            if (context.Games.Any() || context.Publishers.Any() || context.Genres.Any())
            {
                return;
            }

            var publisher1 = new PublisherEntity
            {
                Name = "Epic Games",
                Description = "Epic Games is an American...",
                Country = "USA"
            };
            var publisher2 = new PublisherEntity
            {
                Name = "CD Projekt",
                Description = "CD Projekt is a Polish video game developer...",
                Country = "Poland"
            };
            var genre1 = new GenreEntity
            {
                Name = "Action"
            };
            var genre2 = new GenreEntity
            {
                Name = "RPG"
            };
            var game1 = new GameEntity
            {
                Name = "Fortnite",
                ReleaseDate = new DateTime(2017, 7, 21),
                Publisher = publisher1,
                Genres = new List<GenreEntity> { genre1 }
            };
            var game2 = new GameEntity
            {
                Name = "The Witcher 3: Wild Hunt",
                ReleaseDate = new DateTime(2015, 5, 19),
                Publisher = publisher2,
                Genres = new List<GenreEntity> { genre1, genre2 }
            };
            context.Publishers.AddRange(publisher1, publisher2);
            context.Genres.AddRange(genre1, genre2);
            context.Games.AddRange(game1, game2);
            context.SaveChanges();
        }
    }
}
