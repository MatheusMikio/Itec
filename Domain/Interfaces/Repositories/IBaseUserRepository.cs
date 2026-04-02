namespace Domain.Interfaces.Repositories
{
    public interface IBaseUserRepository<T>
    {
        Task<T> GetById(Guid id);
        Task<T> GetByPublicId(Guid publicId);
        Task<T> GetByEmail(string email);
        Task<T> GetByRefreshToken(string refreshToken);
    }
}