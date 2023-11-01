using Microsoft.AspNetCore.Mvc;
using VarShop.Models;
using VarShop.Repository;

namespace VarShop.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepository _produtoRepository;
        private readonly IWebHostEnvironment _env;


        public ProdutoController(ProdutoRepository produtoRepository, IWebHostEnvironment env)
        {
            _produtoRepository = produtoRepository;
            

        }

        [HttpGet("{id}")]
        public IActionResult MeuProdutoByID(long id)
        {
            var produto = _produtoRepository.FindByID(id);

            return View("~/Views/Vendedor/EditarProduto.cshtml", produto);

        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
