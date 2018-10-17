using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_5
{
    public class Usuario
    {
        public static void PresionarParaContinuar()
        {
            Log.Write("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }

        /**
          * Esta funcion nos permite pedir n lado de fom más sencilla. Solicita un numero válido y que sea mayor a 0
          */
        public static double PedirLado(string solicitud)
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

        public static int PedirEntero(string solicitud)
        {
            Log.Question(solicitud);
            int numero = 0;
            bool valido = false;
            while (!valido)
            {
                bool transformacionExitosa = int.TryParse(Console.ReadLine(), out numero);
                if (transformacionExitosa)
                    valido = true;
                else
                    Log.Error($"Debe ingresar un número entero");
            }
            return numero;
        }
    }
}
