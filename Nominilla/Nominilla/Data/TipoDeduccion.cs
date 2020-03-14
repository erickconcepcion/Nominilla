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
        public string Nombre { get; set; }
        public decimal? PorcentajeSalario { get; set; }
        public bool Estado { get; set; }
        public decimal? MontoFijo { get; set; }

        public ICollection<RegistroTransaccion> RegistroTransaccions { get; set; }
    }
}
