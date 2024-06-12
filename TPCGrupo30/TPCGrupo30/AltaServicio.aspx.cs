using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPCGrupo30
{
    public partial class AltaServicio : System.Web.UI.Page
    {
        public List<Servicio> ServiciosList { get; set; }
        ServicioNegocio negocio = new ServicioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                // Cargar la lista de servicios solo la primera vez que se carga la página
                ServiciosList = negocio.Listar();
                lbServicios.DataSource = ServiciosList;
                lbServicios.DataValueField = "ID";
                lbServicios.DataTextField = "NombreServicio";
                lbServicios.DataBind();
            }

        }

 

        protected void btnAgregarOT_Click(object sender, EventArgs e)
        {

        }

        protected void lbServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbServicios.SelectedItem != null)
            {
                // Obtener y actualizar la lista de servicios agregados en la sesión
                List<Servicio> listaServiciosAgregados = Session["listaServiciosAgregados"] as List<Servicio>;
            if (listaServiciosAgregados == null)
            {
                listaServiciosAgregados = new List<Servicio>();
            }

            // Obtener el ListBox
            ListBox lbServicios = (ListBox)sender;

            // Agregar los servicios seleccionados a la lista de servicios agregados
            foreach (ListItem item in lbServicios.Items)
            {
                if (item.Selected)
                {
                    int servicioID = Convert.ToInt32(item.Value);
                    Servicio servicio = ServiciosList.FirstOrDefault(s => s.ID == servicioID);
                    if (servicio != null && !listaServiciosAgregados.Contains(servicio))
                    {
                        listaServiciosAgregados.Add(servicio);
                    }
                }
            }

            // Actualizar la lista de servicios agregados en la sesión
            Session["listaServiciosAgregados"] = listaServiciosAgregados;

            // Enlazar el GridView con la lista de servicios agregados
            gdvServiciosAgregados.DataSource = listaServiciosAgregados;
            gdvServiciosAgregados.DataBind();
            }
        }
    }
}