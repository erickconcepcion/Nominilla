using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Nominilla.Data
{
    public class RegistroTransaccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal Monto { get; set; } = 1;

        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }

        public int? TipoIngresoId { get; set; }
        public TipoIngreso TipoIngreso { get; set; }

        public int? TipoDeduccionId { get; set; }
        public TipoDeduccion TipoDeduccion { get; set; }
    }
}
