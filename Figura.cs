using System;
namespace Laboratorio_5
{
    public abstract class Figura
    {
        protected string nombre;

        protected Figura(string nombre)
        {
            this.nombre = nombre;
        }

        public abstract double Perimetro();
        public abstract double Area();
        public string Nombre {
            get { return nombre; }
        }
    }
}
