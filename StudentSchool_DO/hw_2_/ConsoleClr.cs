using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2
{
    internal class ConsoleClr
    {
        public static void WriteMenu(string menuText)
        {
            Console.ForegroundColor = System.ConsoleColor.Yellow;
            Console.WriteLine(menuText);
            Console.ResetColor();
        }

        public static void WriteErrors(string errorsText)
        {
            Console.ForegroundColor = System.ConsoleColor.Red;
            Console.WriteLine(errorsText);
            Console.ResetColor();
        }

        public static void WriteService(string serviceText)
        {
            Console.ForegroundColor = System.ConsoleColor.Blue;
            Console.WriteLine(serviceText);
            Console.ResetColor();
        }

    }

}