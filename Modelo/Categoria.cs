using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Categoria
    {
      public int Id { get; set; }
       public string Descripcion { get; set; }

        public Categoria() { 
            Id = 0;
            Descripcion = "Desconocido";
        }

        public Categoria(int id, string descripcion) {
            Id = id;
            Descripcion = descripcion;
        }

        public override string ToString()
        {
            return Descripcion;
        }

    }
}
