using Domain.DTOs.Agendamento;
using Domain.DTOs.Servico;
using Domain.entities;
using Domain.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Tecnico
{
    public class TecnicoResponse(entities.Tecnico tecnico)
    {
        public long Id { get; private set; } = tecnico.Id;
        public string Nome { get; private set; } = tecnico.Nome;
        public string Cpf { get; private set; } = tecnico.CpfCnpj;
        public Contato contato { get; private set; } = tecnico.Contato;
        public Endereco endereco { get; private set; } = tecnico.Endereco;
        public FormaPagamento FormaPagamento { get; private set; } = tecnico.FormaPagamento;
        public IList<AgendamentoResponse> HistoricoAgendameto { get; private set; } = [];
        public string CpfCnpj { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public IList<ServicoResponse > Servicos { get; private set; } = [];
        public bool Ativo { get; private set; }
    }
}
