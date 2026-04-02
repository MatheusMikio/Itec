using Domain.entities;
using Domain.Interfaces;
using InfraStructure.Context;
using InfraStructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ItecDbContext context) : base(context)
        {
        }

        public async Task<Cliente> GetById(Guid id) => await _context.Set<Cliente>()
            .Include(c => c.HistoricoAgendamento)
            .FirstOrDefaultAsync(c => c.PublicId == id);
    }
}