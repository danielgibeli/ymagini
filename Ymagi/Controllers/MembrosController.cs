using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ymagi.Models;
using Ymagi.Models.ViewModels;
using Ymagi.Services;
using Ymagi.Services.Exception;

namespace Ymagi.Controllers
{
    public class MembrosController : Controller
    {
        private readonly YmagiContext _context;
        private readonly OscService _oscService;
        private readonly MembroService _membroService;

        public MembrosController(YmagiContext context, OscService oscService, MembroService membroService)
        {
            _context = context;
            _oscService = oscService;
            _membroService = membroService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _membroService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var oscs = await _oscService.FindAllAsync();
            var viewModel = new MembroViewModel { Oscs = oscs };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Membro membro)
        {
            if (!ModelState.IsValid)
            {
                var oscs = await _oscService.FindAllAsync();
                var viewModel = new MembroViewModel { Membro = membro, Oscs = oscs };
                return View(viewModel);
            }
            await _membroService.InsertAsync(membro);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _membroService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _membroService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _membroService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _membroService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Osc> oscs = await _oscService.FindAllAsync();
            MembroViewModel viewModel = new MembroViewModel { Membro = obj, Oscs = oscs };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Membro membro)
        {
            if (!ModelState.IsValid)
            {
                var oscs = await _oscService.FindAllAsync();
                var viewModel = new MembroViewModel { Membro = membro, Oscs = oscs };
                return View(viewModel);
            }
            if (id != membro.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _membroService.UpdateAsync(membro);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
            
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}