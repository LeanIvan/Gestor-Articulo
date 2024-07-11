using System.ComponentModel;
namespace Modelo
{
    public class Articulo
    {

        public int Id { get; set; }

        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }


        public Articulo(int id, string codigo, string nombre, decimal precio, int idMarca, int idCategoria, string descripcion, string urlImagen)
        {
            Id = id;
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            IdMarca = idMarca;
            IdCategoria = idCategoria;
            Descripcion = descripcion;
            UrlImagen = urlImagen;


        }

        public Articulo( string codigo, string nombre, decimal precio, int idMarca, int idCategoria, string descripcion, string urlImagen)
        {
          
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            IdMarca = idMarca;
            IdCategoria = idCategoria;
            Descripcion = descripcion;
            UrlImagen = urlImagen;


        }




        public Articulo() { }

        public override string ToString()
        {
            return Codigo + Nombre + Precio + IdCategoria + IdMarca;
        }



    }
}