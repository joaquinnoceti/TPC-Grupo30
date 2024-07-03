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
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicioNegocio negocio = new ServicioNegocio();


            Session.Add("listaServicios", negocio.Listar());

            dgvServicios.DataSource = Session["listaServicios"];
            dgvServicios.DataBind();
        }

        protected void dgvServicios_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(dgvServicios.DataKeys[rowIndex].Value);
            if (e.CommandName == "BajaServicio")
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
            else if (e.CommandName == "ModifServicio")
            {
                Response.Redirect("NuevoServicio.aspx?id=" + id);
            }
            else
            {
                try
                {
                    ServicioNegocio negocio = new ServicioNegocio();
                    Servicio serv = (negocio.ListarConID(id))[0];
                    Session.Add("servicio", serv);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }


        
    }
}