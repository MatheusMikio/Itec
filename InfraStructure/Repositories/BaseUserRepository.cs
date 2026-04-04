using Domain.entities.baseEntities;
using Domain.Interfaces.Repositories;
using InfraStructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repositories
{
    public abstract class BaseUserRepository<T> : BaseRepository<T>, IBaseUserRepository<T> where T : BaseUser
    {
        protected BaseUserRepository(ItecDbContext context) : base(context)
        {
        }

        public async Task<T> GetById(Guid id) => await _context.Set<T>().FirstOrDefaultAsync(u => u.PublicId == id);

        public async Task<T> GetByPublicId(Guid publicId) => await _context.Set<T>()
            .Include(u => u.Contato)
            .Include(u => u.Endereco)
            .Include(u => u.FormaPagamento)
            .Include(u => u.HistoricoAgendamento)
            .FirstOrDefaultAsync(u => u.PublicId == publicId);

        public async Task<T> GetByEmail(string email) => await _context.Set<T>()
            .Include(u => u.Contato)
            .FirstOrDefaultAsync(u => u.Contato.Email == email);

        public async Task<T> GetByRefreshToken(string refreshToken) => await _context.Set<T>()
            .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
    }
}
