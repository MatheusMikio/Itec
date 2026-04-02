using Application.Mapping;
using Domain.DTOs.Agendamento;
using Domain.entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.models;
using System.ComponentModel.DataAnnotations;

namespace Application.Services
{
    public class AgendamentoService : BaseService<Agendamento, AgendamentoResponse>, IAgendamentoService
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly ITecnicoRepository _tecnicoRepository;
        private readonly IClienteRepository _clienteRepository;
        public AgendamentoService(
            IAgendamentoRepository agendamentoRepository,
            IServicoRepository servicoRepository,
            ITecnicoRepository tecnicoRepository,
            IClienteRepository clienteRepository,
            IMapper mapper)
            : base(agendamentoRepository, mapper)
        {
            _servicoRepository = servicoRepository;
            _tecnicoRepository = tecnicoRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<OperationResult> Create(AgendamentoRequest request)
        {
            List<MensagemErro> erros = await Validar(request);

            if (erros.Any()) return OperationResult.UnprocessableEntity(erros);

            try
            {
                await _repository.Create(_mapper.Map<Agendamento>(request));
                return OperationResult.Created();
            }
            catch (Exception ex) 
            {
                return OperationResult.FatalError(new MensagemErro("Database", ex.Message));
            }
        }

        public Task<OperationResult> Update(AgendamentoUpdate request)
        {
            throw new NotImplementedException();
        }

        private async Task<List<MensagemErro>> Validar(AgendamentoRequest request)
        {
            ValidationContext validationContext = new(request);
            List<ValidationResult> errors = new();
            bool validation = Validator.TryValidateObject(request, validationContext, errors, true);
            List<MensagemErro> mensagens = errors.Select(erro => new MensagemErro(erro.MemberNames.FirstOrDefault(), erro.ErrorMessage)).ToList();

            Servico servicoDb = await _servicoRepository.GetById(request.ServicoId);
            Tecnico tecnicoDb = await _tecnicoRepository.GetById(request.TecnicoId);
            Cliente clienteDb = await _clienteRepository.GetById(request.ClienteId);

            if (!ValidarEntidadesExistentes(servicoDb, tecnicoDb, clienteDb, mensagens)) return mensagens;

            ValidarPropriedadesRequest(request, servicoDb, tecnicoDb, clienteDb, mensagens);

            return mensagens;
        }

        private bool ValidarEntidadesExistentes(Servico servicoDb, Tecnico tecnicoDb, Cliente clienteDb, List<MensagemErro> mensagens)
        {
            if (servicoDb == null) mensagens.Add(new MensagemErro("Servico", "Não encontrado."));
            if (tecnicoDb == null) mensagens.Add(new MensagemErro("Tecnico", "Não encontrado."));
            if (clienteDb == null) mensagens.Add(new MensagemErro("Cliente", "Não encontrado."));
            return !mensagens.Any();
        }

        private void ValidarPropriedadesRequest(AgendamentoRequest request, Servico servicoDb, Tecnico tecnicoDb, Cliente clienteDb, List<MensagemErro> mensagens)
        {
            if (request.Valor != 0) mensagens.Add(new MensagemErro("Valor", "O valor do agendamento deve ser definido futuramente pelo técnico quando o serviço for concluido."));

            ValidarHorario(request, tecnicoDb, clienteDb, mensagens);
            ValidarServico(servicoDb, tecnicoDb, mensagens);
        }

        private void ValidarHorario(AgendamentoRequest request, Tecnico tecnicoDb, Cliente clienteDb, List<MensagemErro> mensagens)
        {
            if (request.Data < DateTime.Now) mensagens.Add(new MensagemErro("DataAgendamento", "A data do agendamento deve ser futura."));


            IEnumerable<Agendamento> ? agendamentosClienteConflitantes = clienteDb.HistoricoAgendamento
                .Where(
                    ha => ha.Data >= request.Data.AddMinutes(-30) && 
                    ha.Data <= request.Data.AddMinutes(30)
                );

            if (agendamentosClienteConflitantes.Any())
                mensagens.Add(new MensagemErro("DataAgendamento", "O cliente já possui um agendamento para a data informada ou em horário próximo (30 minutos antes ou depois)."));

            IEnumerable<Agendamento> ? agendamentosTecnicoConflitantes = tecnicoDb.HistoricoAgendamento
                .Where(
                    ha => ha.Data >= request.Data.AddMinutes(-30) &&
                    ha.Data <= request.Data.AddMinutes(30)
                );

            if (agendamentosTecnicoConflitantes.Any())
                mensagens.Add(new MensagemErro("DataAgendamento", "O técnico já possui um agendamento para a data informada ou em horário próximo (30 minutos antes ou depois)."));
        }

        private void ValidarServico(Servico servicoDb, Tecnico tecnicoDb, List<MensagemErro> mensagens)
        {
            if (servicoDb.TecnicoId != tecnicoDb.Id)  mensagens.Add(new MensagemErro("ServicoId", "O serviço não pertence ao técnico selecionado."));
        }
    }
}