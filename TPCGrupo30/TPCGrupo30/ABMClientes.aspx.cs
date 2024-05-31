using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace TPCGrupo30
{
    public partial class ABMClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            dgvClientes.DataSource = negocio.Listar();
            dgvClientes.DataBind();
        }
    }
}