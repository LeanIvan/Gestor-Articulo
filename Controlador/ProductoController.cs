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




        public Marca getMarcaById(int id)
        {
            Marca marca = new Marca();

            try
            {
                db.Abrir();
                db.EjecutarQuery($"SELECT Id, Descripcion FROM MARCAS WHERE Id = {id}");
                SqlDataReader reader = db.Command.ExecuteReader();

                while (reader.Read())
                {
                    marca.Id = Convert.ToInt32(reader["Id"]);
                    marca.Descripcion = reader["Descripcion"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la marca por ID: " + ex.Message, ex);
            }
            finally
            {
                db.Cerrar();
            }

            return marca;
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
            string query = @"
        SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.IdMarca, A.IdCategoria, A.ImagenUrl,
               M.Descripcion AS MarcaDescripcion,
               C.Descripcion AS CategoriaDescripcion
        FROM ARTICULOS A
        INNER JOIN MARCAS M ON A.IdMarca = M.Id
        INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id";

            List<Articulo> articulos = new List<Articulo>();

            try
            {
                db.Abrir();
                db.EjecutarQuery(query);
                SqlDataReader reader = db.Command.ExecuteReader();

                while (reader.Read())
                {
                    Marca marca = new Marca
                    {
                        Id = (int)reader["IdMarca"],
                        Descripcion = (string)reader["MarcaDescripcion"]
                    };

                    Categoria categoria = new Categoria
                    {
                        Id = (int)reader["IdCategoria"],
                        Descripcion = (string)reader["CategoriaDescripcion"]
                    };

                    Articulo articulo = new Articulo
                    {
                        Id = (int)reader["Id"],
                        Codigo = (string)reader["Codigo"],
                        Nombre = (string)reader["Nombre"],
                        Precio = (decimal)reader["Precio"],
                        Marca = marca,
                        Categoria = categoria,
                        Descripcion = (string)reader["Descripcion"],
                        UrlImagen = (string)reader["ImagenUrl"]
                    };

                    articulos.Add(articulo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching list of Articulos: " + ex.Message, ex);
            }
            finally
            {
                db.Cerrar();
            }

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
                db.AgregarParametros("@IdMarca", articulo.Marca.Id);
                db.AgregarParametros("@IdCategoria", articulo.Categoria.Id);
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




        public int EliminarArticulo(int Id)
        {

            string query = $"DELETE FROM ARTICULOS WHERE Id = @Id";

            int filasAfectadas;

            try
            {
                db.Abrir();

                db.setQuery(query);
                db.AgregarParametros("@Id",Id);
               
                filasAfectadas = db.EjecutarAccion();
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());

            }
            finally { db.Cerrar(); }
            return filasAfectadas;
        }



        public int ActualizarArticulo(Articulo articulo)
        {
            int filasAfectadas = 0;

            try
            {
                db.Abrir();

                string query = "UPDATE ARTICULOS " +
                               "SET Precio = @Precio, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Codigo = @Codigo " +
                               "WHERE Id = @Id";


                db.setQuery(query);
                db.AgregarParametros("@Id",articulo.Id);
                db.AgregarParametros("@Precio", articulo.Precio);
                db.AgregarParametros("@Nombre", articulo.Nombre);
                db.AgregarParametros("@Descripcion", articulo.Descripcion);
                db.AgregarParametros("@IdMarca", articulo.Marca.Id);
                db.AgregarParametros("@IdCategoria", articulo.Marca.Id);
                db.AgregarParametros("@ImagenUrl", articulo.UrlImagen);
                db.AgregarParametros("@Codigo", articulo.Codigo);

                filasAfectadas = db.EjecutarAccion();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el artículo: " + ex.Message, ex);
            }
            finally
            {
                db.Cerrar();
            }

            return filasAfectadas;
        }



    }
}

