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
            

            while(curr_div != 1)
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
                str += $"{r[0]} * {(curr_div / (int)Pow(10, 0)) % 10} ) / {d} <=> {new_div} / {d} <=> ";

                divs.Add(curr_div);
                curr_div = new_div;
                if (divs.Contains(curr_div)) break;
            }
            rtb.Text += str;
        } 
    }
}
