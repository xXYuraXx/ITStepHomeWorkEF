using _03_Tracking_DataLoad.data;
using _03_Tracking_DataLoad.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Tracking_DataLoad.Repositories
{
    internal class GameRepository : BaseRepository<GameEntity>
    {
        public GameRepository(AppDbContext _context) : base(_context) { }

        public async Task<List<GenreEntity>> GetGenresByGameAsync(int gameId)
        {
            var game = await _context.Games
                .Include(g => g.Genres)
                .FirstOrDefaultAsync(g => g.Id == gameId);
            if (game == null) return [];
            return game.Genres.ToList();
        }

    }
}
