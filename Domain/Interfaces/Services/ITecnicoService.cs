using Domain.DTOs.Cliente;
using Domain.DTOs.Tecnico;

namespace Domain.Interfaces.Services
{
    public interface ITecnicoService : IBaseService<TecnicoResponse>, IBaseUserService<TecnicoResponse>
    {
        Task<OperationResult<TecnicoResponse>> GetById(Guid id);
        Task<OperationResult> Create(TecnicoRequest request);
        Task<OperationResult> Update(TecnicoUpdate request);
        Task<OperationResult> Delete(Guid id);
    }
}
