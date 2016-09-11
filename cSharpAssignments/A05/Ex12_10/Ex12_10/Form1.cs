using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Ex12_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Directory.GetCurrentDirectory() + @textBox1.Text);
                textBox1.Clear();
            }
            catch (FileNotFoundException ex1)
            {
                MessageBox.Show("You entered the wrong path. Type correct file path!", "INCORRECT PATH", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                pictureBox1.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\images\image0.bmp");
            }
            finally 
            {
                textBox1.Clear();
            }
         
        }
    }
}