using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace VarShop.Models.Context
{
    public class MySQLContext :DbContext
    {
        public MySQLContext()
        {

        }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Item_Carrinho> Itens_Carrinho { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>()
                .HasOne(cliente => cliente.Carrinho) // Propriedade de navegação em Cliente
                .WithOne(carrinho => carrinho.Cliente) // Propriedade de navegação em Carrinho
                .HasForeignKey<Carrinho>(carrinho => carrinho.ClienteId);
        }

    }
}
