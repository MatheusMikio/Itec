using Application.Mapping;
using Domain.DTOs.Tecnico;
using Domain.entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class TecnicoService : BaseUserService<Tecnico, TecnicoResponse, ITecnicoRepository>, ITecnicoService
    {
        private readonly ITecnicoRepository _tecnicoRepository;

        public TecnicoService(ITecnicoRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _tecnicoRepository = repository;
        }

        public Task<OperationResult> Create(TecnicoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(TecnicoUpdate request)
        {
            throw new NotImplementedException();
        }
    }
}