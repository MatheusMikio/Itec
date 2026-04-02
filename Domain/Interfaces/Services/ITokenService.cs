using Domain.entities.baseEntities;

namespace Domain.Interfaces.Services
{
    public interface ITokenService
    {
        string Generate(BaseUser user);
        string GenerateRefreshToken();
    }
}