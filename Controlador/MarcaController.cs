using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data.SqlClient;

namespace Controlador
{
    public class MarcaController
    {
        private ConexionDB db;

        public MarcaController() { 
        
            db = new ConexionDB();
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




        public void InsertarMarca(string descipcion)
        {
            string query = "INSERT INTO MARCAS (Descripcion) VALUES (@Descripcion)";

            try
            {
                db.Abrir();
                db.setQuery(query);
                db.AgregarParametros("@Descripcion", descipcion);            
                db.EjecutarAccion();
             

            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la marca: " + ex.Message, ex);
            }
            finally
            {
                db.Cerrar();
            }
        }




        public bool ExisteMarca(string descripcion)
        {
            string query = "SELECT COUNT(*) FROM MARCAS WHERE Descripcion = @Descripcion";

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
                throw new Exception("Error al verificar la existencia de la marca: " + ex.Message, ex);
            }
            finally
            {
                db.Cerrar();
            }
        }







    }
}
