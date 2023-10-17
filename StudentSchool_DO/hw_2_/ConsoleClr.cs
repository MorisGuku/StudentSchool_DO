using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2_
{
    internal class ConsoleClr
    {
        public static void Menu(string MenuText)
        {
            Console.ForegroundColor = System.ConsoleColor.Yellow;
            Console.WriteLine(MenuText);
            Console.ResetColor();
        }
        public static void Errors(string ErrorsText)
        {
            Console.ForegroundColor = System.ConsoleColor.Red;
            Console.WriteLine(ErrorsText);
            Console.ResetColor();
        }
        public static void Service(string ServiceText)
        {
            Console.ForegroundColor = System.ConsoleColor.Blue;
            Console.WriteLine(ServiceText);
            Console.ResetColor();
        }

    }
}