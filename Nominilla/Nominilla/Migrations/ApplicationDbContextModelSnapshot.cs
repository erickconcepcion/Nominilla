﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nominilla.Data;

namespace Nominilla.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nominilla.Data.AsientoContable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cuenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaAsiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEntradaContable")
                        .HasColumnType("int");

                    b.Property<bool>("IsCredit")
                        .HasColumnType("bit");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("AsientoContables");
                });

            modelBuilder.Entity("Nominilla.Data.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<decimal>("SalarioMensual")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Nominilla.Data.RegistroTransaccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TipoDeduccionId")
                        .HasColumnType("int");

                    b.Property<int?>("TipoIngresoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("TipoDeduccionId");

                    b.HasIndex("TipoIngresoId");

                    b.ToTable("RegistroTransaccions");
                });

            modelBuilder.Entity("Nominilla.Data.TipoDeduccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<decimal?>("MontoFijo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal?>("PorcentajeSalario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TipoDeduccions");
                });

            modelBuilder.Entity("Nominilla.Data.TipoIngreso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<decimal?>("MontoFijo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal?>("PorcentajeSalario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TipoIngresos");
                });

            modelBuilder.Entity("Nominilla.Data.AsientoContable", b =>
                {
                    b.HasOne("Nominilla.Data.Empleado", "Empleado")
                        .WithMany("AsientoContables")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Nominilla.Data.RegistroTransaccion", b =>
                {
                    b.HasOne("Nominilla.Data.Empleado", "Empleado")
                        .WithMany("RegistroTransaccions")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nominilla.Data.TipoDeduccion", "TipoDeduccion")
                        .WithMany("RegistroTransaccions")
                        .HasForeignKey("TipoDeduccionId");

                    b.HasOne("Nominilla.Data.TipoIngreso", "TipoIngreso")
                        .WithMany("RegistroTransaccions")
                        .HasForeignKey("TipoIngresoId");
                });
#pragma warning restore 612, 618
        }
    }
}
