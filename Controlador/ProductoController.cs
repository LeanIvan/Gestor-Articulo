using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Modelo;


namespace Controlador
{
    public class ProductoController
    {
        public ConexionDB db = new ConexionDB();

        public List<Articulo> ListarArticulos()
        {
            return db.GetListaDeArticulos();
        }

        public List<Marca> ListarMarcas() {
            return db.GetListaDeMarcas();

        }

        public List<Categoria> ListarCategorias()
        {

            List<Categoria> listaCategoria = new List<Categoria>();

            string query = "select Id , Descripcion from CATEGORIAS";

            try
            {
                db.Abrir();

                db.command = db.EjecutarQuery(query);
                db.reader = db.command.ExecuteReader();

                while (db.reader.Read())
                {
                    Categoria cat = new Categoria((int)db.reader["Id"], db.reader["Descripcion"] as string);



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


        public string getMarcaById(int id)
        {

            string marca = string.Empty;

            try
            {
                db.Abrir();

                db.command = db.EjecutarQuery($"select Descripcion from MARCAS M where M.Id ={id}");
                db.reader = db.command.ExecuteReader();

                while (db.reader.Read())
                {
                    marca = db.reader["Descripcion"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                db.Cerrar();
            }
            return marca;
        }

        public string getCategoriaById(int id)
        {
            string cat = string.Empty;

            try
            {
                db.Abrir();

                db.command = db.EjecutarQuery($"select Descripcion from CATEGORIAS C where C.Id = {id}");
                db.reader = db.command.ExecuteReader();

                while (db.reader.Read())
                {
                    cat = db.reader["Descripcion"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                db.Cerrar();

            }
            return cat;
        }

        public void InsertarArticulo(Articulo articulo)
        {
            string query = "INSERT INTO Articulos (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria, ImagenUrl) " +
                           "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @IdMarca, @IdCategoria, @ImagenUrl)";

            try
            {
                db.Abrir();
                db.command.Parameters.Clear();


                // Asignar parámetros
                db.command.Parameters.AddWithValue("@Codigo", articulo.Codigo);
                db.command.Parameters.AddWithValue("@Nombre", articulo.Nombre);
                db.command.Parameters.AddWithValue("@Descripcion", articulo.Descripcion);
                db.command.Parameters.AddWithValue("@Precio", articulo.Precio);
                db.command.Parameters.AddWithValue("@IdMarca", articulo.IdMarca);
                db.command.Parameters.AddWithValue("@IdCategoria", articulo.IdCategoria);
                db.command.Parameters.AddWithValue("@ImagenUrl", articulo.UrlImagen);

                db.EjecutarQuery(query);
    
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());

            }finally   
            {
                db.Cerrar();
            }      
        }


    }
}

