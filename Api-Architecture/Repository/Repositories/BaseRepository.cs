using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        protected DbSet<T> _entities;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(T entity)
        {
           _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.AsNoTracking().FirstOrDefaultAsync(m=>m.Id==id);
        }
    }
}
