using _03_Tracking_DataLoad.data;
using _03_Tracking_DataLoad.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Tracking_DataLoad.Repositories
{
    internal class GenreRepository : BaseRepository<GenreEntity>
    {
        public GenreRepository(AppDbContext _context) : base(_context) { }

        public async Task<List<GameEntity>> GetGamesByGenreAsync(int genreId)
        {
            return await _context.Games.Where(g => g.Genres.Any(ge => ge.Id == genreId)).Include(g => g.Genres).ToListAsync();
        }

    }
}
