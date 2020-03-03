using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KR1PER
{
    public partial class Form1 : Form
    {
        Mult Z1 = new Mult();
        public Form1()
        {
            InitializeComponent();            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Z1.M1 = Convert.ToInt32(textBox1.Text);
            Z1.M2 = Convert.ToInt32(textBox2.Text);
            textBox3.Text = Convert.ToString(Z1.M1 * Z1.M2);
            
            Z1.ConvToMass();
            /*
            VIV(Z1.A1);
            VIV(Z1.AINV);
            */
            /*
            richTextBox1.Text += Z1.CountOfNumber(Z1.M1);
            richTextBox1.Text += " ";
            richTextBox1.Text += Z1.CountOfNumber(Z1.M2);
            richTextBox1.Text += " ";
            */

            ///*****
            
            Z1.MMU();
            Z1.MRU();
            
            ///******
            Z1.MKB();
            /*
            richTextBox1.Text += '\n';
            richTextBox1.Text += Z1.res_prom1;
            */
        }

        public void VIV(int[] Arr)
        {
            for(int i=0; i<Arr.Length; i++)
            {
                richTextBox2.Text += Arr[i];
                richTextBox2.Text += " ";
                
            }
            richTextBox2.Text += '\n';
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
