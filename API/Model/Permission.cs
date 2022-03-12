using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Model.Base;

namespace API.Model
{
    [Table("Permission")]
    public class Permission : BaseEntity
    {
        [Column("descricao")]
        [StringLength(150)]
        public string Descricao { get; set; }

    }
}
