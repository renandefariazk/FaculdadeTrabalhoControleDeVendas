using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControleVendas.Models;

namespace ControleVendas.Controllers
{
    public class VendasController : Controller
    {
        private readonly ClienteDao clienteDao = new ClienteDao();
        //GET: /<controller>/Cliente
        public IActionResult Cliente()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cliente([Bind("cli_cpf, cli_nome, cli_fone, cli_endereco")] ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await clienteDao.Set_Cliente(cliente);
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
            return View(clienteDao.Get_Cliente());
        }
    }
}
