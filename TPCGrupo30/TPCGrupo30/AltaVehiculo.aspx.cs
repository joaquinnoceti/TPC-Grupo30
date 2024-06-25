using System;
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
            string idCli = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            string idVeh = Request.QueryString["idV"] != null ? Request.QueryString["idV"].ToString() : "";
            if (!IsPostBack)
            {
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

                if (idCli != "")
                {
                    ClienteNegocio negocioCli = new ClienteNegocio();
                    Cliente cli = (negocioCli.Listar(idCli))[0];
                    Session.Add("ClienteAVehiculo", cli);
                    lblNombreCli.Text = "Registrar vehiculo a Cliente: " + cli.Nombre + " " + cli.Apellido;

                }
                else if (idVeh != "")
                {

                    AccesoDatos datos = new AccesoDatos();
                    lblNombreCli.Text = "Modificar Vehiculo";
                    try
                    {
                        VehiculoNegocio negocio = new VehiculoNegocio();
                        Vehiculo modificar = (negocio.ListarxID(idVeh))[0];
                        ddlMarca.SelectedValue = modificar.Marca.ID.ToString();
                        ddlModelo.SelectedValue = modificar.Modelo.ID.ToString();
                        txtAño.Text = modificar.Anio.ToString();
                        txtPatente.Text = modificar.Patente.ToString();
                        ddlTipoVehiculo.SelectedValue = modificar.TipoVehiculo.ToString();


                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }

                }


            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarCampos())
                {
                    Vehiculo nuevo = new Vehiculo();
                    VehiculoNegocio negocio = new VehiculoNegocio();
                    Cliente cliente = Session["ClienteAVehiculo"] != null ? (Cliente)Session["ClienteAVehiculo"] : (Cliente)Session["cliente"];

                    nuevo.IdCliente = cliente.ID;

                    Marca marca = new Marca();
                    marca.ID = int.Parse(ddlMarca.SelectedValue);
                    marca.NombreMarca = ddlMarca.SelectedItem.ToString();
                    nuevo.Marca = marca;

                    Modelo modelo = new Modelo();
                    modelo.ID = int.Parse(ddlModelo.SelectedValue);
                    modelo.NombreModelo = ddlModelo.SelectedItem.ToString();
                    nuevo.Modelo = modelo;

                    nuevo.Anio = int.Parse(txtAño.Text);
                    nuevo.Patente = txtPatente.Text;
                    nuevo.NombreVehiculo = ddlModelo.SelectedItem.ToString() + " " + txtPatente.Text;
                    nuevo.TipoVehiculo = ddlTipoVehiculo.SelectedItem.ToString();

                    if (Session["cliente"] != null)
                    {
                        nuevo.IDVehiculo = int.Parse(Request.QueryString["idV"]);
                        negocio.ModificarVehiculo(nuevo);
                    }
                    else
                    {
                        if (!(negocio.AltaVehiculo(nuevo)))
                        {
                            lblError.Text = "El numero de patente ya se encuentra registrado";
                            lblError.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                    }

                    Response.Redirect("ABMClientes.aspx",false);

                }
            }
            catch (Exception ex)
            {

                throw ex;
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

        protected bool validarCampos()
        {
            if (string.IsNullOrEmpty(ddlMarca.SelectedItem.Value) || string.IsNullOrEmpty(ddlModelo.SelectedItem.Value) || string.IsNullOrEmpty(txtAño.Text)
                || string.IsNullOrEmpty(txtPatente.Text) || string.IsNullOrEmpty(ddlTipoVehiculo.SelectedItem.Value))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Por favor, completar todos los campos para continuar";
                return false;
            }
            return true;
        }

    }
}