using System.ComponentModel.DataAnnotations.Schema;

namespace VarShop.Models.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
