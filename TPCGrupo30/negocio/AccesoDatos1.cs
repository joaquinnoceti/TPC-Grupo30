using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class AccesoDatos1
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos1()
        {
            conexion = new SqlConnection("server=(local); database=TPC_Taller; integrated security=true");
            comando = new SqlCommand();
            comando.Connection = conexion;
        }

        public void abrirConexion()
        {
            if (conexion.State != System.Data.ConnectionState.Open)
            {
                conexion.Open();
            }
        }

        public void cerrarConexion()
        {
            if (lector != null && !lector.IsClosed)
            {
                lector.Close();
            }
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
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
            comando.Parameters.Clear(); // Limpiar parámetros
        }

        public void setearParametro(string nombre, object objeto)
        {
            comando.Parameters.AddWithValue(nombre, objeto);
        }

        public void ejecutarConsulta()
        {
            comando.Connection = conexion;
            abrirConexion(); // Asegura que la conexión está abierta
            lector = comando.ExecuteReader();
        }

        public void ejecutar()
        {
            comando.Connection = conexion;
            abrirConexion(); // Asegura que la conexión está abierta
            comando.ExecuteNonQuery();
        }
    }

}

