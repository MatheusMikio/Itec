using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
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

        public Task<OperationResult<DTOResponse>> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<DTOResponse>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
