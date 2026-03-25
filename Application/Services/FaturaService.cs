using Application.Mapping;
using Domain.DTOs.Fatura;
using Domain.entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class FaturaService : BaseService<Fatura, FaturaResponse>, IFaturaService
    {
        public FaturaService(IFaturaRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public Task<OperationResult> Create(FaturaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(FaturaUpdate request)
        {
            throw new NotImplementedException();
        }
    }
}
