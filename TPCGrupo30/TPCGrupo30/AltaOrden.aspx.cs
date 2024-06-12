﻿using negocio;
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

                    List<Servicio> listaServicios = negocio2.Listar();

                    lbServicios.DataSource = listaServicios;
                    lbServicios.DataValueField = "ID";
                    lbServicios.DataTextField = "NombreServicio";
                    lbServicios.DataBind();



                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            OrdenDeTrabajo orden = new OrdenDeTrabajo();

            orden.FechaCreacion = DateTime.Parse(txtFechaEmision.Text);
            orden.Cliente.Apellido = ddlCliente.SelectedValue;
            orden.Vehiculo.NombreVehiculo = ddlVehiculo.SelectedValue;
            orden.HorasReales = int.Parse(txtReales.Text);
            orden.HorasTeoricas = int.Parse(txtTeoricas.Text);
            //orden.Servicios = lbServicios.Items.Cast<Servicio>.ToList();






        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int id = int.Parse(ddlCliente.SelectedItem.Value);

                ddlVehiculo.DataSource = ((List<Vehiculo>)Session["listaVehiculos"]).FindAll(x => x.IdCliente.ID == id);
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
