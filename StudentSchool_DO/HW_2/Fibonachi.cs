using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2
{
    public class Fibonachi
    {
        public static int GetFibonachi(int StepN)
        {
            int FirstNumberFibonachi = 0;
            int SecondNumberFibonachi = 1;
            for (int i = 0; i < StepN; i++)
            {
                int Temp = FirstNumberFibonachi;
                FirstNumberFibonachi = SecondNumberFibonachi;
                SecondNumberFibonachi = Temp + SecondNumberFibonachi;
            }
            return FirstNumberFibonachi;
        }
    }
}
