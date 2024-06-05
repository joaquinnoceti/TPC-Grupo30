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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ClienteNegocio negocio = new ClienteNegocio();
                    List<Cliente> listaCliente = negocio.Listar();

                    ddlCliente.DataSource = listaCliente;
                    ddlCliente.DataValueField = "ID";
                    ddlCliente.DataTextField = "Nombre";
                    ddlCliente.DataBind();

                }



            }
            catch (Exception ex)
            {

                Session.Add("error",ex);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = int.Parse(ddlCliente.SelectedItem.Value);
            ddlVehiculo.DataSource = ((List<Cliente>)Session["listaCliente"]).FindAll(x => x.Vehiculo.ID == Id);
            ddlVehiculo.DataBind();

                
                
        }
    }
}