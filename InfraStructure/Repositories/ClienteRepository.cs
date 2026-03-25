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
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ItecDbContext context) : base(context)
        {
        }

        public async Task<Cliente> GetById(Guid id) => await _context.Set<Cliente>().FirstOrDefaultAsync(c => c.PublicId == id);
    }
}
