using Domain.DTOs.Servico;
using Domain.models;

namespace Domain.DTOs.Tecnico
{
    // DTO completo para visualização de detalhes do técnico
    public class TecnicoPublicDetail(entities.Tecnico tecnico)
    {
        public Guid PublicId { get; private set; } = tecnico.PublicId;
        public string Nome { get; private set; } = tecnico.Nome;
        public string Descricao { get; private set; } = tecnico.Descricao;
        public Contato Contato { get; private set; } = tecnico.Contato;
        public Endereco Endereco { get; private set; } = tecnico.Endereco;
        public IList<ServicoResponse> Servicos { get; private set; } = [];
        public IList<HorarioDisponibilidade> Horarios { get; private set; } = tecnico.Horarios;
    }
}
