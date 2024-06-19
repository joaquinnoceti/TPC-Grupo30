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
                datos.setearConsulta("SELECT u.ID,u.Nombre,u.Apellido,u.DNI,u.FechaNac,u.Email,u.Telefono,u.IdEspecialidad,e.NombreEspecialidad,u.Categoria,u.IdRol, r.NombreRol, u.Direccion FROM Usuarios u inner join Roles r on u.IdRol = r.ID INNER JOIN Especialidades e on(E.ID = U.IdEspecialidad) where u.Estado = 1");
                if (id != "")
                    datos.setearConsulta("SELECT u.ID,u.Nombre,u.Apellido,u.DNI,u.FechaNac,u.Email,u.Telefono,u.IDEspecialidad,e.NombreEspecialidad,u.Categoria,u.IdRol, r.NombreRol, u.Direccion FROM Usuarios u inner join Roles r on u.IdRol = r.ID INNER JOIN Especialidades e on(E.ID = U.IdEspecialidad) where u.Estado = 1 AND U.ID = " + int.Parse(id));

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
                    aux.Especialidad.ID = (int)datos.Lector["IDEspecialidad"];
                    aux.Especialidad.NombreEspecialidad = (string)datos.Lector["NombreEspecialidad"];
                    
                    aux.Categoria = (string)datos.Lector["Categoria"];
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
                datos.setearParametro("@Especialidad", nuevo.Especialidad.ID);
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

        public void modificarUsuario(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE USUARIOS SET Nombre=@nombre, Apellido=@apellido, DNI=@DNI,FechaNac=@FechaNac, Email=@email, Telefono=@Telefono,  Direccion=@Direccion, IdEspecialidad=@IdEspecialidad, Categoria=@Categoria where id = @ID");
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@DNI", user.DNI);
                datos.setearParametro("@FechaNac", user.FechaNacimiento);
                datos.setearParametro("@Email", user.Email);
                datos.setearParametro("@Telefono", user.Telefono);
                datos.setearParametro("@Direccion", user.Direccion);
                datos.setearParametro("@IdEspecialidad", user.Especialidad.ID);
                datos.setearParametro("@Categoria", user.Categoria);

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


    }
}

