using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class OrdenDeTrabajoNegocio
    {

        public void GuardarOrden(OrdenDeTrabajoNegocio orden)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO OrdenDeTrabajo () VALUES ()");
                datos.setearParametro("@IdCliente", orden);

                //datos.ejecutarLectura();
                  
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
