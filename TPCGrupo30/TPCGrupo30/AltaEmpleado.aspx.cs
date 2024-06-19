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
            if (!IsPostBack)
            {
                EspecialidadNegocio ESPnegocio = new EspecialidadNegocio();
                List<Especialidad> listaEsp = ESPnegocio.Listar();
                ddlEspecialidad.DataSource = listaEsp;
                ddlEspecialidad.DataValueField = "ID";
                ddlEspecialidad.DataTextField = "NombreEspecialidad";
                ddlEspecialidad.DataBind();

                //modificar empleado
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "")
                {
                    Label1.Text = "Modificar Empleado";
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    Usuario User = (negocio.Listar(id))[0];

                    txtNombre.Text = User.Nombre;
                    txtApellido.Text = User.Apellido;
                    txtDni.Text = User.DNI.ToString();
                    txtFechaNac.Text = User.FechaNacimiento.ToString();
                    txtEmail.Text = User.Email;
                    txtTelefono.Text = User.Telefono;
                    txtDireccion.Text = User.Direccion;
                    txtCategoria.Text = User.Categoria;
                    ddlEspecialidad.SelectedValue = User.Especialidad.ID.ToString();
                    txtContrasenia.Visible = false;
                    lblPass.Visible = false;
                    ddlRol.Enabled = false;
                }
            }


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
                nuevo.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                nuevo.Email = txtEmail.Text;
                nuevo.Telefono = txtTelefono.Text;
                nuevo.Direccion = txtDireccion.Text;

                nuevo.Especialidad = new Especialidad();
                nuevo.Especialidad.ID = int.Parse(ddlEspecialidad.SelectedValue);

                nuevo.Categoria = txtCategoria.Text;
                nuevo.Contrasenia = txtContrasenia.Text;
                //nuevo.FechaRegistro = DateTime.Parse(txtFechaRegistro.Text);
                nuevo.Rol = ddlRol.SelectedIndex;

                if (Request.QueryString["id"] != null)
                {
                    negocio.modificarUsuario(nuevo);
                }
                else
                {
                    negocio.altaUsuario(nuevo);
                }
                Response.Redirect("ABMEmpleados.aspx");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}