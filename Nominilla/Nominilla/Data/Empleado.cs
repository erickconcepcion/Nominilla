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

        [Required]
        [RegularExpression("^\\d{3}-\\d{7}-\\d{1}", ErrorMessage ="No es cedula valida")]
        public string Cedula { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 4)]
        public string Nombre { get; set; }

        [Range(1, double.MaxValue)]
        [Required]
        public decimal SalarioMensual { get; set; }
        public ICollection<RegistroTransaccion> RegistroTransaccions { get; set; }
        public ICollection<AsientoContable> AsientoContables { get; set; }

    }
}
