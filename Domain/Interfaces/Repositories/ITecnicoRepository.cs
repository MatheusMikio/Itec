using Domain.entities;
using Domain.Interfaces.Repositories;

namespace Domain.Interfaces
{
    public interface ITecnicoRepository : IBaseRepository<Tecnico>, IBaseUserRepository<Tecnico>
    {
        Task<List<Tecnico>> GetAllPublicSummary(int page, int size);
        Task<Tecnico> GetPublicDetailById(Guid publicId);
    }
}