using Domain.DTOs.Cliente;
using Domain.DTOs.Tecnico;

namespace Domain.Interfaces.Services
{
    public interface ITecnicoService : ICrudService<TecnicoResponse, TecnicoRequest, TecnicoUpdate>, IBaseUserService<TecnicoResponse>
    {
        Task<OperationResult<TecnicoResponse>> GetById(Guid id);
        Task<OperationResult> Delete(Guid id);
    }
}
