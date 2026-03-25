using Domain.DTOs.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IClienteService : IBaseService<ClienteResponse>, IBaseUserService<ClienteResponse>
    {
        Task<OperationResult<ClienteResponse>> GetById(Guid id);
        Task<OperationResult> Create(ClienteRequest request);
        Task<OperationResult> Update(ClienteUpdate request);
        Task<OperationResult> Delete(Guid id);
    }
}
