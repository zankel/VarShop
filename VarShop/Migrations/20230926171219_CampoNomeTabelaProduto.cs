using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VarShop.Migrations
{
    public partial class CampoNomeTabelaProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Produtos",
                type: "varchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Produtos");
        }
    }
}
