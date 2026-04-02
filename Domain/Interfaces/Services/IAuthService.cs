using Domain.DTOs.Auth;

namespace Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<OperationResult<object>> Login(LoginRequest request);
        Task<OperationResult<object>> RefreshToken(RefreshTokenRequest request);
        Task<OperationResult> Logout(Guid publicId);
    }
}
