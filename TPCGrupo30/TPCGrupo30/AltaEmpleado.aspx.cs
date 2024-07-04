using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

                EspecialidadNegocio negocioCate = new EspecialidadNegocio();
                List<Categoria> listaCategoria = negocioCate.ListarCategoria();
                ddlCategoria.DataSource = listaCategoria;
                ddlCategoria.DataValueField = "ID";
                ddlCategoria.DataTextField = "NombreCategoria";
                ddlCategoria.DataBind();

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
                    txtFechaNac.Text = User.FechaNacimiento.ToString("yyyy-MM-dd");
                    txtEmail.Text = User.Email;
                    txtTelefono.Text = User.Telefono;
                    txtDireccion.Text = User.Direccion;
                    ddlCategoria.SelectedValue=User.Categoria.ID.ToString();
                    ddlEspecialidad.SelectedValue = User.Especialidad.ID.ToString();
                    if (User.Rol == 1)
                        ddlRol.Text = "ADMIN";
                    else
                        ddlRol.Text = "EMPLEADO";  

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
                Page.Validate();
                if (!Page.IsValid)
                    return;

                if (validarCampos())
                {

                    Usuario nuevo = new Usuario();
                    UsuarioNegocio negocio = new UsuarioNegocio();

                    // Formatos esperados de las fechas
                    string[] formatosFecha = { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd" }; // Ajusta los formatos según tus necesidades

                    // Validar fecha de nacimiento
                    DateTime fechaNacimiento;
                    if (!DateTime.TryParseExact(txtFechaNac.Text, formatosFecha, null, System.Globalization.DateTimeStyles.None, out fechaNacimiento))
                    {
                        lblError.Text = "La fecha de nacimiento no tiene un formato válido.";
                        return;
                    }

                    nuevo.Nombre = txtNombre.Text;
                    nuevo.Apellido = txtApellido.Text;
                    nuevo.DNI = int.Parse(txtDni.Text);
                    nuevo.FechaNacimiento = fechaNacimiento;
                    nuevo.Email = txtEmail.Text;
                    nuevo.Telefono = txtTelefono.Text;
                    nuevo.Direccion = txtDireccion.Text;

                    nuevo.Especialidad = new Especialidad();
                    nuevo.Especialidad.ID = int.Parse(ddlEspecialidad.SelectedValue);

                    nuevo.Categoria = new Categoria();
                    nuevo.Categoria.ID = int.Parse(ddlCategoria.SelectedValue);
                    nuevo.Contrasenia = txtContrasenia.Text;
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    if (Request.QueryString["id"] == null)
                    {
                        if (usuarioNegocio.VerificarDNI(nuevo.DNI) != 0)
                        {
                            lblError.ForeColor = System.Drawing.Color.Red;
                            lblError.Text = "Ya existe usuario con ese DNI";
                            return;
                        }
                    }
                    //nuevo.FechaRegistro = DateTime.Parse(txtFechaRegistro.Text);
                    //nuevo.Rol = ddlRol.SelectedIndex;

                    if (Request.QueryString["id"] != null)
                    {
                        nuevo.ID = int.Parse(Request.QueryString["id"]);
                        negocio.modificarUsuario(nuevo);
                    }
                    else
                    {
                        negocio.altaUsuario(nuevo);
                    }
                    Response.Redirect("ABMEmpleados.aspx");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected bool validarCampos()
        {
            if (string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtDni.Text) || string.IsNullOrEmpty(txtDireccion.Text)
                || string.IsNullOrEmpty(txtFechaNac.Text))
            {
                if (Request.QueryString["id"] == null)
                {
                    if (string.IsNullOrEmpty(txtContrasenia.Text))
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Por favor, elija su contraseña";
                        return false;
                    }
                }
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Por favor, completar todos los campos para continuar";
                return false;
            }
            return true;
        }
    }
}