﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=(local)  ; database=TPC_Taller; integrated security=true"); //server=(local)  server=.\\SQLEXPRESS
            comando = new SqlCommand();
        }
        public void abrirConexion()
        {
            if (conexion.State != System.Data.ConnectionState.Open)
            {
                conexion.Open();
            }
        }
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
            comando.Parameters.Clear(); // Limpiar parámetros
        }

        public void setearSP(string SP)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = SP;
        }

        public void ejecutarConsulta()
        {
            comando.Connection = conexion;
            try
            {
                comando.Connection = conexion;
                abrirConexion(); // Asegura que la conexión está abierta
                lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void ejecutar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void setearParametro(string nombre, object objeto)
        {
            comando.Parameters.AddWithValue(nombre, objeto);
        }
        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
