using Application.Mapping;
using Domain.DTOs.Agendamento;
using Domain.entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
            OperationResult result = erros.Count > 0 ? OperationResult.UnprocessableEntity(erros) : OperationResult.Created();
            return result;
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

            await ValidarGetByIdRequest(request, mensagens);
            await ValidarPropriedadesRequest(request, mensagens);

            return mensagens;
        }


        private async Task ValidarGetByIdRequest(AgendamentoRequest request, List<MensagemErro> mensagens)
        {
            Servico servicoDb = await _servicoRepository.GetById(request.ServicoId);
            if (servicoDb == null) mensagens.Add(new MensagemErro("Servico", "Não encontrado."));

            Tecnico tecnicoDb = await _tecnicoRepository.GetById(request.TecnicoId);
            if (tecnicoDb == null) mensagens.Add(new MensagemErro("Tecnico", "Não encontrado."));

            Cliente clienteDb = await _clienteRepository.GetById(request.ClienteId);
            if (clienteDb == null) mensagens.Add(new MensagemErro("Cliente", "Não encontrado."));
        }

        private async Task ValidarPropriedadesRequest(AgendamentoRequest request, List<MensagemErro> mensagens)
        {
            if (request.Valor != 0) mensagens.Add(new MensagemErro("Valor", "O valor do agendamento deve ser definido futuramente pelo técnico quando o serviço for concluido."));

            if (request.Data < DateTime.Now) mensagens.Add(new MensagemErro("DataAgendamento", "A data do agendamento deve ser futura."));

            Cliente clienteDb = await _clienteRepository.GetById(request.ClienteId);
            Tecnico tecnicoDb = await _tecnicoRepository.GetById(request.TecnicoId);

            var agendamentosClienteConflitantes = clienteDb.HistoricoAgendamento.Where(ha => ha.Data >= request.Data.AddMinutes(-30) && ha.Data <= request.Data.AddMinutes(30));

            if (agendamentosClienteConflitantes.Any())
                mensagens.Add(new MensagemErro("DataAgendamento", "O cliente já possui um agendamento para a data informada ou em horário próximo (30 minutos antes ou depois)."));

            var agendamentosTecnicoConflitantes = tecnicoDb.HistoricoAgendamento.Where(ha => ha.Data >= request.Data.AddMinutes(-30) && ha.Data <= request.Data.AddMinutes(30));

            if (agendamentosTecnicoConflitantes.Any())
                mensagens.Add(new MensagemErro("DataAgendamento", "O técnico já possui um agendamento para a data informada ou em horário próximo (30 minutos antes ou depois)."));
        }
    }
}
