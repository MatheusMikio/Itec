using Domain.DTOs.Servico;

namespace Domain.Interfaces.Services
{
    public interface IServicoService : ICrudService<ServicoResponse, ServicoRequest, ServicoUpdate>
    {
    }
}