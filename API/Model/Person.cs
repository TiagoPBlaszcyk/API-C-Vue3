using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Model.Base;

namespace API.Model
{
    [Table("Persons")]
    public class Person : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column("senha")]
        [Required]
        [Range(1, 20)]
        public string Senha { get; set; }       

        [Column("email")]
        [StringLength(300)]
        public string? Email { get; set; }
        
        public int? PermissaoId {get; set; }
        [ForeignKey("PermissaoId")]
        public virtual Permission IdPermission { get; set; }

        [Column("cpf")]
        [StringLength(20)]
        public string? Cpf { get; set; }

        [Column("whats-app")]
        [Range(1, 20)]
        public decimal? WhatsApp { get; set; }

        [Column("image_url")]
        [StringLength(300)]
        public string? ImageUrl { get; set; }

    }
}
