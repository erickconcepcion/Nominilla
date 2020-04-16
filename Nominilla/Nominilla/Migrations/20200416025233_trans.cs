using Microsoft.EntityFrameworkCore.Migrations;

namespace Nominilla.Migrations
{
    public partial class trans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroTransaccions_TipoDeduccions_TipoDeduccionId",
                table: "RegistroTransaccions");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroTransaccions_TipoIngresos_TipoIngresoId",
                table: "RegistroTransaccions");

            migrationBuilder.AlterColumn<int>(
                name: "TipoIngresoId",
                table: "RegistroTransaccions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDeduccionId",
                table: "RegistroTransaccions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroTransaccions_TipoDeduccions_TipoDeduccionId",
                table: "RegistroTransaccions",
                column: "TipoDeduccionId",
                principalTable: "TipoDeduccions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroTransaccions_TipoIngresos_TipoIngresoId",
                table: "RegistroTransaccions",
                column: "TipoIngresoId",
                principalTable: "TipoIngresos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroTransaccions_TipoDeduccions_TipoDeduccionId",
                table: "RegistroTransaccions");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroTransaccions_TipoIngresos_TipoIngresoId",
                table: "RegistroTransaccions");

            migrationBuilder.AlterColumn<int>(
                name: "TipoIngresoId",
                table: "RegistroTransaccions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TipoDeduccionId",
                table: "RegistroTransaccions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroTransaccions_TipoDeduccions_TipoDeduccionId",
                table: "RegistroTransaccions",
                column: "TipoDeduccionId",
                principalTable: "TipoDeduccions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroTransaccions_TipoIngresos_TipoIngresoId",
                table: "RegistroTransaccions",
                column: "TipoIngresoId",
                principalTable: "TipoIngresos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
