using Domain.entities;
using Domain.Interfaces;
using InfraStructure.Context;
using InfraStructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositories
{
    public class TecnicoRepository : BaseRepository<Tecnico>, ITecnicoRepository
    {
        public TecnicoRepository(ItecDbContext context) : base(context)
        {
        }

        public async Task<Tecnico> GetById(Guid id) => await _context.Set<Tecnico>().FirstOrDefaultAsync(t => t.PublicId == id);
    }
}
