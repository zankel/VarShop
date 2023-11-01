using VarShop.Models.Context;
using VarShop.Models;
using VarShop.Repository.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace VarShop.Repository
{
    public class ClienteRepository : GenericRepository<Cliente>
    {
        private readonly MySQLContext _context;

        public ClienteRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public Cliente Authenticate(string nome, string senha)
        {
            // Tente encontrar um vendedor com o nome e senha fornecidos no banco de dados.
            // Isso pode variar dependendo de como você está armazenando senhas e configurando sua autenticação.
            // Este é um exemplo simples usando LINQ para encontrar um vendedor com base no nome.
            // Lembre-se de adicionar tratamento adequado de senha, como hash e comparação segura.

            return _context.Clientes.FirstOrDefault(v => v.Nome == nome && v.Senha == senha);
        }

    }
}
