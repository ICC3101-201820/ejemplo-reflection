using System;
using FiguraBase;

namespace Laboratorio_5
{
    public class Triangulo : Figura
    {
        private readonly double a, b, c, h;

        public Triangulo(double a, double b, double c, double h) : base("Triángulo")
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.h = h;
        }

        public override double Area()
        {
            return b * a / 2;
        }

        public override double Perimetro()
        {
            return a + b + c;
        }
    }
}
