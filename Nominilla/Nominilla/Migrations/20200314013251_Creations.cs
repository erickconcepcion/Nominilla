using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nominilla.Migrations
{
    public partial class Creations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    SalarioMensual = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeduccions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    PorcentajeSalario = table.Column<decimal>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    MontoFijo = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeduccions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoIngresos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    PorcentajeSalario = table.Column<decimal>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    MontoFijo = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIngresos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AsientoContables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false),
                    Cuenta = table.Column<string>(nullable: true),
                    IsCredit = table.Column<bool>(nullable: false),
                    FechaAsiento = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    EmpleadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsientoContables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AsientoContables_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistroTransaccions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    EmpleadoId = table.Column<int>(nullable: false),
                    TipoIngresoId = table.Column<int>(nullable: false),
                    TipoDeduccionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroTransaccions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroTransaccions_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroTransaccions_TipoDeduccions_TipoDeduccionId",
                        column: x => x.TipoDeduccionId,
                        principalTable: "TipoDeduccions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroTransaccions_TipoIngresos_TipoIngresoId",
                        column: x => x.TipoIngresoId,
                        principalTable: "TipoIngresos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsientoContables_EmpleadoId",
                table: "AsientoContables",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroTransaccions_EmpleadoId",
                table: "RegistroTransaccions",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroTransaccions_TipoDeduccionId",
                table: "RegistroTransaccions",
                column: "TipoDeduccionId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroTransaccions_TipoIngresoId",
                table: "RegistroTransaccions",
                column: "TipoIngresoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsientoContables");

            migrationBuilder.DropTable(
                name: "RegistroTransaccions");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "TipoDeduccions");

            migrationBuilder.DropTable(
                name: "TipoIngresos");
        }
    }
}
