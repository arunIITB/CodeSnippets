using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoGrad2016
{
    class Program
    {
        static void Main(string[] args)
        {

            var totalCount = int.Parse(Console.ReadLine());
            var testTimeInStr = Console.ReadLine();

            var today = DateTime.Today;

            var testTime = TimeSpan.Parse(testTimeInStr);

            var testDateTime = DateTime.Today.Add(testTime);

            var ans = 0;

            for(int test1=0; test1 < totalCount;test1++)
            {

                var input = Console.ReadLine().Split(' ');

                var enteredTime = TimeSpan.Parse(input[0]);
                var enteredDateTime = DateTime.Today.Add(enteredTime);

                var exitTime = TimeSpan.Parse(input[1]);
                var exitDateTime = DateTime.Today.Add(exitTime);


                if(enteredDateTime <= testDateTime && exitDateTime >= testDateTime)
                {
                    ans++;
                }

                

            }

            Console.WriteLine(ans);
            
        }
    }
}
