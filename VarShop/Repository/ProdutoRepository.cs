using VarShop.Models.Context;
using VarShop.Models;
using VarShop.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace VarShop.Repository
{
    public class ProdutoRepository : GenericRepository<Produto>
    {
        private readonly MySQLContext _context;

        public ProdutoRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Produto> ObterProdutosComVendedores()
        {
            return _context.Produtos.Include(p => p.Vendedor).ToList();
        }

        public IEnumerable<Produto> FindByIdMyProducts(long id)
        {
            return _context.Produtos.Where(p => p.VendedorId == id).ToList();
        }

    }
}
