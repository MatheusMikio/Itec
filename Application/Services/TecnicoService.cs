using Application.Mapping;
using Domain.DTOs.Fatura;
using Domain.DTOs.Tecnico;
using Domain.entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TecnicoService : BaseService<Tecnico, TecnicoResponse>, ITecnicoService
    {
        private readonly ITecnicoRepository _tecnicoRepository;

        public TecnicoService(ITecnicoRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _tecnicoRepository = repository;
        }

        public async Task<OperationResult<TecnicoResponse>> GetById(Guid id)
        {
            Tecnico entity = await _tecnicoRepository.GetById(id);
            if (entity == null) return OperationResult<TecnicoResponse>.NotFound(new MensagemErro(typeof(Tecnico).Name, "Não encontrado."));

            TecnicoResponse mapped = _mapper.Map<TecnicoResponse>(entity);
            return OperationResult<TecnicoResponse>.Ok(mapped);
        }

        public Task<OperationResult> Create(TecnicoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(TecnicoUpdate request)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> Delete(Guid id)
        {
            Tecnico entity = await _tecnicoRepository.GetById(id);
            if (entity == null) return OperationResult.NotFound(new MensagemErro(typeof(Tecnico).Name, "Não encontrado."));

            await _repository.Delete(entity);
            return OperationResult.Ok();
        }


    }
}
    