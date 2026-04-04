using Domain.DTOs.Tecnico;

namespace Domain.Interfaces.Services
{
    public interface ITecnicoService : ICrudService<TecnicoResponse, TecnicoRequest, TecnicoUpdate>, IBaseUserService<TecnicoResponse>
    {
        Task<OperationResult<List<TecnicoPublicSummary>>> GetAllPublic(int page, int size);
        Task<OperationResult<TecnicoPublicDetail>> GetByIdPublic(Guid publicId);
    }
}