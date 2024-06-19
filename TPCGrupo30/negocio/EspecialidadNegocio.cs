using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class EspecialidadNegocio
    {
        public List<Especialidad> Listar()
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT ID, NombreEspecialidad FROM Especialidades");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Especialidad esp = new Especialidad();
                    esp.ID = (int)datos.Lector["ID"];
                    esp.NombreEspecialidad = (string)datos.Lector["NombreEspecialidad"];

                    lista.Add(esp);
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
