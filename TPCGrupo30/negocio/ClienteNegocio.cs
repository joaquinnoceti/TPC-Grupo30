﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;

namespace negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT c.ID,c.Nombre,c.Apellido,c.Email,c.DNI,c.Telefono,c.FechaNac,c.Direccion,v.ID as IDVehiculo,v.Patente FROM Clientes c, Vehiculos v WHERE v.IdCliente = c.ID");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {

                    Cliente aux = new Cliente();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.DNI = (int)datos.Lector["DNI"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.FechaNac = (DateTime)datos.Lector["FechaNac"];
                    aux.Direccion = (string)datos.Lector["Direccion"];

                    aux.Vehiculo = new Vehiculo();
                    aux.Vehiculo.ID = (int)datos.Lector["IDVehiculo"];
                    aux.Vehiculo.Patente = (string)datos.Lector["Patente"];


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
        public void altaCliente(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spAltaCliente");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@DNI", nuevo.DNI);
                datos.setearParametro("@Telefono", nuevo.Telefono);
                datos.setearParametro("@FechaNac", nuevo.FechaNac);
                datos.setearParametro("@Direccion", nuevo.Direccion);

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

        public void bajaCliente(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                DialogResult rta = MessageBox.Show("Eliminar Cliente?", "Cliente Eliminado.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (rta == DialogResult.Yes)
                {
                    datos.setearConsulta("DELETE FROM CLIENTES WHERE CODIGO = @ID");
                    datos.setearParametro("@ID", id);
                    datos.ejecutarConsulta();
                }
                else
                {
                    return;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
