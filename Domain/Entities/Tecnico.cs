using Domain.DTOs.Tecnico;
using Domain.entities.baseEntities;
using Domain.models;

namespace Domain.entities
{
    public class Tecnico : BaseUser
    {
        public string CpfCnpj { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public IList<Servico> Servicos { get; private set; } = [];
        public IList<HorarioDisponibilidade> Horarios { get; private set; } = [];

        public Tecnico(TecnicoRequest request, List<HorarioDisponibilidade> horarios) : base(request)
        {
            CpfCnpj = request.CnpjCpf;
            Descricao = request.Descricao;
            Horarios = horarios;
        }

        protected Tecnico() { }
    }
}