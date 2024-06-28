using System;
using System.Collections.Generic;
using System.Globalization;
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
        ServicioNegocio negocio5 = new ServicioNegocio();
        public List<Servicio> listaServiciosOrden { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar la lista de servicios solo la primera vez que se carga la página
                ServiciosList = negocio.Listar();

                if (ServiciosList != null)
                {
                    ddlServicios.DataSource = ServiciosList;
                    ddlServicios.DataValueField = "ID";
                    ddlServicios.DataTextField = "NombreServicio";
                    ddlServicios.DataBind();

                    // Establecer el primer elemento como seleccionado por defecto
                    if (ddlServicios.Items.Count > 0)
                    {
                        ddlServicios.SelectedIndex = 0;
                    }
                }
                else
                {
                    // Manejar el caso en que ServiciosList sea null
                    lblServicios.Text = "No se pudo cargar la lista de servicios.";
                }

                // Cargar el GridView con los datos de la sesión si existen
                var listaServiciosAgregados = Session["listaServiciosAgregados"] as List<Servicio>;
                if (listaServiciosAgregados != null)
                {
                    gdvServiciosAgregados.DataSource = listaServiciosAgregados;
                    gdvServiciosAgregados.DataBind();
                }

                // Verificar si hay una ID en la query string para cargar los servicios de la orden de trabajo
                if (Request.QueryString["ID"] != null)
                {
                    int id = int.Parse(Request.QueryString["ID"].ToString());
                    listaServiciosOrden = negocio5.ListarOrdenesServicios(id);
                    if (listaServiciosOrden != null)
                    {
                        gdvServiciosAgregados.DataSource = listaServiciosOrden;
                        gdvServiciosAgregados.DataBind();
                        // Guardar la lista en la sesión
                        Session["listaServiciosAgregados"] = listaServiciosOrden;
                    }
                }
            }

        }



        protected void btnAgregarOT_Click(object sender, EventArgs e)
        {

            int id;
            if (int.TryParse(Request.QueryString["ID"], out id))
            {
                Response.Redirect("AltaOrden.aspx?ID=" + id);
            }
            else
            {
                Response.Redirect("AltaOrden.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ServiciosList = negocio.Listar();
            // Obtener y actualizar la lista de servicios agregados en la sesión
            List<Servicio> listaServiciosAgregados = Session["listaServiciosAgregados"] as List<Servicio>;
            if (listaServiciosAgregados == null)
            {
                listaServiciosAgregados = new List<Servicio>();
            }

            // Agregar el servicio seleccionado a la lista de servicios agregados
            int servicioID = Convert.ToInt32(ddlServicios.SelectedValue);
            if (ServiciosList != null)
            {
                Servicio servicio = ServiciosList.FirstOrDefault(s => s.ID == servicioID);
                if (servicio != null && !listaServiciosAgregados.Any(s => s.ID == servicioID))
                {
                    listaServiciosAgregados.Add(servicio);
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