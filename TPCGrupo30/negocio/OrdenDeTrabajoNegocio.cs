using dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class OrdenDeTrabajoNegocio
    {

        public void GuardarOrden(OrdenDeTrabajo orden)
        {
            AccesoDatos1 datos = new AccesoDatos1();

            try
            {
                // Insertar la orden de trabajo y obtener el ID generado
                datos.abrirConexion();
                datos.setearConsulta(@"
            INSERT INTO OrdenDeTrabajo(FechaCreacion, IdCliente, IdVehiculo, HorasTeoricas, HorasReales, FechaFinalizacion, Observaciones, Total, Cobrado, IdEmpleado, Estado, CreadoPor)
            VALUES (@FechaCreacion, @IdCliente, @IdVehiculo, @HorasTeoricas, @HorasReales, @FechaFinalizacion, @Observaciones, @Total, @Cobrado, @IdEmpleado, @Estado, @CreadoPor);
            SELECT SCOPE_IDENTITY();
        ");
                datos.setearParametro("@FechaCreacion", orden.FechaCreacion);
                datos.setearParametro("@IdCliente", orden.Cliente.ID);
                datos.setearParametro("@IdVehiculo", orden.Vehiculo.IDVehiculo);
                datos.setearParametro("@HorasTeoricas", orden.HorasTeoricas);
                datos.setearParametro("@HorasReales", orden.HorasReales);
                datos.setearParametro("@FechaFinalizacion", orden.FechaFinalizacion);
                datos.setearParametro("@Observaciones", orden.Observaciones);
                datos.setearParametro("@Total", orden.Total);
                datos.setearParametro("@Cobrado", orden.Cobrado);
                datos.setearParametro("@IdEmpleado", orden.Mecanico.ID);
                datos.setearParametro("@Estado", orden.Estado.ID);
                datos.setearParametro("@CreadoPor", orden.Mecanico.ID);

                datos.ejecutarConsulta();
                if (datos.Lector.Read())
                {
                    orden.ID = Convert.ToInt32(datos.Lector[0]);
                }
                else
                {
                    throw new Exception("No se pudo obtener el ID de la nueva orden de trabajo.");
                }

                datos.Lector.Close();
                datos.cerrarConexion();

                // Insertar cada servicio asociado en la tabla intermedia
                foreach (Servicio item in orden.Servicios)
                {
                    datos.abrirConexion();
                    datos.setearConsulta("INSERT INTO OrdenServicio(IdOrden, IdServicio) VALUES(@IdOrden, @IdServicio)");
                    datos.setearParametro("@IdOrden", orden.ID);
                    datos.setearParametro("@IdServicio", item.ID);

                    datos.ejecutar();
                    datos.cerrarConexion();
                }
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
                datos.setearConsulta("SELECT ID,NombreEstado FROM EstadoOrden");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    EstadoOrden aux = new EstadoOrden();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.NombreEstado= (string)datos.Lector["NombreEstado"];


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
