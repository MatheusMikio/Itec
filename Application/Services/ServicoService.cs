using Application.Mapping;
using Domain.DTOs.Servico;
using Domain.entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class ServicoService : BaseService<Servico, ServicoResponse>, IServicoService
    {
        public ServicoService(IServicoRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public Task<OperationResult> Create(ServicoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(ServicoUpdate request)
        {
            throw new NotImplementedException();
        }
    }
}
