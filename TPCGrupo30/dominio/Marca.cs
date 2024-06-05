using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Marca
    {
        public int ID { get; set; }
        public string NombreMarca { get; set; }
    }

    public class Modelo
    {
        public int ID { get; set; }

        public Marca Marca { get; set; }

        public string NombreModelo { get; set; }
    }
}
