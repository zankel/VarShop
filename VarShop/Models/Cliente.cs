using System.ComponentModel.DataAnnotations;
using System.Numerics;
using VarShop.Models.Base;

namespace VarShop.Models
{
    public class Cliente : BaseEntity
    {
        [Required]
        [MaxLength(256)]
        public string Nome { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string CPF { get; set; }

        [Required]
        [StringLength(70)]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        public string Senha { get; set; }

        // Relacionamento um para muitos com Carrinho
        public Carrinho Carrinho { get; set; }

    }
}
