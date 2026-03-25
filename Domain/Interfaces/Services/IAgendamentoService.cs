using Domain.DTOs.Agendamento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IAgendamentoService : IBaseService<AgendamentoResponse>
    {
        Task<OperationResult> Create(AgendamentoRequest result);
        Task<OperationResult> Update(AgendamentoUpdate result);
    }
}
