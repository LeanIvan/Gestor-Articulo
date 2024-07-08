using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class ConexionDB
    {

        public string ConexionString { get; set; }

        public SqlConnection sqlConnection;
        public SqlCommand command;
        public SqlDataReader reader;



        public ConexionDB()
        {
            command = new SqlCommand();

            try
            {
                ConexionString = "server =.\\SQLEXPRESS; database = CATALOGO_DB; integrated security = true";
                sqlConnection = new SqlConnection(ConexionString);
                command.CommandType = System.Data.CommandType.Text;

            }
            catch (Exception ex)
            {
                throw new Exception("Revisar String Conection", ex);

            }

        }

        public void Abrir()
        {

            if (this.sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();

        }

        public void Cerrar()
        {
            if (this.sqlConnection.State == ConnectionState.Open) sqlConnection.Close();


        }

        public SqlCommand EjecutarQuery(string query)
        {
            try
            {
                this.command = new SqlCommand(query, this.sqlConnection);           
                this.command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
          

            return this.command;
        }







        /*

        public bool VerificarExistenciaProducto(Articulo producto)
        {
            string query = "SELECT COUNT(1) FROM Productos WHERE Nombre = @nombre AND MarcaID = @marcaID";

            try
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@MarcaID", producto.marca.Id);

                    int count = (int)command.ExecuteScalar();
                    if(count > 0)return true;
                    else return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la existencia del producto en la base de datos", ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        */

        /*
        public Marca GetMarcaById(int id)
        {
            Marca marca = null;
            string query = "SELECT MarcaID, Nombre FROM Marcas WHERE MarcaID = @id";

            try
            {
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("id", id);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    marca = new Marca(id, (string)reader["Nombre"]);
                }

            }
            catch (Exception ex)
            {

                throw new Exception("error al devolver marca por ID", ex);

            }
            finally { sqlConnection.Close(); }

            return marca;
        }
        */





        public List<Marca> GetListaDeMarcas()
        {
            string query = "SELECT Id, Descripcion FROM Marcas";
            List<Marca> marcas = new List<Marca>();

            try
            {

                sqlConnection.Open();

                command = EjecutarQuery(query);

                reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Marca marca = new Marca((int)reader["Id"], (string)reader["Descripcion"]);
                    marcas.Add(marca);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error al devolver lista de marcas", ex);

            }
            finally { sqlConnection.Close(); }

            return marcas;
        }





        public List<Articulo> GetListaDeArticulos()
        {

            string query =  "SELECT A.Codigo,A.Nombre,A.Descripcion,A.Precio,A.IdMarca,A.IdCategoria,A.ImagenUrl FROM ARTICULOS A";

                   

            List<Articulo> articulos = new List<Articulo>();


            try
            {
                Abrir();

                command = EjecutarQuery(query);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Articulo articulo = new Articulo(
                        (string)reader["Codigo"],
                        (string)reader["Nombre"],
                        (decimal)reader["Precio"],
                        (int)reader["IdMarca"],
                        (int)reader["IdCategoria"],
                        (string)reader["Descripcion"],
                        (string)reader["ImagenUrl"]                    
                    );



                    articulos.Add(articulo);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching list of Articulitos: " + ex.Message, ex);
            }
            finally
            {
                Cerrar();
            }

            return articulos;
        }
 

        /*


        public void AgregarProducto(Articulo producto)
        {
            string nombre = producto.Nombre;
            int marcaID = producto.marca.Id;
            int stock = producto.Stock;
            decimal precio = producto.Precio;

            string query = "INSERT INTO Productos (Nombre, Precio, Stock, MarcaID) VALUES (@nombre, @precio, @stock, @marcaID)";

            try
            {
                sqlConnection.Open();
                using (this.command = new SqlCommand(query, sqlConnection))
                {
                   
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@precio", precio);
                    command.Parameters.AddWithValue("@stock", stock);
                    command.Parameters.AddWithValue("@marcaID", marcaID);                 
                    command.ExecuteNonQuery();
                }
                          

            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el producto a la base de datos", ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        */
    }


}