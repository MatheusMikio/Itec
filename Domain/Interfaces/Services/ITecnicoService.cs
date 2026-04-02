using Domain.DTOs.Tecnico;

namespace Domain.Interfaces.Services
{
    public interface ITecnicoService : ICrudService<TecnicoResponse, TecnicoRequest, TecnicoUpdate>, IBaseUserService<TecnicoResponse>
    {
        Task<OperationResult<List<TecnicoResponse>>> GetAllPublic(int page, int size);
    }
}