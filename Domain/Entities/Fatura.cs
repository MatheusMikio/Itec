using Domain.entities.baseEntities;
using Domain.Enums;

namespace Domain.entities
{
    public class Fatura : BaseModel
    {
        public long TecnicoId { get; private set; }
        public Tecnico Tecnico { get; set; }
        public DateTime MesReferencia { get; private set; }
        public decimal ValorBruto { get; private set; } = 0;
        public decimal ValorComissao { get; private set; } = 0;
        public DateTime DataVencimento { get; private set; }
        public StatusFatura Status { get; private set; } = StatusFatura.Pendente;
        public IList<Agendamento> Agendamentos { get; private set; } = new List<Agendamento>();

        public Fatura(long tecnicoId, DateTime mesReferencia, DateTime dataVencimento)
        {
            TecnicoId = tecnicoId;
            MesReferencia = mesReferencia;
            DataVencimento = dataVencimento;
        }
        protected Fatura() { }

        public void AdicionarAgendamento(Agendamento agendamento)
        {
            if (agendamento == null) return;

            Agendamentos.Add(agendamento);
            RecalcularValores();
        }

        public void RecalcularValores()
        {
            ValorBruto = Agendamentos.Sum(a => a.Valor);

            ValorComissao = ValorBruto * 0.10m;
        }
    }
}