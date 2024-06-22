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
    public partial class AltaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //modificar cliente
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "")
                {
                    Label1.Text = "Modificar Cliente";
                    ClienteNegocio negocio = new ClienteNegocio();
                    Cliente cli = (negocio.Listar(id))[0];

                    txtNombre.Text = cli.Nombre;
                    txtApellido.Text = cli.Apellido;
                    txtDni.Text = cli.DNI.ToString();
                    txtDirecion.Text = cli.Direccion;
                    txtEmail.Text = cli.Email;
                    txtFecha.Text = cli.FechaNac.ToString("yyyy-MM-dd");
                    txtTelefono.Text = cli.Telefono;
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente nuevo = new Cliente();
                ClienteNegocio negocio = new ClienteNegocio();

                // Formatos esperados de las fechas
                string[] formatosFecha = { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd" }; // Ajusta los formatos según tus necesidades

                // Validar fecha de nacimiento
                DateTime fechaNacimiento;
                if (!DateTime.TryParseExact(txtFecha.Text, formatosFecha, null, System.Globalization.DateTimeStyles.None, out fechaNacimiento))
                {
                    lblError.Text = "La fecha de nacimiento no tiene un formato válido.";
                    return;
                }

                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtApellido.Text;
                nuevo.Email = txtEmail.Text;
                nuevo.DNI = int.Parse(txtDni.Text);
                nuevo.Telefono = txtTelefono.Text;
                nuevo.FechaNac = fechaNacimiento;
                nuevo.Direccion = txtDirecion.Text;

                if (Request.QueryString["id"] != null)
                {
                    nuevo.ID = int.Parse(Request.QueryString["id"]);
                    negocio.modificar(nuevo);
                }

                else
                {
                    negocio.altaCliente(nuevo);
                }

                Response.Redirect("ABMClientes.ASPX");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}