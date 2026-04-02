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

        public async Task<Tecnico> GetByPublicId(Guid publicId) => await _context.Set<Tecnico>()
            .Include(t => t.Contato)
            .Include(t => t.Endereco)
            .Include(t => t.FormaPagamento)
            .FirstOrDefaultAsync(t => t.PublicId == publicId);

        public async Task<Tecnico> GetByEmail(string email) => await _context.Set<Tecnico>()
            .Include(t => t.Contato)
            .Include(t => t.Endereco)
            .Include(t => t.FormaPagamento)
            .FirstOrDefaultAsync(t => t.Contato.Email == email);

        public async Task<Tecnico> GetByRefreshToken(string refreshToken) => await _context.Set<Tecnico>()
            .Include(t => t.Contato)
            .Include(t => t.Endereco)
            .Include(t => t.FormaPagamento)
            .FirstOrDefaultAsync(t => t.RefreshToken == refreshToken);

        public async Task<List<Tecnico>> GetAllWithServices() => await _context.Set<Tecnico>()
            .Include(t => t.Servicos)
            .Include(t => t.Contato)
            .Include(t => t.Endereco)
            .Include(t => t.Horarios)
            .Where(t => t.Ativo)
            .ToListAsync();
    }
}