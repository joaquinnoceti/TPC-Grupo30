using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TPCGrupo30
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected bool validarCampos()
        {
            if (string.IsNullOrEmpty(txtMail.Text) || string.IsNullOrEmpty(txtPass.Text))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Por favor, completar todos los campos para continuar";
                return false;
            }



            return true;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            usuario.Email = txtMail.Text;
            usuario.Contrasenia = txtPass.Text;

            if (validarCampos())
            {
                try
                {
                    if (!(negocio.UserLogin(usuario)))
                    {
                        lblError.Text = "email o password invalidos";
                        lblError.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        Session.Add("user", usuario);
                        Response.Redirect("principal.aspx");
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}