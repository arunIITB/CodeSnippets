using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSumSubMatrix
{

   
    class Program
    {
        public static Dictionary<Point,int> dictMax = new Dictionary<Point, int>();


        public static void MaxSubMatrix(int [] A, int left, int right)
        {

            var len = A.Count();


            var cumSum = new int[len];


            for(int i=0;i < len;i++)
            {
                if(i ==0)
                {
                    cumSum[i] = A[i];
                }
                else
                {
                    cumSum[i] += cumSum[i - 1] + A[i];
                }
            }


            var currentColCount = right - left + 1;


            foreach(var point in dictMax.Keys.ToList())
            {

                if(point.Col == currentColCount)
                {
                    var rowSize = point.Row;
                    for(int index = 0; index < len;index++)
                    {
                        if(index + rowSize <= len)
                        {
                            var currentSum = 0;
                            if (index ==0)
                            {
                                 currentSum = cumSum[index+rowSize - 1];
                            }
                            else
                            {
                                currentSum = cumSum[index + rowSize - 1] - cumSum[index - 1];
                            }

                            if(currentSum > dictMax[point])
                            {
                                dictMax[point] = currentSum;
                            }
                        }
                    }
                }
            }


            
        }


       public class Point
        {
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
                    return otherPoint.Row == Row && otherPoint.Col == Col;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return Row.GetHashCode() ^ Col.GetHashCode();
            }

            public override string ToString()
            {
                return string.Format("{0}-{1}", Row, Col);
            }
        }

        public static List<Point> GetMaxSubMatrix(int[,] A)
        {
            var ans = new List<Point>();

            var r = A.GetLength(0);
            var c = A.GetLength(1);


         


          //  queries.ForEach(x => dictMax.Add(x, 0));

            var rowSumArray = new int[r];
            for(int left=0;left< c;left++)
            {


                for(int right=left; right< c;right++)
                {
                    
                    for(int row=0;row < r;row++)
                    {

                        rowSumArray[row] += A[row, right];
                    }

                    // Kadane(rowSmArray, left, right);
                    MaxSubMatrix(rowSumArray, left, right);
                }

                for (int row = 0; row < r; row++)
                {

                    rowSumArray[row] = 0;
                }

            }


            return ans;

        }

        static void Main(string[] args)
        {

            int testCases = int.Parse(Console.ReadLine());


            for(int test=0;test < testCases; test++)
            {
                var input = Console.ReadLine().Split(' ');
                var row = int.Parse(input[0]);
                var col = int.Parse(input[1]);

                var arr = new int[row, col];

                var input2 = Console.ReadLine().Split(' ');

                
                for(int i=0;i <input2.Count();i++)
                {
                    arr[i / col, i % col] = int.Parse(input2[i]);
                }

                dictMax.Clear();


                int queries = int.Parse(Console.ReadLine());

                int qIndex = 0;

              var A_temp=  Console.ReadLine().Split(' ');
                var input3 = Array.ConvertAll(A_temp, Int32.Parse);

                var list = new List<Point>(); 
                for (int q=0;q < queries;q++)
                {

                    var a = input3[qIndex];
                    qIndex++;
                    var b = input3[qIndex];
                    qIndex++;
                    var point = new Point(a,b);
                    list.Add(point);
                    dictMax.Add(point, 0);

                }

                GetMaxSubMatrix(arr);

                list.ForEach(x => Console.Write(dictMax[x] + " "));
                Console.WriteLine();


            }

           // Console.WriteLine(sum);

        }
    }
}
