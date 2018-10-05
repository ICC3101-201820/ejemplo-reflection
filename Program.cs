using System;

namespace Laboratorio_5
{

    class MainClass
    {
        // Opciones menu inicial
        private const string OPCION_SALIR = "0";
        private const string OPCION_SELECCIONAR_FIGURA = "1";

        // Opciones menu figuras
        private const string OPCION_CUADRADO = "1";
        private const string OPCION_TRIANGULO = "2";
        private const string OPCION_CIRCULO = "3";

        // Opciones menu figura
        private const string OPCION_CALCULAR_AREA = "1";
        private const string OPCION_CALCULAR_PERIMETRO = "2";

        /**
         * Esta funcion nos permite pedir n lado de fom más sencilla. Solicita un numero válido y que sea mayor a 0
         */
        static double PedirLado(string solicitud)
        {
            Log.Question(solicitud);
            double numero = 0;
            bool valido = false;
            while (!valido)
            {
                bool transformacionExitosa = double.TryParse(Console.ReadLine(), out numero);
                if (transformacionExitosa && numero > 0)
                    valido = true;
                else
                    Log.Error($"Debe ingresar un número double mayor que {numero}");
            }
            return numero;
        }

        public static void PresionarParaContinuar()
        {
            Log.Write("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void MenuInicial()
        {
            Log.WriteLineWithColor("Bienvenido! En este programa podrás calcular algunas propiedades de tus figuras favoritas: cuadrados, círculos y triángulos", ConsoleColor.Cyan);

            while (true)
            {
                Log.Question("\n¿Qué deseas hacer?");
                Console.WriteLine($"[{OPCION_SELECCIONAR_FIGURA}] Seleccionar figura");
                Console.WriteLine($"[{OPCION_SALIR}] Salir");
                Console.WriteLine("");

                string opcion = Console.ReadLine();

                if (opcion == OPCION_SELECCIONAR_FIGURA)
                {
                    MenuFiguras();
                }
                else
                {
                    Log.Write("Hasta pronto!");
                    break;
                }
            }
        }

        public static void MenuFiguras()
        {
            while (true)
            {
                Console.WriteLine("\nLas figuras que tenemos disponibles son:");
                Console.WriteLine($"[{OPCION_CUADRADO}] Cuadrado");
                Console.WriteLine($"[{OPCION_TRIANGULO}] Triángulo");
                Console.WriteLine($"[{OPCION_CIRCULO}] Círculo");
                Console.WriteLine($"[{OPCION_SALIR}] Volver al menú\n");

                Log.Question("¿Cuál quieres seleccionar?");
                string opcion = Console.ReadLine();

                if (opcion == OPCION_CUADRADO)
                {
                    double lado = PedirLado("\nIngresa el lado del cuadrado");
                    Cuadrado cuadrado = new Cuadrado(lado);
                    MenuFigura(cuadrado);
                }
                else if (opcion == OPCION_TRIANGULO)
                {
                    double a = PedirLado("\nIngresa el lado a del triángulo");
                    double b = PedirLado("\nIngresa el lado b del triángulo");
                    double c = PedirLado("\nIngresa el lado c del triángulo");
                    double h = PedirLado("\nIngresa la altura h del triángulo");
                    Triangulo triangulo = new Triangulo(a, b, c, h);
                    MenuFigura(triangulo);
                }
                else if (opcion == OPCION_CIRCULO)
                {
                    double radio = PedirLado("\nIngresa el radio del círculo");
                    Circulo circulo = new Circulo(radio);
                    MenuFigura(circulo);
                }
                else if (opcion == OPCION_SALIR)
                {
                    break;
                }
                else
                {
                    Log.Error($"La opción ingresada ({opcion}) no existe");
                }
            }
        }

        public static void MenuFigura(Figura figura)
        {
            Log.Success($"\n¡Haz creado tu {figura.Nombre}!");

            while (true)
            {
                Console.WriteLine("");
                Log.Question($"¿Qué quieres saber de este {figura.Nombre}?");
                Console.WriteLine($"[{OPCION_CALCULAR_AREA}] Calcular área");
                Console.WriteLine($"[{OPCION_CALCULAR_PERIMETRO}] Calcular perímetro");
                Console.WriteLine($"[{OPCION_SALIR}] Volver al menú de figuras");
                Console.WriteLine("");

                string opcion = Console.ReadLine();

                if (opcion == OPCION_CALCULAR_AREA)
                {
                    Log.Log("Calculando área...\n");
                    Log.Success($"El área de tu {figura.Nombre} es {figura.Area()}\n");
                    PresionarParaContinuar();
                }
                else if (opcion == OPCION_CALCULAR_PERIMETRO)
                {
                    Log.Write("Calculando perímetro...\n");
                    Log.Success($"El perímetro de tu {figura.Nombre} es {figura.Area()}\n");
                    PresionarParaContinuar();
                }
                else if (opcion == OPCION_SALIR)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Log.Error("La opción ingresada ({0}) no existe");
                    PresionarParaContinuar();
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            MenuInicial();
        }
    }
}
