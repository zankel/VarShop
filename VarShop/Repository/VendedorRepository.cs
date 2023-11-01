using System.Data;
using VarShop.Models;
using VarShop.Models.Context;
using VarShop.Repository.Generic;

namespace VarShop.Repository
{
    public class VendedorRepository : GenericRepository<Vendedor>
    {
        private readonly MySQLContext _context;
        public VendedorRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public Vendedor Authenticate(string nome, string senha)
        {
            // Tente encontrar um vendedor com o nome e senha fornecidos no banco de dados.
            // Isso pode variar dependendo de como você está armazenando senhas e configurando sua autenticação.
            // Este é um exemplo simples usando LINQ para encontrar um vendedor com base no nome.
            // Lembre-se de adicionar tratamento adequado de senha, como hash e comparação segura.

            return _context.Vendedores.FirstOrDefault(v => v.Nome_Fantasia == nome && v.Senha == senha);
        }
    }
}
