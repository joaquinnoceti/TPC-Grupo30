using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> Listar(string id = "")
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT u.ID,u.Nombre,u.Apellido,u.DNI,u.FechaNac,u.Email,u.Telefono,u.Categoria FROM Usuarios u where u.Estado = 1 AND u.IdRol = 2");
                if (id != "")
                    datos.setearConsulta("SELECT u.ID,u.Nombre,u.Apellido,u.DNI,u.FechaNac,u.Email,u.Telefono,u.Categoria FROM Usuarios u where u.Estado = 1 AND u.IdRol = 2 AND C.ID = " + int.Parse(id));

                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {

                    Usuario aux = new Usuario();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.DNI = (int)datos.Lector["DNI"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNac"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Categoria = (string)datos.Lector["Categoria"];


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
        public void altaUsuario(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spAltaUsuario");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@DNI", nuevo.DNI);
                datos.setearParametro("@FechaNac", nuevo.FechaNacimiento);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Telefono", nuevo.Telefono);
                datos.setearParametro("@Direccion", nuevo.Direccion);
                datos.setearParametro("@Especialidad", nuevo.Especialidad);
                datos.setearParametro("@Categoria", nuevo.Categoria);
                datos.setearParametro("@Contrasenia", nuevo.Contrasenia);

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

        public void bajaUsuario(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                DialogResult rta = MessageBox.Show("Eliminar Usuario?", "Usuario Eliminado.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (rta == DialogResult.Yes)
                {
                    datos.setearConsulta("UPDATE Usuarios SET Estado = 0 WHERE ID = @ID");
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

