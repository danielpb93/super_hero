using backend.DatabaseContext;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Repository
{
    public interface ISuperpoderRepository
    {
        IQueryable<Superpoder> Get();
    }
    public class SuperpoderRepository : ISuperpoderRepository
    {
        private readonly ApplicationDbContext _context;

        public SuperpoderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Superpoder> Get() => _context.Superpoderes.AsNoTracking();
    }
}
