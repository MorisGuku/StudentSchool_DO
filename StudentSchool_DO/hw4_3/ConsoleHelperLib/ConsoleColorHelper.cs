using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2
{
    public class ConsoleColorHelper
    {
        public static void WriteMenu(string menuText)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(menuText);
            Console.ResetColor();
        }

        public static void WriteErrors(string errorsText)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorsText);
            Console.ResetColor();
        }

        public static void WriteService(string serviceText)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(serviceText);
            Console.ResetColor();
        }

    }

}