namespace Domain.Interfaces.Repositories
{
    public interface IBaseUserRepository<T>
    {
        Task<T> GetById(Guid id);
    }
}