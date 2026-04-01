namespace Domain.Interfaces.Services
{
    public interface ICrudService<TResponseDTO, TRequestDTO, TUpdateDTO> : IBaseService<TResponseDTO>
    where TResponseDTO : class
    where TRequestDTO : class
    where TUpdateDTO : class
    {
        Task<OperationResult> Create(TRequestDTO request);
        Task<OperationResult> Update(TUpdateDTO request);
    }
}