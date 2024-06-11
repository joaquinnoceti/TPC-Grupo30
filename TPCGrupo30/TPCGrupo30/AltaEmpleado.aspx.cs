using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPCGrupo30
{
    public partial class AltaEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario nuevo = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtApellido.Text;
                nuevo.DNI = int.Parse(txtDni.Text);
                nuevo.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                nuevo.Email = txtEmail.Text;
                nuevo.Telefono = txtTelefono.Text;
                nuevo.Direccion = txtDireccion.Text;
                nuevo.Especialidad = txtEspecialidad.Text;
                nuevo.Categoria = txtCategoria.Text;
                nuevo.Contrasenia = txtContrasenia.Text;
                //nuevo.FechaRegistro = DateTime.Parse(txtFechaRegistro.Text);
                //nuevo.Rol = (Rol)txtRol.Text;

                negocio.altaUsuario(nuevo);

                Response.Redirect("ABMEmpleados.aspx");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}