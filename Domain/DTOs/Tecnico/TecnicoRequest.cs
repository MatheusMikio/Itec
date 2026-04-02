using Domain.models;

namespace Domain.DTOs.Tecnico
{
    public class TecnicoRequest : BaseUserRequest
    {
        public string CnpjCpf { get; set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public IList<HorarioDisponibilidade> Horarios { get; private set; } = [];
    }
}