using Domain.DTOs.Cliente;

namespace Domain.Interfaces.Services
{
    public interface IClienteService : ICrudService<ClienteResponse, ClienteRequest, ClienteUpdate>, IBaseUserService<ClienteResponse>
    {
    }
}