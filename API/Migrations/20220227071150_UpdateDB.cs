using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "image_url",
                table: "product",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "product",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "category_name",
                table: "product",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "image_url",
                keyValue: null,
                column: "image_url",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "image_url",
                table: "product",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "description",
                keyValue: null,
                column: "description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "product",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "category_name",
                keyValue: null,
                column: "category_name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "category_name",
                table: "product",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
    }
}
