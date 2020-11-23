using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControleVendas.Models;

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
                    await clienteDao.setCliente(cliente);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Não foi possivel inserir dados." + e.Message);
            }
            return View(cliente);
        }
        public async Task<IActionResult> Index()
        {
            return View(clienteDao.getCliente());
        }
    }
}
