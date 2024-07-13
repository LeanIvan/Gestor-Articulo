using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Modelo
{
    public class Articulo
    {

        public int Id { get; set; }

        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public Categoria Categoria { get; set; }
        public Marca Marca { get; set; }

    //    public int IdMarca { get; set; }
    //    public int IdCategoria { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }


        public Articulo(int id, string codigo, string nombre, decimal precio, Marca marca, Categoria categoria, string descripcion, string urlImagen)
        {
            Id = id;
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            Marca = marca;
            Categoria = categoria;
            Descripcion = descripcion;
            UrlImagen = urlImagen;
        }

        public Articulo( string codigo, string nombre, decimal precio, Marca marca, Categoria categoria, string descripcion, string urlImagen)
        {   
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;      
            Descripcion = descripcion;
            UrlImagen = urlImagen;
            Marca = marca;
            Categoria = categoria;
        }




        public Articulo() { }

        public override string ToString()
        {
            return this.Id.ToString();
        }



    }
}