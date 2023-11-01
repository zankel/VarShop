using Microsoft.AspNetCore.Mvc;
using VarShop.Models;
using VarShop.Repository;

namespace VarShop.Controllers
{
    public class VendedorController : Controller
    {
        private readonly ProdutoRepository _produtoRepository;
        private readonly IWebHostEnvironment _env;


        public VendedorController(ProdutoRepository produtoRepository, IWebHostEnvironment env)
        {
            _produtoRepository = produtoRepository;
            _env = env;

        }

        public IActionResult AdicionarProduto()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            var produto = new Produto
            {
                VendedorId = userId.HasValue ? userId.Value : 0,
            };

            return View(produto);
        }

        public IActionResult MeusProdutos()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            long userIDLong = userId.Value;
            var produtos = _produtoRepository.FindByIdMyProducts(userIDLong);
            if (produtos != null)
            {
                return View(produtos);
            }
            else
            {
                return RedirectToAction("NenhumProdutoEncontrado");
            }          
        }

        public IActionResult ExcluirProduto(long id)
        {
            _produtoRepository.Delete(id);
                   
            return RedirectToAction("MeusProdutos");
        }
        [HttpPost]
        public IActionResult EditarProduto(Produto produto)
        {
            // Verifique se há uma nova imagem selecionada
            if (produto.Imagem != null && produto.Imagem.Length > 0)
            {
                // Verifique o tipo do arquivo se necessário
                if (!produto.Imagem.ContentType.StartsWith("image/"))
                {
                    ModelState.AddModelError("Imagem", "O arquivo deve ser uma imagem.");
                    return View(produto);
                }

                // Defina o caminho onde a imagem será salva no servidor
                var caminhoImagem = Path.Combine(_env.WebRootPath, "img", produto.Imagem.FileName);

                // Salve o arquivo no servidor
                using (var stream = new FileStream(caminhoImagem, FileMode.Create))
                {
                    produto.Imagem.CopyTo(stream);
                }

                // Defina o caminho da imagem no modelo
                produto.ImageURL = "/img/" + produto.Imagem.FileName;
            }
            else
            {
                // Se nenhuma nova imagem for selecionada, mantenha a imagem existente
                Produto produtoExistente = _produtoRepository.FindByID(produto.Id);
                produto.ImageURL = produtoExistente.ImageURL;
            }

            _produtoRepository.Update(produto);

            return RedirectToAction("MeusProdutos");
        }

        public IActionResult SalvarProduto(Produto produto)
        {
            if (produto.Imagem != null && produto.Imagem.Length > 0)
            {
                // Verifique o tipo do arquivo se necessário
                if (!produto.Imagem.ContentType.StartsWith("image/"))
                {
                    ModelState.AddModelError("Imagem", "O arquivo deve ser uma imagem.");
                    return View(produto);
                }

                // Defina o caminho onde a imagem será salva no servidor
                var caminhoImagem = Path.Combine(_env.WebRootPath, "img", produto.Imagem.FileName);

                // Salve o arquivo no servidor
                using (var stream = new FileStream(caminhoImagem, FileMode.Create))
                {
                    produto.Imagem.CopyTo(stream);
                }

                // Defina o caminho da imagem no modelo
                produto.ImageURL = "/img/" + produto.Imagem.FileName;
            }

            _produtoRepository.Create(produto);
 
            return RedirectToAction("Index", "Home");
        }
    }
}
