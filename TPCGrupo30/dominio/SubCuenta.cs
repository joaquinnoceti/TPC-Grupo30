using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class SubCuenta
    {
        public int ID { get; set; }
        public string CodSubcuenta { get; set; }
        public string DescripcionSubCuenta { get; set; }
        public Cuenta CuentaPadre { get; set; }
    }
}
