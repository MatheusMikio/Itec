using Domain.entities;
using Domain.Interfaces.Repositories;

namespace Domain.Interfaces
{
    public interface ITecnicoRepository : IBaseRepository<Tecnico>, IBaseUserRepository<Tecnico>
    {
    }
}