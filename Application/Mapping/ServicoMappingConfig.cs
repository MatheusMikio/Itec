using Domain.DTOs.Servico;
using Domain.entities;
using Mapster;

namespace Application.Mapping
{
    public class ServicoMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ServicoRequest, Servico>()
                .MapWith(src => new Servico(src));

            config.NewConfig<Servico, ServicoResponse>()
                .MapWith(src => new ServicoResponse(src));
        }
    }
}
