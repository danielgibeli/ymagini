using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ymagi.Models;
using Ymagi.Services.Exception;

namespace Ymagi.Services
{
    public class MembroService
    {
        private readonly YmagiContext _context;

        public MembroService(YmagiContext context)
        {
            _context = context;
        }

        public async Task<List<Membro>> FindAllAsync()
        {
            return await _context.Membro.ToListAsync();
        }

        public async Task InsertAsync(Membro obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Membro> FindByIdAsync(int id)
        {
            return await _context.Membro.Include(obj => obj.Osc).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Membro.FindAsync(id);
                _context.Membro.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message  );
            }
        }

        public async Task UpdateAsync(Membro obj)
        {
            bool hasAny = await _context.Membro.AnyAsync(x => x.Id == obj.Id);
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