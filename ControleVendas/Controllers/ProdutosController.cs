using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControleVendas.Models;

namespace ControleVendas.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutoDao produtoDao = new ProdutoDao();
        public IActionResult ProdutoCadastro()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProdutoCadastro([Bind("Codigo, Nome, PrecoUnit, Quantidade")] ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await produtoDao.setProduto(produto);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Não foi possivel inserir dados." + e.Message);
            }
            return View(produto);
        }
        public async Task<IActionResult> Index()
        {
            return View(produtoDao.getProduto());
        }
    }
}
