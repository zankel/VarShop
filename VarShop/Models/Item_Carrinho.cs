using System.ComponentModel.DataAnnotations;

namespace VarShop.Models
{
    public class Item_Carrinho
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(45)]
        public string Quantidade { get; set; }
        
        [Required]
        [RegularExpression(@"^\d{1,5}(\.\d{2})?$")]
        public string Total { get; set; }

        // Relacionamento muitos para um com Produto
        public long ProdutoId { get; set; }
        public Produto Produto { get; set; }

        // Relacionamento muitos para um com Carrinho
        public long CarrinhoId { get; set; }
        public Carrinho Carrinho { get; set; }

    }
}
