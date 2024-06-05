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

        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.SelectedDataKey != null)
                {
                    ClienteNegocio negocio = new ClienteNegocio();
                    int id = (int)dgvClientes.SelectedDataKey.Value;
                    negocio.bajaCliente(id);
                    dgvClientes.DataSource = negocio.Listar();
                    dgvClientes.DataBind();

                }
            }
            catch (Exception ex)
            {

                ex.ToString();
            }

        }
    }
}