using VarShop.Models.Context;
using VarShop.Models;
using VarShop.Repository.Generic;

namespace VarShop.Repository
{
    public class CarrinhoRepository : GenericRepository<Carrinho>
    {
        public CarrinhoRepository(MySQLContext context) : base(context)
        {

        }

    }
}
