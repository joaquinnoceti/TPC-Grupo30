using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class Empleado : Persona
    {
        public int legajo { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string nombreUsuario { get; set; }
    }
}
