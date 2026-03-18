using Domain.entities.baseEntities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.entities
{
    public class Agendamento : BaseModel
    {
        public DateTime Data { get; private set; }
        public long TecnicoId { get; private set; }
        public Tecnico Tecnico { get; set; }
        public long ClienteId { get; private set; }
        public Cliente Cliente { get; set; }
        public long ServicoId { get; private set; }
        public Servico Servico { get; set; }
        public decimal Valor { get; private set; } = 0;
        public long? FaturaId { get; private set; }
        public Fatura Fatura { get; set; }
        public StatusAgendamento Status { get; private set; } = StatusAgendamento.Pendente;

        public Agendamento(DateTime data, long tecnicoId, long clientId, long servicoId)
        {
            Data = data;
            TecnicoId = tecnicoId;
            ClienteId = clientId;
            ServicoId = servicoId;
        }

        protected Agendamento() { }

        public void VincularFatura(long faturaId)
        {
            FaturaId = faturaId;
        }

    }
}