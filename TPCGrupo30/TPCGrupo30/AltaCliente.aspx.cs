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
                    txtFecha.Text = cli.FechaNac.ToString();
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

                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtApellido.Text;
                nuevo.Email = txtEmail.Text;
                nuevo.DNI = int.Parse(txtDni.Text);
                nuevo.Telefono = txtTelefono.Text;
                nuevo.FechaNac = DateTime.Parse(txtFecha.Text);
                nuevo.Direccion = txtDirecion.Text;


                if (Request.QueryString["id"] != null)
                    negocio.modificar(nuevo);
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