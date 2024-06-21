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
    public partial class ListadoVehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listado();
            }

        }

        protected void dgvVehiculo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(dgvVehiculo.DataKeys[rowIndex].Value);

            if (e.CommandName == "Baja")
            {
                try
                {
                    VehiculoNegocio negocio = new VehiculoNegocio();
                    negocio.BajaVehiculo(id);
                    listado();

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else if (e.CommandName == "Detalle")
            {
                Response.Redirect("AltaVehiculo.aspx?idV=" + id);
            }

        }

        public void listado()
        {
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "")
            {
                VehiculoNegocio negocio = new VehiculoNegocio();
                ClienteNegocio Clinegocio = new ClienteNegocio();
                List<ClientexVehiculo> listadoCV = new List<ClientexVehiculo>();
                List<Vehiculo> listadoVehiculo = negocio.ListarxID(id);
                List<Cliente> listadoCliente = Clinegocio.Listar(id);

                foreach (var cliente in listadoCliente)
                {
                    foreach (var vehiculos in listadoVehiculo)
                    {
                        if (cliente.ID == vehiculos.IdCliente)
                        {
                            listadoCV.Add(new ClientexVehiculo
                            {
                                IDCliente = cliente.ID,
                                IDVehiculo = vehiculos.IDVehiculo,
                                NombreCli = cliente.Nombre + " " + cliente.Apellido,
                                Marca = vehiculos.Marca.NombreMarca + " " + vehiculos.Modelo.NombreModelo + " " + vehiculos.Anio,
                                Patente = vehiculos.Patente
                            });
                        }
                    }
                    Label1.Font.Size = 50;
                    Label1.Text = "Vehiculos del cliente: " + cliente.Nombre + " " + cliente.Apellido;

                }
                dgvVehiculo.DataSource = listadoCV;
                dgvVehiculo.DataBind();
            }
        }

    }
}