using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCGrupo30
{
    public partial class NuevaOrden : System.Web.UI.Page
    {
        VehiculoNegocio negocio1 = new VehiculoNegocio();
        ClienteNegocio negocio = new ClienteNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    List<Cliente> listaCliente = negocio.Listar();

                    ddlCliente.DataSource = listaCliente;
                    ddlCliente.DataValueField = "ID";
                    ddlCliente.DataTextField = "Apellido";
                    ddlCliente.DataBind();


                    List<Vehiculo> listaVehiculos = negocio1.Listar();
                    Session["listaVehiculos"] = listaVehiculos;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCliente.SelectedItem != null)
                {
                    int Id = int.Parse(ddlCliente.SelectedItem.Value);
                    List<Vehiculo> listaVehiculos = (List<Vehiculo>)Session["listaVehiculos"];
                    if (listaVehiculos != null)
                    {
                        var vehiculosCliente = listaVehiculos.FindAll(x => x.IdCliente.ID == Id);
                        ddlVehiculo.DataSource = vehiculosCliente;
                        ddlVehiculo.DataValueField = "ID"; // Set this to the appropriate field
                        ddlVehiculo.DataTextField = "NombreVehiculo"; // Set this to the appropriate field
                        ddlVehiculo.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                // Optionally display error to the user
                // lblError.Text = "An error occurred while selecting a client.";
            }
        }
    
    }
}
