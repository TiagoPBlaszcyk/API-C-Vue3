using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.ValueObjects
{
    public class LoginVO
    {
        public string Name { get; set; }
        public string Senha { get; set; }
    }
}
