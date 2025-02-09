﻿namespace Modelo
{
    public class Marca
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

       

        public Marca()
        {
            Id = 0;
            Descripcion = "Desconocido";
        }



        public Marca(int IdMarca, string nombre)
        {
            Id = IdMarca;
            Descripcion = nombre;
        }




        public override string ToString()
        {
            return this.Descripcion;
        }


        public bool Equals(Marca other)
        {
            return (this.Id == other.Id && this.Descripcion == other.Descripcion);
        }



    }
}
