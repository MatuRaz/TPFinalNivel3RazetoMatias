using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;

        private SqlCommand comando;

        private SqlDataReader lector;

        public SqlDataReader Lector { get { return lector; } }

        public AccesoDatos() 
        {
            conexion = new SqlConnection("server=MATIASPC\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            comando = new SqlCommand();
        }

        public void SetearConsulta(string consuta) 
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consuta;
        }

        public void EjecutarLectura() 
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EjecutarAccion()
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

        public void SetearParametros(string nombre, object value) 
        {
            comando.Parameters.AddWithValue(nombre, value);
        }

        public void CerrarConexion() 
        {
            if(conexion != null)
                conexion.Close();
        }


    }
}
