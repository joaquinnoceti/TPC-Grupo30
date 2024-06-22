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

        public List<Vehiculo> ListarxIDCLIENTE(string id)
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT V.ID,V.NombreVehiculo,v.Anio,v.Patente,v.TipoVehiculo,v.IdCliente, M.ID  as 'idMarca',M.NombreMarca,MO.ID as 'idModelo',MO.NombreModelo from vehiculos V JOIN MARCAS M ON (V.MARCA=M.ID) JOIN Modelos MO ON (MO.ID = V.MODELO) JOIN Clientes c on (c.ID = v.IdCliente) WHERE v.Estado = 1 and c.ID = " + int.Parse(id));
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Vehiculo aux = new Vehiculo();
                    
                    aux.IDVehiculo = (int)datos.Lector["ID"];
                    aux.NombreVehiculo = (string)datos.Lector["NombreVehiculo"];
                    aux.Anio = (int)datos.Lector["Anio"];
                    aux.Patente = (string)datos.Lector["Patente"];
                    aux.TipoVehiculo = (string)datos.Lector["TipoVehiculo"];
                    aux.IdCliente = (int)datos.Lector["IdCliente"];

                    aux.Marca = new Marca();
                    aux.Marca.ID = (int)datos.Lector["idMarca"];
                    aux.Marca.NombreMarca = (string)datos.Lector["NombreMarca"];

                    aux.Modelo = new Modelo();
                    aux.Modelo.ID = (int)datos.Lector["idModelo"];
                    aux.Modelo.NombreModelo = (string)datos.Lector["NombreModelo"];


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

        public List<Vehiculo> ListarxID(string id)
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT V.ID,V.NombreVehiculo,v.Anio,v.Patente,v.TipoVehiculo,v.IdCliente, M.ID  as 'idMarca',M.NombreMarca,MO.ID as 'idModelo',MO.NombreModelo from vehiculos V JOIN MARCAS M ON (V.MARCA=M.ID) JOIN Modelos MO ON (MO.ID = V.MODELO) JOIN Clientes c on (c.ID = v.IdCliente) WHERE v.Estado = 1 and v.ID = " + int.Parse(id));
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Vehiculo aux = new Vehiculo();

                    aux.IDVehiculo = (int)datos.Lector["ID"];
                    aux.NombreVehiculo = (string)datos.Lector["NombreVehiculo"];
                    aux.Anio = (int)datos.Lector["Anio"];
                    aux.Patente = (string)datos.Lector["Patente"];
                    aux.TipoVehiculo = (string)datos.Lector["TipoVehiculo"];
                    aux.IdCliente = (int)datos.Lector["IdCliente"];

                    aux.Marca = new Marca();
                    aux.Marca.ID = (int)datos.Lector["idMarca"];
                    aux.Marca.NombreMarca = (string)datos.Lector["NombreMarca"];

                    aux.Modelo = new Modelo();
                    aux.Modelo.ID = (int)datos.Lector["idModelo"];
                    aux.Modelo.NombreModelo = (string)datos.Lector["NombreModelo"];


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

        public void ModificarVehiculo(Vehiculo v)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update VEHICULOS set NOMBREVEHICULO=@NOMBREVEHICULO, MARCA=@IDMARCA, MODELO=@IDMODELO, ANIO=@ANIO, PATENTE=@PATENTE, TIPOVEHICULO=@TIPOVEHICULO WHERE ID=@IDVEHICULO");
                datos.setearParametro("@NOMBREVEHICULO",v.NombreVehiculo);
                datos.setearParametro("@IDMARCA", v.Marca.ID);
                datos.setearParametro("@IDMODELO", v.Modelo.ID);
                datos.setearParametro("@ANIO", v.Anio);
                datos.setearParametro("@PATENTE", v.Patente);
                datos.setearParametro("@TIPOVEHICULO", v.TipoVehiculo);
                datos.setearParametro("@IDVEHICULO", v.IDVehiculo);

                datos.ejecutarConsulta();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

    }
}
