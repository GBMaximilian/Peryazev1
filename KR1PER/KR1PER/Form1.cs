using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KR1PER.Work_with_int;

namespace KR1PER
{
    public partial class Form1 : Form
    {
        Mult Z1;
        Matrix Z2;
        public Form1()
        {
            InitializeComponent();
            Z1 = new Mult(richTextBox2);
            Z2 = new Matrix(richTextBox3);
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
           
            Z1.MMU();
            Z1.MRU();            
            Z1.MKB_();
            Z1.MSU();
          
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
            Z2.M1_ = new int[dataGridView1.Columns.Count][];
            for (int i = 0; i < Z2.M1_.Length; i++) Z2.M1_[i] = new int[dataGridView1.Columns.Count];

            Z2.M2_ = new int[dataGridView1.Columns.Count][];
            for (int i = 0; i < Z2.M2_.Length; i++) Z2.M2_[i] = new int[dataGridView1.Columns.Count];

            Z2.MR_ = new int[dataGridView1.Columns.Count][];
            for (int i = 0; i < Z2.MR_.Length; i++) Z2.MR_[i] = new int[dataGridView1.Columns.Count];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    Z2.M1_[i][j] = Convert.ToInt32(dataGridView1[j, i].Value); //у грида инверсия индексов
                    Z2.M2_[i][j] = Convert.ToInt32(dataGridView2[j, i].Value);//у грида инверсия индексов
                }
            }

            richTextBox3.Text += "\n Матрица a\n";
            for (int i = 0; i < Z2.M1_.Length; i++)
            {
                for (int j = 0; j < Z2.M1_.Length; j++)
                {
                    richTextBox3.Text += Z2.M1_[i][j] + " ";
                }
                richTextBox3.Text += '\n';
            }
            richTextBox3.Text += "\n Матрица b\n";
            for (int i = 0; i < Z2.M2_.GetLength(0); i++)
            {
                for (int j = 0; j < Z2.M2_.GetLength(0); j++)
                {
                    richTextBox3.Text += Z2.M2_[i][j] + " ";
                }
                richTextBox3.Text += '\n';
            }

            richTextBox3.Text += '\n';
            

            Z2.MR_ = Z2.multiStrassen(Z2.M1_, Z2.M2_, dataGridView1.Columns.Count);/////********

            richTextBox3.Text += '\n';
            richTextBox3.Text += "Ответ";
            richTextBox3.Text += '\n';
            for (int i = 0; i < Z2.MR_.Length; i++)
            {
                for (int j = 0; j < Z2.MR_.Length; j++)
                {
                    richTextBox3.Text += Z2.MR_[i][j] + " ";
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

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView3.Columns.Add("e", "e");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView3.Columns.RemoveAt(dataGridView3.Columns.Count - 1);

            }
            catch { }
        }

        //calculates determinant for 2x2
        private int DeterminantChio(int i_min, int j_min, int i_max, int j_max, int[,] array)
        {
            int result = array[i_max, j_max] * array[i_min, j_min] - array[i_min, j_max] * array[i_max, j_min];
            //richTextBox4.Text += $"result {result}\n";
            return array[i_max, j_max] * array[i_min, j_min] - array[i_min, j_max] * array[i_max, j_min];
        }

        private int DeterminantChioMethod (int dimension, int [,] MDR_2, int [,] MDR_3){
            int i_min = 9999999, j_min = 9999999, min = 9999999;
            for (int i = 0; i < MDR_2.GetLength(0); i++)
            {
                for (int j = 0; j < MDR_2.GetLength(1); j++)
                {
                    if (Math.Abs(MDR_2[i, j]) <= Math.Abs(min) && MDR_2[i, j] != 0)
                    {
                        min = MDR_2[i, j];
                        i_min = i;
                        j_min = j;
                        if (min == 1)
                        {
                            break;
                        }
                    }
                }
                if (min == 1)
                {
                    break;
                }
            }

            richTextBox4.Text += $"\nMDR_2 min [{i_min}, {j_min}]: {MDR_2[i_min, j_min]}\n";

            for (int k = 0; k < dimension - 1; k++)
            {
                for (int l = 0; l < dimension - 1; l++)
                { 
                    //if ((1 <= k) & (k <= i_min - 1) & (1 <= l) & (l <= j_min - 1))
                    if ((0 <= k) & (k <= i_min - 1) & (0 <= l) & (l <= j_min - 1))
                    {
                        MDR_3[k, l] = DeterminantChio(k, l, i_min, j_min, MDR_2);
                    }
                    //if ((1 <= k) & (k <= i_min - 1) & (j_min + 1 <= l) & (l <= dimension))

                    if ((0 <= k) & (k <= i_min - 1) & (j_min <= l) & (l <= dimension))
                    {
                        MDR_3[k, l] = DeterminantChio(k, j_min, i_min, l + 1, MDR_2);
                    }
                    if ((i_min <= k) & (k <= dimension) & (0 <= l) & (l <= j_min - 1))
                    //if ((i_min + 1 <= k) & (k <= dimension) & (1 <= l) & (l <= j_min - 1))
                    
                    {
                         MDR_3[k, l] = DeterminantChio(i_min, l, k + 1, j_min, MDR_2);
                        //MDR_3[k, l] = (int)(DeterminantChio(i_min, l, k, j_min, MDR_2) / Math.Pow(MDR_2[i_min, j_min], dimension - 2));
                    }
                    if ((i_min <= k) & (k <= dimension) & (j_min <= l) & (l <= dimension))
                    //if ((i_min + 1 <= k) & (k <= dimension) & (j_min + 1 <= l) & (l <= dimension))

                    {
                        MDR_3[k, l] = DeterminantChio(i_min, j_min, k + 1, l + 1, MDR_2);

                        //MDR_3[k, l] = (int)(DeterminantChio(i_min, j_min, k, l, MDR_2) / Math.Pow(MDR_2[i_min, j_min], dimension - 2));

                    }
                    richTextBox4.Text += $"\nMDR_3 [{k},{l}]: {MDR_3[k, l]}\n";
                }
            }
            return (int)Math.Pow(MDR_2[i_min, j_min], dimension - 2);
        }


        private void button6_Click(object sender, EventArgs e)
        {

            Z2.MD_ = new int[dataGridView3.Columns.Count, dataGridView3.Columns.Count];
            

            Z2.MDR_ = new int[dataGridView3.Columns.Count*2-1, dataGridView3.Columns.Count];
            

            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView3.Columns.Count; j++)
                {
                    Z2.MD_[i, j] = Convert.ToInt32(dataGridView3[j, i].Value); 
                }
            }
            for (int i = 0, k = 0; i < Z2.MDR_.GetLength(0); i++)
            {
                if (i%2 == 1 )
                {

                    for (int j = 0; j < Z2.MDR_.GetLength(1) - 1; j++)
                    {
                        Z2.MDR_[i, j] = Z2.MD_[k, j] * Z2.MD_[k + 1, j + 1] - Z2.MD_[k, j + 1] * Z2.MD_[k + 1, j];
                        //Z2.MDR_[i, j] = 0;
                    }

                    Z2.MDR_[i, Z2.MDR_.GetLength(1) - 1] = int.MaxValue;
                    k++;
                }
                else
                {
                    for (int j = 0; j < Z2.MDR_.GetLength(1); j++)
                    {
                        Z2.MDR_[i, j] = Z2.MD_[k, j];
                    }
                }
                
            }
            richTextBox4.Text += OutNumDoubleArrayInCapacity(Z2.MD_) + "\n = \n";
            richTextBox4.Text += OutNumDoubleArrayForDeterminantInCapacity(Z2.MDR_) + "\n = \n";
            int[,] MDR_1 = new int[Z2.MDR_.GetLength(0) - 2, Z2.MDR_.GetLength(1) - 1];
            //for (int l = 0; l < Z2.MDR_.GetLength(0) - 2; l++)
            if ((DeterminantChio(1, 1, 2, 2, Z2.MD_) != 0) && Z2.MD_[1, 1] * Z2.MD_[1, 2] * Z2.MD_[2, 1] * Z2.MD_[2, 2] != 0)
            {

                for (int i = 0; i < 5; i++)
                {

                    if (i % 2 == 1)
                    {

                        for (int j = 0; j < 2; j++)
                        {
                            MDR_1[i, j] = (Z2.MDR_[i, j] * Z2.MDR_[i+2, j+1] - Z2.MDR_[i, j + 1] * Z2.MDR_[i + 2, j])/ Z2.MDR_[i+1, j+1];
                            richTextBox4.Text += $"\n{MDR_1[i, j]}=({Z2.MDR_[i, j]}*{Z2.MDR_[i+2, j+1]}-{Z2.MDR_[i, j+1]}*{Z2.MDR_[i+2, j]})/{Z2.MDR_[i+1, j+1]}\n";
                            //Z2.MDR_[i, j] = 0;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            MDR_1[i, j] = Z2.MDR_[i + 1, j];
                        }
                    }
                }

                Z2.MDR_ = new int[MDR_1.GetLength(0), MDR_1.GetLength(1)];
                for (int i = 0; i < MDR_1.GetLength(0); i++)
                {
                    for (int j = 0; j < MDR_1.GetLength(1); j++)
                    {
                        Z2.MDR_[i, j] = MDR_1[i, j];
                    }
                }
                richTextBox4.Text += OutNumDoubleArrayForDeterminantInCapacity(Z2.MDR_) + "\n = \n";
                richTextBox4.Text += $"({MDR_1[1, 0]} * {MDR_1[3, 1]} - {MDR_1[1, 1]} * {MDR_1[3, 0]}) / {MDR_1[2, 1]} " +
                    $"= {(MDR_1[1, 0]*MDR_1[3, 1] - MDR_1[1, 1] * MDR_1[3, 0])/MDR_1[2,1]}\n";


            } 
            else
            {
                richTextBox4.Text += "Dodgson failed\n\n";
            }
            richTextBox4.Text += "Chio started ---------------------------\n";

            //------Chio-------
            int dimension = 4;
            int[,] MDR_2 = new int[Z2.MD_.GetLength(0), Z2.MD_.GetLength(1)];
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView3.Columns.Count; j++)
                {
                    MDR_2[i, j] = Z2.MD_[i, j];
                    //richTextBox4.Text += $"\nMDR_2 [{i},{j}]: {MDR_2[i, j]}\n";
                }
            }

            
            //DeterminantChio()
            int[,] MDR_3 = new int[Z2.MD_.GetLength(0) - 1, Z2.MD_.GetLength(1) - 1];
            int divider = 1;
            divider *= DeterminantChioMethod(dimension, MDR_2, MDR_3);
            int[,] MDR_4 = new int[MDR_3.GetLength(0), MDR_3.GetLength(1)];
            int[,] MDR_5 = new int[MDR_3.GetLength(0), MDR_3.GetLength(1)];
            int[,] MDR_6 = new int[MDR_3.GetLength(0) - 1, MDR_3.GetLength(1) - 1];
            int[,] MDR_7 = new int[MDR_3.GetLength(0) - 1, MDR_3.GetLength(1) - 1];
            divider *= DeterminantChioMethod(dimension - 1, MDR_3, MDR_4);

            richTextBox4.Text += $"\n Determinant Chio: {DeterminantChio(0, 0, 1, 1, MDR_4)/divider} \n-------\n\n";

            // Common Chio
            
            int ded = 1;
            int i_left_up = 0;
            int j_left_up = 0;
            int i_right_down = 0;
            int j_right_down = 0;

            for (i_left_up = 0; i_left_up < dimension - 1; ++i_left_up)
            {
                for (j_left_up = 0; j_left_up < dimension - 1; ++j_left_up)
                {
                    for (i_right_down = i_left_up + 1; i_right_down < dimension; ++i_right_down)
                    {
                        for (j_right_down = j_left_up + 1; j_right_down < dimension; ++j_right_down)
                        {
                            ded = DeterminantChio(i_left_up, j_left_up, i_right_down, j_right_down, MDR_2);
                            if (ded != 0)
                            {
                                break;
                            }
                        }
                        if (ded != 0)
                        {
                            break;
                        }
                    }
                    if (ded != 0)
                    {
                        break;
                    }
                }
                if (ded != 0)
                {
                    break;
                }
            }
            

            int i_left_up_2 = -1;
            int j_left_up_2 = -1;
            int i_right_down_2 = -1;
            int j_right_down_2 = -1;

            for (int i = 0; i < dimension; ++i)
            {
                if(i == i_left_up || i == i_right_down || i == i_left_up_2)
                {
                    continue;
                }
                for(int j = 0; j < dimension; ++j)
                {
                    if (j == j_left_up || j == j_right_down || j == j_left_up_2)
                    {
                        continue;
                    } else
                    {
                        if (i_left_up_2 == -1)
                        {
                            i_left_up_2 = i;
                            j_left_up_2 = j;
                        } else
                        {
                            i_right_down_2 = i;
                            j_right_down_2 = j;
                        }
                    }
                }
            }

            int[,] i_major = new int[2, 2];
            int[,] j_major = new int[2, 2];

            i_major[0, 0] = i_left_up_2;
            i_major[0, 1] = i_left_up_2;
            i_major[1, 0] = i_right_down_2;
            i_major[1, 1] = i_right_down_2;

            j_major[0, 0] = j_left_up_2;
            j_major[1, 0] = j_left_up_2;
            j_major[0, 1] = j_right_down_2;
            j_major[1, 1] = j_right_down_2;

            richTextBox4.Text += $"Minor's determinant: {ded}\n";
            richTextBox4.Text += $"Minor's indexes:\n";
            richTextBox4.Text += $" i_left_up = {i_left_up}; j_left_up = {j_left_up}\n";
            richTextBox4.Text += $" i_right_down = {i_right_down}; i_right_down = {j_right_down}\n";

            //richTextBox4.Text += $" i_left_up_2 = {i_left_up_2}; j_left_up_2 = {j_left_up_2}\n";
            //richTextBox4.Text += $" i_right_down_2 = {i_right_down_2}; i_right_down_2 = {j_right_down_2}\n";

            int[] i_array = new int[dimension - 1];
            int[] j_array = new int[dimension - 1];

            for(int k = 0; k < dimension - 2; ++k)
            {
                for (int l = 0; l < dimension - 2; ++l)
                {
                    i_array[0] = i_left_up;
                    i_array[1] = i_right_down;

                    j_array[0] = j_left_up;
                    j_array[1] = j_right_down;

                    i_array[2] = i_major[k, l];
                    j_array[2] = j_major[k, l];

                    Array.Sort(i_array);
                    Array.Sort(j_array);

                    for (int m = 0; m < dimension - 1; ++m)
                    {
                        for(int n = 0; n < dimension - 1; ++n)
                        {
                            MDR_5[m, n] = MDR_2[i_array[m], j_array[n]];
                        }
                    }
                    richTextBox4.Text += $"array[{k}, {l}]:\n{OutNumDoubleArrayInCapacity(MDR_5)} \n";
                    divider = DeterminantChioMethod(dimension - 1, MDR_5, MDR_6);
                    MDR_7[k, l] = DeterminantChio(0, 0, 1, 1, MDR_6) / divider;

                }
            }
            richTextBox4.Text += $"{OutNumDoubleArrayInCapacity(MDR_7)}\n";
            richTextBox4.Text += $"\n Determinant Common (Super Puper) Chio: {DeterminantChio(0, 0, 1, 1, MDR_7) / ded} \n";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Div div = new Div(richTextBox5, Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox5.Text));
            div.Pascal();
            div.SimplePascal();
            div.Rachinskiy1();
            div.Rachinskiy2();
            div.Rachinskiy3();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Введите квадратную матрицу со стороной, равной 2^n,\n" +
                "если сторона не соответствует - до дополните матрицу до таковой\n" +
                "нулевыми строками (справа и снизу), " +
                "например:\n2 6 8\t\t2 6 8 0\n" +
                "1 7 5\t\t1 7 5 0\n8 0 2\t\t8 0 2 0\n\t\t0 0 0 0");
        }
    }
}
