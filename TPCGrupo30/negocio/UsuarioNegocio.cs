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
            AccesoDatos1 datos = new AccesoDatos1();

            try
            {
                datos.setearConsulta("SELECT u.ID,u.Nombre,u.Apellido,u.DNI,u.FechaNac,u.Email,u.Telefono,u.Direccion,u.FechaRegistro,u.IdEspecialidad,e.NombreEspecialidad,u.IdCategoria,c.NombreCategoria,u.IdRol,u.Estado FROM Usuarios u INNER JOIN Especialidades e ON u.IdEspecialidad=e.ID INNER JOIN Categorias c ON u.IdCategoria=c.ID WHERE u.Estado=1");
                if (id != "")
                    datos.setearConsulta("SELECT u.ID,u.Nombre,u.Apellido,u.DNI,u.FechaNac,u.Email,u.Telefono,u.Direccion,u.FechaRegistro,u.IdEspecialidad,e.NombreEspecialidad,u.IdCategoria,c.NombreCategoria,u.IdRol,u.Estado FROM Usuarios u INNER JOIN Especialidades e ON u.IdEspecialidad=e.ID INNER JOIN Categorias c ON u.IdCategoria=c.ID WHERE u.Estado=1 AND U.ID = " + int.Parse(id));

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

                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.ID = (int)datos.Lector["IdEspecialidad"];
                    aux.Especialidad.NombreEspecialidad = (string)datos.Lector["NombreEspecialidad"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.ID = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.NombreCategoria = (string)datos.Lector["NombreCategoria"];

                    aux.Rol = (int)datos.Lector["IdRol"];
                    
                    aux.Direccion = (string)datos.Lector["Direccion"];

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
        public bool altaUsuario(Usuario nuevo)
        {
            AccesoDatos1 datos = new AccesoDatos1();
            if (VerificarDNI(nuevo.DNI) == 0 && VerificarMAIL(nuevo.Email) == 0)
            {
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
                    datos.setearParametro("@IdEspecialidad", nuevo.Especialidad.ID);
                    datos.setearParametro("@IdCategoria", nuevo.Categoria.ID);
                    datos.setearParametro("@Contrasenia", nuevo.Contrasenia);

                    datos.ejecutar();
                    return true;
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
            else
                return false;
        }

        public List<Usuario> ListarInactivos()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT u.ID,u.Nombre,u.Apellido,u.DNI,u.FechaNac,u.Email,u.Telefono,u.Direccion,u.FechaRegistro,u.IdEspecialidad,e.NombreEspecialidad,u.IdCategoria,c.NombreCategoria,u.IdRol,u.Estado FROM Usuarios u INNER JOIN Especialidades e ON u.IdEspecialidad=e.ID INNER JOIN Categorias c ON u.IdCategoria=c.ID WHERE u.Estado=0");
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

                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.ID = (int)datos.Lector["IdEspecialidad"];
                    aux.Especialidad.NombreEspecialidad = (string)datos.Lector["NombreEspecialidad"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.ID = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.NombreCategoria = (string)datos.Lector["NombreCategoria"];

                    aux.Rol = (int)datos.Lector["IdRol"];

                    aux.Direccion = (string)datos.Lector["Direccion"];

                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { datos.cerrarConexion(); }
        }

        public void bajaUsuario(int id, bool activo = true)
        {
            AccesoDatos1 datos = new AccesoDatos1();
            if(activo == true)
            {
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
            else
            {
                try
                {
                    DialogResult rta = MessageBox.Show("Reactivar Usuario?", "Reactivar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (rta == DialogResult.Yes)
                    {
                        datos.setearConsulta("UPDATE Usuarios SET Estado = 1 WHERE ID = @ID");
                        datos.setearParametro("@ID", id);
                        datos.ejecutarConsulta();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            
        }

        public void modificarUsuario(Usuario user)
        {
            AccesoDatos1 datos = new AccesoDatos1();
            try
            {
                datos.setearConsulta("UPDATE USUARIOS SET Nombre=@nombre, Apellido=@apellido, DNI=@DNI,FechaNac=@FechaNac, Email=@email, Telefono=@Telefono,  Direccion=@Direccion, IdEspecialidad=@IdEspecialidad, IdCategoria=@Categoria where id = @ID");
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@DNI", user.DNI);
                datos.setearParametro("@FechaNac", user.FechaNacimiento);
                datos.setearParametro("@Email", user.Email);
                datos.setearParametro("@Telefono", user.Telefono);
                datos.setearParametro("@Direccion", user.Direccion);
                datos.setearParametro("@IdEspecialidad", user.Especialidad.ID);
                datos.setearParametro("@Categoria", user.Categoria.ID);

                datos.setearParametro("@ID", user.ID);
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
        public int VerificarDNI(int dni)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string query = "SELECT DNI FROM Usuarios WHERE DNI = '" + dni + "'";
                int resultado = datos.executaScalar(query);
                return resultado;
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

        public int VerificarMAIL(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string query = "SELECT EMAIL FROM Usuarios WHERE email = '" + email + "'";
                int resultado = datos.executaScalar(query);
                return resultado;
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

