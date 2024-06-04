using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Costo
    {
        public int ID { get; set; }
        public Cuenta CodigoCuenta { get; set; }
        public SubCuenta CodigoSubCuenta { get; set; }
        public string DescripcionCuenta { get; set; }
        public string Tipo { get; set; }
        public string Asignacion { get; set; }
        public DateTime FechaCosto { get; set; }
        public decimal Importe { get; set; }

    }
}
