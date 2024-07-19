using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class CategoriaController
    {

      private ConexionDB db;

       public CategoriaController()
        {
        
            db = new ConexionDB();

        }





        public bool ExisteCategoria(string descripcion)
        {
            string query = "SELECT COUNT(*) FROM CATEGORIAS WHERE Descripcion = @Descripcion";
            try

            {
                db.Abrir();
                db.Command.Parameters.AddWithValue("@Descripcion", descripcion);
                db.EjecutarQuery(query);

                int count = (int)db.Command.ExecuteScalar();
                /// !=0 es que encontró
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la existencia de la Categoria: " + ex.Message, ex);
            }
            finally
            {
                db.Cerrar();
            }
        }






        public List<Categoria> ListarCategorias()
        {
            List<Categoria> listaCategoria = new List<Categoria>();

            string query = "select Id , Descripcion from CATEGORIAS";

            try
            {
                db.Abrir();
                db.EjecutarQuery(query);
                SqlDataReader reader = db.Command.ExecuteReader();

                while (reader.Read())
                {
                    Categoria cat = new Categoria((int)reader["Id"], reader["Descripcion"] as string);

                    listaCategoria.Add(cat);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
            finally
            {
                db.Cerrar();
            }

            return listaCategoria;
        }





        public Categoria getCategoriaById(int id)
        {
            Categoria cat = new Categoria();

            try
            {
                db.Abrir();
                db.EjecutarQuery($"SELECT Id, Descripcion FROM CATEGORIAS WHERE Id = {id}");
                SqlDataReader reader = db.Command.ExecuteReader();

                while (reader.Read())
                {
                    cat.Id = Convert.ToInt32(reader["Id"]);
                    cat.Descripcion = reader["Descripcion"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la categoría por ID: " + ex.Message, ex);
            }
            finally
            {
                db.Cerrar();
            }

            return cat;
        }






        public void InsertarCategoria(string descipcion)
        {
            string query = "INSERT INTO CATEGORIAS (Descripcion) VALUES (@Descripcion)";

            try
            {
                db.Abrir();
                db.setQuery(query);
                db.AgregarParametros("@Descripcion", descipcion);
                db.EjecutarAccion();


            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la Categoría: " + ex.Message, ex);
            }
            finally
            {
                db.Cerrar();
            }
        }





    }
}
