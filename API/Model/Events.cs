using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Model.Base;

namespace API.Model
{
    [Table("Events")]
    public class Events : BaseEntity
    {
        [Column("name")]
        [StringLength(150)]
        public string? Name { get; set; }

        [Column("category")]
        [StringLength(150)]
        public string? Category { get; set; }       

        [Column("date")]
        [Range(1, 20)]
        public string? Date { get; set; }

        [Column("state")]
        [StringLength(20)]
        public string? State { get; set; }

        public int? PersonId {get; set; }
        [ForeignKey("PersonId")]
        public virtual Person id { get; set; }
    }
}