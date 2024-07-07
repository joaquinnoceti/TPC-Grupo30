using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TPCGrupo30
{
    public partial class AltaOrden : System.Web.UI.Page
    {
        VehiculoNegocio negocio1 = new VehiculoNegocio();
        ClienteNegocio negocio = new ClienteNegocio();
        ServicioNegocio negocio2 = new ServicioNegocio();
        UsuarioNegocio negocio3 = new UsuarioNegocio();
        OrdenDeTrabajoNegocio negocio4 = new OrdenDeTrabajoNegocio();
        ServicioNegocio negocio5 = new ServicioNegocio();

        public List<Servicio> listaServiciosOrden { get; set; }
        public List<Servicio> listaServiciosAgregados1 { get; set; }

        public List<Servicio> listaServiciosAgregados2 { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    // Cargar datos iniciales
                    CargarDatosIniciales();

                    // Verificar si hay un ID en la consulta
                    if (Request.QueryString["ID"] != null)
                    {
                        int idOrden = int.Parse(Request.QueryString["ID"].ToString());
                        CargarDatosOrden(idOrden);
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        private void CargarDatosIniciales()
        {
            // Cargar lista de clientes
            List<Cliente> listaCliente = negocio.ListarDDL();
            ddlCliente.DataSource = listaCliente;
            ddlCliente.DataValueField = "ID";
            ddlCliente.DataTextField = "Apellido";
            ddlCliente.DataBind();

            // Cargar lista de vehiculos
            List<Vehiculo> listaVehiculos = negocio1.Listar();
            Session["listaVehiculos"] = listaVehiculos;
            ddlVehiculo.DataSource = listaVehiculos;
            ddlVehiculo.DataValueField = "IDVehiculo";
            ddlVehiculo.DataTextField = "NombreVehiculo";
            ddlVehiculo.DataBind();

            // Cargar servicios agregados
            listaServiciosAgregados1 = (List<Servicio>)Session["listaServiciosAgregados"];
            gdvServiciosAgregados1.DataSource = listaServiciosAgregados1;
            gdvServiciosAgregados1.DataBind();

            // Cargar lista de empleados
            List<Usuario> listaEmpleados = negocio3.Listar();
            ddlMecanico.DataSource = listaEmpleados;
            ddlMecanico.DataValueField = "ID";
            ddlMecanico.DataTextField = "Apellido";
            ddlMecanico.DataBind();

            // Cargar lista de estados
            //List<EstadoOrden> listaEstados = negocio4.ListarEstados();
            //ddlEstado.DataSource = listaEstados;
            //ddlEstado.DataValueField = "ID";
            //ddlEstado.DataTextField = "NombreEstado";
            //ddlEstado.DataBind();

            // Calcular el total inicial
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            if (Request.QueryString["ID"] != null)
            {
                int idOrden = int.Parse(Request.QueryString["ID"].ToString());
                listaServiciosOrden = negocio5.ListarOrdenesServicios(idOrden);
                foreach (Servicio servicio in listaServiciosOrden)
                {
                    total += servicio.Precio;
                }
            }
            else
            {
                foreach (Servicio servicio in listaServiciosAgregados1)
                {
                    total += servicio.Precio;
                }
            }
            txtTotal.Text = total.ToString("N2"); // Formatear como moneda
        }

        private void CargarDatosOrden(int id)
        {
            // Obtener la orden de trabajo
            OrdenDeTrabajoNegocio negocio = new OrdenDeTrabajoNegocio();
            List<OrdenDeTrabajo> listaOrdenes = negocio.ListarOrdenes();
            OrdenDeTrabajo seleccionado = listaOrdenes.Find(x => x.ID == id);

            if (seleccionado != null)
            {
                txtFechaEmision.Text = seleccionado.FechaCreacion.ToString("yyyy-MM-dd");
                txtFechaEmision.ReadOnly = true;

                txtCliente.Text = seleccionado.Cliente.Apellido.ToString();
                txtCliente.ReadOnly = true;

                txtVehiculo.Text = seleccionado.Vehiculo.NombreVehiculo;
                txtVehiculo.ReadOnly = true;

                txtReales.Text = seleccionado.HorasReales.ToString();
                txtTeoricas.Text = seleccionado.HorasTeoricas.ToString();
                tbObservaciones.Text = seleccionado.Observaciones.ToString();
                txtFechaFin.Text = seleccionado.FechaFinalizacion.ToString("yyyy-MM-dd");
                txtTotal.Text = seleccionado.Total.ToString("N2");

                ddlMecanico.SelectedValue = seleccionado.Mecanico.ID.ToString();
                //ddlEstado.SelectedValue = seleccionado.Estado.ID.ToString();
                txtEstado.Text = seleccionado.Estado.NombreEstado;

                rdbSi.Checked = seleccionado.Cobrado;
                rdbNo.Checked = !seleccionado.Cobrado;

                // Actualizar servicios agregados
                if (Session["listaServiciosAgregados"] != null)
                {
                    listaServiciosOrden = (List<Servicio>)Session["listaServiciosAgregados"];
                }
                else
                {
                    listaServiciosOrden = negocio5.ListarOrdenesServicios(id);
                    Session["listaServiciosAgregados"] = listaServiciosOrden;
                }

                decimal total = 0;

                foreach (Servicio servicio in listaServiciosOrden)
                {

                    total += servicio.Precio;

                }

                txtTotal.Text = total.ToString("N2"); // Formatear como moneda


                gdvServiciosAgregados2.DataSource = listaServiciosOrden;
                gdvServiciosAgregados2.DataBind();


            }
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            OrdenDeTrabajoNegocio negocio = new OrdenDeTrabajoNegocio();    
            try
            {
                if (string.IsNullOrEmpty(txtFechaEmision.Text) || string.IsNullOrEmpty(ddlCliente.SelectedItem.Value) ||
                    string.IsNullOrEmpty(ddlVehiculo.SelectedItem.Value) || string.IsNullOrEmpty(ddlMecanico.SelectedItem.Value)) //||
                    //string.IsNullOrEmpty(ddlEstado.SelectedItem.Value))
                {
                    lblError.Text = "Por favor, complete todos los campos obligatorios.";
                    return;
                }

                // Formatos esperados de las fechas
                string[] formatosFecha = { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd" }; // Ajusta los formatos según tus necesidades

                // Validar fecha de creación
                DateTime fechaCreacion;
                if (!DateTime.TryParseExact(txtFechaEmision.Text, formatosFecha, null, System.Globalization.DateTimeStyles.None, out fechaCreacion))
                {
                    lblError.Text = "La fecha de emisión no tiene un formato válido.";
                    return;
                }

                // Validar y asignar fecha de finalización
                DateTime fechaFinalizacion;
                if (string.IsNullOrEmpty(txtFechaFin.Text))
                {
                    fechaFinalizacion = new DateTime(2999, 1, 1);
                }
                else if (!DateTime.TryParseExact(txtFechaFin.Text, formatosFecha, null, System.Globalization.DateTimeStyles.None, out fechaFinalizacion))
                {
                    lblError.Text = "La fecha de finalización no tiene un formato válido.";
                    return;
                }

                if (fechaFinalizacion < fechaCreacion)
                {
                    lblError.Text = "La fecha de finalización no puede ser anterior a la fecha de creación.";
                    return;
                }


                OrdenDeTrabajo orden = new OrdenDeTrabajo();

                orden.FechaCreacion = fechaCreacion;

                Cliente cli = new Cliente();
                cli.ID = int.Parse(ddlCliente.SelectedItem.Value);
                cli.Apellido = ddlCliente.SelectedItem.Text;
                orden.Cliente = cli;

                Vehiculo ve = new Vehiculo();
                ve.IDVehiculo = int.Parse(ddlVehiculo.SelectedItem.Value);
                ve.NombreVehiculo = ddlVehiculo.SelectedItem.Text;
                orden.Vehiculo = ve;

                Usuario em = new Usuario();
                em.ID = int.Parse(ddlMecanico.SelectedItem.Value);
                em.Apellido = ddlMecanico.SelectedItem.Text;
                orden.Mecanico = em;

                EstadoOrden est = new EstadoOrden();
                est.ID = 1;
                est.NombreEstado = "Pendiente";
                orden.Estado = est;

                orden.HorasTeoricas = int.Parse(txtTeoricas.Text);

                // Validar y asignar HorasReales
                if (string.IsNullOrEmpty(txtReales.Text))
                {
                    orden.HorasReales = 0;
                }
                else
                {
                    orden.HorasReales = int.Parse(txtReales.Text);
                }


                orden.FechaFinalizacion = fechaFinalizacion;
                orden.Observaciones = tbObservaciones.Text;


                List<Servicio> listaServiciosAgregados = (List<Servicio>)Session["listaServiciosAgregados"];
                orden.Servicios = listaServiciosAgregados;


                decimal total = 0;

                foreach (Servicio servicio in listaServiciosAgregados)
                {

                    total += servicio.Precio;

                }

                txtTotal.Text = total.ToString("N2"); // Formatear como moneda

                orden.Total = total;

                if (rdbSi.Checked)
                {
                    orden.Cobrado = true;
                }
                else if (rdbNo.Checked)
                {
                    orden.Cobrado = false;
                }

                negocio.GuardarOrden(orden);
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al guardar la orden de trabajo. Por favor, inténtelo de nuevo.";
                throw ex;
            }
            

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


        protected void btnModificarServicios_Click(object sender, EventArgs e)
        {
            int idOrden = int.Parse(Request.QueryString["ID"].ToString()); 

            Response.Redirect("AltaServicio.aspx?ID=" + idOrden);

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            OrdenDeTrabajoNegocio negocio = new OrdenDeTrabajoNegocio();

            OrdenDeTrabajo ordenMod = new OrdenDeTrabajo();

            DateTime fechaFinalizacion;
            string[] formatosFecha = { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd" };

            if (!DateTime.TryParseExact(txtFechaFin.Text, formatosFecha, null, System.Globalization.DateTimeStyles.None, out fechaFinalizacion))
            {
                lblError.Text = "La fecha de finalización no tiene un formato válido.";
                return;
            }

            int idOrden = int.Parse(Request.QueryString["ID"].ToString());

            try
            {
                ordenMod.ID = idOrden;
                ordenMod.HorasReales = int.Parse(txtReales.Text);             
                ordenMod.HorasTeoricas = int.Parse(txtTeoricas.Text);
                ordenMod.Observaciones = tbObservaciones.Text;
                ordenMod.FechaFinalizacion = fechaFinalizacion;
               
              
                Usuario em = new Usuario();
                em.ID = int.Parse(ddlMecanico.SelectedItem.Value);
                em.Apellido = ddlMecanico.SelectedItem.Text;
                ordenMod.Mecanico = em;

                EstadoOrden est = new EstadoOrden();
                //est.ID = int.Parse(ddlEstado.SelectedItem.Value);
                est.NombreEstado = txtEstado.Text;
                ordenMod.Estado = est;

                List<Servicio> listaServiciosAgregados = (List<Servicio>)Session["listaServiciosAgregados"];
                ordenMod.Servicios = listaServiciosAgregados;

                decimal total = listaServiciosAgregados.Sum(servicio => servicio.Precio);
                txtTotal.Text = total.ToString("N2"); // Formatear como moneda
                ordenMod.Total = total;

                ordenMod.Cobrado = rdbSi.Checked; 


                negocio.ModificarOrden(ordenMod);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void btnAvanzarEstado_Click(object sender, EventArgs e)
        {
            OrdenDeTrabajoNegocio negocio = new OrdenDeTrabajoNegocio();
            OrdenDeTrabajo ordenMod = new OrdenDeTrabajo();
            DateTime fechaFinalizacion;
            string[] formatosFecha = { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd" };

            if (!DateTime.TryParseExact(txtFechaFin.Text, formatosFecha, null, System.Globalization.DateTimeStyles.None, out fechaFinalizacion))
            {
                lblError.Text = "La fecha de finalización no tiene un formato válido.";
                return;
            }
            int idOrden = int.Parse(Request.QueryString["ID"].ToString());
            try
            {
                ordenMod.ID = idOrden;
                ordenMod.HorasReales = int.Parse(txtReales.Text);
                ordenMod.HorasTeoricas = int.Parse(txtTeoricas.Text);
                ordenMod.Observaciones = tbObservaciones.Text;
                ordenMod.FechaFinalizacion = fechaFinalizacion;


                Usuario em = new Usuario();
                em.ID = int.Parse(ddlMecanico.SelectedItem.Value);
                em.Apellido = ddlMecanico.SelectedItem.Text;
                ordenMod.Mecanico = em;

                EstadoOrden est = new EstadoOrden();
                est.ID = negocio.ObtenerIDEstado(txtEstado.Text);
                est.NombreEstado = negocio.ObtenerNombreEstado(est.ID);
                est.ID++;
                ordenMod.Estado = est;

                List<Servicio> listaServiciosAgregados = (List<Servicio>)Session["listaServiciosAgregados"];
                ordenMod.Servicios = listaServiciosAgregados;

                decimal total = listaServiciosAgregados.Sum(servicio => servicio.Precio);
                txtTotal.Text = total.ToString("N2"); // Formatear como moneda
                ordenMod.Total = total;

                ordenMod.Cobrado = rdbSi.Checked;
                
                negocio.ModificarOrden(ordenMod);
            }
            catch (Exception)
            {

                throw;
            }
            Response.Redirect("ABMOrdenes.aspx");
        }
    }
}
