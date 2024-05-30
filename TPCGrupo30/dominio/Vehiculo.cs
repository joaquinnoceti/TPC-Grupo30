using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Vehiculo
    {
        public string marca { get; set; }
        public string modelo { get; set; }
        public int anio { get; set; }
        public string patente { get; set; }
        public string tipoVehiculo { get; set; }
        Cliente cliente { get; set; }
    }
}
