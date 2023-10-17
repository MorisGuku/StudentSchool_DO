using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2
{
    internal class FileReader
    {
        public static string[] ReadLines(string filePath, int numberOfLines)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string[] result = new string[numberOfLines];
                string line;
                int counter = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    result[counter] = line;
                    counter++;
                    if (counter >= numberOfLines) break;
                }
                return result;
            }

        }
    }
}
