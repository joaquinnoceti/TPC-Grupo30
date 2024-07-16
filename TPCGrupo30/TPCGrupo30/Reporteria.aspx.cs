using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
using static System.Collections.Specialized.BitVector32;

namespace TPCGrupo30
{
    public partial class Reporteria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OrdenDeTrabajoNegocio ordenNegocio = new OrdenDeTrabajoNegocio();
            CostoNegocio costoNegocio = new CostoNegocio();
            List<Costo> listaCosto = new List<Costo>();
            List<OrdenDeTrabajo> listaOrden = new List<OrdenDeTrabajo>();
            try
            {
                ///listado de costos con fecha de mes actual
                listaCosto = costoNegocio.ListarCostosMensuales();
                Session.Add("listaCostos", listaCosto);
                dgvCostos.DataSource = Session["listaCostos"];
                dgvCostos.DataBind();
                ///calculo total mensual
                decimal costoMensual = 0;
                foreach (Costo costo in listaCosto)
                {
                    costoMensual += costo.Importe;
                }
                lblCosto.Text = "Total: $" + costoMensual.ToString("N2");


                ///listado de OT con fecha de mes actual y en estado Facturado
                listaOrden = ordenNegocio.ListarOrdenesMensuales();
                Session.Add("listaOrdenes", listaOrden);
                dgvOrdenes.DataSource = Session["listaOrdenes"];
                dgvOrdenes.DataBind();
                ///calculo total mensual
                decimal importeOTMensual = 0;
                foreach (OrdenDeTrabajo orden in listaOrden)
                {
                    importeOTMensual += orden.Total;
                }
                lblOT.Text = "Total: $" + importeOTMensual.ToString("N2");
                decimal rentabilidad = importeOTMensual - costoMensual;
                lblRentabilidad.Text = "Rentabilidad del mes: $" + rentabilidad.ToString("N2");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}