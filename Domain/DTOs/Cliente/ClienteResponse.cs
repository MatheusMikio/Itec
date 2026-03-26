using Domain.DTOs.Agendamento;
using Domain.models;


namespace Domain.DTOs.Cliente
{
    public class ClienteResponse(entities.Cliente cliente)
    {
        public long Id { get; private set; } = cliente.Id;
        public string Nome { get; private set; } = cliente.Nome;
        public string Cpf { get; private set; } = cliente.CPF;
        public Contato contato { get; private set; } = cliente.Contato;
        public Endereco endereco { get; private set; } = cliente.Endereco;
        public FormaPagamento FormaPagamento { get; private set; } = cliente.FormaPagamento;
        public IList<AgendamentoResponse> HistoricoAgendameto { get; private set; } = [];
        public bool Ativo { get; private set; }

    }
}
