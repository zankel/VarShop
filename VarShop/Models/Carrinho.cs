using System.ComponentModel.DataAnnotations;
using VarShop.Models.Base;

namespace VarShop.Models
{
    public class Carrinho : BaseEntity
    {
        [Required]
        [MaxLength(256)]
        public DateTime Data_Pedido { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,5}(\.\d{2})?$")]
        public float Valor_Total { get; set; }

        // Chave estrangeira para o Cliente
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public ICollection<Item_Carrinho> ItensCarrinho { get; set; }

    }
}
