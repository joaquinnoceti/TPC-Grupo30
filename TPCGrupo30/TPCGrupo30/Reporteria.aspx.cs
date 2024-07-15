using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TPCGrupo30
{
    public partial class Reporteria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CostoNegocio costoNegocio = new CostoNegocio();
            try
            {
                Session.Add("listaCostos", costoNegocio.ListarCostosMensuales());
                dgvCostos.DataSource = Session["listaCostos"];
                dgvCostos.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}