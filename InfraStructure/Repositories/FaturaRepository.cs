using Domain.entities;
using Domain.Interfaces;
using InfraStructure.Context;
using InfraStructure.Repositories;

namespace Infra.Repositories
{
    public class FaturaRepository : BaseRepository<Fatura>, IFaturaRepository
    {
        public FaturaRepository(ItecDbContext context) : base(context)
        {
        }
    }
}