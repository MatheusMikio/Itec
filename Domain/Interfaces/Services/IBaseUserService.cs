namespace Domain.Interfaces.Services
{
    public interface IBaseUserService<TResponseDTO>
    {
        Task<OperationResult<TResponseDTO>> GetById(Guid id);
        Task<OperationResult<TResponseDTO>> GetMyInfo(Guid publicId);
        Task<OperationResult> Delete(Guid id);
    }
}