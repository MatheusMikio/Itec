using Application.Mapping;
using Domain.DTOs.Fatura;
using Domain.entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class FaturaService : BaseService<Fatura, FaturaResponse>, IFaturaService
    {
        public FaturaService(IFaturaRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}