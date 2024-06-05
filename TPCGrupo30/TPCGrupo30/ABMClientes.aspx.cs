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
            Session.Add("listaClientes", negocio.Listar());

            dgvClientes.DataSource = Session["listaClientes"];
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

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Cliente> lista = (List<Cliente>)Session["listaClientes"];
            List<Cliente> filtrada;
            if (ddlFiltrar.SelectedItem.Text == "Nombre")
            {
                filtrada = lista.FindAll(x => x.Nombre.ToLower().Contains(txtBuscar.Text.ToLower()));
                dgvClientes.DataSource=filtrada;
                dgvClientes.DataBind();
            }
            else
            {
                //busqueda por apellido..... armar filtro con case para buscar x mas parametros....
                filtrada = lista.FindAll(x => x.Apellido.ToLower().Contains(txtBuscar.Text.ToLower()));
                dgvClientes.DataSource = filtrada;
                dgvClientes.DataBind();
            }


        }
    }
}