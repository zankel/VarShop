using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VarShop.Models;
using VarShop.Repository;

namespace VarShop.Controllers
{
    public class AccountController : Controller
    {

        private readonly VendedorRepository _vendedorRepository;
        private readonly ClienteRepository _clienteRepository;

        public AccountController(ClienteRepository clienteRepository, VendedorRepository vendedorRepository)
        {
            _clienteRepository = clienteRepository;
            _vendedorRepository = vendedorRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VendedorCadastro()
        {
            return View();
        }

        public IActionResult ClienteCadastro()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroVendedor(Vendedor vendedor)
        {

            _vendedorRepository.Create(vendedor);

            // Redirecione para a página de login ou para onde for apropriado
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult CadastroCliente(Cliente cliente)
        {

            _clienteRepository.Create(cliente);

            // Redirecione para a página de login ou para onde for apropriado
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(string userType, string Nome, string Senha)
        {
            if (userType == "Cliente")
            {
                // Consultar a tabela de clientes para autenticar o cliente
                var cliente = _clienteRepository.Authenticate(Nome, Senha);
                if (cliente != null)
                {
                    // Autenticação bem-sucedida para o cliente
                    // Realize as ações apropriadas, como definir cookies de autenticação, etc.
                    HttpContext.Session.SetString("UserType", "Cliente");
                    HttpContext.Session.SetInt32("UserId", (int)cliente.Id);
                    HttpContext.Session.SetString("UserName", cliente.Nome); 


                    return RedirectToAction("Index", "Home");
                }
            }
            else if (userType == "Vendedor")
            {
                // Consultar a tabela de vendedores para autenticar o vendedor
                var vendedor = _vendedorRepository.Authenticate(Nome, Senha);
                if (vendedor != null)
                {
                    // Autenticação bem-sucedida para o vendedor
                    // Realize as ações apropriadas, como definir cookies de autenticação, etc.

                    HttpContext.Session.SetString("UserType", "Vendedor");
                    HttpContext.Session.SetInt32("UserId", (int)vendedor.Id);
                    HttpContext.Session.SetString("UserName", vendedor.Nome_Fantasia); 

                    return RedirectToAction("Index", "Home");
                }
            }

            // Se a autenticação falhar, retorne a página de login com uma mensagem de erro
            ModelState.AddModelError(string.Empty, "Nome de usuário ou senha inválidos.");
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Limpa todos os dados da sessão
            return RedirectToAction("Index", "Home"); // Redireciona para a página de login
        }
    }
}
