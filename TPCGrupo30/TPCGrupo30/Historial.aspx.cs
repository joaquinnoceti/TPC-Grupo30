using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using dominio;
using negocio;

namespace TPCGrupo30
{
    public partial class Historial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			HistorialModificacionesOT historial = new HistorialModificacionesOT();
			HistorialOTNegocio negocio = new HistorialOTNegocio();
            try
			{
                int id = int.Parse(Request.QueryString["id"]);

                Session.Add("listaHistorial", negocio.ListarHistorialPorOT(id));
                dgvHistorial.DataSource = Session["listaHistorial"];
                
                dgvHistorial.DataBind();
            }
			catch (Exception ex)
			{

				throw ex;
			}
        }
        protected void btnHistorial_Click(object sender, EventArgs e)
        {
            int idOrden = int.Parse(Request.QueryString["ID"].ToString());
            Response.Redirect("AltaOrden.aspx?ID=" + idOrden);

        }

    }
}