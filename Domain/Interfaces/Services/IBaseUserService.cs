namespace Domain.Interfaces.Services
{
    public interface IBaseUserService<TResponseDTO>
    {
        Task<OperationResult<TResponseDTO>> GetById(Guid id);
        Task<OperationResult> Delete(Guid id);
    }
}