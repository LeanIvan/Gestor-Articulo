using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;

namespace Modelo
{
    public class ConexionDB
    {
        private string ConexionString { get; set; }
        private SqlConnection sqlConnection;
        private SqlCommand command;


        public ConexionDB()
        {
            try
            {
                ConexionString = "server =.\\SQLEXPRESS; database = CATALOGO_DB; integrated security = true";
                sqlConnection = new SqlConnection(ConexionString);
                command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = sqlConnection; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al inicializar la conexión", ex);
            }
        }


        public SqlCommand Command
        {
            get { return command; }
        }

        public void Abrir()
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
        }

        public void Cerrar()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
                command.Parameters.Clear(); 
            }
        }

        public void EjecutarQuery(string query)
        {
            try
            {
                
                command.CommandText = query; 
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la consulta", ex);
            }
           
        }

        public int EjecutarAccion()
        {
            int rowAfectadas;
            try
            {      
                rowAfectadas = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la acción", ex);
            }
           
            return rowAfectadas;
        }

        public void AgregarParametros(string parametro, object valor)
        {
            command.Parameters.AddWithValue(parametro, valor);
        }

        public void setQuery(string query)
        {
            this.command.CommandText = query;
        }



    }


}