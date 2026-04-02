using Domain.entities;
using Domain.Interfaces.Repositories;

namespace Domain.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>, IBaseUserRepository<Cliente>
    {
    }
}