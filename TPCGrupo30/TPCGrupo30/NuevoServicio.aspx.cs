using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCGrupo30
{
    public partial class NuevoServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //modificar servicio
                
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "")
                {
                    ServicioNegocio negocio = new ServicioNegocio();
                    Servicio serv = (negocio.ListarConID(id))[0];

                    txtNombreServ.Text = serv.NombreServicio;
                    txtDescripcion.Text = serv.Descripcion;
                    txtPrecio.Text = serv.Precio.ToString();

                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
                {
                    Servicio nuevo = new Servicio();
                    ServicioNegocio negocio = new ServicioNegocio();

                    nuevo.NombreServicio = txtNombreServ.Text;
                    nuevo.Descripcion = txtDescripcion.Text;
                    nuevo.Precio = decimal.Parse(txtPrecio.Text);

                 if (Request.QueryString["id"] != null)
                {
                    nuevo.ID = int.Parse(Request.QueryString["id"]);
                    negocio.modificar(nuevo);
                    Response.Redirect("ABMServicios.aspx");

                }
                else
                {
                    negocio.altaServicio(nuevo);
                    Response.Redirect("ABMServicios.aspx");
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }

        }

}   }
