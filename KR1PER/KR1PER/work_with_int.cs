using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR1PER
{
    class Work_with_int
    {
        public static int Capacity(int n)
        {
            int res = 0;
            if (n == 0)
                res = 1;
            while (n > 0)
            {
                res++;
                n /= 10;

            }
            return res;
        }
        public static int MaxNumDoubleArrayCapacity(int[,] N)
        {
            int res = 0;
            Console.WriteLine(N.GetLength(0));
            Console.WriteLine(N.GetLength(1));
            for (int i = 0; i < N.GetLength(0); i++)
                for (int j = 0; j < N.GetLength(1); j++)
                {
                    if (N[i, j] != int.MaxValue && Capacity(N[i, j]) > res)
                        res = Capacity(N[i, j]);
                }
            return res;
        }
        public static string OutInCapacity(int n, int outCapacity)
        {
            string res = "";
            for (int i = 0; i < outCapacity - Capacity(n); i++)
                res += "  ";
            res += n.ToString();
            return res;
        }
        public static string OutNumDoubleArrayInCapacity(int[,] N)
        {
            string res = "";
            int cap = MaxNumDoubleArrayCapacity(N);
            for (int i = 0; i < N.GetLength(0); i++)
            {
                res += '|';
                for (int j = 0; j < N.GetLength(1); j++)
                {
                    res += OutInCapacity(N[i, j], cap) + " ";
                }
                res += "|\n";
            }
            return res;
        }
        public static string OutNumDoubleArrayForDeterminantInCapacity(int[, ] N)
        {
            string res = "";
            int cap = MaxNumDoubleArrayCapacity(N);
            for (int i = 0; i < N.GetLength(0); i++)
            {
                res += '|';
                if (i%2 == 1)
                {
                    for (int j = 0; j < cap; j++)
                    {
                        res += "  ";
                    }
                    for (int j = 0; j < N.GetLength(1) - 1; j++)
                    {
                        if (N[i, j] != int.MaxValue)
                        {
                            res += OutInCapacity(N[i, j], cap);
                            for (int k = 0; k < cap; k++)
                                res += "  ";
                        }
                    }

                    
                }
                else
                {
                    for (int j = 0; j < N.GetLength(1) - 1; j++)
                    {
                        if (N[i, j] != int.MaxValue)
                        {
                            res += OutInCapacity(N[i, j], cap);
                            for (int k = 0; k < cap; k++)
                                res += "  ";
                        }
                    }
                    res += OutInCapacity(N[i, N.GetLength(1) - 1], cap);
                }
                
                    
                
                
                res += "|\n";
            }
            return res;
        }
    }
}
