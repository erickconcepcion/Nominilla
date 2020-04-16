using Microsoft.EntityFrameworkCore.Migrations;

namespace Nominilla.Migrations
{
    public partial class contable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEntradaContable",
                table: "AsientoContables",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEntradaContable",
                table: "AsientoContables");
        }
    }
}
