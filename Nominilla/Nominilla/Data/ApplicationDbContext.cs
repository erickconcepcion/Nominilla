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
                "Server=tcp:nominilla.database.windows.net,1433;Initial Catalog=nominilladb;Persist Security Info=False;User ID=nominilla;Password=Abcd.1234;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<TipoDeduccion> TipoDeduccions { get; set; }
        public DbSet<TipoIngreso> TipoIngresos { get; set; }
        public DbSet<RegistroTransaccion> RegistroTransaccions { get; set; }
        public DbSet<AsientoContable> AsientoContables { get; set; }
    }
}
