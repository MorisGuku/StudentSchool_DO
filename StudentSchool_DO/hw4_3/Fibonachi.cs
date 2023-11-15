using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2
{
    public class Fibonachi
    {
        public static int GetFibonachi(int stepN)
        {
            int firstNumberFibonachi = 0;
            int secondNumberFibonachi = 1;
            for (int i = 0; i < stepN; i++)
            {
                int Temp = firstNumberFibonachi;
                firstNumberFibonachi = secondNumberFibonachi;
                secondNumberFibonachi = Temp + secondNumberFibonachi;
            }

            return firstNumberFibonachi;
        }

    }

}
