using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;

namespace negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> Listar(string id = "")
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT c.ID,c.Nombre,c.Apellido,c.Email,c.DNI,c.Telefono,c.FechaNac,c.Direccion FROM Clientes c where C.ACTIVO = 1 ");
                if (id != "")
                    datos.setearConsulta("SELECT c.ID,c.Nombre,c.Apellido,c.Email,c.DNI,c.Telefono,c.FechaNac,c.Direccion FROM Clientes c where C.ACTIVO = 1 AND C.ID = " + int.Parse(id));

                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {

                    Cliente aux = new Cliente();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.DNI = (int)datos.Lector["DNI"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.FechaNac = DateTime.Parse(datos.Lector["FechaNac"].ToString());
                    aux.Direccion = (string)datos.Lector["Direccion"];

                    //aux.Vehiculo = new Vehiculo();
                    //aux.Vehiculo.ID = (int)datos.Lector["IDVehiculo"];
                    //aux.Vehiculo.Patente = (string)datos.Lector["Patente"];


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
        public void altaCliente(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spAltaCliente");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@DNI", nuevo.DNI);
                datos.setearParametro("@Telefono", nuevo.Telefono);
                datos.setearParametro("@FechaNac", nuevo.FechaNac);
                datos.setearParametro("@Direccion", nuevo.Direccion);

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

        public void bajaCliente(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                DialogResult rta = MessageBox.Show("Eliminar Cliente?", "Cliente Eliminado.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (rta == DialogResult.Yes)
                {
                    datos.setearConsulta("UPDATE CLIENTES SET ACTIVO = 0 WHERE ID = @ID");
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
        public List<Cliente> ListarDDL()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT c.ID,c.Nombre,c.Apellido,c.Email,c.DNI,c.Telefono,c.FechaNac,c.Direccion,v.ID,v.NombreVehiculo,v.IdCliente FROM Vehiculos v INNER JOIN Clientes c ON v.IdCliente=c.ID WHERE c.Activo=1");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {

                    Cliente aux = new Cliente();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.DNI = (int)datos.Lector["DNI"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.FechaNac = (DateTime)datos.Lector["FechaNac"];
                    aux.Direccion = (string)datos.Lector["Direccion"];

                    //aux.Vehiculo = new Vehiculo();
                    //aux.Vehiculo.IDVehiculo = (int)datos.Lector["IDVehiculo"];
                    //aux.Vehiculo.NombreVehiculo = (string)datos.Lector["NombreVehiculo"];

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

        public void modificar(Cliente cli)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE CLIENTES SET Nombre=@nombre, Apellido=@apellido, Email=@email, DNI=@DNI, Telefono=@Telefono, FechaNac=@FechaNac, Direccion=@Direccion where id = @ID");
                datos.setearParametro("@nombre", cli.Nombre);
                datos.setearParametro("@apellido", cli.Apellido);
                datos.setearParametro("@Email", cli.Email);
                datos.setearParametro("@DNI", cli.DNI);
                datos.setearParametro("@Telefono", cli.Telefono);
                datos.setearParametro("@FechaNac", cli.FechaNac);
                datos.setearParametro("@Direccion", cli.Direccion);
                datos.setearParametro("@ID", cli.ID);
                datos.ejecutarConsulta();

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
