using Domain.DTOs.Servico;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IServicoService : IBaseService<ServicoResponse>
    {
        Task<OperationResult> Create(ServicoRequest request);
        Task<OperationResult> Update(ServicoUpdate request);
    }
}
