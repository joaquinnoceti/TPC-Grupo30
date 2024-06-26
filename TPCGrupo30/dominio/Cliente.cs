﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int DNI { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNac { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }

    }

    public class ClientexVehiculo
    {
        public int IDCliente { get; set; }
        public int IDVehiculo { get; set; }
        public string NombreCli { get; set; }
        public string ApellidoCli { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Patente { get; set; }
    }


}
