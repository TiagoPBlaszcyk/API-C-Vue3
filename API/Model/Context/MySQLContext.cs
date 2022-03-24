using Microsoft.EntityFrameworkCore;

namespace API.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Events> Events { get; set; }


        // Adiciona uma base minima para login como permissoes de Administrador e Convidado
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>().HasData(new Permission
            {
                Id = 1,
                Descricao = "Administrador"
            });
            modelBuilder.Entity<Permission>().HasData(new Permission
            {
                Id = 2,
                Descricao = "Usuário"
            });
            modelBuilder.Entity<Permission>().HasData(new Permission
            {
                Id = 3,
                Descricao = "Convidado"
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                Id = 1,
                Name = "admin",
                Email = "admin@admin.com.br",
                Senha = "admin",
                Cpf = "11122233344",
                PermissaoId = 1,
                WhatsApp = 11233445566,
                ImageUrl = "http://google.com.br"
            });
        }
    }
}
