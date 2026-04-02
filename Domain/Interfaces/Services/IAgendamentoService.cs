using Domain.DTOs.Agendamento;

namespace Domain.Interfaces.Services
{
    public interface IAgendamentoService : ICrudService<AgendamentoResponse, AgendamentoRequest, AgendamentoUpdate>
    {
    }
}