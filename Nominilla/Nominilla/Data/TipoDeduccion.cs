using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Nominilla.Data
{
    public class TipoDeduccion
    {
        public TipoDeduccion()
        {
            RegistroTransaccions = new HashSet<RegistroTransaccion>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Nombre { get; set; }


        [Range(0.01, 100)]
        public decimal? PorcentajeSalario { get; set; }
        public bool Estado { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? MontoFijo { get; set; }

        public ICollection<RegistroTransaccion> RegistroTransaccions { get; set; }
    }
}
