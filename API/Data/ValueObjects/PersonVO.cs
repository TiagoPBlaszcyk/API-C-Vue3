using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Model;

namespace API.Data.ValueObjects
{
    public class PersonVO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Senha { get; set; }
        public string? Email { get; set; }
        public Permission Permissao { get; set; }
        public string? Cpf { get; set; }
        public decimal? WhatsApp { get; set; }
        public string? ImageUrl { get; set; }

    }
}
