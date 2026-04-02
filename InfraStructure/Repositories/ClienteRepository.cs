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

        public async Task<Cliente> GetByPublicId(Guid publicId) => await _context.Set<Cliente>()
            .Include(c => c.Contato)
            .Include(c => c.Endereco)
            .Include(c => c.FormaPagamento)
            .FirstOrDefaultAsync(c => c.PublicId == publicId);

        public async Task<Cliente> GetByEmail(string email) => await _context.Set<Cliente>()
            .Include(c => c.Contato)
            .Include(c => c.Endereco)
            .Include(c => c.FormaPagamento)
            .FirstOrDefaultAsync(c => c.Contato.Email == email);

        public async Task<Cliente> GetByRefreshToken(string refreshToken) => await _context.Set<Cliente>()
            .Include(c => c.Contato)
            .Include(c => c.Endereco)
            .Include(c => c.FormaPagamento)
            .FirstOrDefaultAsync(c => c.RefreshToken == refreshToken);
    }
}