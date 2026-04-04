using Domain.entities;
using Domain.Interfaces;
using InfraStructure.Context;
using InfraStructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class TecnicoRepository : BaseUserRepository<Tecnico>, ITecnicoRepository
    {
        public TecnicoRepository(ItecDbContext context) : base(context)
        {
        }

        public async Task<List<Tecnico>> GetAllPublicSummary(int page, int size) => await _context.Set<Tecnico>()
            .Include(t => t.Horarios)
            .Where(t => t.Ativo)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();

        public async Task<Tecnico> GetPublicDetailById(Guid publicId) => await _context.Set<Tecnico>()
            .Include(t => t.Contato)
            .Include(t => t.Endereco)
            .Include(t => t.Servicos)
            .Include(t => t.Horarios)
            .FirstOrDefaultAsync(t => t.PublicId == publicId && t.Ativo);
    }
}