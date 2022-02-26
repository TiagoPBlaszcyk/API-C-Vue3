using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class SeedProductDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { 3L, "T-Shirt", "Camisa", "https://previews.123rf.com/images/happyjob/happyjob1608/happyjob160800122/62039034-.jpg", "Camisa", 69.9m },
                    { 4L, "T-Shirt", "Camisa", "https://previews.123rf.com/images/happyjob/happyjob1608/happyjob160800122/62039034-.jpg", "Camisa", 69.9m },
                    { 5L, "T-Shirt", "Camisa", "https://previews.123rf.com/images/happyjob/happyjob1608/happyjob160800122/62039034-.jpg", "Camisa", 69.9m },
                    { 6L, "T-Shirt", "Camisa", "https://previews.123rf.com/images/happyjob/happyjob1608/happyjob160800122/62039034-.jpg", "Camisa", 69.9m },
                    { 7L, "T-Shirt", "Camisa", "https://previews.123rf.com/images/happyjob/happyjob1608/happyjob160800122/62039034-.jpg", "Camisa", 69.9m },
                    { 8L, "T-Shirt", "Camisa", "https://previews.123rf.com/images/happyjob/happyjob1608/happyjob160800122/62039034-.jpg", "Camisa", 69.9m },
                    { 9L, "T-Shirt", "Camisa", "https://previews.123rf.com/images/happyjob/happyjob1608/happyjob160800122/62039034-.jpg", "Camisa", 69.9m },
                    { 10L, "T-Shirt", "Camisa", "https://previews.123rf.com/images/happyjob/happyjob1608/happyjob160800122/62039034-.jpg", "Camisa", 69.9m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 10L);
        }
    }
}
