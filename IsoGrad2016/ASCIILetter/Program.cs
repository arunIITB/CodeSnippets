using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIILetter
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringBuilder = new StringBuilder();

            for(int i=0;i < 8;i++)
            {

               stringBuilder.Append(Convert.ToChar(Convert.ToInt32(Console.ReadLine(), 2)));
            }

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
