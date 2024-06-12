﻿using negocio;
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
            ServicioNegocio negocio = new ServicioNegocio();
            Session.Add("listaServicios", negocio.Listar());

            dgvOrdenes.DataSource = Session["listaServicios"];
            dgvOrdenes.DataBind();
        }
    }
}