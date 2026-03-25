using Domain.entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ITecnicoRepository : IBaseRepository<Tecnico>
    {
        Task<Tecnico> GetById(Guid id);
    }
}
