using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class OrdenDeTrabajo
    {
        public int ID { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Cliente Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public List<Servicio> Servicios { get; set; }
        public OrdenDeTrabajo()
        {
            Servicios = new List<Servicio>();
        }
        public int HorasTeoricas { get; set; }      
        public int HorasReales { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public string Observaciones { get; set; }
        public decimal Total { get; set; }
        public bool Cobrado { get; set; }
        public Usuario Mecanico { get; set; }
        public EstadoOrden Estado { get; set; }
        public string CreadoPor { get; set; }

    }

}
