using Domain.DTOs.Agendamento;
using Domain.Enums;

namespace Domain.DTOs.Fatura
{
    public class FaturaResponse(entities.Fatura fatura)
    {
        public long TecnicoId { get; private set; } = fatura.TecnicoId;
        public DateTime MesReferencia { get; private set; } = fatura.MesReferencia;
        public decimal ValorBruto { get; private set; } = fatura.ValorBruto;
        public decimal ValorComissao { get; private set; } = fatura.ValorComissao;
        public DateTime DataVencimento { get; private set; } = fatura.DataVencimento;
        public StatusFatura Status { get; private set; } = fatura.Status;
        public IList<AgendamentoResponse> Agendamentos { get; private set; } = new List<AgendamentoResponse>();
    }
}