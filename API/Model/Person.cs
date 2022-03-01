using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Model.Base;

namespace API.Model
{
    [Table("person")]
    public class Person : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column("whats-app")]
        [Required]
        [Range(1, 50)]
        public decimal WhatsApp { get; set; }

        [Column("email")]
        [StringLength(300)]
        public string? Email { get; set; }

        [Column("cpf")]
        [StringLength(50)]
        public string? Cpf { get; set; }

        [Column("image_url")]
        [StringLength(300)]
        public string? ImageUrl { get; set; }

    }
}
