using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    senha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PermissaoId = table.Column<long>(type: "bigint", nullable: true),
                    cpf = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    whatsapp = table.Column<decimal>(name: "whats-app", type: "decimal(65,30)", nullable: true),
                    image_url = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.id);
                    table.ForeignKey(
                        name: "FK_Persons_Permission_PermissaoId",
                        column: x => x.PermissaoId,
                        principalTable: "Permission",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "id", "descricao" },
                values: new object[] { 1L, "Administrador" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "id", "descricao" },
                values: new object[] { 2L, "Convidado" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "id", "cpf", "email", "image_url", "name", "PermissaoId", "senha", "whats-app" },
                values: new object[] { 1L, "11122233344", "admin@admin.com.br", "http://google.com.br", "admin", 1L, "admin", 11233445566m });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "id", "cpf", "email", "image_url", "name", "PermissaoId", "senha", "whats-app" },
                values: new object[] { 2L, "22233344455", "convidado@convidado.com.br", "http://bing.com.br", "convidado", 2L, "convidado", 22233445566m });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PermissaoId",
                table: "Persons",
                column: "PermissaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Permission");
        }
    }
}
