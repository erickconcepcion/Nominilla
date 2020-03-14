using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nominilla.Data
{
    public class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Nominilla;Integrated Security=True");
        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<TipoDeduccion> TipoDeduccions { get; set; }
        public DbSet<TipoIngreso> TipoIngresos { get; set; }
        public DbSet<RegistroTransaccion> RegistroTransaccions { get; set; }
        public DbSet<AsientoContable> AsientoContables { get; set; }
    }
}
