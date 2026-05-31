using Application.Contracts;
using Domain.Entities.Base;
using Infrastucture.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Persistance
{
    public class UnitOWork : IUnitOWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public DbContext Context => _context;

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
           return new GenericRepository<T>(_context);
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
