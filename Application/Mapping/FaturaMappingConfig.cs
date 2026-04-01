using Domain.DTOs.Fatura;
using Domain.entities;
using Mapster;

namespace Application.Mapping
{
    public class FaturaMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Fatura não tem Request DTO, apenas Response
            config.NewConfig<Fatura, FaturaResponse>()
                .MapWith(src => new FaturaResponse(src));
        }
    }
}
