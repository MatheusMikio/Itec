using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseUserRepository<T>
    {
        Task<T> GetById(Guid id);
    }
}
