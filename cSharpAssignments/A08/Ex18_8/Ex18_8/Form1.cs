using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Ex18_8
{
    public partial class Form1 : Form
    {
        private StreamWriter fileWriter;
        private StreamReader fileReader;
        private FileStream output;
        private FileStream input; 
        private string inp;


        public Form1()
        {
            
            InitializeComponent();
            inp = "";
            try
            {
            output = new FileStream("numbers.txt",
               FileMode.Create, FileAccess.Write);
            fileWriter = new StreamWriter(output);

            }
            catch (IOException)
            {
                MessageBox.Show("Error opening file", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void textBoxFrequency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((Convert.ToInt32(textBoxFrequency.Text) < 0) || (Convert.ToInt32(textBoxFrequency.Text) > 10))
                {
                    MessageBox.Show("Type numbers in the range from 0 to 10", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxFrequency.Text = "";
                }
                else
                {
                    if (inp == "")
                    {
                        inp += textBoxFrequency.Text;
                    }
                    else
                    {
                        inp = inp + "," + textBoxFrequency.Text;
                    }
                    textBoxFrequency.Text = "";
                }
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            fileWriter.WriteLine(inp);
            
            if (output != null)
            {
                try
                {
                    fileWriter.Close(); // close StreamWriter
                    output.Close(); // close file
                } 
                catch (IOException)
                {
                    MessageBox.Show("Cannot close file", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
            
            input = new FileStream("numbers.txt", FileMode.Open, FileAccess.Read);
            fileReader = new StreamReader(input);

            int i;
            string inputRecord = fileReader.ReadLine();
            string[] inputFields; // will store individual pieces of data
           

            if (inputRecord != null)
            {
                inputFields = inputRecord.Split(',');
                int[] frequency = new int[inputFields.Length];
                int[] tmp = new int[inputFields.Length];

                for (i = 0; i < inputFields.Length; i++)
                {
                    tmp[i] = Convert.ToInt32(inputFields[i]);
                }
                Array.Sort(tmp);

                for (i = 0; i < inputFields.Length; i++)
                {
                    frequency[i] = 0;
                }
                
                for (i = 0; i < inputFields.Length; i++)
                {
                        frequency[tmp[i]] = frequency[tmp[i]] + 1;
                }

                listBoxOutput.Items.Add("RATING     FREQUENCY");
                for (i = 0; i < 11; i++)
                {
                    
                    if (i < inputFields.Length)
                    {
                        listBoxOutput.Items.Add(i + "_________" + frequency[i]);
                    }
                    else if (i>=inputFields.Length) 
                    {
                        listBoxOutput.Items.Add(i + "_________" + 0);
                    }
                                
                }
                                              
                        
            }
            input.Close();
            btnDone.Enabled = false;
            btnStartNew.Enabled = true;

        }

        private void textBoxFrequency_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStartNew_Click(object sender, EventArgs e)
        {
            inp = "";
            listBoxOutput.Items.Clear();
            try
            {
                output = new FileStream("numbers.txt",
                   FileMode.Create, FileAccess.Write);
                fileWriter = new StreamWriter(output);

            }
            catch (IOException)
            {
                MessageBox.Show("Error opening file", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnDone.Enabled = true;
            
            
            
        }

              
      
    }
}