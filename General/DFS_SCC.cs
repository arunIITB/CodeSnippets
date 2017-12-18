using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Solution for https://www.hackerrank.com/challenges/torque-and-development/problem

namespace Library
{
    public class Edge : IComparer<Edge>
    {
        public int Start { get; set; }
        public int End { get; set; }
        public ulong Weight { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", Start, End, Weight);
        }

        public int Compare(Edge x, Edge y)
        {
            if (x.Weight == y.Weight)
            {
                return x.Start.CompareTo(y.Start);
            }

            return x.Weight.CompareTo(y.Weight);
        }


    }
    class SCC
    {
        public long LibCost { get; set; }
        public long RoadCost { get; set; }

        public long NodeCount { get; set; }
        public Dictionary<int, List<int>> _adjList;

        public List<Edge> _edgeList;

        public bool[] _visited;

        public void AddEdge(int start, int end)
        {
            var temp = new List<int>();

            if (_adjList.ContainsKey(start))
            {
                _adjList[start].Add(end);
            }
            else
            {
                temp.Add(end);
                _adjList.Add(start, temp);

            }


            if (_adjList.ContainsKey(end))
            {
                _adjList[end].Add(start);
            }
            else
            {
                temp.Add(start);
                _adjList.Add(end, temp);

            }


        }

        public SCC(long nodeCount)
        {
            NodeCount = nodeCount;
            _visited = new bool[nodeCount+1];
            _edgeList = new List<Edge>();
            _visited[0] = true;
            _adjList = new Dictionary<int, List<int>>();

        }

        public ulong Cost { get; set; }


        public int DoBFS(int index)
        {

            var ans = 0;

            var queue = new Queue<int>();


            queue.Enqueue(index);


            while(queue.Any())
            {
                var item = queue.Dequeue();

                if(_visited[item])
                {
                    continue;
                }

                _visited[item] = true;

                ans++;

                if (_adjList.ContainsKey(item))
                {
                    foreach (var nextNode in _adjList[item])
                    {
                        queue.Enqueue(nextNode);
                    }
                }

            }


            return ans;

        }


        public void Compute()
        {
           for(int i=1; i <=NodeCount;i++)
            {

                if(!_visited[i])
                {

                    var nodeCount = DoBFS(i);

                    if(nodeCount == 1)
                    {
                        Cost += (ulong)LibCost;
                    }
                    else
                    {
                        var currentComponetCost = (nodeCount - 1) * RoadCost;
                        currentComponetCost += LibCost;

                        Cost += (ulong)currentComponetCost;
                    }
                }

            }

        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                var n = Convert.ToInt64(tokens_n[0]);
                int m = Convert.ToInt32(tokens_n[1]);
                var x = Convert.ToInt64(tokens_n[2]);
                var y = Convert.ToInt64(tokens_n[3]);

                var scc = new SCC(n);
                for (int a1 = 0; a1 < m; a1++)
                {
                    string[] tokens_city_1 = Console.ReadLine().Split(' ');
                    int city_1 = Convert.ToInt32(tokens_city_1[0]);
                    int city_2 = Convert.ToInt32(tokens_city_1[1]);
                    scc.AddEdge(city_1, city_2);
                }

                if(x < y )
                {
                    Console.WriteLine(n * x);
                }
                else
                {
                    scc.LibCost = x;
                    scc.RoadCost = y;

                    scc.Compute();

                    Console.WriteLine(scc.Cost);

                }
            }
        }
    }
}