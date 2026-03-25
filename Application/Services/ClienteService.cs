using Application.Mapping;
using Domain.DTOs.Cliente;
using Domain.entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class ClienteService : BaseService<Cliente, ClienteResponse>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _clienteRepository = repository;
        }

        public async Task<OperationResult<ClienteResponse>> GetById(Guid id)
        {
            Cliente entity = await _clienteRepository.GetById(id);
            if (entity == null) return OperationResult<ClienteResponse>.NotFound(new MensagemErro(typeof(Cliente).Name, "Não encontrado."));

            ClienteResponse mapped = _mapper.Map<ClienteResponse>(entity);
            return OperationResult<ClienteResponse>.Ok(mapped);
        }

        public Task<OperationResult> Create(ClienteRequest request)
        {
            List<MensagemErro> errors = Validate(request);
            
            if (errors.Count > 0) return Task.FromResult(OperationResult.UnprocessableEntity(errors));

            try
            {
                _repository.Create(_mapper.Map<Cliente>(request));
                return Task.FromResult(OperationResult.Created());
            }
            catch
            {
                MensagemErro error = new("Database", "Erro Inesperado");
                return Task.FromResult(OperationResult.FatalError(error));
            }
        }

        public Task<OperationResult> Update(ClienteUpdate request)
        {
            List<MensagemErro> errors = ValidateUpdate(request);

            if (errors.Count > 0) return Task.FromResult(OperationResult.UnprocessableEntity(errors));

            try
            {
                _repository.Update(_mapper.Map<Cliente>(request));
                return Task.FromResult(OperationResult.Ok());

            }
            catch
            {
                MensagemErro error = new("Database", "Erro Inesperado");
                return Task.FromResult(OperationResult.FatalError(error));
            }        
        }

        public async Task<OperationResult> Delete(Guid id)
        {
            Cliente entity = await _clienteRepository.GetById(id);
            if (entity == null) return OperationResult.NotFound(new MensagemErro(typeof(Cliente).Name, "Não encontrado."));

            await _repository.Delete(entity);
            return OperationResult.Ok();
        }

        private static List<MensagemErro> Validate(ClienteRequest request) 
        {
            return new List<MensagemErro>();
        }

        private static List<MensagemErro> ValidateUpdate(ClienteUpdate request)
        {
            return new List<MensagemErro>();
        }
    }
}
