﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using dominio;
using negocio;

namespace TPCGrupo30
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!Seguridad.EsAdmin(Session["user"]))
            //{
            //    MessageBox.Show("No hay permisos d admin");
            //}
        }
    }
}