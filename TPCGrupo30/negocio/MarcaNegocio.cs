using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class MarcaNegocio
    {

        public List<Marca> Listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT ID, NombreMarca FROM MARCAS");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();
                    marca.ID = (int)datos.Lector["id"];
                    marca.NombreMarca = (string)datos.Lector["NombreMarca"];

                    lista.Add(marca);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

    }
}
