using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ModeloNegocio
    {
        public List<Modelo> Listar(string id = "")
        {
            List<Modelo> list = new List<Modelo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT MO.ID, MO.IDMARCA, MO.NOMBREMODELO, MA.NOMBREMARCA  FROM MODELOS MO JOIN MARCAS MA ON (MO.IDMARCA = MA.ID)");
                if (id != "")
                    datos.setearConsulta("SELECT MO.ID, MO.IDMARCA, MO.NOMBREMODELO, MA.NOMBREMARCA  FROM MODELOS MO JOIN MARCAS MA ON (MO.IDMARCA = MA.ID) WHERE MO.IDMARCA = " + int.Parse(id));
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Modelo mo = new Modelo();
                    Marca ma = new Marca();
                    mo.ID = (int)datos.Lector["ID"];
                    mo.NombreModelo = (string)datos.Lector["NombreModelo"];
                    ma.ID = (int)datos.Lector["IDMARCA"];
                    ma.NombreMarca = (string)datos.Lector["NombreMarca"];
                    mo.Marca = ma;

                    list.Add(mo);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
