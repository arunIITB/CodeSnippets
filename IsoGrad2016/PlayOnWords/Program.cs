using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayOnWords
{
    class Node
    {
        public string ID { get; set; }
        public Node Next { get; set; }

        public int Cost { get; set; }
    }
    class Program
    {
        public static Dictionary<string, List<Node>> dict = new Dictionary<string, List<Node>>();


        public static int MaxCost(string startCity, ref string endCity)
        {

            var ans = 0;
            endCity = startCity;

            var globalMin = 0;
            var current = 0;
            var currentCity = startCity;

            while(true)
            {

                if(dict[currentCity].Next == null)
                {
                    return globalMin;
                }

                current += dict[currentCity].Cost;

                if(current < globalMin)
                {
                    globalMin = current;
                    endCity = dict[currentCity].Next.ID;
                }

                currentCity = dict[currentCity].Next.ID;

            }



          
        }
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var start = Console.ReadLine();

            for(int i=0;i < count;i++)
            {
                var input1 = Console.ReadLine().Split(' ');

                var A = input1[0];
                var B = input1[1];
                var cost = int.Parse(input1[2]);


                Node nodeA = null;
                if(!dict.ContainsKey(A))
                {
                    nodeA = new Node();
                    nodeA.ID = A;
                    nodeA.Cost = cost;
                    dict.Add(A, nodeA);
                    
                }
                else
                {
                    nodeA = dict[A];
                }

                Node nodeB = null;
                if(!dict.ContainsKey(B))
                {
                    nodeB = new Node();
                    nodeB.ID = B;
                    dict.Add(B, nodeB);
                }
                else
                {
                    nodeB = dict[B];
                }

                nodeA.Cost = cost;
                nodeA.Next = nodeB;

            }

            string endCity=null;
          var ans=  MaxCost(start,ref endCity);

            Console.WriteLine(endCity + " " + ans);

        }
    }
}
