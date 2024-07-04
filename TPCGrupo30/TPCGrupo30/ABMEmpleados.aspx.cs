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
        public bool FiltroInactivos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FiltroInactivos = false;
                UsuarioNegocio negocio = new UsuarioNegocio();
                Session.Add("listaUsuarios", negocio.Listar());

                dgvEmpleados.DataSource = Session["listaUsuarios"];
                dgvEmpleados.DataBind();
            }
            
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Usuario> lista = (List<Usuario>)Session["listaUsuarios"];
            List<Usuario> filtrada;
            switch (ddlFiltrar.SelectedItem.Text)
            {
                case ("Nombre"):
                    filtrada = lista.FindAll(x => x.Nombre.ToLower().Contains(txtBuscar.Text.ToLower()));
                    dgvEmpleados.DataSource = filtrada;
                    dgvEmpleados.DataBind();
                    break;
                case ("Apellido"):
                    filtrada = lista.FindAll(x => x.Apellido.ToLower().Contains(txtBuscar.Text.ToLower()));
                    dgvEmpleados.DataSource = filtrada;
                    dgvEmpleados.DataBind();
                    break;
                case ("DNI"):
                    if (txtBuscar.Text == "")
                    {
                        filtrada = lista;
                    }
                    else
                    {
                        filtrada = lista.FindAll(x => x.DNI.Equals(int.Parse(txtBuscar.Text)));
                        dgvEmpleados.DataSource = filtrada;
                        dgvEmpleados.DataBind();
                    }
                    break;
                default:
                    break;
            }
            //if (ddlFiltrar.SelectedItem.Text == "Nombre")
            //{
            //    filtrada = lista.FindAll(x => x.Nombre.ToLower().Contains(txtBuscar.Text.ToLower()));
            //    dgvEmpleados.DataSource = filtrada;
            //    dgvEmpleados.DataBind();
            //}
            //else
            //{
            //    //busqueda por apellido..... armar filtro con case para buscar x mas parametros....
            //    filtrada = lista.FindAll(x => x.Apellido.ToLower().Contains(txtBuscar.Text.ToLower()));
            //    dgvEmpleados.DataSource = filtrada;
            //    dgvEmpleados.DataBind();
            //}
        }

        protected void dgvEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(dgvEmpleados.DataKeys[rowIndex].Value);
            if (e.CommandName == "BajaUsuario")
            {
                try
                {
                    if (!(cBoxInactivos.Checked))
                    {
                        UsuarioNegocio negocio = new UsuarioNegocio();
                        negocio.bajaUsuario(id);
                        dgvEmpleados.DataSource = negocio.Listar();
                        dgvEmpleados.DataBind();
                    }
                    else
                    {
                        UsuarioNegocio negocio = new UsuarioNegocio();
                        negocio.bajaUsuario(id,false);
                        dgvEmpleados.DataSource = negocio.Listar();
                        dgvEmpleados.DataBind();
                        cBoxInactivos.Checked = false;

                    }



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

        protected void cBoxInactivos_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxInactivos.Checked)
            {
                FiltroInactivos = cBoxInactivos.Checked;
                ddlFiltrar.Enabled = !FiltroInactivos;
                txtBuscar.Enabled = !FiltroInactivos;

                UsuarioNegocio negocio = new UsuarioNegocio();
                List<Usuario> lista = new List<Usuario>();
                lista = negocio.ListarInactivos();
                dgvEmpleados.DataSource = lista;
                dgvEmpleados.DataBind();
            }
            else
            {
                FiltroInactivos = cBoxInactivos.Checked;
                ddlFiltrar.Enabled = !FiltroInactivos;
                txtBuscar.Enabled = !FiltroInactivos;

                dgvEmpleados.DataSource = Session["listaClientes"];
                dgvEmpleados.DataBind();
            }
        }
    }
}