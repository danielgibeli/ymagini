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
    public class OscsController : Controller
    {
        private readonly YmagiContext _context;

        public OscsController(YmagiContext context)
        {
            _context = context;
        }

        // GET: Oscs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Osc.ToListAsync());
        }

        // GET: Oscs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osc = await _context.Osc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (osc == null)
            {
                return NotFound();
            }

            return View(osc);
        }

        // GET: Oscs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oscs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Osc osc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(osc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(osc);
        }

        // GET: Oscs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osc = await _context.Osc.FindAsync(id);
            if (osc == null)
            {
                return NotFound();
            }
            return View(osc);
        }

        // POST: Oscs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Osc osc)
        {
            if (id != osc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(osc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OscExists(osc.Id))
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
            return View(osc);
        }

        // GET: Oscs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osc = await _context.Osc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (osc == null)
            {
                return NotFound();
            }

            return View(osc);
        }

        // POST: Oscs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var osc = await _context.Osc.FindAsync(id);
            _context.Osc.Remove(osc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OscExists(int id)
        {
            return _context.Osc.Any(e => e.Id == id);
        }
    }
}
