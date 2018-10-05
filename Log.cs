using System;
namespace Laboratorio_5
{
    /**
     * Esta función  utilizamos para escribir de manera más simple consola con color en nuestro programa
     */

    public static class Log
    {
        public static void WriteLineWithColor(object o, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(o);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Success(object o)
        {
            WriteLineWithColor(o, ConsoleColor.Green);
        }

        public static void Write(object o)
        {
            WriteLineWithColor(o, ConsoleColor.DarkGray);
        }

        public static void Question(object o)
        {
            WriteLineWithColor(o, ConsoleColor.Yellow);
        }

        public static void Error(object o)
        {
            WriteLineWithColor(o, ConsoleColor.Red);
        }
    }
}
