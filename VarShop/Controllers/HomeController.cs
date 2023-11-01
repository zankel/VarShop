using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VarShop.Models;
using VarShop.Repository;

namespace VarShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProdutoRepository _produtoRepository;


        public HomeController(ILogger<HomeController> logger, ProdutoRepository produtoRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
        }

        public IActionResult Index()
        {
            var produtos = _produtoRepository.ObterProdutosComVendedores();
            return View(produtos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}