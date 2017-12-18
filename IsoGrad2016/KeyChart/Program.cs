using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyChart
{
    class Node
    {
        public string ID { get; set; }

        public List<Node> Children { get; set; }

        public Node(string id)
        {
            ID = id;
            Children = new List<Node>();
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var temp = obj as Node;

            if(temp == null)
            {
                return false;
            }

            return temp.ID == ID;
        }
    }
    class Program
    {
       public static  Dictionary<string, Node> dict = new Dictionary<string, Node>();
        public static Dictionary<string, int> height = new Dictionary<string, int>();
        public static int HeightOfTree(string root)
        {

            if(height.ContainsKey(root))
            {
                return height[root];
            }

            var ans = 0;

            if(dict[root].Children.Count() ==0)
            {
                return 1;
            }

            var list = new List<int>();

            foreach(var chil in dict[root].Children)
            {
                list.Add(1 + HeightOfTree(chil.ID));

            }

            if (list.Any())
            {
                ans = list.Min();
            }

            height[root] = ans;
            return ans;
        }
        static void Main(string[] args)
        {
            var totalInput = int.Parse(Console.ReadLine());

            var dependentKey = new HashSet<string>();

            var masterKey = new HashSet<string>();

            for(int i=0; i < totalInput; i++)
            {
                var input1 = Console.ReadLine().Split(' ');

                var key1 = input1[0];
                var key2 = input1[1];

                var key1Node = new Node(key1);
                var key2Node = new Node(key2);


                if(!dependentKey.Contains(key2))
                {
                    dependentKey.Add(key2);
                }

                if(!masterKey.Contains(key1))
                {
                    masterKey.Add(key1);
                }

                if (dict.ContainsKey(key1))
                {
                    if(dict.ContainsKey(key2))
                    {

                        dict[key1].Children.Add(dict[key2]);
                    }
                    else
                    {
                        dict.Add(key2, key2Node);
                        dict[key1].Children.Add(dict[key2]);
                    }

                }
                else
                {
                    dict.Add(key1, key1Node);

                    if (dict.ContainsKey(key2))
                    {

                        dict[key1].Children.Add(dict[key2]);
                    }
                    else
                    {
                        dict.Add(key2, key2Node);
                        dict[key1].Children.Add(dict[key2]);
                    }
                }


            }

            var root = string.Empty;
            foreach(var key in masterKey)
            {
                if(!dependentKey.Contains(key))
                {
                    root = key;
                    break;
                }
            }



            var height = HeightOfTree(root);

            foreach(var key in dict.Keys)
            {
                height = Math.Max(height, HeightOfTree(key));
            }

            Console.WriteLine(height);

        }
    }
}
