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
    public partial class PanelControlAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OrdenDeTrabajoNegocio negocio = new OrdenDeTrabajoNegocio();


                Session.Add("listaOrdenes", negocio.ListarOrdenes());

                dgvOrdenes.DataSource = Session["listaOrdenes"];
                dgvOrdenes.DataBind();
            }
        }


        protected string CalcularVencimiento(object fechaCreacion, object horasTeoricas)
        {
            DateTime fecha = Convert.ToDateTime(fechaCreacion);
            int horas = Convert.ToInt32(horasTeoricas);
            int dias = (int)Math.Ceiling(horas / 8.0);
            TimeSpan diferencia = DateTime.Now - fecha;
            return (dias - diferencia.Days).ToString();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {

        }

        protected void GridViewOrdenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int idOrden = (int)dgvOrdenes.DataKeys[index].Value;

            if (e.CommandName == "VerHistorial")
            {
                // Implementar lógica para ver historial
            }
            else if (e.CommandName == "Editar")
            {
                // Implementar lógica para editar
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void txtNroOrden_TextChanged(object sender, EventArgs e)
        {
            List<OrdenDeTrabajo> listaOr = (List<OrdenDeTrabajo>)Session["listaOrdenes"];

            List<OrdenDeTrabajo> listaFiltrada = listaOr.FindAll(x => x.ID.Equals(txtNroOrden.Text));
        }
    }
}