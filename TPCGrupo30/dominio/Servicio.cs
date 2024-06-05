using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Servicio
    {
        public int ID { get; set; }
        public string NombreServicio { get; set; }
        public string Descripcion { get; set; } 
        public decimal Precio { get; set; } 
    }
}
