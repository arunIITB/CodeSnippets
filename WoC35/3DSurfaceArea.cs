using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DSurfaceArea
{
    class Program
    {


        static int SurfaceAreaSingle(int[,] A)
        {
            // Complete this function

            int ans = 0;

            var r = A.GetLength(0);
            var c = A.GetLength(1);

            var previousWasOne = false;

            // =>
            for(int i=0;i < r;i++)
            {

                for(int j=0; j < c;j++)
                {

                    if(A[i,j] == 1)
                    {
                        if (!previousWasOne)
                        {
                            
                            ans++;
                        }

                      

                    }

                    previousWasOne = A[i, j] == 1 ? true : false;

                }

                previousWasOne = false;

            }


            previousWasOne = false;
            for (int col=0; col < c;col++)
            {

                for(var row=r-1; row >=0;row --)
                {
                    if (A[row,col] == 1)
                    {
                        if (!previousWasOne)
                        {
                           
                            ans++;
                        }

                        
                    }

                    previousWasOne = A[row, col] == 1 ? true : false;
                }

                previousWasOne = false;
            }

            previousWasOne = false;

            for (int i = 0; i < r; i++)
            {

                for (int j = c-1; j >=0; j--)
                {

                    if (A[i,j] == 1)
                    {
                        if (!previousWasOne)
                        {
                           
                            ans++;
                        }
                      
                    }

                    previousWasOne = A[i, j] == 1 ? true : false;

                }

                previousWasOne = false;

            }

            previousWasOne = false;
            for (int col = 0; col < c; col++)
            {

                for (var row = 0; row < r; row++)
                {
                    if (A[row,col] == 1)
                    {
                        if (!previousWasOne)
                        {
                           
                            ans++;
                        }

                       
                    }

                    previousWasOne = A[row, col] == 1 ? true : false;
                }

                previousWasOne = false;
            }


            return ans;

        }


        static int surfaceArea(int[,] A)
        {
            // Complete this function

            int ans = 0;
            var r = A.GetLength(0);
            var c = A.GetLength(1);


            var nonZeroCount = 0;
            int maxHeight = 0;
            for (int i = 0; i < r; i++)
            {

                for (int j = 0; j < c; j++)
                {

                    if (A[i, j] >= 1)
                    {

                        nonZeroCount++;
                    }

                    if(maxHeight < A[i,j])
                    {
                        maxHeight = A[i, j];
                    }



                }


            }

            

            for(int height = 1; height <=maxHeight;height++)
            {
                var twoDimensionalArray = new int[r, c];

                for (int i = 0; i < r; i++)
                {

                    for (int j = 0; j < c; j++)
                    {

                        if (A[i, j] >= height)
                        {

                            twoDimensionalArray[i, j] = 1;
                        }

                        

                    }

                    
                }


                 ans+=  SurfaceAreaSingle(twoDimensionalArray);

            }



          

            ans += nonZeroCount + nonZeroCount;

            return ans;

        }


        static void Main(string[] args)
        {

            //var arr = new int[3,3]
            //{
            //    {1,1,1 },
            //    {1,1,1 },
            //    {1,1,1}
            //};



            //var ans = SurfaceAreaSingle(arr);


            string[] tokens_H = Console.ReadLine().Split(' ');
            int H = Convert.ToInt32(tokens_H[0]);
            int W = Convert.ToInt32(tokens_H[1]);
            int[][] A = new int[H][];
            for (int A_i = 0; A_i < H; A_i++)
            {
                string[] A_temp = Console.ReadLine().Split(' ');
                A[A_i] = Array.ConvertAll(A_temp, Int32.Parse);
            }

            var dummyArray = new int[H, W];

            var nonZeroCount = 0;
            for (int i = 0; i < H ; i++)
            {

                for (int j = 0; j < W; j++)
                {

                    dummyArray[i, j] = A[i][j];



                }


            }


            int result = surfaceArea(dummyArray);
            Console.WriteLine(result);
        }
    }
}
