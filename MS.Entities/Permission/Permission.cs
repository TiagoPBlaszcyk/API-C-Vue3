using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MS.Entities.Base;

namespace MS.Entities.Permission
{
    [Table("Permission")]
    public class Permission : BaseEntity
    {
        [Column("descricao")]
        [StringLength(150)]
        public string Descricao { get; set; }

    }
}
