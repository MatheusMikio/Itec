using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Agendamento
{
    public class AgendamentoRequest
    {
        public DateTime Data { get; private set; }
        public long TecnicoId { get; private set; }
        public long ClienteId { get; private set; }
        public long ServicoId { get; private set; }
        public decimal Valor { get; private set; } = 0;
        public long ? FaturaId { get; private set; }
    }
}
