using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TPCGrupo30
{
    public partial class ListadoVehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VehiculoNegocio negocio = new VehiculoNegocio();
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "")
            {
                Session.Add("listadoVehiculos", negocio.ListarxID(id));

                dgvVehiculo.DataSource = Session["listadoVehiculos"];
                dgvVehiculo.DataBind();


            }




        }
    }
}