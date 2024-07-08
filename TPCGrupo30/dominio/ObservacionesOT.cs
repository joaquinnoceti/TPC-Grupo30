using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ObservacionesOT
    {
        public int ID { get; set; }
        public int IDOrdenDeTrabajo { get; set; }
        public DateTime FechaObservacion { get; set; }
        public string Observacion { get; set; }
        public int IDEmpleado { get; set; }
    }
}
