using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControleVendas.Models;
using ControleVendas.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleVendas.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClienteDao clienteDao = new ClienteDao();
        
        public IActionResult ClienteCadastro()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClienteCadastro([Bind("Cpf, Nome, Telefone, Endereco")] ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possivel inserir dados.");
            }
            return View(cliente);
        }
        ///De acordo com o PDF CRUD COMPLETO
        private readonly ControleVendasContext _context;

        public ClientesController(ControleVendasContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.OrderBy(a => a.Nome).ToListAsync());
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.SingleOrDefaultAsync(a => a.ClienteModelId == id);
            if(cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        
        public async Task<IActionResult> Edit(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.SingleOrDefaultAsync(a => a.ClienteModelId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id,[Bind("ClinteModelId, Cpf, Nome, Telefone, Endereco")] ClienteModel cliente)
        {
            if(id != cliente.ClienteModelId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteModelId))
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
            return View(cliente);
        }

        public bool ClienteExists(long? id)
        {
            return _context.Clientes.Any(a => a.ClienteModelId == id);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.SingleOrDefaultAsync(a => a.ClienteModelId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);   
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var cliente = await _context.Clientes.SingleOrDefaultAsync(a => a.ClienteModelId == id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
