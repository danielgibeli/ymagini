using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ymagi.Models;

namespace Ymagi.Services
{
    public class OscService
    {
        private readonly YmagiContext _context;

        public OscService(YmagiContext context)
        {
            _context = context;
        }

        public async Task<List<Osc>> FindAllAsync()
        {
            return await _context.Osc.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
