using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCGrupo30
{
    public partial class NuevaOrden : System.Web.UI.Page
    {
        VehiculoNegocio negocio1 = new VehiculoNegocio();
        ClienteNegocio negocio = new ClienteNegocio();
        ServicioNegocio negocio2 = new ServicioNegocio();
        UsuarioNegocio negocio3 = new UsuarioNegocio();
        OrdenDeTrabajoNegocio negocio4 = new OrdenDeTrabajoNegocio();


        public List<Servicio> listaServiciosAgregados1 { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    List<Cliente> listaCliente = negocio.ListarDDL();

                    ddlCliente.DataSource = listaCliente;
                    ddlCliente.DataValueField = "ID";
                    ddlCliente.DataTextField = "Apellido";
                    ddlCliente.DataBind();


                    List<Vehiculo> listaVehiculos = negocio1.Listar();
                    Session["listaVehiculos"] = listaVehiculos;

                    listaServiciosAgregados1 = (List<Servicio>)Session["listaServiciosAgregados"];

                    gdvServiciosAgregados1.DataSource = listaServiciosAgregados1;
                    gdvServiciosAgregados1.DataBind();

                    List<Usuario> listaEmpleados = negocio3.Listar();

                    ddlMecanico.DataSource = listaEmpleados;
                    ddlMecanico.DataValueField = "ID";
                    ddlMecanico.DataTextField = "Apellido";
                    ddlMecanico.DataBind();

                    List<EstadoOrden> listaEstados = negocio4.ListarEstados();

                    ddlEstado.DataSource = listaEstados;
                    ddlEstado.DataValueField = "ID";
                    ddlEstado.DataTextField = "NombreEstado";
                    ddlEstado.DataBind();

                    decimal total = 0;

                    foreach (Servicio servicio in listaServiciosAgregados1)
                    {

                        total += servicio.Precio;

                    }

                    txtTotal.Text = total.ToString("N2"); // Formatear como moneda

                    
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            foreach (Servicio servicio in listaServiciosAgregados1)
            {

                    total += servicio.Precio;

            }

            txtTotal.Text = total.ToString("C"); // Formatear como moneda
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            OrdenDeTrabajo orden = new OrdenDeTrabajo();

            orden.FechaCreacion = DateTime.Parse(txtFechaEmision.Text);
            orden.Cliente.Apellido = ddlCliente.SelectedValue;
            orden.Vehiculo.NombreVehiculo = ddlVehiculo.SelectedValue;
            orden.HorasReales = int.Parse(txtReales.Text);
            orden.HorasTeoricas = int.Parse(txtTeoricas.Text);
            //orden.Servicios = listaServiciosAgregados1.Items.Cast<Servicio>.ToList();
            orden.FechaFinalizacion = DateTime.Parse(txtFechaFin.Text);
            orden.Observaciones = tbObservaciones.Text;


            decimal total = 0;

            foreach (Servicio servicio in listaServiciosAgregados1)
            {

                total += servicio.Precio;

            }

            txtTotal.Text = total.ToString("N2"); // Formatear como moneda

            orden.Total = total;
            //orden.Cobrado = btnCobradoNo.

        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int id = int.Parse(ddlCliente.SelectedItem.Value);

                ddlVehiculo.DataSource = ((List<Vehiculo>)Session["listaVehiculos"]).FindAll(x => x.IdCliente == id);
                //ddlVehiculo.DataValueField = "IDVehiculo";
                ddlVehiculo.DataTextField = "NombreVehiculo";

                ddlVehiculo.DataBind();
            } 
   
        }

        protected void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaServicio.aspx");

        }

    
  

    }
}
