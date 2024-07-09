using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Controlador
{
    public class ProductoController
    {
        public ConexionDB db;

        public ProductoController()
        {
            db = new ConexionDB();

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





        public string getMarcaById(int id)
        {

            string marca = string.Empty;

            try
            {

                db.Abrir();
                db.EjecutarQuery($"select Descripcion from MARCAS M where M.Id ={id}");
                SqlDataReader reader = db.Command.ExecuteReader();

                while (reader.Read())
                {
                    marca = reader["Descripcion"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { db.Cerrar(); }

            return marca;
        }





        public string getCategoriaById(int id)
        {
            string cat = string.Empty;

            try
            {
                db.Abrir();
                db.EjecutarQuery($"select Descripcion from CATEGORIAS C where C.Id = {id}");
                SqlDataReader reader = db.Command.ExecuteReader();

                while (reader.Read())
                {
                    cat = reader["Descripcion"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }finally { db.Cerrar(); }

            return cat;
        }





        public List<Marca> ListarMarcas()
        {
            string query = "SELECT Id, Descripcion FROM Marcas";

            List<Marca> marcas = new List<Marca>();

            try
            {
                db.Abrir();
                db.EjecutarQuery(query);
                SqlDataReader reader = db.Command.ExecuteReader();


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
            finally { db.Cerrar(); }
            return marcas;
        }





        public List<Articulo> ListarArticulos()
        {

            string query = "SELECT A.Codigo,A.Nombre,A.Descripcion,A.Precio,A.IdMarca,A.IdCategoria,A.ImagenUrl FROM ARTICULOS A";

            List<Articulo> articulos = new List<Articulo>();
            try
            {
                db.Abrir();
                db.EjecutarQuery(query);
                SqlDataReader reader = db.Command.ExecuteReader();

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
            finally { db.Cerrar(); }

            return articulos;
        }





        public int InsertarArticulo(Articulo articulo)
        {

            string query = $"insert into ARTICULOS(Codigo , Nombre , Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)" +
                $"values (@Codigo ,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@ImagenUrl,@Precio)";

            int filasAfectadas;

            try
            {
                db.Abrir();

                db.setQuery(query);
                db.AgregarParametros("@Codigo", articulo.Codigo);
                db.AgregarParametros("@Nombre", articulo.Nombre);
                db.AgregarParametros("@Descripcion", articulo.Descripcion);
                db.AgregarParametros("@IdMarca", articulo.IdMarca);
                db.AgregarParametros("@IdCategoria", articulo.IdCategoria);
                db.AgregarParametros("@ImagenUrl", articulo.UrlImagen);
                db.AgregarParametros("@Precio", articulo.Precio);
                filasAfectadas = db.EjecutarAccion();

            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());

            }finally { db.Cerrar(); }
            return filasAfectadas;
        }


    }
}

