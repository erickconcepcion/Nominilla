using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Nominilla.Data
{
    public class AsientoContable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Descripcion { get; set; }

        public string Cuenta { get; set; }

        public int IdEntradaContable { get; set; }

        public bool IsCredit { get; set; } = false;

        [Required]
        [Range(1, double.MaxValue)]
        public decimal Monto { get; set; } = 1;

        public DateTime FechaAsiento { get; set; }
        public bool Estado { get; set; }

        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
    }
}
