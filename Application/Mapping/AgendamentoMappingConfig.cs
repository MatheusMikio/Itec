using Domain.DTOs.Agendamento;
using Domain.entities;
using Mapster;

namespace Application.Mapping
{
    public class AgendamentoMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AgendamentoRequest, Agendamento>()
                .MapWith(src => new Agendamento(src));

            config.NewConfig<Agendamento, AgendamentoResponse>()
                .MapWith(src => new AgendamentoResponse(src));
        }
    }
}