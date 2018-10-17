using System;
using FiguraBase;

namespace Laboratorio_5
{
    public class Cuadrado : Figura
    {
        private double lado;

        public Cuadrado(double lado) : base("Cuadrado")
        {
            this.lado = lado;
        }

        public override double Area()
        {
            return lado * lado;
        }

        public override double Perimetro()
        {
            return 4 * lado;
        }

        public double Lado
        {
            get { return lado; }
            set { lado = value; }
        }
    }
}
