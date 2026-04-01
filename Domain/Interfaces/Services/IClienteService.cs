using Domain.DTOs.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IClienteService : ICrudService<ClienteResponse, ClienteRequest, ClienteUpdate>, IBaseUserService<ClienteResponse>
    {
        Task<OperationResult<ClienteResponse>> GetById(Guid id);
        Task<OperationResult> Delete(Guid id);
    }
}
