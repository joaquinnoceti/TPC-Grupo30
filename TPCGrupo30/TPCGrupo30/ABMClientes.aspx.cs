using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using System.Windows.Forms;

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

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Cliente> lista = (List<Cliente>)Session["listaClientes"];
            List<Cliente> filtrada;
            if (ddlFiltrar.SelectedItem.Text == "Nombre")
            {
                filtrada = lista.FindAll(x => x.Nombre.ToLower().Contains(txtBuscar.Text.ToLower()));
                dgvClientes.DataSource = filtrada;
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

        protected void dgvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(dgvClientes.DataKeys[rowIndex].Value);
            if (e.CommandName == "BajaCliente")
            {
                try
                {

                    ClienteNegocio negocio = new ClienteNegocio();
                    negocio.bajaCliente(id);
                    dgvClientes.DataSource = negocio.Listar();
                    dgvClientes.DataBind();

                }
                catch (Exception ex)
                {

                    Session.Add("error", ex.ToString());
                }
            }
            else if(e.CommandName == "AsignarVehiculo")
            {
                Session.Remove("cliente");
                Response.Redirect("AltaVehiculo.aspx?id=" + id);
            }
            else if(e.CommandName == "ModifCliente")
            {
                Response.Redirect("AltaCliente.aspx?id=" + id);
            }
            else
            {
                try
                {
                    ClienteNegocio negocio = new ClienteNegocio();
                    Cliente cli = (negocio.Listar(id.ToString()))[0];
                    Session.Add("cliente", cli);
                    Response.Redirect("ListadoVehiculos.aspx?id=" + id, false);

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}