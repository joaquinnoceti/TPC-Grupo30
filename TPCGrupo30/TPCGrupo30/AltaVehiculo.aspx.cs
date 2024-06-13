﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPCGrupo30
{
    public partial class AltaVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                ClienteNegocio negocioCli = new ClienteNegocio();
                Cliente cli = (negocioCli.Listar(id))[0];

                lblNombreCli.Text = "Cliente: " + cli.Nombre + " " + cli.Apellido;

                MarcaNegocio marcaNegocio = new MarcaNegocio();
                List<Marca> ListaMarca = marcaNegocio.Listar();
                ddlMarca.DataSource = ListaMarca;
                ddlMarca.DataValueField = "ID";
                ddlMarca.DataTextField = "NombreMarca";
                ddlMarca.DataBind();


                ModeloNegocio modeloNegocio = new ModeloNegocio();
                List<Modelo> ListaModelo = modeloNegocio.Listar();
                Session["listaModelos"] = ListaModelo;
                ddlModelo.DataSource = ListaModelo;
                ddlModelo.DataValueField = "ID";
                ddlModelo.DataTextField = "NombreModelo";
                ddlModelo.DataBind();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Vehiculo nuevo = new Vehiculo();
                VehiculoNegocio negocio = new VehiculoNegocio();





            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                int id = int.Parse(ddlMarca.SelectedItem.Value);
                ddlModelo.DataSource = ((List<Modelo>)Session["listaModelos"]).FindAll(x => x.Marca.ID == id);
                ddlModelo.DataValueField = "ID";
                ddlModelo.DataTextField = "NombreModelo";
                ddlModelo.DataBind();

            }
        }
    }
}