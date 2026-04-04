namespace Domain.DTOs.Tecnico
{
    // DTO simplificado para listagem na home
    public class TecnicoPublicSummary(entities.Tecnico tecnico)
    {
        public Guid PublicId { get; private set; } = tecnico.PublicId;
        public string Nome { get; private set; } = tecnico.Nome;
        public string Descricao { get; private set; } = tecnico.Descricao;
        public bool EstaDisponivelHoje { get; private set; } = tecnico.Horarios?.Any(h => h.Dia == DateTime.Now.DayOfWeek) ?? false;
    }
}
