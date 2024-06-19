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
    public partial class ABMEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Session.Add("listaUsuarios", negocio.Listar());

            dgvEmpleados.DataSource = Session["listaUsuarios"];
            dgvEmpleados.DataBind();
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Usuario> lista = (List<Usuario>)Session["listaUsuarios"];
            List<Usuario> filtrada;
            if (ddlFiltrar.SelectedItem.Text == "Nombre")
            {
                filtrada = lista.FindAll(x => x.Nombre.ToLower().Contains(txtBuscar.Text.ToLower()));
                dgvEmpleados.DataSource = filtrada;
                dgvEmpleados.DataBind();
            }
            else
            {
                //busqueda por apellido..... armar filtro con case para buscar x mas parametros....
                filtrada = lista.FindAll(x => x.Apellido.ToLower().Contains(txtBuscar.Text.ToLower()));
                dgvEmpleados.DataSource = filtrada;
                dgvEmpleados.DataBind();
            }
        }

        protected void dgvEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(dgvEmpleados.DataKeys[rowIndex].Value);
            if (e.CommandName == "BajaCliente")
            {
                try
                {

                    UsuarioNegocio negocio = new UsuarioNegocio();
                    negocio.bajaUsuario(id);
                    dgvEmpleados.DataSource = negocio.Listar();
                    dgvEmpleados.DataBind();


                }
                catch (Exception ex)
                {

                    Session.Add("error", ex.ToString());
                }
            }
            else
            {
                Response.Redirect("AltaEmpleado.aspx?id="+id);

            }
        }
    }
}