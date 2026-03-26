using Domain.entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Agendamento
{
    public class AgendamentoUpdate
    {
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public long TecnicoId { get; set; }
        public long ClienteId { get; set; }
        public long ServicoId { get; set; }
        public decimal Valor { get; set; }
        public StatusAgendamento Status { get; set; }
    }
}
