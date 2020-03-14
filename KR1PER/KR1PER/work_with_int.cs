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
            while (n > 0)
            {
                res++;
                n /= 10;

            }
            return res;
        }
        public static int MaxNumDoubleArrayCapacity(int[][] N)
        {
            int res = 0;
            for (int i = 0; i < N.Length; i++)
                for (int j = 0; j < N.Length; j++)
                {
                    if (N[i][j] != int.MaxValue && Capacity(N[i][j]) > res)
                        res = Capacity(N[i][j]);
                }
            return res;
        }
        public string OutInCapacity(int n, int outCapacity)
        {
            string res = "";
            for (int i = 0; i < outCapacity - Capacity(n))
                res += ' ';
            res += n.ToString();
            return res;
        }
    }
}
