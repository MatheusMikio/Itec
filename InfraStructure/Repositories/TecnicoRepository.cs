using Domain.entities;
using Domain.Interfaces;
using InfraStructure.Context;
using InfraStructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class TecnicoRepository : BaseRepository<Tecnico>, ITecnicoRepository
    {
        public TecnicoRepository(ItecDbContext context) : base(context)
        {
        }

        public async Task<Tecnico> GetById(Guid id) => await _context.Set<Tecnico>()
            .Include(t => t.HistoricoAgendamento)
            .FirstOrDefaultAsync(t => t.PublicId == id);
    }
}