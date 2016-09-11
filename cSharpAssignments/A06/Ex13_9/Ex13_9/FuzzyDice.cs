using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex13_9
{
    public partial class FuzzyDice : Form
    {
        const int priceRed = 5;
        const int priceGreen = 11;
        const int priceYellow = 13;
        const double percent = 0.05;

        public FuzzyDice()
        {
            InitializeComponent();
            this.BackColor = Color.White;
        }

        private void checkBoxRed_CheckedChanged(object sender, EventArgs e)
        {
            textBoxRedQ.Text = "0";
            if (checkBoxRed.Checked)
            {
                textBoxRedQ.Enabled = true;
            }
            else
            {
                textBoxRedQ.Enabled = false;
            }

        }

        private void checkBoxGreen_CheckedChanged(object sender, EventArgs e)
        {
            textBoxGreenQ.Text = "0";
            if (checkBoxGreen.Checked)
            {
                textBoxGreenQ.Enabled = true;
            }
            else
            {
                textBoxGreenQ.Enabled = false;
            }

        }

        private void checkBoxYellow_CheckedChanged(object sender, EventArgs e)
        {
            textBoxYellowQ.Text = "0";
            if (checkBoxYellow.Checked)
            {
                textBoxYellowQ.Enabled = true;
            }
            else
            {
                textBoxYellowQ.Enabled = false;
            }
            
        }

        private void textBoxRedQ_TextChanged(object sender, EventArgs e)
        {
            
            if (textBoxRedQ.Text=="")
            {
                textBoxRedQ.Text = "0";
            }

            textBoxCostRed.Text = Convert.ToString(Convert.ToDouble(textBoxRedQ.Text) * priceRed);
            CalculateFilds();
        }

        private void textBoxGreenQ_TextChanged(object sender, EventArgs e)
        {

            if (textBoxGreenQ.Text == "")
            {
                textBoxGreenQ.Text = "0";
            }

            textBoxCostGreen.Text = Convert.ToString(Convert.ToDouble(textBoxGreenQ.Text) * priceGreen);
            CalculateFilds();
        }

        private void textBoxYellowQ_TextChanged(object sender, EventArgs e)
        {
            if (textBoxYellowQ.Text == "")
            {
                textBoxYellowQ.Text = "0";
            }

            textBoxCostYellow.Text = Convert.ToString(Convert.ToDouble(textBoxYellowQ.Text) * priceYellow);
            CalculateFilds();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxRedQ.Text = "0";
            textBoxGreenQ.Text = "0";
            textBoxYellowQ.Text = "0";
            CalculateFilds();
        }
             
        
        private void CalculateFilds()
        {
            double subtotal, numberOfDices;
            double shipping = 1.5;
            subtotal = (Convert.ToDouble(textBoxRedQ.Text) * priceRed) + (Convert.ToDouble(textBoxGreenQ.Text) * priceGreen) + (Convert.ToDouble(textBoxYellowQ.Text) * priceYellow);
            textBoxSubtotal.Text = Convert.ToString(subtotal);
            
            textBoxTax.Text = Convert.ToString(subtotal + subtotal * percent);
            numberOfDices = Convert.ToDouble(textBoxRedQ.Text) + Convert.ToDouble(textBoxGreenQ.Text) + Convert.ToDouble(textBoxYellowQ.Text);
            if (numberOfDices > 20)
            {
                shipping = 0;
                textBoxshipping.Text = "free";
                labelShipping.Text = "shipping is free because you ordered more than 20 dices";
            }
            else {
                shipping = 1.5;
                textBoxshipping.Text = "$1.50";
                labelShipping.Text = "";
            }

            textBoxTotal.Text = Convert.ToString(subtotal + subtotal * percent+shipping);

        }

     
    }
}