using dominio;
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
        public bool FiltroInactivos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (!Seguridad.sesionActiva(Session["user"]))
                    Response.Redirect("login.aspx");

                FiltroInactivos = false;

                ServicioNegocio negocio = new ServicioNegocio();
                Session.Add("listaServicios", negocio.Listar());
                dgvServicios.DataSource = Session["listaServicios"];
                dgvServicios.DataBind();
            }
        }

        protected void dgvServicios_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(dgvServicios.DataKeys[rowIndex].Value);
            if (e.CommandName == "BajaServicio")
            {
                if (!(cBoxInactivosServ.Checked))
                {
                    try
                    {
                        ServicioNegocio negocio = new ServicioNegocio();
                        negocio.bajaServicio(id);
                        dgvServicios.DataSource = negocio.Listar();
                        dgvServicios.DataBind();

                    }
                    catch (Exception ex)
                    {

                        Session.Add("error", ex.ToString());
                    }
                }
                else
                {
                    ServicioNegocio negocio = new ServicioNegocio();
                    negocio.bajaServicio(id, false);
                    dgvServicios.DataSource = negocio.Listar();
                    dgvServicios.DataBind();
                    cBoxInactivosServ.Checked = false;
                }

            }
            else if (e.CommandName == "ModifServicio")
            {
                Response.Redirect("NuevoServicio.aspx?id=" + id);
            }
            else
            {
                try
                {
                    string idS = id.ToString();
                    ServicioNegocio negocio = new ServicioNegocio();
                    Servicio serv = (negocio.ListarConID(idS))[0];
                    Session.Add("servicio", serv);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        protected void cBoxInactivosServ_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxInactivosServ.Checked)
            {
                FiltroInactivos = cBoxInactivosServ.Checked;
                ddlFiltrar.Enabled = !FiltroInactivos;
                txtBuscar.Enabled = !FiltroInactivos;

                ServicioNegocio negocio = new ServicioNegocio();
                List<Servicio> lista = new List<Servicio>();
                lista = negocio.ListarInactivos();
                dgvServicios.DataSource = lista;
                dgvServicios.DataBind();
            }
            else
            {
                FiltroInactivos = cBoxInactivosServ.Checked;
                ddlFiltrar.Enabled = !FiltroInactivos;
                txtBuscar.Enabled = !FiltroInactivos;

                dgvServicios.DataSource = Session["listaServicios"];
                dgvServicios.DataBind();
            }
        }
    }
}