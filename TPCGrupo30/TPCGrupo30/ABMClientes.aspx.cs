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

        public bool FiltroInactivos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FiltroInactivos = false;
                ClienteNegocio negocio = new ClienteNegocio();
                Session.Add("listaClientes", negocio.Listar());

                dgvClientes.DataSource = Session["listaClientes"];
                dgvClientes.DataBind();
            }
            
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
            else if (ddlFiltrar.SelectedItem.Text == "Apellido")
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
                    if (!(cBoxInactivos.Checked))                           //PREGUNTO Q ESTADO D USUARIOS SE MUESTRAN EN DGV
                    {                                                       //BAJA DE CLIENTES ACTIVOS
                        ClienteNegocio negocio = new ClienteNegocio();
                        negocio.bajaCliente(id);
                        dgvClientes.DataSource = negocio.Listar();
                        dgvClientes.DataBind();
                    }
                    else
                    {                                                       //ALTA DE CLIENTES INACTIVOS
                        ClienteNegocio negocio = new ClienteNegocio();
                        negocio.bajaCliente(id,false);
                        dgvClientes.DataSource = negocio.Listar();
                        dgvClientes.DataBind();
                        cBoxInactivos.Checked = false;
                    }

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

        protected void cBoxInactivos_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxInactivos.Checked)
            {
                FiltroInactivos = cBoxInactivos.Checked;
                ddlFiltrar.Enabled = !FiltroInactivos;
                txtBuscar.Enabled = !FiltroInactivos;

                ClienteNegocio negocio = new ClienteNegocio();
                List<Cliente> lista = new List<Cliente>();
                lista = negocio.ListarInactivos();
                dgvClientes.DataSource = lista;
                dgvClientes.DataBind();
            }
            else
            {
                FiltroInactivos = cBoxInactivos.Checked;
                ddlFiltrar.Enabled = !FiltroInactivos;
                txtBuscar.Enabled = !FiltroInactivos;

                dgvClientes.DataSource = Session["listaClientes"];
                dgvClientes.DataBind();
            }

        }


    }
}