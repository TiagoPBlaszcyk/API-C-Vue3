using Microsoft.EntityFrameworkCore;

namespace API.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Camisa",
                Price = new decimal(69.9),
                Description = "Camisa",
                ImageUrl = "https://previews.123rf.com/images/happyjob/happyjob1608/happyjob160800122/62039034-.jpg",
                CategoryName = "T-Shirt"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Camisa",
                Price = new decimal(69.9),
                Description = "Camisa",
                ImageUrl = "https://previews.123rf.com/images/happyjob/happyjob1608/happyjob160800122/62039034-.jpg",
                CategoryName = "T-Shirt"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Camisa",
                Price = new decimal(69.9),
                Description = "Camisa",
                ImageUrl = "https://previews.123rf.com/images/happyjob/happyjob1608/happyjob160800122/62039034-.jpg",
                CategoryName = "T-Shirt"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Camisa",
                Price = new decimal(69.9),
                Description = "Camisa",
                ImageUrl = "https://previews.123rf.com/images/happyjob/happyjob1608/happyjob160800122/62039034-.jpg",
                CategoryName = "T-Shirt"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Name = "Camisa",
                Price = new decimal(69.9),
                Description = "Camisa",
                ImageUrl = "https://previews.123rf.com/images/happyjob/happyjob1608/happyjob160800122/62039034-.jpg",
                CategoryName = "T-Shirt"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 8,
                Name = "Camisa",
                Price = new decimal(69.9),
                Description = "Camisa",
                ImageUrl = "https://previews.123rf.com/images/happyjob/happyjob1608/happyjob160800122/62039034-.jpg",
                CategoryName = "T-Shirt"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 9,
                Name = "Camisa",
                Price = new decimal(69.9),
                Description = "Camisa",
                ImageUrl = "https://previews.123rf.com/images/happyjob/happyjob1608/happyjob160800122/62039034-.jpg",
                CategoryName = "T-Shirt"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 10,
                Name = "Camisa",
                Price = new decimal(69.9),
                Description = "Camisa",
                ImageUrl = "https://previews.123rf.com/images/happyjob/happyjob1608/happyjob160800122/62039034-.jpg",
                CategoryName = "T-Shirt"
            });
        }
    }
}
