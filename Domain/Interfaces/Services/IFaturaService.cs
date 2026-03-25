using Domain.DTOs.Fatura;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IFaturaService : IBaseService<FaturaResponse>
    {
        Task<OperationResult> Create(FaturaRequest request);
        Task<OperationResult> Update(FaturaUpdate request);
    }
}
