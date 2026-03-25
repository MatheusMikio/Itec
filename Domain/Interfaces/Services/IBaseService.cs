namespace Domain.Interfaces.Services
{
    public interface IBaseService<TResponseDTO>
    {
        Task<OperationResult<List<TResponseDTO>>> GetAll(int page, int size);
        Task<OperationResult<TResponseDTO>> GetById(long id);
        Task<OperationResult> Delete(long id);
    }
}