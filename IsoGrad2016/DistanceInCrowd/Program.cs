using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceInCrowd
{
    class Point
    {
        public int ID { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public Point(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public override bool Equals(object obj)
        {
            var otherPoint = obj as Point;

            if (otherPoint != null)
            {
                return otherPoint.ID == ID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}", Row, Col);
        }
    }

    class Program
    {

        public  static double Distance(Point p1, Point p2)
        {

            var xDiff = Math.Pow(p1.Row - p2.Row, 2);
            var yDiff = Math.Pow(p1.Col - p2.Col, 2);

            return Math.Sqrt(xDiff + yDiff);

        }


        static void Main(string[] args)
        {
            var input1 = Console.ReadLine().Split(' ');
            var N = int.Parse(input1[0]);
            var K = int.Parse(input1[1]);
            var R = double.Parse(input1[2]);

            var hashSet = new HashSet<Point>();

            var list = new List<Point>();

            for(int i=1; i <=N;i++)
            {
                var input2 = Console.ReadLine().Split(' ');

                var newPoint = new Point(int.Parse(input2[0]), int.Parse(input2[1]));
                newPoint.ID = i;

                list.Add(newPoint);

            }


            foreach(var point in list)
            {

                if(hashSet.Contains(point))
                {
                    continue;
                }

                var count = 0;
                foreach(var point2 in list)
                {
                    if(point.Equals(point2))
                    {
                        continue;
                    }

                    var dist = Distance(point, point2);

                    if(dist <= R)
                    {
                        count++;
                    }

                }

                if(count >= K)
                {
                    hashSet.Add(point);
                }
            }

            if (hashSet.Any())
            {

                var ans = hashSet.OrderBy(x => x.ID);


                foreach (var x in ans)
                {
                    Console.Write(x.ID + " ");
                }
            }
            else
            {
                Console.WriteLine("No danger");
            }


        }
    }
}
