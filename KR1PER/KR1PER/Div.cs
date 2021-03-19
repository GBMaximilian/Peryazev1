using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;

namespace KR1PER
{
    class Div
    {
        int n, d;
        RichTextBox rtb;
        public Div(RichTextBox rtb, int n, int d)
        {
            this.rtb = rtb;
            this.n = n;
            this.d = d;
        }
        public void Pascal()
        {
            string str = "";
            str += "\t\n\n Паскаль: \n";
            str += $"\nn = {n}, d = {d}\n";
            str += "(r_s*n_s + r_s-1*n_s-1 + ... + r_1*n_1 + r_0)\n\n";
            int am = Mult.CountOfNumber(n);
            int j = 0;
            int[] r = new int[n];
            for (int i = 0; i < am; i++)
            {
                r[i] = (int)Pow(10, i) % d;
                str += $"r_{i} = {r[i]}\n";
            }
            List<int> divs = new List<int>();
            int curr_div = n;


            while (curr_div != 0)
            {
                int s = Mult.CountOfNumber(curr_div);
                str += $" {++j}) ( ";
                int new_div = 0;

                for (int i = s - 1; i > 0; i--)
                {
                    new_div += r[i] * ((curr_div / (int)Pow(10, i)) % 10);
                    str += $"{r[i]} * {((curr_div / (int)Pow(10, i)) % 10)} + ";
                }
                new_div += r[0] * ((curr_div / (int)Pow(10, 0)) % 10);
                str += $"{r[0]} * {(curr_div / (int)Pow(10, 0)) % 10} ) = {new_div} \n";

                divs.Add(curr_div);
                curr_div = new_div;
                if (divs.Contains(curr_div)) break;
                else str += "";
            }
            rtb.Text += str;
            rtb.Text += $"Ответ: {n}/{d} <=> {curr_div}/{d}\n";
        }
        public void SimplePascal()
        {
            string str = "";
            str += "\t\n\n Упрощённый Паскаль: \n";
            str += $"\nn = {n}, d = {d}\n";
            str += "(r_t*a + b)\n\n";
            str += "r рассчитываются в предыдущем методе\n";
            int am = Mult.CountOfNumber(n);
            int[] r = new int[n];
            for (int i = 0; i < am; i++)
            {
                r[i] = (int)Pow(10, i) % d;
                str += $"r_{i} = {r[i]}\n";
            }
            List<int> divs = new List<int>();
            List<int> rs = new List<int>();
            int curr_div = n;
            int j = 0;

            while (curr_div != 0)
            {
                int s = Mult.CountOfNumber(curr_div);
                str += $" {++j}) ( ";
                int new_div = 0;

                int i;
                if (s > 1)
                {
                    i = s / 2;
                }
                else
                {
                    i = s - 1;
                }
                i = s - 1;
                new_div += r[i] * (curr_div / (int)Pow(10, i)) + curr_div % (int)Pow(10, i);
                str += $"{r[i]} * {curr_div / (int)Pow(10, i)} + {curr_div % (int)Pow(10, i)} ) = {new_div}\n";
                divs.Add(curr_div);

                curr_div = new_div;
                if (divs.Contains(curr_div) && rs.Contains(r[i])) break;
                else
                {
                    rs.Add(r[i]);
                }
            }
            rtb.Text += str;
            rtb.Text += $"Ответ: {n}/{d} <=> {curr_div}/{d}\n";
        }
        public void Rachinskiy1()
        {
            string str = "";
            str += "\t\n\n Метод Рачинского 1: \n";
            str += $"\nn = {n}, p = {d}\n";
            str += "|b*m - a*k|\n\n";
            int n_d = n;
            int a = 0, b, m, k, n1 = 999999;
            str += $"{n_d}/{d} = \n";
            int i = 0;
            while (n_d > d && n1 > n_d)
            {
                k = n_d % 10;
                m = (n_d - k) / 10;
                b = d % 10;
                a = (d - b) / 10;
                n1 = n_d;
                n_d = Math.Abs(m * b - a * k);
                str += $" {++i}) ({b}*{m} - {a}*{k}) = {n_d}\n";
                if (n_d < d && n_d != 0)
                {
                    str += $"Ответ: {n_d} Не делится на {d}";
                }
                if (n_d == d || n_d == 0)
                {
                    str += $"Ответ: {n_d} Делится на {d}";
                }
            }
            rtb.Text += str;
        }

        public void Rachinskiy2()
        {
            string str = "";
            str += "\t\n\n Метод Рачинского 2: \n";
            str += $"\nn = {n}, p = {d}\n";
            str += "m+kq\n";
            int q = 0, b, m, k, n1 = 999999;
            int n_d = n;
            int i = 0;

            b = d % 10;
            if (b == 1 || b == 9)
            {
                b = 10 - b;
            }
            q = (d * b + 1) / 10;
            str += $"q = ({d}*{b} + 1) / 10 = {q}\n\n";


            str += $"{n_d} = \n";

            while (n_d > d && n1 > n_d)
            {
                k = n_d % 10;
                m = (n_d - k) / 10;
                /*  деланм 1 раз так как p не меняется => и b тоже
                b = d % 10;
                if (b == 1 || b == 9)
                {
                    b = 10 - b;
                }
                q = (d * b + 1) / 10;
                str += $"q = ({d} * {b} + 1) / 10\n";
                */
                
                n1 = n_d;
                n_d = Math.Abs(m + k * q);
                str += $" {++i}) {m} + {k}*{q} = {n_d}\n";
                if ((n1 < n_d) && (n_d > d))
                {
                    str += "далее следует бесконечный цикл, а раз так, видимо оно не делится";
                    break;
                }
                if (n_d < d && n_d != 0)
                {
                    str += $"Ответ: {n_d} Не делится на {d}";
                }
                if (n_d == d || n_d == 0)
                {
                    str += $"Ответ: {n_d} Делится на {d}";
                }
            }
            rtb.Text += str;

        }

        public void Rachinskiy3()
        {
            string str = "";
            str += "\t\n\n Метод Рачинского 3: \n";
            str += $"\nn = {n}, p = {d}\n";
            str += "m-kq*\n";
            int q = 0, b, m, k, n1 = 999999, q1;
            int n_d = n;
            int i = 0;

            b = d % 10;
            if (b == 1 || b == 9)
            {
                b = 10 - b;
            }
            q = (d * b + 1) / 10;
            q1 = Math.Abs(d - q);
            str += $"q = ({d}*{b} + 1) / 10 = {q}\n";
            str += $"q* = |{d} - {q}| = {q1}\n";

            while (n_d > d && n1 > n_d)
            {
                k = n_d % 10;
                m = (n_d - k) / 10;
                /*
                b = d % 10;
                if (b == 1 || b == 9)
                {
                    b = 10 - b;
                }
                q = (d * b + 1) / 10;                
                q1 = Math.Abs(d - q);
                */
                n1 = n_d;
                n_d = Math.Abs(m - k * q1);

                str += $" {++i}) |{m} - {k}*{q1}| = {n_d}\n";

                if (n_d < d && n_d != 0)
                {
                    str += $"Ответ: {n_d} Не делится на {d}";
                }
                if (n_d == d || n_d == 0)
                {
                    str += $"Ответ: {n_d} Делится на {d}";
                }
            }
            rtb.Text += str;
        }
    }
}
