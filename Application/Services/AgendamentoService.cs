using Application.Mapping;
using Domain.DTOs.Agendamento;
using Domain.entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class AgendamentoService : BaseService<Agendamento, AgendamentoResponse>, IAgendamentoService
    {
        public AgendamentoService(IAgendamentoRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public Task<OperationResult> Create(AgendamentoRequest result)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(AgendamentoUpdate result)
        {
            throw new NotImplementedException();
        }
    }
}
