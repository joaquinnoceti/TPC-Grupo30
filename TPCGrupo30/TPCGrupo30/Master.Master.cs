using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TPCGrupo30
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Default))
            {
                if (!Seguridad.sesionActiva(Session["user"]))
                    Response.Redirect("login.aspx");
            }
            
        }
    }
}