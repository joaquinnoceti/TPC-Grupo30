﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Vehiculo
    {
        public int IDVehiculo { get; set; }
        public string NombreVehiculo { get; set; }
        public Marca Marca { get; set; }
        public Modelo Modelo { get; set; }
        public int Anio { get; set; }
        public string Patente { get; set; }
        public string TipoVehiculo { get; set; }
        public int IdCliente { get; set; }
        public bool Estado { get; set; }
    }
}
