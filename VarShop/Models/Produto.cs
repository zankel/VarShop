using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VarShop.Models.Base;

namespace VarShop.Models
{
    public class Produto : BaseEntity
    {
        [Required]
        [MaxLength(45)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(45)]
        public string Descricao { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,5}(\.\d{2})?$")]
        public string Preco { get; set; }

        [Required]
        [StringLength(200)]
        public string ImageURL { get; set; }

        [NotMapped] 
        public IFormFile Imagem { get; set; } 

        public bool Status { get; set; }

        public long VendedorId { get; set; }

        public Vendedor Vendedor { get; set; }

        public ICollection<Item_Carrinho> ItensCarrinho { get; set; }
    }
}
