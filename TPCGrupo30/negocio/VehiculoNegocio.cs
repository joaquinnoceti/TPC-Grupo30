using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                datos.setearConsulta("SELECT v.ID,v.NombreVehiculo, m.ID as Marca, m.NombreMarca,mo.ID as Modelo, mo.NombreModelo,v.Anio,v.Patente,v.TipoVehiculo,v.IdCliente, c.Apellido FROM Vehiculos v, Clientes c, Marcas m, Modelos mo WHERE v.IdCliente=c.ID and v.Marca=m.ID and v.Modelo=mo.ID AND C.ID =" + int.Parse(id));
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Vehiculo aux = new Vehiculo();

                    aux.Marca = new Marca();
                    aux.Marca.ID = (int)datos.Lector["Marca"];
                    aux.Marca.NombreMarca = (string)datos.Lector["NombreMarca"];

                    aux.Modelo = new Modelo();
                    aux.Modelo.ID = (int)datos.Lector["Modelo"];
                    aux.Modelo.NombreModelo = (string)datos.Lector["NombreModelo"];

                    aux.IDVehiculo = (int)datos.Lector["id"];
                    aux.Anio = (int)datos.Lector["Anio"];
                    aux.Patente = (string)datos.Lector["Patente"];
                    aux.TipoVehiculo = (string)datos.Lector["TipoVehiculo"];
                    aux.IdCliente = (int)datos.Lector["IdCliente"];

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
                string nombreVehiculo = nuevo.Modelo.NombreModelo+ " " + nuevo.Patente;
                datos.setearConsulta("INSERT INTO VEHICULOS(NombreVehiculo,Marca,Modelo,Anio,Patente,TipoVehiculo,IdCliente,ESTADO) VALUES(@NombreVehiculo,@Marca,@Modelo,@Anio,@Patente,@TipoVehiculo,@IdCliente,1)");
                datos.setearParametro("@NombreVehiculo", nombreVehiculo);
                datos.setearParametro("@Marca", nuevo.Marca.ID);
                datos.setearParametro("@Modelo", nuevo.Modelo.ID);
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

        public void BajaVehiculo(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                DialogResult rta = MessageBox.Show("Eliminar Vehiculo?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (rta == DialogResult.Yes)
                {
                    datos.setearConsulta("UPDATE VEHICULOS SET ESTADO = 0 WHERE ID = @ID");
                    datos.setearParametro("@ID", id);
                    datos.ejecutarConsulta();
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
