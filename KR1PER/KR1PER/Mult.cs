using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;
using System.Windows.Forms;

namespace KR1PER
{
    public class Mult
    {
        public int M1;
        public int M2;
        public int[] A1;
        public int[] A2;
        public int[] A1_D;
        public int[] A2_D;
        public int[] A_K;
        public int[] B_K;
        public int[] AINV;

        int n;
        public int res_prom1 = 0;
        public int res_prom2 = 0;
        public int res_prom3 = 0;
        public RichTextBox rtb;


        public Mult(RichTextBox rtb)
        {
            this.rtb = rtb;
        }

        public void ConvToMass()
        {
            A1 = new int[CountOfNumber(M1) + CountOfNumber(M2) - 1];
            A2 = new int[CountOfNumber(M1) + CountOfNumber(M2) - 1];


            A1_D = new int[Math.Max(CountOfNumber(M1), CountOfNumber(M2))];
            A2_D = new int[Math.Max(CountOfNumber(M1), CountOfNumber(M2))];

            

            A1 = Con(M1, (CountOfNumber(M1) + CountOfNumber(M2) - 1));
            A2 = Con(M2, (CountOfNumber(M1) + CountOfNumber(M2) - 1));
            AINV = Con_Inv(M2, (CountOfNumber(M1) + CountOfNumber(M2) - 1));

            A1_D = Con_en(M1, Math.Max(CountOfNumber(M1), CountOfNumber(M2)));
            A2_D = Con_en(M2, Math.Max(CountOfNumber(M1), CountOfNumber(M2)));
        }

        public int MMU() // метод методического умножения
        {
            int[] res;

            rtb.Text += '\n';
            rtb.Text += "Метод Методического умножения";
            rtb.Text += '\n';

            int k = CountOfNumber(M1) + CountOfNumber(M2) - 1;
            int k1 = k- CountOfNumber(M1);
            int k2 = k - CountOfNumber(M2);

            res = new int[CountOfNumber(M1*M2)];

            for (int i = 0; i < CountOfNumber(M1 * M2); i++)
            {
                res[i] = 0;
            }
            

            for (int i = 0; i < k; i++)
            {
                res_prom2 = 0;

                for (int f1 = 0; f1 < k; f1++) // результат умножения и сложения на данной итерации
                {
                    res_prom2 += A1[f1] * AINV[f1];
                }

                res_prom3 = 0;

                for (int f4 = res.Length - 1 - i; f4 >= 0; f4--) // выделяются из результата числа, которые могут быть просуммированы с текущим результатом
                {
                    res_prom3 += res[f4] * (int)Math.Pow(10, (res.Length - 1 - i - f4));                   
                }
                
                res_prom3 += res_prom2;
                res_prom1 = res_prom3;
                /*
                Form1.richTextBox1.Text += '\n';
                Form1.richTextBox1.Text += "***res_prom3 ";
                Form1.richTextBox1.Text += Convert.ToString(res_prom3);
                Form1.richTextBox1.Text += "***";
                Form1.richTextBox1.Text += '\n';
                */
                for (int f1 = 0; f1 < CountOfNumber(res_prom1); f1++)
                {                  
                    res[CountOfNumber(M1 * M2)-i-1-f1] = res_prom3 % 10;
                    res_prom3 = res_prom3 / 10;
                }


                rtb.Text += '\n';
                VIV1(A1);
                VIV1(AINV);
                rtb.Text += "-------";
                rtb.Text += '\n';
                VIV1(res);
                rtb.Text += '\n';


                if (k1 > 0)
                {
                    for (int f2 = k - 1; f2 > 0; f2--)
                    {
                        A1[f2] = A1[f2 - 1];
                        A1[f2 - 1] = 0;
                    }
                    k1 = k1 - 1;
                }
                else
                if (k2 > 0)
                {
                    for (int f2 = 0; f2 < k - 1; f2++)
                    {
                        AINV[f2] = AINV[f2 + 1];
                        AINV[f2 + 1] = 0;
                    }
                    k2 = k2 - 1;
                }
                
            }

            rtb.Text += "Ответ: ";
            rtb.Text += '\n';
            rtb.Text += Conv_To_Number(res);
            return 0;
        }

        public int MSU() //Метод сокращенного умножения
        {
            int[] res;
            int[,] res_D;

            res = new int[CountOfNumber(M1 * M2)];
            res_D = new int[CountOfNumber(M1 * M2), CountOfNumber(M1 * M2)];

            for (int i = 0; i < CountOfNumber(M1 * M2); i++)
            {
                res[i] = 0;
            }
            rtb.Text += '\n';
            rtb.Text += "Метод Сокращенного умножения";
            rtb.Text += '\n';
            VIV1(A1_D);
            VIV1(A2_D);
            rtb.Text += "-------";
            for (int i = A1_D.Length - 1; i >= 0; i--) // по количеству итераций, разных перекрестий
            {
                for (int j = i; j >= 0; j--) // по количеству итераций сдвига перекрестия
                {
                    //нужна динамическая матрица
                }
            }
            
            return 0;
        }

        public int MRU() // метод русского уиножения
        {
            rtb.Text += '\n';
            rtb.Text += '\n';
            rtb.Text += "Метод Русского умножения";
            rtb.Text += '\n';
            int M1_D = M1;
            int M2_D = M2;
            int Result = 0;

            while(M1_D >= 1)
            {
                rtb.Text += '\n' + M1_D + "  " + M2_D;
                if (M1_D % 2 != 0)
                {
                    
                    rtb.Text += "**";
                    Result += M2_D;
                }
                else
                {
                   
                }
                M1_D = M1_D / 2;
                M2_D = M2_D * 2;                
            }
            rtb.Text += '\n';
            rtb.Text += "Складываем все значения с обозначением **, получаем ответ: ";
            rtb.Text += Result;
            rtb.Text += '\n';

            return 0;
        }

        public int MKB(int a, int b) //Метод Карацубы
        {
            int[] a1;
            int[] a2;
            int[] b1;
            int[] b2;
            int n, n2;
            long RX;
            
            
            n = Math.Max(CountOfNumber(a), CountOfNumber(b));
            n2 = Division_(n, 2);
            if (n % 2 != 0) n++;

            A_K = new int[n];
            B_K = new int[n];
            A_K = Con_en(a, n);
            B_K = Con_en(b, n);

            a1 = new int[n2];
            b1 = new int[n2];
            a2 = new int[n2];
            b2 = new int[n2];

            for (int i = 0; i < A_K.Length; i++)
            {                
                if (i < n - n2)     a1[i] = A_K[i];
                else                a2[i-n2] = A_K[i];                    
            }
            for (int i = 0; i < B_K.Length; i++)
            {
                if (i < n - n2)     b1[i] = B_K[i];
                else                b2[i-n2] = B_K[i];
            }

            rtb.Text += "-------*******-------";
            rtb.Text += '\n';
            rtb.Text += "n="+n;
            rtb.Text += '\n';
            rtb.Text += "n/2= " + n2;
            rtb.Text += '\n';
            rtb.Text += "a= " + Conv_To_Number(A_K);
            rtb.Text += '\n';
            rtb.Text += "b= " + Conv_To_Number(B_K);
            rtb.Text += '\n';
            rtb.Text += "a1= " + string.Join("", a1);
            rtb.Text += '\n';
            rtb.Text += "a2= " + string.Join("", a2);
            rtb.Text += '\n';
            rtb.Text += "b1= " + string.Join("", b1);
            rtb.Text += '\n';
            rtb.Text += "b2= " + string.Join("", b2);
            rtb.Text += '\n';
            rtb.Text += Conv_To_Number(a1) + "*" + Conv_To_Number(b1) + "*" + 10 + "^" + n + "+ ((" + Conv_To_Number(a1) + " + " + Conv_To_Number(a2) + ")" + "*(" + Conv_To_Number(b1) + " + " + Conv_To_Number(b2) + ")" + " - " + Conv_To_Number(a1) + "*" + Conv_To_Number(b1) + " - " + Conv_To_Number(a2) + "*" + Conv_To_Number(b2) + ")" + "*" + 10 + "^" + n / 2 + " + " + Conv_To_Number(a2) + "*" + Conv_To_Number(b2);
            RX = (Conv_To_Number(a1) * Conv_To_Number(b1) * (int)Math.Pow(10, n)) + ((Conv_To_Number(a1) + Conv_To_Number(a2)) * (Conv_To_Number(b1) + Conv_To_Number(b2)) - Conv_To_Number(a1) * Conv_To_Number(b1) - Conv_To_Number(a2) * Conv_To_Number(b2)) * (int)Math.Pow(10, n2) + Conv_To_Number(a2) * Conv_To_Number(b2);



            //rtb.Text += '\n';
            rtb.Text += " Ответ: ";
            rtb.Text += RX;
            rtb.Text += '\n';

            if (n > 2)
            {
                MKB(Conv_To_Number(a1), Conv_To_Number(b1));
                MKB(Conv_To_Number(a2), Conv_To_Number(b2));
                MKB((Conv_To_Number(a1) + Conv_To_Number(a2)),(Conv_To_Number(b1) + Conv_To_Number(b2)));
            }

            return 0;
        }

        public int MKB_ ()//Метод Карацубы, управляющий метод
        {
            rtb.Text += '\n';
            rtb.Text += "Метод Карацубы";
            rtb.Text += '\n';

            MKB(M1, M2);

            return 0;
        }

            public int Division_ (int a, int b)
        {
            int R2;
            R2 = a / b;
            if (a % b != 0) R2 = R2 + 1;
            return R2;
        }

            public int[] Con(int x, int AL) // преобразует число в массив
        {
            n = CountOfNumber(x) - 1;
            int[] mas = new int[AL];

            while (x > 0)
            {
                mas[n] = x % 10;
                x = x / 10;
                if(x > 0) n--;
            }
            return mas;
        }

        public int[] Con_en(int x, int AL) // преобразует число в массив
        {            
            int[] mas = new int[AL];
            n = mas.Length - 1;

            while (x > 0)
            {
                mas[n] = x % 10;
                x = x / 10;
                if (x > 0) n--;
            }
            return mas;
        }

        public int[] Con_Inv(int x, int AL) // преобразует число в массив с инверсией значащих цифр (применяется для методического умножения)
        {
            n = AL - CountOfNumber(x);
            int[] mas = new int[AL];

            while (x > 0)
            {
                mas[n] = x % 10;
                x = x / 10;
                n++;
            }
            return mas;
        }

        public int CountOfNumber(int x) //подсчитывает количество цифр в числе х
        {
            int CON = 0;
            while (x > 0)
            {
                x = x / 10;
                CON++;
            }
            return CON;
        }
        public void VIV1(int[] Arr) //выводит поэлементно массив Arr в поле richTextBox1
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                rtb.Text += Arr[i];
            }
            rtb.Text += '\n';
        }

        public void VIV2(int[] Arr) //выводит поэлементно массив Arr в поле richTextBox1
        {           
            rtb.Text += string.Join(" ", Arr);
            rtb.Text += '\n';
        }

        public int Conv_To_Number(int[] Arr) //преобразует массив Arr в число
        {
            int Result = 0;
            for (int i = Arr.Length-1; i >= 0; i--)
            {
                Result += Arr[i] * (int)Math.Pow(10, Arr.Length - 1 - i);
            }
            return Result;
        }
    }        
}
