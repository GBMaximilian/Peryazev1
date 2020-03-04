﻿using System;
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
        // Mult Z1 = new Mult();
        Matrix Z2 = new Matrix();
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
            /*
            Z1.M1 = Convert.ToInt32(textBox1.Text);
            Z1.M2 = Convert.ToInt32(textBox2.Text);
            textBox3.Text = Convert.ToString(Z1.M1 * Z1.M2);
            
            Z1.ConvToMass();
           
            Z1.MMU();
            Z1.MRU();            
            Z1.MKB_();
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

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("e","e");
            dataGridView2.Columns.Add("e", "e");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Z2.M1 = new int[dataGridView1.Columns.Count, dataGridView1.Columns.Count];
            Z2.M2 = new int[dataGridView1.Columns.Count, dataGridView1.Columns.Count];
            Z2.MR = new int[dataGridView1.Columns.Count, dataGridView1.Columns.Count];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    Z2.M1[i, j] = Convert.ToInt32(dataGridView1[j, i].Value); //у грида инверсия индексов
                    Z2.M2[i, j] = Convert.ToInt32(dataGridView2[j, i].Value);//у грида инверсия индексов
                }
            }

            for (int i = 0; i < Z2.M1.GetLength(0); i++)
            {
                for (int j = 0; j < Z2.M1.GetLength(0); j++)
                {
                    richTextBox3.Text += Z2.M1[i, j] + " ";
                }
                richTextBox3.Text += '\n';
            }

            for (int i = 0; i < Z2.M2.GetLength(0); i++)
            {
                for (int j = 0; j < Z2.M2.GetLength(0); j++)
                {
                    richTextBox3.Text += Z2.M2[i, j] + " ";
                }
                richTextBox3.Text += '\n';
            }
            richTextBox3.Text += '\n';
            richTextBox3.Text += "Ответ";
            richTextBox3.Text += '\n';
            Z2.MR =  Z2.MCH(Z2.M1, Z2.M2);

            for (int i = 0; i < Z2.MR.GetLength(0); i++)
            {
                for (int j = 0; j < Z2.MR.GetLength(0); j++)
                {
                    richTextBox3.Text += Z2.MR[i, j] + " ";
                }
                richTextBox3.Text += '\n';
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 1);
                dataGridView2.Columns.RemoveAt(dataGridView2.Columns.Count - 1);
            }
            catch { }
        }
    }
}
