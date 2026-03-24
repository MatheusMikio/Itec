using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public abstract class BaseService<T, DTOResponse> : IBaseService<DTOResponse>
        where T : class
        where DTOResponse : class
    {
        protected readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<List<DTOResponse>>> GetAll(int page, int size)
        {
            List<T> entities = await _repository.GetAll(page, size);
            if (entities == null || !entities.Any())
            {
                return OperationResult<List<DTOResponse>>.Ok(new List<DTOResponse>());
            }

            List<DTOResponse> mappedEntities = entities.Adapt<List<DTOResponse>>();
            return OperationResult<List<DTOResponse>>.Ok(mappedEntities);
        }

        public async Task<OperationResult<DTOResponse>> GetById(long id)
        {
            T entity = await _repository.GetById(id);
            if (entity == null)
            {
                return OperationResult<DTOResponse>.NotFound(new MensagemErro(typeof(T).Name, "Não encontrado."));
            }

            DTOResponse mappedEntity = entity.Adapt<DTOResponse>();
            return OperationResult<DTOResponse>.Ok(mappedEntity);   
        }

        public async Task<OperationResult<DTOResponse>> GetById(Guid id)
        {
            T entity = await _repository.GetById(id);
            if (entity == null)
            {
                return OperationResult<DTOResponse>.NotFound(new MensagemErro(typeof(T).Name, "Não encontrado."));
            }

            DTOResponse mappedEntity = entity.Adapt<DTOResponse>();
            return OperationResult<DTOResponse>.Ok(mappedEntity);
        }

        public async Task<OperationResult> Delete(long id)
        {
            T entity = await _repository.GetById(id);
            if (entity == null)
            {
                return OperationResult<DTOResponse>.NotFound(new MensagemErro(typeof(T).Name, "Não encontrado."));
            }

            await _repository.Delete(entity);
            return OperationResult.Ok();
        }
    }
}