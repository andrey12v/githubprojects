using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex13_8
{
    public partial class GuessNumber : Form
    {
        public int RandNumber;
        
        public GuessNumber()
        {
            InitializeComponent();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            label1.Text = "I have a number between 1 and 1000  -- can you guess the number?";
            label2.Text="Please enetr your guess";
            textBoxGuess.Text = "";
            label3.Text = "";
            this.BackColor = Color.Empty;
            textBoxGuess.Enabled=true;
            Random random = new Random();
            RandNumber = random.Next(1, 1000);
            label4.Text = Convert.ToString(RandNumber);
        }

        private void textBoxGuess_TextChanged(object sender, EventArgs e)
        {
            if (textBoxGuess.Text=="")
            {
                textBoxGuess.Text = "";
            }
            else if (Convert.ToInt32(textBoxGuess.Text) < RandNumber)
            {
                label3.Text = "Too low";
                this.BackColor = Color.LightSkyBlue;
            
            }
            else if (Convert.ToInt32(textBoxGuess.Text) > RandNumber)
            {
                label3.Text = "Too high";
                this.BackColor = Color.Red;
            }
            else if (Convert.ToInt32(textBoxGuess.Text) == RandNumber) 
            {
                MessageBox.Show("You guessed the number!", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.BackColor = Color.Green;
                textBoxGuess.Enabled = false;
                label3.Text = "";
                label1.Text = "";
            }



        }
       
    
    }
}