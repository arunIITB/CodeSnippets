using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {

            var stepsCount = int.Parse(Console.ReadLine());

            var stepsTaken = int.Parse(Console.ReadLine());


            var ACount = stepsCount;
            var BCount = stepsCount;


            while(stepsTaken >0)
            {

                var input = Console.ReadLine().Split(' ');

                var AStep = int.Parse(input[0]);
                var BStep = int.Parse(input[1]);

                ACount -= AStep;
                BCount -= BStep;

                if(ACount <=0 && BCount <=0)
                {
                    Console.WriteLine("NO WINNER");
                    return;
                }
                else if(ACount <=0)
                {
                    Console.WriteLine("A");
                    return;
                }
                else if(BCount <= 0)
                {
                    Console.WriteLine("B");
                    return;
                }
                stepsTaken--;

            }
        }
    }
}
