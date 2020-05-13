using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ymagi.Models;

namespace Ymagi.Services
{
    public class UsuarioService
    {
        private readonly YmagiContext _context;

        public UsuarioService(YmagiContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> FindAllAsync()
        {
            return await _context.Usuario.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
