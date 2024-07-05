using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCGrupo30
{
    public partial class AltaGasto : System.Web.UI.Page
    {
        CostoNegocio negocio = new CostoNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<Cuenta> listaCuentas = negocio.ListarCuentas();

                ddlCuenta.DataSource = listaCuentas;
                ddlCuenta.DataValueField = "CodCuenta";
                ddlCuenta.DataTextField = "DescripcionCuenta";
                ddlCuenta.DataBind();

                ddlCuenta.Items.Insert(0, new ListItem("--Selecciona una cuenta--", ""));

                List<SubCuenta> listaSubCuentas = negocio.ListarSubCuentas();
                Session["listaSubCuentas"] = listaSubCuentas;

            }

        }

        protected void ddlCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string codCuentaSeleccionada = ddlCuenta.SelectedValue;

                if (!string.IsNullOrEmpty(codCuentaSeleccionada))
                {
                    List<SubCuenta> listaSubCuentas = (List<SubCuenta>)Session["listaSubCuentas"];
                    List<SubCuenta> subCuentasFiltradas = listaSubCuentas
                        .Where(subCuenta => subCuenta.CuentaPadre.CodCuenta == codCuentaSeleccionada)
                        .ToList();

                    ddlSubCuenta.DataSource = subCuentasFiltradas;
                    ddlSubCuenta.DataValueField = "ID";
                    ddlSubCuenta.DataTextField = "DescripcionSubCuenta";
                    ddlSubCuenta.DataBind();

                    // Añadir un ítem inicial (opcional)
                    ddlSubCuenta.Items.Insert(0, new ListItem("--Selecciona una subcuenta--", ""));
                }
                else
                {
                    // Limpiar ddlSubCuenta si no se seleccionó ninguna cuenta válida
                    ddlSubCuenta.Items.Clear();
                    ddlSubCuenta.Items.Insert(0, new ListItem("--Selecciona una subcuenta--", ""));
                }

            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                try
                {
                    Costo nuevo = new Costo();
                    CostoNegocio negocio = new CostoNegocio();

                    Cuenta cuent = new Cuenta();
                    cuent.ID = int.Parse(ddlCuenta.SelectedItem.Value);
                    cuent.DescripcionCuenta = ddlCuenta.SelectedItem.Text;
                    nuevo.CodigoCuenta = cuent;

                    SubCuenta scuent = new SubCuenta();
                    scuent.ID = int.Parse(ddlSubCuenta.SelectedItem.Value);
                    scuent.DescripcionSubCuenta = ddlSubCuenta.SelectedItem.Text;
                    nuevo.CodigoSubCuenta = scuent;

                    nuevo.Tipo = txtTipo.Text;
                    nuevo.Comentarios = txtAsignacion.Text;
                    nuevo.FechaCosto = DateTime.Parse(txtFechaEmision.Text);
                    nuevo.Importe = decimal.Parse(txtImporte.Text);

                    negocio.altaCosto(nuevo);
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                }
                lblError.Text = "Agregado con exito!";
                lblError.ForeColor = System.Drawing.Color.Green;
            }

        }

        protected bool validarCampos()
        {
            if (string.IsNullOrEmpty(txtAsignacion.Text) || string.IsNullOrEmpty(txtFechaEmision.Text) || string.IsNullOrEmpty(txtImporte.Text)
                || string.IsNullOrEmpty(txtTipo.Text) || string.IsNullOrEmpty(ddlCuenta.SelectedItem.Value) || string.IsNullOrEmpty(ddlSubCuenta.SelectedItem.Value))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Por favor, completar todos los campos para continuar";
                return false;
            }
            return true;
        }


    }
}