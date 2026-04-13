using _03_Tracking_DataLoad.data;
using _03_Tracking_DataLoad.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Tracking_DataLoad.Repositories
{
    internal class PublisherRepository : BaseRepository<PublisherEntity>
    {
        public PublisherRepository(AppDbContext _context) : base(_context) { }

        public async Task<List<GameEntity>> GetGamesByPublisherAsync(int publisherId)
        {
            var publisher = await GetByIdAsync(publisherId);
            if (publisher == null) return [];
            await _context.Entry(publisher)
                .Collection(p => p.Games)
                .LoadAsync();
            return publisher.Games.ToList();
        }
    }
}
