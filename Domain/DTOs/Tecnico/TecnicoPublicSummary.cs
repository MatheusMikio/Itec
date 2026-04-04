namespace Domain.DTOs.Tecnico
{
    // DTO simplificado para listagem na home
    public class TecnicoPublicSummary(entities.Tecnico tecnico)
    {
        public Guid PublicId { get; private set; } = tecnico.PublicId;
        public string Nome { get; private set; } = tecnico.Nome;
        public string Descricao { get; private set; } = tecnico.Descricao;
        public bool EstaDisponivelHoje { get; private set; } = EstaDisponivelNoMomento(tecnico.Horarios);

        private static bool EstaDisponivelNoMomento(IList<models.HorarioDisponibilidade>? horarios)
        {
            var agora = DateTime.Now;
            var diaAtual = agora.DayOfWeek;
            var horaAtual = TimeOnly.FromDateTime(agora);

            return horarios?.Any(h => h.Dia == diaAtual && horaAtual >= h.Inicio && horaAtual <= h.Fim) ?? false;
        }
    }
}
