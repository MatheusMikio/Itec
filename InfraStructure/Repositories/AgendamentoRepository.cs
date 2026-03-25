using Domain.entities;
using Domain.Interfaces;
using InfraStructure.Context;
using InfraStructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositories
{
    public class AgendamentoRepository : BaseRepository<Agendamento>, IAgendamentoRepository
    {
        public AgendamentoRepository(ItecDbContext context) : base(context)
        {
        }
    }
}
