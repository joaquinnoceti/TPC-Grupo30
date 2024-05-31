using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{

    public enum Rol
    {
        ADMIN = 1,
        MECANICO = 2
    }
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Especialidad { get; set; }
        public string Categoria { get; set; }
        public string Contrasenia { get; set; }
        public Rol Rol { get; set; }
        public bool Estado { get; set; }
    }
}
