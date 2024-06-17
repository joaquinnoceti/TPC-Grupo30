using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class OrdenDeTrabajoNegocio
    {
        
        public void GuardarOrden(OrdenDeTrabajoNegocio orden)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO OrdenDeTrabajo () VALUES ()");
                datos.setearParametro("@IdCliente", orden);

                datos.ejecutar();
                  
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



        public List<EstadoOrden> ListarEstados()
        {
            List<EstadoOrden> lista = new List<EstadoOrden>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT ID,Nombre FROM EstadoOrden");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    EstadoOrden aux = new EstadoOrden();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.NombreEstado= (string)datos.Lector["Nombre"];


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
