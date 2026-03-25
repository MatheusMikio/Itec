using Domain.entities;
using Domain.Interfaces;
using InfraStructure.Context;
using InfraStructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositories
{
    public class FaturaRepository : BaseRepository<Fatura>, IFaturaRepository
    {
        public FaturaRepository(ItecDbContext context) : base(context)
        {
        }
    }
}
