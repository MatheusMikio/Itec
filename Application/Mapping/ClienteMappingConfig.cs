using Domain.DTOs.Cliente;
using Domain.entities;
using Mapster;

namespace Application.Mapping
{
    public class ClienteMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ClienteRequest, Cliente>()
                .MapWith(src => new Cliente(src));

            config.NewConfig<Cliente, ClienteResponse>()
                .MapWith(src => new ClienteResponse(src));
        }
    }
}