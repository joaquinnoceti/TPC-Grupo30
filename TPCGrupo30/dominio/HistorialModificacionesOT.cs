using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class HistorialModificacionesOT
    {
        public int ID { get; set; }
        public int IDOrdenDeTrabajo { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Observacion { get; set; }
        public string ValorAnterior { get; set; }
        public string ValorNuevo { get; set; }
        public Usuario ModificadoPor { get; set; }
    }
}
