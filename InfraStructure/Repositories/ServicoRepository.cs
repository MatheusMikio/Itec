using Domain.entities;
using Domain.Interfaces;
using InfraStructure.Context;
using InfraStructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositories
{
    public class ServicoRepository : BaseRepository<Servico>, IServicoRepository
    {
        public ServicoRepository(ItecDbContext context) : base(context)
        {
        }
    }
}