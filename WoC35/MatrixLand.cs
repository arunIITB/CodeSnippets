using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLand
{
    struct Values
    {
        public int Best {
            get
            {
                return Math.Max(CellValue+Right+Left,  Math.Max(CellValue, Math.Max(CellValue + Right, CellValue + Left)));
            }
        }

        public int Left { get; set; }

        public int Right { get; set; }

        public int CellValue { get; set; }

        public int CumSum { get; set; }


        public int ? MaxPossible { get; set; }

        public Values(int val)
        {           
            Left = 0;
            Right = 0;
            CellValue = val;
            CumSum = 0;
            MaxPossible = null;
        }

        public override string ToString()
        {
            return Best.ToString();
        }

    }
    class Program
    {


        public static int[,,] temp=null;

        public static int?[,] BestSum=null;

        public static long Solve(Values [,] A)
        {

            long ans = 0;


            var r = A.GetLength(0);
            var c = A.GetLength(1);






            for (int row = 0; row < r; row++)
            {



                for (int col = 0; col < c; col++)
                {
                    if (col == 0)
                    {
                        A[row, col].Left = 0;
                        A[row, col].CumSum = A[row, col].CellValue;
                        continue;
                    }

                    var prevCell = A[row, col - 1];

                    A[row, col].Left = prevCell.CellValue + Math.Max(prevCell.Left, 0);
                    A[row, col].CumSum = A[row, col - 1].CumSum + A[row, col].CellValue;

                }


                for (int col = c-1; col >=0; col--)
                {
                    if (col == c-1)
                    {
                        A[row, col].Right = 0;
                        continue;
                    }
                    var prevCell = A[row, col +1];


                    A[row, col].Right = prevCell.CellValue + Math.Max(prevCell.Right, 0);

                }


            }


            for(int i=0; i < r;i++)
            {
                for(int j=0;j < c;j++)
                {


                    for (int k = 0; k < c; k++)
                    {

                          if(j==k)
                        {
                            temp[i, j, k] = A[i, j].Best;
                        }
                        else if( k < j)
                        {
                            var cumSum = 0;
                            if(k ==0)
                            {
                                cumSum = A[i, j].CumSum;
                            }
                            else
                            {
                                cumSum = A[i, j].CumSum - A[i, k-1].CumSum;
                            }
                            
                            temp[i, j, k] = Math.Max(0, A[i, j].Right) +  Math.Max(0, A[i, k].Left) +  cumSum;
                        }
                        else if(k > j)
                        {
                            var cumSum = A[i, k].CumSum -A[i, j].CumSum;
                            temp[i, j, k] = Math.Max(0, A[i, j].Left) + A[i, j].CellValue + Math.Max(0, A[i, k].Right) +   cumSum;
                        }


                    }

                    
                  }
            }




        //    PrintArray(A);



            for(int jj =0;jj < c;jj++)
            {
                var temp1 = FindBestPathCost(temp, 0, jj);

                if(ans < temp1)
                {
                    ans = temp1;
                }

                
            }

            return ans;


            
        }


        public static int FindBestPathCost(int [,,] A,int row,int col)
        {

            if(BestSum[row,col] != null )
            {
                return BestSum[row, col].Value;
            }

            int ans = 0;


            var r = A.GetLength(0);
            var c = A.GetLength(1);
            


            if(row == r-1)
            {
                BestSum[row,col] = A[row, col, col];
                return BestSum[row, col].Value;

            }
            else
            {

                for(int k=0;k < c;k++)
                {
                    var temp = A[row, col, k] + FindBestPathCost(A, row + 1, k);

                    if(ans < temp)
                    {
                        ans = temp;
                    }
                }

                BestSum[row, col] = ans;

            }




            return ans;

        }





        public class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X { get; set; }
            public int Y { get; set; }


            public override string ToString()
            {
                return string.Format("{0} => {1}", X, Y);
            }

            public override bool Equals(object obj)
            {
                var tempPoint =obj as Point;

                if(tempPoint == null)
                {
                    return false;
                }

                return tempPoint.X == X&& tempPoint.Y == Y;
            }

            public override int GetHashCode()
            {
                return X.GetHashCode() ^ Y.GetHashCode();
            }
        }

        public static List<Point> finalAnswer;
        public static long maxAnswerSoFar;

        public static long MaxSum(int [,] A, int [,] cumSum, int i, int j, long currentSum,string strPath, List<Point> points)
        {

            if(strPath.Contains("3,3") && currentSum == 450)
            {

            }

         

         //   Console.WriteLine(strPath+" =========>  "+currentSum);

            var r = A.GetLength(0);
            var c = A.GetLength(1);


            if (maxAnswerSoFar < currentSum && j == c-1)
            {

                maxAnswerSoFar = currentSum;
                finalAnswer = points;

            }

            //if(i >= r || j >=c )
            //{
            //    return currentSum;
            //}


            long ans = 0;

            long right = 0;
            long down = 0;
            long left = 0;


            if (j < c - 1 &&  i < r)
            {
                var pointTemp = new List<Point>(points);
                pointTemp.Add(new Point(i, j + 1));

                if (!points.Contains(new Point(i, j + 1)))
                {
                    right = MaxSum(A, cumSum, i, j + 1, currentSum + A[i, j + 1], string.Format("{0}=>{1},{2} ", strPath, i, j + 1), pointTemp);
                }

            }


            if(j > 0 && i < r)
            {

                var pointTemp = new List<Point>(points);
                pointTemp.Add(new Point(i, j-1));

                if (!points.Contains(new Point(i, j -1)))
                {
                    left = MaxSum(A, cumSum, i, j - 1, currentSum + A[i, j - 1], string.Format("{0}=>{1},{2} ", strPath, i, j - 1), pointTemp);
                }
            }

            //if(j > 0)
            //{
            //    left = MaxSum(A, cumSum, i, j -1, currentSum + A[i, j + 1]);
            //}

            if(i < r-1 && j < c)
            {
                var pointTemp = new List<Point>(points);
                pointTemp.Add(new Point(i+1, j));
                down = MaxSum(A, cumSum, i+1, j, currentSum + cumSum[i+1, j], string.Format("{0}=>{1},{2} ", strPath, i+1, j ), pointTemp);
            }
                                  

            ans = Math.Max(left, Math.Max(currentSum, Math.Max(right,down)));

            return ans;


        }

        public static void PrintArray(Values[,] A)
        {

            Console.WriteLine();
            Console.WriteLine();

            var r = A.GetLength(0);
            var c = A.GetLength(1);


            for(int i=0; i < r; i ++)
            {


                for(int j=0;j < c;j++)
                {


                    Console.Write(A[i, j]+"      ");
                }

                Console.WriteLine();

            }


        }

        static void Main(string[] args)
        {

            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);
            int[][] A = new int[n][];

            temp = new int[n, m,m];
            BestSum = new int?[n, m];

            for (int A_i = 0; A_i < n; A_i++)
            {
                string[] A_temp = Console.ReadLine().Split(' ');
                A[A_i] = Array.ConvertAll(A_temp, Int32.Parse);
            }
            


            var dummyArray = new Values[n, m];

            var nonZeroCount = 0;
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {

                    dummyArray[i, j] = new Values(A[i][j]);



                }


            }


            long result = Solve(dummyArray);
            Console.WriteLine(result);

        }
    }
}
