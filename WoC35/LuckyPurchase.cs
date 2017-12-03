using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoC35
{
    class Program
    {

        public static long SevenAndFourCountsSameAreNot(string str)
        {

            long ans = -1;

            if(String.IsNullOrWhiteSpace(str))
            {
                return ans;
            }

            int count4 = 0;
            int count7 = 0;

            foreach(var ch in str)
            {

                if(ch == '4')
                {
                    count4++;
                }
                else if(ch =='7')
                {
                    count7++;
                }
                else
                {
                    return -1;
                }
            }

            if(count4 == 0 || count7==0)
            {
                return ans;
            }


            if(count7 != count4)
            {
                return ans;
            }


         return   long.Parse(str, CultureInfo.InvariantCulture);


        }
        static void Main(string[] args)
        {

            var dictionary = new Dictionary<long, string>();

            int n = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < n; a0++)
            {
                string[] tokens_s = Console.ReadLine().Split(' ');
                string s = tokens_s[0];
                int n1 = Convert.ToInt32(tokens_s[1]);

                var ans = SevenAndFourCountsSameAreNot(n1.ToString());


                if(ans != -1)
                {
                    dictionary.Add(ans, s);

                }


            }


            if(!dictionary.Any())
            {
                System.Console.WriteLine(-1);
            }
            else
            {
                var min = dictionary.Min(x => x.Key);

                System.Console.WriteLine(dictionary[min]);
            }



        }
    }
}
