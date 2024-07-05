using dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CostoNegocio
    {
        public List<Cuenta> ListarCuentas()
        {
            List<Cuenta> lista = new List<Cuenta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT ID,CodCuenta,DescripcionCuenta FROM Cuentas");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Cuenta aux = new Cuenta();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.CodCuenta = (string)datos.Lector["CodCuenta"];
                    aux.DescripcionCuenta = (string)datos.Lector["DescripcionCuenta"];

                    lista.Add(aux);

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

        public List<SubCuenta> ListarSubCuentas()
        {
            List<SubCuenta> lista = new List<SubCuenta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT ID,CodigoSubcuenta,DescripcionSubCuenta,CodCuenta FROM SubCuentas");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    SubCuenta aux = new SubCuenta();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.CodSubcuenta = (string)datos.Lector["CodigoSubcuenta"];
                    aux.DescripcionSubCuenta = (string)datos.Lector["DescripcionSubCuenta"];

                    aux.CuentaPadre = new Cuenta();
                    aux.CuentaPadre.ID = (int)datos.Lector["ID"];
                    aux.CuentaPadre.CodCuenta = (string)datos.Lector["CodCuenta"];

                    lista.Add(aux);
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

        public void altaCosto(Costo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Costos(CodigoCuenta,CodigoSubcuenta,Tipo,Asignacion,FechaCosto,Importe) VALUES (@CodigoCuenta,@CodigoSubcuenta,@Tipo,@Asignacion,@FechaCosto,@Importe)");
                datos.setearParametro("@CodigoCuenta", nuevo.CodigoCuenta.ID);              //agregar id o nombre de cuenta?
                datos.setearParametro("@CodigoSubCuenta", nuevo.CodigoSubCuenta.ID);        //agregar id o nombre de subcuenta?
                datos.setearParametro("@Tipo", nuevo.Tipo);
                datos.setearParametro("@Asignacion", nuevo.Comentarios);
                datos.setearParametro("@FechaCosto", nuevo.FechaCosto);
                datos.setearParametro("@Importe", nuevo.Importe);
                
                datos.ejecutar();
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
