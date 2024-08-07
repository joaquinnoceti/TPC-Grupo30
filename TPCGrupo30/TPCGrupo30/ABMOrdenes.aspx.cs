﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCGrupo30
{
    public partial class ABMOrdenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OrdenDeTrabajoNegocio negocio = new OrdenDeTrabajoNegocio();
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            usuario = Session["user"] as Usuario;
            if (usuario.Apellido != "ADMIN")
            {
                usuario.ID = usuarioNegocio.buscarPorApellido(usuario.Email);
                Session.Add("listaOrdenes", negocio.ListarOrdenes(usuario.ID));
            }
            else
            {
                Session.Add("listaOrdenes", negocio.ListarOrdenes());
                //negocio.ListarOrdenes();
            }
            dgvOrdenes.DataSource = Session["listaOrdenes"];
            dgvOrdenes.DataBind();
        }

        protected void dgvOrdenes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvOrdenes.PageIndex = e.NewPageIndex;
            dgvOrdenes.DataBind();
        }

        protected void dgvOrdenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvOrdenes.SelectedDataKey.Value.ToString();
            Response.Redirect("AltaOrden.aspx?ID=" + id);
        }
    }
}