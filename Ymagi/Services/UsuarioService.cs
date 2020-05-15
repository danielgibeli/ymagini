using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ymagi.Models;
using Ymagi.Services.Exception;

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

        public async Task InsertAsync(Usuario obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> FindByIdAsync(int id)
        {
            return await _context.Usuario.Include(obj => obj.Membro).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Usuario.FindAsync(id);
                _context.Usuario.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Usuario obj)
        {
            bool hasAny = await _context.Usuario.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}   