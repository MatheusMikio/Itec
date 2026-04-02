using Domain.Interfaces.Repositories;
using InfraStructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T: class
    {
        protected readonly ItecDbContext _context;

        public BaseRepository(ItecDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAll(int page, int size) => await _context.Set<T>()
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();

        public async Task<T> GetById(long id) => await _context.Set<T>().FindAsync(id);

        public async Task Create(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        
    }
}