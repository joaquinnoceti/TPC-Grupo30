using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class VehiculoNegocio
    {

        public List<Vehiculo> ListarxID(string id)
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Marca,Modelo,Anio,Patente,TipoVehiculo from vehiculos v JOIN Clientes c on (V.IdCliente = c.ID) WHERE C.ID =" + int.Parse(id));
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Vehiculo aux = new Vehiculo();

                    aux.Marca = new Marca();
                    aux.Marca.NombreMarca = (string)datos.Lector["Marca"];
                    aux.Modelo = new Modelo();
                    aux.Modelo.NombreModelo = (string)datos.Lector["Modelo"];


                    aux.Anio = (int)datos.Lector["Anio"];
                    aux.Patente = (string)datos.Lector["Patente"];
                    aux.TipoVehiculo = (string)datos.Lector["TipoVehiculo"];

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


        public List<Vehiculo> Listar()
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT v.ID,v.NombreVehiculo, m.ID as Marca, m.NombreMarca,mo.ID as Modelo, mo.NombreModelo,v.Anio,v.Patente,v.TipoVehiculo,v.IdCliente, c.Apellido FROM Vehiculos v, Clientes c, Marcas m, Modelos mo WHERE v.IdCliente=c.ID and v.Marca=m.ID and v.Modelo=mo.ID");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {

                    Vehiculo aux = new Vehiculo();

                    aux.IDVehiculo = (int)datos.Lector["ID"];
                    aux.NombreVehiculo = (string)datos.Lector["NombreVehiculo"];

                    aux.Marca = new Marca();
                    aux.Marca.ID = (int)datos.Lector["Marca"];
                    aux.Marca.NombreMarca = (string)datos.Lector["NombreMarca"];

                    aux.Modelo = new Modelo();
                    aux.Modelo.ID = (int)datos.Lector["Modelo"];
                    aux.Modelo.NombreModelo = (string)datos.Lector["NombreModelo"];


                    aux.Anio = (int)datos.Lector["Anio"];
                    aux.TipoVehiculo = (string)datos.Lector["TipoVehiculo"];
                    aux.Patente = (string)datos.Lector["Patente"];

                    aux.IdCliente = (int)datos.Lector["IDCliente"];


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

        public void AltaVehiculo(Vehiculo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO VEHICULOS(Marca,Modelo,Anio,Patente,TipoVehiculo,IdCliente) VALUES(@Marca,@Modelo,@Anio,@Patente,@TipoVehiculo,@IdCliente)");
                datos.setearParametro("@Marca", nuevo.Marca.NombreMarca);
                datos.setearParametro("@Modelo", nuevo.Modelo.NombreModelo);
                datos.setearParametro("@Anio", nuevo.Anio);
                datos.setearParametro("@Patente", nuevo.Patente);
                datos.setearParametro("@TipoVehiculo", nuevo.TipoVehiculo);
                datos.setearParametro("@IdCliente", nuevo.IdCliente);

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
    }
}
