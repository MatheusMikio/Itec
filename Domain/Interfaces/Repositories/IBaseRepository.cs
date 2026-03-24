using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll(int page, int size);
        Task<T> GetById (long id);
        Task<T> GetById(Guid id);
        Task Create (T entity);
        Task Update (T entity);
        Task Delete(T entity);
        
    }
}
