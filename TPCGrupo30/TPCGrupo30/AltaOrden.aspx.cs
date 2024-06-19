﻿using negocio;
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
                    ddlVehiculo.DataValueField = "IDVehiculo";
                    ddlVehiculo.DataTextField = "NombreVehiculo";
                    ddlVehiculo.DataBind();

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
            OrdenDeTrabajoNegocio negocio = new OrdenDeTrabajoNegocio();    
            try
            {
                if (string.IsNullOrEmpty(txtFechaEmision.Text) || string.IsNullOrEmpty(ddlCliente.SelectedItem.Value) ||
                    string.IsNullOrEmpty(ddlVehiculo.SelectedItem.Value) || string.IsNullOrEmpty(ddlMecanico.SelectedItem.Value) ||
                    string.IsNullOrEmpty(ddlEstado.SelectedItem.Value))
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
                est.ID = int.Parse(ddlEstado.SelectedItem.Value);
                est.NombreEstado = ddlEstado.SelectedItem.Text;
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

        protected void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaServicio.aspx");

        }

    
  

    }
}
