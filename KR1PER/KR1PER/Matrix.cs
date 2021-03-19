using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;

namespace KR1PER
{
    class Matrix
    {
        public int[][] M1_;
        public int[][] M2_;
        public int[][] MR_;
        public int[,] MD_;
        public int[,] MDR_;

        

        RichTextBox rtb;
        public Matrix (RichTextBox rtb)
        {
            this.rtb = rtb;
        }


        public int[][] MCH(int[][] A, int[][] B) //Метод Штрассена дл n=2
        {
            int[][] C;

            string str = "";

            C = new int[A.Length][ ];
            for (int i = 0; i < C.Length; i++) C[i] = new int[A.Length];

            int d1, d2, d3, d4, d5, d6, d7;
            
            d1 = Mult(SUM(A[0][0], A[1][1]), SUM(B[0][0], B[1][1]));
            //str += $"d1 = ({A[0][0]}+{A[1][1]}) * ({B[0][0]}+{B[1][1]}) = {d1}\n";

            d2 = Mult(RS(A[0][1], A[1][1]), SUM(B[1][0], B[1][1]));
            //str += $"d2 = ({A[0][1]}-{A[1][1]}) * ({B[1][0]}+{B[1][1]}) = {d2}\n";

            d3 = Mult(RS(A[1][0], A[0][0]), SUM(B[0][0], B[0][1]));
            //str += $"d3 = ({A[1][0]}-{A[0][0]}) * ({B[0][0]}+{B[0][1]}) = {d3}\n";

            d4 = Mult(SUM(A[0][0], A[0][1]), B[1][1]);
            //str += $"d4 = ({A[0][0]}+{A[0][1]}) * {B[1][1]} = {d4}\n";

            d5 = Mult(A[1][1], RS(B[1][0], B[0][0]));
            //str += $"d5 = {A[1][1]} * ({B[1][0]}-{B[0][0]}) = {d5}\n";

            d6 = Mult(A[0][0], RS(B[0][1], B[1][1]));
            //str += $"d6 = {A[0][0]} * ({B[0][1]}-{B[1][1]}) = {d6}\n";

            d7 = Mult(SUM(A[1][0], A[1][1]), B[0][0]);
            //str += $"d7 = ({A[1][0]}+{A[1][1]}) * {B[0][0]} = {d7}\n";

            C[0][0] = d1 + d2 - d4 + d5;
            //str += $"c00 = {d1}+{d2}-{d4}+{d5} = {C[0][0]}\n";
            C[0][1] = d4 + d6;
            //str += $"c01 = {d4} + {d6} = {C[0][1]}\n";
            C[1][0] = d5 + d7;
            //str += $"c10 = {d5} + {d7} = {C[1][0]}\n";
            C[1][1] = d1 + d3 + d6 - d7;
            //str += $"c11 = {d1} + {d3} + {d6} - {d7} = {C[1][1]}\n";

            //str += $"{C[0][0]} {C[0][1]}\n";
            //str += $"{C[1][0]} {C[1][1]}\n";

           // str += "\t\t-*-откат\n";

            rtb.Text += str;
            return C;
        }

        public int Mult(int a, int b) //умножение чисел
        {
            return a * b;
        }
        
        public int[][] Mult(int[][] a, int[][] b) //умножение матриц
        {
            return MCH(a, b);
        }
               
        public int SUM(int a, int b)
        {
            return a + b;
        }

        public int RS(int a, int b) //разность матриц
        {
            return a - b;
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
                System.Array.Copy(a21[i], 0, a[i + n], 0, n);//
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
            return 1 << log2(Math.Max(a.Length, Math.Max(a[0].Length, b[0].Length)));

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

        public int[][] summation(int[][] a, int[][] b)
        {
            int[][] C = new int[a.Length][];
            for (int i = 0; i < C.Length; i++) C[i] = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                    C[i][j] = a[i][j] + b[i][j];
            return C;
        }

        public int[][] subtraction(int[][] a, int[][] b)
        {
            int[][] C = new int[a.Length][];
            for (int i = 0; i < C.Length; i++) C[i] = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                    C[i][j] = a[i][j] - b[i][j];
            return C;
        }

        public int[][] multiStrassen(int[][] a, int[][] b, int n)
        {
            string str = $"************n={n}\n";
            rtb.Text += str;
            str = "";
            if (n == 2)
            {
                // return multiply(a, b);
                int[][] C = MCH(a, b);
                return C;
            }
            
            n = n >> 1;

            

            int[][] a11 = new int[n][];
            for (int i = 0; i < a11.Length; i++) a11[i] = new int[n];

            int[][] a12 = new int[n][];
            for (int i = 0; i < a12.Length; i++) a12[i] = new int[n];

            int[][] a21 = new int[n][];
            for (int i = 0; i < a21.Length; i++) a21[i] = new int[n];

            int[][] a22 = new int[n][];
            for (int i = 0; i < a22.Length; i++) a22[i] = new int[n];

            int[][] b11 = new int[n][];
            for (int i = 0; i < b11.Length; i++) b11[i] = new int[n];

            int[][] b12 = new int[n][];
            for (int i = 0; i < b12.Length; i++) b12[i] = new int[n];

            int[][] b21 = new int[n][];
            for (int i = 0; i < b21.Length; i++) b21[i] = new int[n];

            int[][] b22 = new int[n][];
            for (int i = 0; i < b22.Length; i++) b22[i] = new int[n];

            splitMatrix(a, a11, a12, a21, a22);
            splitMatrix(b, b11, b12, b21, b22);

            rtb.Text += "    a11\n";
            MTS(ref str, a11);

            rtb.Text += "    a12\n";
            MTS(ref str, a12);

            rtb.Text += "    a21\n";
            MTS(ref str, a21);

            rtb.Text += "    a22\n";
            MTS(ref str, a22);

            rtb.Text += "    b11\n";
            MTS(ref str, b11);

            rtb.Text += "    b12\n";
            MTS(ref str, b12);

            rtb.Text += "    b21\n";
            MTS(ref str, b21);

            rtb.Text += "    b22\n";
            MTS(ref str, b22);

            rtb.Text += str;
            str = "";

            rtb.Text += "d0 = (a11+a22)*(b11+b22)\n";
            rtb.Text += "(a11+a22)=\n";MTS(ref str, summation(a11, a22));
            rtb.Text += "(b11+b22)=\n";MTS(ref str, summation(b11, b22));
            int[][] p1 = multiStrassen(summation(a11, a22), summation(b11, b22), n);
            rtb.Text += "d0=\n"; MTS(ref str, p1);
            rtb.Text += "\n==*==\n";
            rtb.Text += "d6 = (a21+a22)*(b11)\n";
            rtb.Text += "(a21+a22)=\n"; MTS(ref str, summation(a21, a22));
            rtb.Text += "(b11)=\n"; MTS(ref str, b11);
            int[][] p2 = multiStrassen(summation(a21, a22), b11, n);
            rtb.Text += "d6=\n"; MTS(ref str, p2);
            rtb.Text += "\n==*==\n";
            rtb.Text += "d4 = (a11)*(b12-b22)\n";
            rtb.Text += "(a11)=\n"; MTS(ref str, a11);
            rtb.Text += "(b12-b22)=\n"; MTS(ref str, subtraction(b12, b22));
            int[][] p3 = multiStrassen(a11, subtraction(b12, b22), n);
            rtb.Text += "d4=\n"; MTS(ref str, p3);
            rtb.Text += "\n==*==\n";
            rtb.Text += "d5 = (a22)*(b21-b11)\n";
            rtb.Text += "(a22)=\n"; MTS(ref str, a22);
            rtb.Text += "(b21-b11)=\n"; MTS(ref str, subtraction(b21, b11));
            int[][] p4 = multiStrassen(a22, subtraction(b21, b11), n);
            rtb.Text += "d5=\n"; MTS(ref str, p4);
            rtb.Text += "\n==*==\n";
            rtb.Text += "d3 = (a11+a12)*(b22)\n";
            rtb.Text += "(a11+a12)=\n"; MTS(ref str, summation(a11, a12));
            rtb.Text += "(b22)=\n"; MTS(ref str, b22);
            int[][] p5 = multiStrassen(summation(a11, a12), b22, n);
            rtb.Text += "d3=\n"; MTS(ref str, p5);
            rtb.Text += "\n==*==\n";
            rtb.Text += "d2 = (a21-a11)*(b11+b12)\n";
            rtb.Text += "(a21-a11)=\n"; MTS(ref str, subtraction(a21, a11));
            rtb.Text += "(b11+b12)=\n"; MTS(ref str, summation(b11, b12));
            int[][] p6 = multiStrassen(subtraction(a21, a11), summation(b11, b12), n);
            rtb.Text += "d2=\n"; MTS(ref str, p6);
            rtb.Text += "\n==*==\n";
            rtb.Text += "d1 = (a12-a22)*(b21+b22)\n";
            rtb.Text += "(a12-a22)=\n"; MTS(ref str, subtraction(a12, a22));
            rtb.Text += "(b21+b22)=\n"; MTS(ref str, summation(b21, b22));
            int[][] p7 = multiStrassen(subtraction(a12, a22), summation(b21, b22), n);
            rtb.Text += "d1=\n"; MTS(ref str, p7);
            rtb.Text += "\n==*==\n";
            rtb.Text += "c11 = d0+d1-d3+d5\n";
            int[][] c11 = summation(summation(p1, p4), subtraction(p7, p5));
            MTS(ref str, c11);
            rtb.Text += "c12 = d3+d4\n";
            int[][] c12 = summation(p3, p5);
            MTS(ref str, c12);
            rtb.Text += "c21 = d5+d6\n";
            int[][] c21 = summation(p2, p4);
            MTS(ref str, c21);
            rtb.Text += "c22 = d0+d2+d4-d6\n";
            int[][] c22 = summation(subtraction(p1, p2), summation(p3, p6));
            MTS(ref str, c22);

            rtb.Text += str;

            return collectMatrix(c11, c12, c21, c22);            
        }

        public string MTS (ref string str, int[][] Matr)
        {
            for (int i = 0; i < Matr.Length; i++)
            {
                for (int j = 0; j < Matr.Length; j++) { rtb.Text += $"{Matr[i][j]} "; }
                rtb.Text += "\n";
            }
            return str;
        }
    }
}
