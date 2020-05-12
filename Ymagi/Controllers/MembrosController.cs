using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ymagi.Models;

namespace Ymagi.Controllers
{
    public class MembrosController : Controller
    {
        private readonly YmagiContext _context;

        public MembrosController(YmagiContext context)
        {
            _context = context;
        }

        // GET: Membros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Membro.ToListAsync());
        }

        // GET: Membros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membro = await _context.Membro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membro == null)
            {
                return NotFound();
            }

            return View(membro);
        }

        // GET: Membros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Membros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Rg,Telefone,Email,Nascimento,Sexo,EstadoCivil,Filhos,DataCadastro,Cep,Rua,Numero,Complemento,Bairro,Cidade,Estado")] Membro membro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membro);
        }

        // GET: Membros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membro = await _context.Membro.FindAsync(id);
            if (membro == null)
            {
                return NotFound();
            }
            return View(membro);
        }

        // POST: Membros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Rg,Telefone,Email,Nascimento,Sexo,EstadoCivil,Filhos,DataCadastro,Cep,Rua,Numero,Complemento,Bairro,Cidade,Estado")] Membro membro)
        {
            if (id != membro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembroExists(membro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(membro);
        }

        // GET: Membros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membro = await _context.Membro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membro == null)
            {
                return NotFound();
            }

            return View(membro);
        }

        // POST: Membros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membro = await _context.Membro.FindAsync(id);
            _context.Membro.Remove(membro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembroExists(int id)
        {
            return _context.Membro.Any(e => e.Id == id);
        }
    }
}
