using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Agendamento
{
    public class AgendamentoResponse(entities.Agendamento agendamento)
    {
        public long Id { get; private set; } = agendamento.Id;
        public DateTime Data { get; private set; } = agendamento.Data;
        public long TecnicoId { get; private set; } = agendamento.TecnicoId;
        public long ClienteId { get; private set; } = agendamento.ClienteId;
        public long ServicoId { get; private set; } = agendamento.ServicoId;
        public decimal Valor { get; private set; } = agendamento.Valor;
        public StatusAgendamento Status { get; private set; } = agendamento.Status;
    }
}
