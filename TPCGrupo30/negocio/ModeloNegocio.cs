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
                datos.setearConsulta("SELECT ID,IDMARCA,NOMBREMODELO FROM MODELOS");
                    if(id != "")
                    datos.setearConsulta("SELECT MO.ID,MO.IDMARCA,MO.NOMBREMODELO FROM MODELOS MO JOIN MARCAS MA ON (MO.IDMARCA = MA.ID) WHERE MO.IDMARCA = " + int.Parse(id));
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Modelo mo = new Modelo();
                    Marca ma = new Marca();
                    mo.ID = (int)datos.Lector["ID"];
                    mo.Marca.ID = (int)datos.Lector["IDMARCA"];
                    mo.NombreModelo = (string)datos.Lector["NombreModelo"];
                    

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
