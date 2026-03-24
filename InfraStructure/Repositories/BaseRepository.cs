using Domain.Interfaces.Repositories;
using InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T: class
    {
        protected readonly ItecDbContext _context;

        public BaseRepository(ItecDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAll(int page, int size) => await _context.Set<T>().Skip((page - 1) * size).Take(size).ToListAsync();

        public async Task<T> GetById(long id) => await _context.Set<T>().FindAsync(id);
        public async Task<T> GetById(Guid id) => await _context.Set<T>().FindAsync(id);

        public async Task Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        
    }
}
