using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCGrupo30
{
    public partial class ABMServicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicioNegocio negocio = new ServicioNegocio();


            Session.Add("listaServicios", negocio.Listar());

            dgvServicios.DataSource = Session["listaServicios"];
            dgvServicios.DataBind();
        }

        protected void dgvServicios_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}