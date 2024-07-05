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
        public List<OrdenDeTrabajo> ListarOrdenes()
        {
            List<OrdenDeTrabajo> lista = new List<OrdenDeTrabajo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT o.ID,o.FechaCreacion,o.IdCliente,o.IdVehiculo,o.HorasTeoricas,o.HorasReales,o.FechaFinalizacion,o.IdEmpleado,u.Apellido as Mecanico,o.Observaciones,o.Total,o.Cobrado,o.CreadoPor,c.Apellido as Cliente,v.NombreVehiculo,o.Estado,eo.NombreEstado,v.ID FROM OrdenDeTrabajo o INNER JOIN Clientes c ON o.IdCliente=c.ID INNER JOIN Vehiculos v ON c.ID=v.IdCliente INNER JOIN EstadoOrden eo ON o.Estado=eo.ID INNER JOIN Usuarios u ON o.IdEmpleado=u.ID");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    OrdenDeTrabajo aux = new OrdenDeTrabajo();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.FechaCreacion = DateTime.Parse(datos.Lector["FechaCreacion"].ToString());

                    aux.Cliente = new Cliente();
                    aux.Cliente.ID = (int)datos.Lector["IdCliente"];
                    aux.Cliente.Apellido = (string)datos.Lector["Cliente"];

                    aux.Vehiculo = new Vehiculo();
                    aux.Vehiculo.IDVehiculo = (int)datos.Lector["ID"];
                    aux.Vehiculo.Patente = (string)datos.Lector["NombreVehiculo"];

                    aux.HorasTeoricas = (int)datos.Lector["HorasTeoricas"];
                    aux.HorasReales = (int)datos.Lector["HorasReales"];
                    aux.FechaFinalizacion = DateTime.Parse(datos.Lector["FechaFinalizacion"].ToString());
                    aux.Observaciones = (string)datos.Lector["Observaciones"];
                    aux.Total = (decimal)datos.Lector["Total"];
                    aux.Cobrado = (bool)datos.Lector["Cobrado"];

                    aux.Estado = new EstadoOrden();
                    aux.Estado.ID = (int)datos.Lector["Estado"];
                    aux.Estado.NombreEstado = (string)datos.Lector["NombreEstado"];

                    aux.Mecanico = new Usuario();
                    aux.Mecanico.ID = (int)datos.Lector["IdEmpleado"];
                    aux.Mecanico.Apellido = (string)datos.Lector["Mecanico"];

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
                    aux.NombreEstado = (string)datos.Lector["NombreEstado"];


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

        public void ModificarOrden(OrdenDeTrabajo orden)
        {
            AccesoDatos1 datos = new AccesoDatos1();

            try
            {
                datos.abrirConexion();
                int Id = orden.ID;
                datos.setearConsulta("UPDATE OrdenDeTrabajo SET HorasTeoricas=@HorasTeoricas,HorasReales=@HorasReales,FechaFinalizacion=@FechaFinalizacion,Observaciones=@Observaciones,Total=@Total,Cobrado=@Cobrado,IdEmpleado=@IdEmpleado,Estado=@Estado,CreadoPor=@CreadoPor where ID = "+ Id);
                //datos.setearParametro("@ID", orden.ID);
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
                datos.cerrarConexion();

                // Delete existing services for the order
                datos.abrirConexion();
                datos.setearConsulta("DELETE FROM OrdenServicio WHERE IdOrden = @IdOrden");
                datos.setearParametro("@IdOrden", orden.ID);
                datos.ejecutar();
                datos.cerrarConexion();

                // Insert each service associated with the order
                foreach (Servicio item in orden.Servicios)
                {
                    datos.abrirConexion();
                    datos.setearConsulta("INSERT INTO OrdenServicio (IdOrden, IdServicio) VALUES (@IdOrden, @IdServicio)");
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
    }
}
