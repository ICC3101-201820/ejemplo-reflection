using System;
using System.Collections.Generic;
using FiguraBase;
using System.Reflection;

namespace Laboratorio_5
{

    class MainClass
    {
        // Opciones menu inicial
        private const string OPCION_SALIR = "0";
        private const string OPCION_SELECCIONAR_FIGURA = "1";
        private const string OPCION_IMPORTAR_PLUGIN = "2";

        // Opciones menu figura
        private const string OPCION_CALCULAR_AREA = "1";
        private const string OPCION_CALCULAR_PERIMETRO = "2";

        // Listado de tipos
        private static List<Type> figureTypes = new List<Type>();

        static void ImportarPlugin()
        {
            Log.Question("\nIngresa la ruta del plug-in");
            string ruta = Console.ReadLine();
            Assembly assembly = Assembly.LoadFrom(ruta);
            int importadas = 0;
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(Figura)))
                {
                    Log.Write(string.Format("Agregando {0}...", type.Name));
                    figureTypes.Add(type);
                    importadas += 1;
                }
            }
            if (importadas == 0)
                Log.Error("No existían figuras a importar");
            else
                Log.Success(string.Format("{0} figura(s) importadas", importadas));
        }

        static void MenuInicial()
        {
            Log.WriteLineWithColor("Bienvenido! En este programa podrás calcular algunas propiedades de tus figuras favoritas: cuadrados, círculos y triángulos", ConsoleColor.Cyan);

            while (true)
            {
                Log.Question("\n¿Qué deseas hacer?");
                Console.WriteLine($"[{OPCION_SELECCIONAR_FIGURA}] Seleccionar figura");
                Console.WriteLine($"[{OPCION_IMPORTAR_PLUGIN}] Importar plug-in");
                Console.WriteLine($"[{OPCION_SALIR}] Salir");
                Console.WriteLine("");

                string opcion = Console.ReadLine();

                if (opcion == OPCION_SELECCIONAR_FIGURA)
                {
                    MenuFiguras();
                }
                else if (opcion == OPCION_IMPORTAR_PLUGIN)
                {
                    ImportarPlugin();
                }
                else
                {
                    Log.Write("Hasta pronto!");
                    break;
                }
            }
        }

        static void MenuFiguras()
        {
            while (true)
            {
                Console.WriteLine("\nLas figuras que tenemos disponibles son:");
                for(int i = 0; i < figureTypes.Count; i++)
                    Console.WriteLine($"[{i + 1}]: {figureTypes[i].Name}");
                Console.WriteLine($"[{OPCION_SALIR}] Volver al menú\n");

                int opcion = Usuario.PedirEntero("¿Cuál quieres seleccionar?");

                if (opcion == 0)
                {
                    break;
                }
                else
                {
                    int indice = opcion - 1;
                    bool estaEnLaLista = indice >= 0 || indice < figureTypes.Count;
                    if (estaEnLaLista)
                    {
                        Type tipoFigura = figureTypes[indice];
                        var constructorInfo = tipoFigura.GetConstructors()[0];
                        var constructorParams = constructorInfo.GetParameters();
                        var parameters = new object[constructorParams.Length];
                        for(int i = 0; i < constructorParams.Length; i++)
                            parameters[i] = Usuario.PedirLado(string.Format("\nIngresa el valor de {0}:", constructorParams[i].Name));
                        Figura figura = (Figura) constructorInfo.Invoke(parameters);
                        MenuFigura(figura);
                    }
                    else
                    {
                        Log.Error($"La opción ingresada ({opcion}) no existe");
                    }
                }
            }
        }

        static void MenuFigura(Figura figura)
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
                    Log.Write("Calculando área...\n");
                    Log.Success($"El área de tu {figura.Nombre} es {figura.Area()}\n");
                    Usuario.PresionarParaContinuar();
                }
                else if (opcion == OPCION_CALCULAR_PERIMETRO)
                {
                    Log.Write("Calculando perímetro...\n");
                    Log.Success($"El perímetro de tu {figura.Nombre} es {figura.Perimetro()}\n");
                    Usuario.PresionarParaContinuar();
                }
                else if (opcion == OPCION_SALIR)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Log.Error("La opción ingresada ({0}) no existe");
                    Usuario.PresionarParaContinuar();
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            // Aquí agregamos figuras base de nuestro programa
            figureTypes.Add(typeof(Circulo));
            figureTypes.Add(typeof(Cuadrado));
            figureTypes.Add(typeof(Triangulo));
            MenuInicial();
        }
    }
}
