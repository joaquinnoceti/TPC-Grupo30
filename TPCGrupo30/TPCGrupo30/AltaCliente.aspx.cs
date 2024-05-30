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
    public partial class AltaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente nuevo = new Cliente();
                ClienteNegocio negocio = new ClienteNegocio();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtApellido.Text;
                nuevo.Email = txtEmail.Text;
                nuevo.DNI = int.Parse(txtDni.Text);
                nuevo.Telefono = txtTelefono.Text;
                nuevo.FechaNac = DateTime.Parse(txtFecha.Text);
                nuevo.Direccion = txtDirecion.Text;

                negocio.altaCliente(nuevo);

                Response.Redirect("Principal.ASPX");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}