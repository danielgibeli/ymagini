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
    public class RecebimentosController : Controller
    {
        private readonly YmagiContext _context;

        public RecebimentosController(YmagiContext context)
        {
            _context = context;
        }

        // GET: Recebimentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recebimento.ToListAsync());
        }

        // GET: Recebimentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recebimento = await _context.Recebimento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recebimento == null)
            {
                return NotFound();
            }

            return View(recebimento);
        }

        // GET: Recebimentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recebimentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,MembroId,FornecedorId,UsuarioId")] Recebimento recebimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recebimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recebimento);
        }

        // GET: Recebimentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recebimento = await _context.Recebimento.FindAsync(id);
            if (recebimento == null)
            {
                return NotFound();
            }
            return View(recebimento);
        }

        // POST: Recebimentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,MembroId,FornecedorId,UsuarioId")] Recebimento recebimento)
        {
            if (id != recebimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recebimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecebimentoExists(recebimento.Id))
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
            return View(recebimento);
        }

        // GET: Recebimentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recebimento = await _context.Recebimento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recebimento == null)
            {
                return NotFound();
            }

            return View(recebimento);
        }

        // POST: Recebimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recebimento = await _context.Recebimento.FindAsync(id);
            _context.Recebimento.Remove(recebimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecebimentoExists(int id)
        {
            return _context.Recebimento.Any(e => e.Id == id);
        }
    }
}
