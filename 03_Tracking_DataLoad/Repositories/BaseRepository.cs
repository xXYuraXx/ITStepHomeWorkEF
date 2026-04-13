using _03_Tracking_DataLoad.data;
using _03_Tracking_DataLoad.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Tracking_DataLoad.Repositories
{
    internal class BaseRepository<T> where T : class
    {
        readonly protected AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return _context.Set<T>().AsQueryable();
        }
        

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            try
            {
                _context.Set<T>().Remove(entity);
                int res = await _context.SaveChangesAsync();
                return res > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            if (entity == null) return false;

            try
            {
                _context.Set<T>().Update(entity);
                int res = await _context.SaveChangesAsync();
                return res > 0;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
