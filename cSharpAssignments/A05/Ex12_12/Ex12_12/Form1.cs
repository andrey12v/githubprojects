using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex12_12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string[] snack = new string[4];
            snack[0] = "Cookie";
            snack[1] = "Bubble Gum";
            snack[2] = "Pretzels";
            snack[3] = "Soda";

            try
            {
                label6.Text = snack[Convert.ToInt32(textBox1.Text)] + " has been dispensed";
            }
            catch (IndexOutOfRangeException ex1)
            {
                MessageBox.Show(ex1.Message, "Index bound error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (FormatException ex2)
            {
                MessageBox.Show(ex2.Message, "Format error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                textBox1.Text = "";
            }



        }
    }
}