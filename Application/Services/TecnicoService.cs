using Application.Mapping;
using Domain.DTOs.Tecnico;
using Domain.entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.models;

namespace Application.Services
{
    public class TecnicoService : BaseUserService<Tecnico, TecnicoResponse, ITecnicoRepository>, ITecnicoService
    {
        private readonly ITecnicoRepository _tecnicoRepository;

        public TecnicoService(ITecnicoRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _tecnicoRepository = repository;
        }

        public async Task<OperationResult<List<TecnicoPublicSummary>>> GetAllPublic(int page, int size)
        {
            List<Tecnico> tecnicos = await _tecnicoRepository.GetAllPublicSummary(page, size);
            if (tecnicos == null || !tecnicos.Any())  return OperationResult<List<TecnicoPublicSummary>>.Ok(new List<TecnicoPublicSummary>());

            List<TecnicoPublicSummary> mappedTecnicos = _mapper.Map<List<TecnicoPublicSummary>>(tecnicos);
            return OperationResult<List<TecnicoPublicSummary>>.Ok(mappedTecnicos);
        }

        public async Task<OperationResult<TecnicoPublicDetail>> GetByIdPublic(Guid publicId)
        {
            Tecnico tecnico = await _tecnicoRepository.GetPublicDetailById(publicId);
            if (tecnico == null) return OperationResult<TecnicoPublicDetail>.NotFound(new MensagemErro("Tecnico", "Não encontrado"));

            TecnicoPublicDetail mappedTecnico = _mapper.Map<TecnicoPublicDetail>(tecnico);
            return OperationResult<TecnicoPublicDetail>.Ok(mappedTecnico);
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