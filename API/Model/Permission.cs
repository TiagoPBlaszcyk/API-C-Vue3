using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Model.Base;

namespace API.Model
{
    [Table("permission")]
    public class Permission : BaseEntity
    {
        [Column("permission")]
        [StringLength(150)]
        public string permission { get; }

    }
}
