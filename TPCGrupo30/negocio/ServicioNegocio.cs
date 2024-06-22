using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ServicioNegocio
    {

        public List<Servicio> Listar()
        {
            List<Servicio> lista = new List<Servicio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT ID,NombreServicio,Descripcion,Precio FROM Servicios");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Servicio aux = new Servicio();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.NombreServicio = (string)datos.Lector["NombreServicio"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);

                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

