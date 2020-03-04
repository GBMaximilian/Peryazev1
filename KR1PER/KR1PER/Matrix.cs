using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR1PER
{
    class Matrix
    {
        public int[,] M1;
        public int[,] M2;
        public int[,] MR;

        public int[,] MCH_(int[,] A, int[,] B) //Метод Штрассена
        {
            int[,] C;
            C = new int[A.GetLength(0), A.GetLength(0)];
            int[,] d1, d2, d3, d4, d5, d6, d7;
            
            return C;
        }

            public int[,] MCH(int[,] A, int[,] B) //Метод Штрассена
        {
            int[,] C;
            C = new int[A.GetLength(0), A.GetLength(0)];
            int d1, d2, d3, d4, d5, d6, d7;
            d1 = Mult(SUM(A[0, 0], A[1, 1]), SUM(B[0, 0], B[1, 1]));
            d2 = Mult(RS(A[0, 1], A[1, 1]), SUM(B[1, 0], B[1, 1]));
            d3 = Mult(RS(A[1, 0], A[0, 0]), SUM(B[0, 0], B[0, 1]));
            d4 = Mult(SUM(A[0, 0], A[0, 1]), B[1, 1]);
            d5 = Mult(A[1, 1], RS(B[1, 0], B[0, 0]));
            d6 = Mult(A[0, 0], RS(B[0, 1], B[1, 1]));
            d7 = Mult(SUM(A[1, 0], A[1, 1]), B[0, 0]);

            

            C[0, 0] = d1 + d2 - d4 + d5;
            C[1, 1] = d1 + d3 + d6 - d7;
            C[0, 1] = d4 + d6;
            C[1, 0] = d5 + d7;

            return C;
        }

        public int Mult(int a, int b) //умножение чисел
        {
            return a * b;
        }

        public int[,] Mult(int[,] a, int[,] b) //умножение матриц
        {
            return MCH(a, b);
        }

        public int[,] SUM(int[,] a, int[,] b) //сложение матриц
        {
            int[,] AR;
            AR = new int[a.GetLength(0), a.GetLength(0)];

            /*
             
             */
            return AR;
        }
        public int SUM(int a, int b)
        {
            return a + b;
        }

        public int[,] RS(int[,] a, int[,] b) //разность матриц
        {
            int[,] AR;
            AR = new int[a.GetLength(0), a.GetLength(0)];

            /*
             
             */
            return AR;

        }

        public int RS(int a, int b) //разность матриц
        {
            return a-b;
        }

        private static void splitMatrix(int[][] a, int[][] a11, int[][] a12, int[][] a21, int[][] a22) //разбитие матрицы
        {
            int n = a.Length >> 1;

            for (int i = 0; i < n; i++)
            {
                System.Array.Copy(a[i], 0, a11[i], 0, n);
                System.Array.Copy(a[i], n, a12[i], 0, n);
                System.Array.Copy(a[i + n], 0, a21[i], 0, n);
                System.Array.Copy(a[i + n], n, a22[i], 0, n);
            }
        }

        private static int[][] collectMatrix(int[][] a11, int[][] a12, int[][] a21, int[][] a22)
        {
            int n = a11.Length;
            int[][] a = new int[n << 1][];
            for (int i = 0; i < a.Length; i++)
                a[i] = new int[n << 1];
            
            for (int i = 0; i < n; i++)
            {
                System.Array.Copy(a11[i], 0, a[i], 0, n);
                System.Array.Copy(a12[i], 0, a[i], n, n);
                System.Array.Copy(a22[i], 0, a[i + n], n, n);
            }
            return a;
        }

        private static int log2(int x)
        {
            int result = 1;
            while ((x >>= 1) != 0) result++;
            return result;
        }

        private static int getNewDimension(int[][] a, int[][] b)
        {
            return 1 << log2(Math.Max(a.Length, Math.Max( a[0].Length, b[0].Length)));
            
        }

        private static int[][] addition2SquareMatrix(int[][] a, int n)
        {
            int[][] result = new int[n][];
            for (int i = 0; i < result.Length; i++)
                result[i] = new int[n];


            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    result[i][j] = a[i][j];
                }
            }
            return result;
        }

        private static int[][] multiStrassen(int[][] a, int[][] b, int n)
        {
            if (n <= 64)
            {
                return multiply(a, b);
            }

            n = n >> 1;

            int[][] a11 = new int[n][n];
            int[][] a12 = new int[n][n];
            int[][] a21 = new int[n][n];
            int[][] a22 = new int[n][n];

            int[][] b11 = new int[n][n];
            int[][] b12 = new int[n][n];
            int[][] b21 = new int[n][n];
            int[][] b22 = new int[n][n];

            splitMatrix(a, a11, a12, a21, a22);
            splitMatrix(b, b11, b12, b21, b22);

            int[][] p1 = multiStrassen(summation(a11, a22), summation(b11, b22), n);
            int[][] p2 = multiStrassen(summation(a21, a22), b11, n);
            int[][] p3 = multiStrassen(a11, subtraction(b12, b22), n);
            int[][] p4 = multiStrassen(a22, subtraction(b21, b11), n);
            int[][] p5 = multiStrassen(summation(a11, a12), b22, n);
            int[][] p6 = multiStrassen(subtraction(a21, a11), summation(b11, b12), n);
            int[][] p7 = multiStrassen(subtraction(a12, a22), summation(b21, b22), n);

            int[][] c11 = summation(summation(p1, p4), subtraction(p7, p5));
            int[][] c12 = summation(p3, p5);
            int[][] c21 = summation(p2, p4);
            int[][] c22 = summation(subtraction(p1, p2), summation(p3, p6));

            return collectMatrix(c11, c12, c21, c22);
        }
    }
}
