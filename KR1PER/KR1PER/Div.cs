﻿using System;
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
            str += "\n Паскаль: \n";
            str += $"\nn = {n}, d = {d}\n";
            str += "n = 10^s*n_s + 10^s-1*n_s-1 + ... + 10*n_1 + n_0\n";
            str += "10 = a_1*d +r_1\n10^2 = a_2*d +r_2\n10^s = a_s*d +r_s\n";
            str += "n/d <=> (r_s*n_s + r_s-1*n_s-1 + ... + r_1*n_1 + r_0)/d\n\n";
            int am = Mult.CountOfNumber(n);
            int[] r = new int[n];
            for (int i = 0; i < am; i++)
            {
                r[i] = (int)Pow(10, i) % d;
                str += $"r_{i} = {r[i]}\n";
            }
            str += $"{n} / {d} <=> ";
            List<int> divs = new List<int>();
            int curr_div = n;


            while (curr_div != 0)
            {
                int s = Mult.CountOfNumber(curr_div);
                str += "( ";
                int new_div = 0;

                for (int i = s - 1; i > 0; i--)
                {
                    new_div += r[i] * ((curr_div / (int)Pow(10, i)) % 10);
                    str += $"{r[i]} * {((curr_div / (int)Pow(10, i)) % 10)} + ";
                }
                new_div += r[0] * ((curr_div / (int)Pow(10, 0)) % 10);
                str += $"{r[0]} * {(curr_div / (int)Pow(10, 0)) % 10} ) / {d} <=> {new_div} / {d}";

                divs.Add(curr_div);
                curr_div = new_div;
                if (divs.Contains(curr_div)) break;
                else str += " <=>";
            }
            rtb.Text += str;
        }
        public void SimplePascal()
        {
            string str = "";
            str += "\n Упрощённый Паскаль: \n";
            str += $"\nn = {n}, d = {d}\n";
            str += "n = 10^t*a + b0\n";
            str += "n/d <=> (r_t*a + b)/d\n\n";
            str += "r рассчитываются в предыдущем методе\n";
            int am = Mult.CountOfNumber(n);
            int[] r = new int[n];
            for (int i = 0; i < am; i++)
            {
                r[i] = (int)Pow(10, i) % d;
                str += $"r_{i} = {r[i]}\n";
            }
            str += $"{n} / {d} <=> ";
            List<int> divs = new List<int>();
            List<int> rs = new List<int>();
            int curr_div = n;


            while (curr_div != 0)
            {
                int s = Mult.CountOfNumber(curr_div);
                str += "( ";
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
                str += $"{r[i]} * {curr_div / (int)Pow(10, i)} + {curr_div % (int)Pow(10, i)} ) / {d} <=> {new_div} / {d}";
                divs.Add(curr_div);

                curr_div = new_div;
                if (divs.Contains(curr_div) && rs.Contains(r[i])) break;
                else
                {
                    str += " <=>";
                    rs.Add(r[i]);
                }
            }
            rtb.Text += str;
        }
        public void Rachinskiy1()
        {
            string str = "";
            str += "\n Метод Рачинского 1: \n";
            str += $"\nn = {n}, p = {d}\n";
            str += "n = 10*m + k (0<=k<=9)\n";
            str += "p = 10*a + b (0<=b<=9)\n";
            str += "n/p <=> |b*m - a*k|/p\n\n";
            int a = 0, b, m, k, n1 = 0;
            int n_d = n;
            str += $"{n_d}/{d} <=> ";
            while (n_d > d && n1 != n_d)
            {
                k = n_d % 10;
                m = (n_d - k) / 10;
                b = d % 10;
                a = (d - b) / 10;
                n1 = n_d;
                n_d = m * b - a * k;
                str += $"({b}*{m} - {a}*{k})/{d} <=> {n_d}/{d}\n";
                str += " <=> ";
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
