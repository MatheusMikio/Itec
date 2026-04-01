using Domain.DTOs.Tecnico;
using Domain.entities;
using Domain.models;
using Mapster;

namespace Application.Mapping
{
    public class TecnicoMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TecnicoRequest, Tecnico>()
                .MapWith(src => new Tecnico(src, new List<HorarioDisponibilidade>()));

            config.NewConfig<Tecnico, TecnicoResponse>()
                .MapWith(src => new TecnicoResponse(src));
        }
    }
}
