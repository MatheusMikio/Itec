using Domain.DTOs.Tecnico;
using Domain.entities;
using Mapster;

namespace Application.Mapping
{
    public class TecnicoMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TecnicoRequest, Tecnico>()
                .MapWith(src => new Tecnico(src));

            config.NewConfig<Tecnico, TecnicoResponse>()
                .MapWith(src => new TecnicoResponse(src));

            config.NewConfig<Tecnico, TecnicoPublicSummary>()
                .MapWith(src => new TecnicoPublicSummary(src));

            config.NewConfig<Tecnico, TecnicoPublicDetail>()
                .MapWith(src => new TecnicoPublicDetail(src));
        }
    }
}