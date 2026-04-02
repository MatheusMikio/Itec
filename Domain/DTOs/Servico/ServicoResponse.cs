using Domain.Enums;

namespace Domain.DTOs.Servico
{
    public class ServicoResponse(entities.Servico servico)
    {
        public long Id { get; private set; } = servico.Id;
        public string Nome { get; set; } = servico.Nome;
        public decimal MinPreco { get; set; } = servico.MinPreco;
        public decimal MaxPreco { get; private set; } = servico.MaxPreco;
        public string Descricao { get; private set; } = servico.Descricao;
        public Categorias Categoria { get; private set; } = servico.Categoria;
        public long TecnicoId { get; private set; } = servico.TecnicoId;
    }
}