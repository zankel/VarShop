using System.ComponentModel.DataAnnotations;
using VarShop.Models.Base;

namespace VarShop.Models
{
    public class Vendedor : BaseEntity
    {

        [Required]
        [MaxLength(256)]
        public string Razao_Social { get; set; }

        [Required]
        [MaxLength(70)]
        public string Nome_Fantasia { get; set; }

        [Required]
        [StringLength(70)]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        public string Senha { get; set; }

        [Required]
        [StringLength(18)]
        public string CNPJ { get; set; }

        public int Comissao { get; set; }

        // Propriedade de navegação para os produtos do vendedor
        public ICollection<Produto> Produtos { get; set; }
    }
}
