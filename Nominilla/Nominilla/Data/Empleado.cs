using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Nominilla.Data
{
    public class Empleado
    {
        public Empleado()
        {
            RegistroTransaccions = new HashSet<RegistroTransaccion>();
            AsientoContables = new HashSet<AsientoContable>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Cedula { get; set; }
        public decimal SalarioMensual { get; set; }
        public ICollection<RegistroTransaccion> RegistroTransaccions { get; set; }
        public ICollection<AsientoContable> AsientoContables { get; set; }

    }
}
