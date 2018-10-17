using System;
using FiguraBase;

namespace Laboratorio_5
{
    public class Circulo : Figura
    {
        private readonly double radio;

        public Circulo(double radio) : base("Círculo")
        {
            this.radio = radio;
        }

        public override double Area()
        {
            return Math.PI * radio * radio;
        }

        public override double Perimetro()
        {
            return 2 * Math.PI * radio;
        }
    }
}
