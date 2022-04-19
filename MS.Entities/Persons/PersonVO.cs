namespace MS.Entities.Person
{
    public class PersonVO
    {
        public string Name { get; set; }
        public string Senha { get; set; }
        public string? Email { get; set; }
        public int? PermissaoId { get; set; }
        public string? Cpf { get; set; }
        public decimal? WhatsApp { get; set; }
        public string? ImageUrl { get; set; }

    }
}
