using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class HistorialOTNegocio
    {
        public List<HistorialModificacionesOT> ListarHistorial()
        {
            List<HistorialModificacionesOT> lista = new List<HistorialModificacionesOT>();
            AccesoDatos1 datos = new AccesoDatos1();

            try
            {
                datos.setearConsulta("Select * From HistorialModificacionesOT");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    HistorialModificacionesOT aux = new HistorialModificacionesOT();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.IDOrdenDeTrabajo = (int)datos.Lector["IDOrdenDeTrabajo"];
                    aux.FechaModificacion = DateTime.Parse(datos.Lector["FechaModificacion"].ToString());
                    aux.CampoModificado = (string)datos.Lector["CampoModificado"];
                    aux.ValorAnterior = (string)datos.Lector["ValorAnterior"];
                    aux.ValorNuevo = (string)datos.Lector["ValorNuevo"];
                    aux.ModificadoPor = (int)datos.Lector["ModificadoPor"];

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
        public List<HistorialModificacionesOT> ListarHistorialPorOT(OrdenDeTrabajo ot)
        {
            List<HistorialModificacionesOT> lista = new List<HistorialModificacionesOT>();
            AccesoDatos1 datos = new AccesoDatos1();

            try
            {
                datos.setearConsulta("Select * From HistorialModificacionesOT Where IDOrdenDeTrabajo = @OT");
                datos.setearParametro("@OT", ot.ID);
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    HistorialModificacionesOT aux = new HistorialModificacionesOT();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.IDOrdenDeTrabajo = (int)datos.Lector["IDOrdenDeTrabajo"];
                    aux.FechaModificacion = DateTime.Parse(datos.Lector["FechaModificacion"].ToString());
                    aux.CampoModificado = (string)datos.Lector["CampoModificado"];
                    aux.ValorAnterior = (string)datos.Lector["ValorAnterior"];
                    aux.ValorNuevo = (string)datos.Lector["ValorNuevo"];
                    aux.ModificadoPor = (int)datos.Lector["ModificadoPor"];

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
        public void RegistrarHistorial(HistorialModificacionesOT historial)
        {
            AccesoDatos1 datos = new AccesoDatos1();
            try
            {
                // Registrar historial y obtener el ID generado
                datos.abrirConexion();
                datos.setearConsulta(@"
                    INSERT INTO HistorialModificacionesOT(IDOrdenDeTrabajo, FechaModificacion, CampoModificado, ValorAnterior, ValorNuevo, ModificadoPor)
                    VALUES (@IDOrdenDeTrabajo, @FechaModificacion, @CampoModificado, @ValorAnterior, @ValorNuevo, @ModificadoPor);
                    SELECT SCOPE_IDENTITY();");
                datos.setearParametro("@IDOrdenDeTrabajo", historial.IDOrdenDeTrabajo);
                datos.setearParametro("@IdCliente", historial.FechaModificacion);
                datos.setearParametro("@IdVehiculo", historial.CampoModificado);
                datos.setearParametro("@HorasTeoricas", historial.ValorAnterior);
                datos.setearParametro("@HorasReales", historial.ValorNuevo);
                datos.setearParametro("@FechaFinalizacion", historial.ModificadoPor);

                datos.ejecutarConsulta();
                if (datos.Lector.Read())
                {
                    historial.ID = Convert.ToInt32(datos.Lector[0]);
                }
                else
                {
                    throw new Exception("No se pudo obtener el ID del nuevo historial de orden de trabajo.");
                }

                datos.Lector.Close();
                datos.cerrarConexion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
