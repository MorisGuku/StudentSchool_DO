using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2
{
    internal class FileReader
    {
        public static string[] ReadLines(string filePath, int numberOfLines)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string[] result = new string[numberOfLines];
                for (int counter = 0; counter < numberOfLines; counter++)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    result[counter] = line;
                }

                return result;
            }

        }

    }

}

