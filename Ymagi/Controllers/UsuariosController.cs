﻿using System;
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
    public class UsuariosController : Controller
    {
        private readonly YmagiContext _context;
        private readonly MembroService _membroService;
        private readonly UsuarioService _usuarioService;

        public UsuariosController(YmagiContext context, MembroService membroService, UsuarioService usuarioService)
        {
            _context = context;
            _membroService = membroService;
            _usuarioService = usuarioService;

        }

        public async Task<IActionResult> Index()
        {
            var list = await _usuarioService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var membros = await _membroService.FindAllAsync();
            var viewModel = new UserViewModel { Membros = membros };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                var membros = await _membroService.FindAllAsync();
                var viewModel = new UserViewModel { Usuario = usuario, Membros = membros };
                return View(viewModel);
            }
            await _usuarioService.InsertAsync(usuario);
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
                await _usuarioService.RemoveAsync(id);
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

            var obj = await _usuarioService.FindByIdAsync(id.Value);
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

            var obj = await _usuarioService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Membro> membros = await _membroService.FindAllAsync();
            UserViewModel viewModel = new UserViewModel { Usuario = obj, Membros = membros };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                var membro = await _membroService.FindAllAsync();
                var viewModel = new UserViewModel { Usuario = usuario, Membros = membro };
                return View(viewModel);
            }
            if (id != usuario.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _usuarioService.UpdateAsync(usuario);
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