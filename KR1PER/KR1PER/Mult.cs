using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;

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
        public int[] AINV;

        int n;
        public int res_prom1 = 0;
        public int res_prom2 = 0;
        public int res_prom3 = 0;
        


        public void ConvToMass()
        {
            A1 = new int[CountOfNumber(M1) + CountOfNumber(M2) - 1];
            A2 = new int[CountOfNumber(M1) + CountOfNumber(M2) - 1];

            A1_D = new int[Math.Max(CountOfNumber(M1), CountOfNumber(M2))];
            A2_D = new int[Math.Max(CountOfNumber(M1), CountOfNumber(M2))];

            A1 = Con(M1, (CountOfNumber(M1) + CountOfNumber(M2) - 1));
            A2 = Con(M2, (CountOfNumber(M1) + CountOfNumber(M2) - 1));
            AINV = Con_Inv(M2, (CountOfNumber(M1) + CountOfNumber(M2) - 1));

            A1_D = Con(M1, Math.Max(CountOfNumber(M1), CountOfNumber(M2)));
            A2_D = Con(M2, Math.Max(CountOfNumber(M1), CountOfNumber(M2)));
        }

        public int MMU() // метод методического умножения
        {
            int[] res;
            Form1.richTextBox1.Text += '\n';
            Form1.richTextBox1.Text += "Метод Методического умножения";
            Form1.richTextBox1.Text += '\n';

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


                Form1.richTextBox1.Text += '\n';
                VIV1(A1);
                VIV1(AINV);
                Form1.richTextBox1.Text += "-------";
                Form1.richTextBox1.Text += '\n';
                VIV1(res);
                Form1.richTextBox1.Text += '\n';


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

            Form1.richTextBox1.Text += "Ответ: ";
            Form1.richTextBox1.Text += '\n';
            Form1.richTextBox1.Text += Conv_To_Number(res);
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
            Form1.richTextBox1.Text += '\n';
            Form1.richTextBox1.Text += "Метод Сокращенного умножения";
            Form1.richTextBox1.Text += '\n';
            VIV1(A1_D);
            VIV1(A2_D);
            Form1.richTextBox1.Text += "-------";
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
            Form1.richTextBox1.Text += '\n';
            Form1.richTextBox1.Text += '\n';
            Form1.richTextBox1.Text += "Метод Русского умножения";
            Form1.richTextBox1.Text += '\n';
            int M1_D = M1;
            int M2_D = M2;
            int Result = 0;

            while(M1_D >= 1)
            {
                if (M1_D % 2 != 0)
                {
                    Form1.richTextBox1.Text += '\n';
                    Form1.richTextBox1.Text += M1_D;
                    Form1.richTextBox1.Text += "  ";
                    Form1.richTextBox1.Text += M2_D;
                    Form1.richTextBox1.Text += "**";
                    Result += M2_D;
                }
                else
                {
                    Form1.richTextBox1.Text += '\n';
                    Form1.richTextBox1.Text += M1_D;
                    Form1.richTextBox1.Text += "  ";
                    Form1.richTextBox1.Text += M2_D;
                }
                M1_D = M1_D / 2;
                M2_D = M2_D * 2;                
            }
            Form1.richTextBox1.Text += '\n';
            Form1.richTextBox1.Text += "Складываем все значения с обозначением **, получаем ответ: ";
            Form1.richTextBox1.Text += Result;
            Form1.richTextBox1.Text += '\n';

            return 0;
        }

        public int MSU() //Метод сокращенного умножения
        {

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
                Form1.richTextBox1.Text += Arr[i];
            }
            Form1.richTextBox1.Text += '\n';
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
