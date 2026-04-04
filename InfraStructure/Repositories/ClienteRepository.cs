using Domain.entities;
using Domain.Interfaces;
using InfraStructure.Context;
using InfraStructure.Repositories;

namespace Infra.Repositories
{
    public class ClienteRepository : BaseUserRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ItecDbContext context) : base(context)
        {
        }
    }
}