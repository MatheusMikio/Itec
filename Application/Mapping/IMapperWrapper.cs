using Mapster;

namespace Application.Mapping
{
    public interface IMapper
    {
        TDestination Map<TDestination>(object ? source);
    }

    public class ServiceMapper : IMapper
    {
        private readonly TypeAdapterConfig _config;

        public ServiceMapper(TypeAdapterConfig config)
        {
            _config = config;
        }

        public TDestination Map<TDestination>(object ? source)
        {
            if (source == null) return default!;

            return source.Adapt<TDestination>(_config);
        }
    }
}