using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nominilla.Models
{
    public class Asiento
    {
        public int idEntradaContable { get; set; } = 0;
        public string descripcion { get; set; }
        public int idAuxiliar { get; set; } 
        public int idCuentasContables { get; set; }
        public decimal montoDebito { get; set; }
        public decimal montoCredito { get; set; }
        public int idSisAuxiliar { get; set; } = 8;
        public string fecha { get; set; } = "0001-01-01T00:00:00";
        public decimal monto { get; set; }
        public string estado { get; set; } = "Activo";
        public int idTiposMonedas { get; set; } = 2;

}
}
