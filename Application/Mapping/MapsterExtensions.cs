using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Application.Mapping
{
    public static class MapsterExtensions
    {
        public static IServiceCollection AddApplicationMapping(this IServiceCollection services)
        {
            var config = new TypeAdapterConfig();
            

            config.Scan(typeof(MapsterExtensions).Assembly);

            config.Default.PreserveReference(true);

            services.TryAddSingleton(config);
            services.TryAddSingleton<IMapper, ServiceMapper>();

            return services;
        }
    }
}