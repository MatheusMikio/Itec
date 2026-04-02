using Application.Mapping;
using Domain.entities.baseEntities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.models;

namespace Application.Services
{
    public abstract class BaseUserService<TEntity, TResponseDTO, TRepository> : BaseService<TEntity, TResponseDTO>, IBaseUserService<TResponseDTO>
        where TEntity : BaseUser
        where TResponseDTO : class
        where TRepository : IBaseRepository<TEntity>, IBaseUserRepository<TEntity>
    {
        protected readonly TRepository _userRepository;

        protected BaseUserService(TRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _userRepository = repository;
        }

        public async Task<OperationResult<TResponseDTO>> GetById(Guid id)
        {
            TEntity entity = await _userRepository.GetById(id);
            if (entity == null) return OperationResult<TResponseDTO>.NotFound(new MensagemErro(typeof(TEntity).Name, "Não encontrado."));

            TResponseDTO mapped = _mapper.Map<TResponseDTO>(entity);
            return OperationResult<TResponseDTO>.Ok(mapped);
        }

        public async Task<OperationResult> Delete(Guid id)
        {
            TEntity entity = await _userRepository.GetById(id);
            if (entity == null) return OperationResult.NotFound(new MensagemErro(typeof(TEntity).Name, "Não encontrado."));

            await _repository.Delete(entity);
            return OperationResult.Ok();
        }
    }
}