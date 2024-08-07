﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace negocio
{
    public class ServicioNegocio
    {

        public List<Servicio> Listar()
        {
            List<Servicio> lista = new List<Servicio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT ID,NombreServicio,Descripcion,Precio,EstadoServicio FROM Servicios WHERE EstadoServicio = 1");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Servicio aux = new Servicio();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.NombreServicio = (string)datos.Lector["NombreServicio"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.EstadoServicio = (bool)datos.Lector["EstadoServicio"];

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

        public List<Servicio> ListarOrdenesServicios(int id)
        {
            List<Servicio> lista = new List<Servicio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT os.IdOrden,s.ID,s.NombreServicio,s.Descripcion,s.Precio FROM OrdenServicio os INNER JOIN OrdenDeTrabajo o ON os.IdOrden=o.ID INNER JOIN Servicios s ON os.IdServicio=s.ID WHERE os.IdOrden=" + id);
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Servicio aux = new Servicio();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.NombreServicio = (string)datos.Lector["NombreServicio"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];


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

        public List<Servicio> ListarConID(string id)
        {
            List<Servicio> lista = new List<Servicio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT ID,NombreServicio,Descripcion,Precio,EstadoServicio FROM Servicios where ID = " + int.Parse(id));
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Servicio aux = new Servicio();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.NombreServicio = (string)datos.Lector["NombreServicio"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.EstadoServicio = (bool)datos.Lector["EstadoServicio"];

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

        public void altaServicio(Servicio nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Servicios(NombreServicio, Descripcion, Precio,EstadoServicio) VALUES( @NombreServicio, @Descripcion, @Precio, 1)");
                datos.setearParametro("@NombreServicio", nuevo.NombreServicio);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Precio", nuevo.Precio);
       

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

        public void modificar(Servicio serv)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Servicios SET NombreServicio=@NombreServicio, Descripcion=@Descripcion, Precio=@Precio WHERE ID=@ID");
                datos.setearParametro("NombreServicio", serv.NombreServicio);
                datos.setearParametro("@Descripcion", serv.Descripcion);
                datos.setearParametro("@Precio", serv.Precio);
                datos.setearParametro("@ID", serv.ID);
                datos.ejecutarConsulta();

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

        public void bajaServicio(int id, bool EstadoServicio = true)
        {
            AccesoDatos datos = new AccesoDatos();

            if (EstadoServicio == true)
            {
                try
                {

                    datos.setearConsulta("UPDATE Servicios SET EstadoServicio = 0 WHERE ID = @ID");
                    datos.setearParametro("@ID", id);
                    datos.ejecutarConsulta();

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
            else //Servicio inactivo
            {
                try
                {
                    DialogResult rta = MessageBox.Show("Reactivar Servicio?", "Reactivar Servicio", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (rta == DialogResult.Yes)
                    {
                        datos.setearConsulta("UPDATE Servicios SET EstadoServicio = 1 WHERE ID = @ID");
                        datos.setearParametro("@ID", id);
                        datos.ejecutarConsulta();
                    }

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


        public List<Servicio> ListarInactivos()
        {
            List<Servicio> lista = new List<Servicio>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID,NombreServicio,Descripcion,Precio,EstadoServicio FROM Servicios WHERE EstadoServicio = 0");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {

                    Servicio aux = new Servicio();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.NombreServicio = (string)datos.Lector["NombreServicio"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.EstadoServicio = (bool)datos.Lector["EstadoServicio"];

                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { datos.cerrarConexion(); }
        }

    }
}

