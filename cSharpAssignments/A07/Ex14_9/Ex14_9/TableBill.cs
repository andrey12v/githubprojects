using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex14_9
{
    public partial class Form1 : Form
    {
        private double beverage;
        private double appetizer;
        private double mainCourse;
        private double desert;
        private const double tax = 0.05;

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBoxBeverage_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxBeverage.SelectedIndex)
            {
                case 0:
                    beverage = 1.95;
                    lblBeverage.Text = "$ 1.95";
                    CalculateResults();
                    break;
                case 1:
                    beverage = 1.50;
                    lblBeverage.Text = "$ 1.50";
                    CalculateResults();
                    break;
                case 2:
                    beverage = 1.25;
                    lblBeverage.Text = "$ 1.25";
                    CalculateResults();
                    break;
                case 3:
                    beverage = 2.95;
                    lblBeverage.Text = "$ 2.95";   
                    CalculateResults();
                    break;
                case 4:
                    beverage = 2.50;
                    lblBeverage.Text = "$ 2.50";
                    CalculateResults();
                    break;
                case 5:
                    beverage = 1.50;
                    lblBeverage.Text = "$ 1.50";
                    CalculateResults();
                    break;
            }
        }
        
        private void comboBoxAppetizer_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxAppetizer.SelectedIndex)
            {
                case 0:
                    appetizer = 5.95;
                    lblAppetizer.Text = "$ 5.95";
                    //txtBoxSubtotal.Text = Convert.ToString(CalculateSubtotal());
                    CalculateResults();
                    break;
                case 1:
                    appetizer = 6.95;
                    lblAppetizer.Text = "$ 6.95";
                    CalculateResults();
                    break;
                case 2:
                    appetizer = 8.95;
                    lblAppetizer.Text = "$ 8.95";
                    CalculateResults();
                    break;
                case 3:
                    appetizer = 10.95;
                    lblAppetizer.Text = "$ 10.95";
                    CalculateResults();
                    break;
                case 4:
                    appetizer = 12.95;
                    lblAppetizer.Text = "$ 12.95";
                    CalculateResults();
                    break;
                case 5:
                    appetizer = 6.95;
                    lblAppetizer.Text = "$ 6.95";
                    CalculateResults();
                    break;
            }
        }

        private void comboBoxMainCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxMainCourse.SelectedIndex)
            {
                case 0:
                    mainCourse = 15.95;
                    lblMainCourse.Text = "$ 15.95";
                    //txtBoxSubtotal.Text = Convert.ToString(CalculateSubtotal());
                    CalculateResults();
                    break;
                case 1:
                    mainCourse = 13.95;
                    lblMainCourse.Text = "$ 13.95";
                    CalculateResults();
                    break;
                case 2:
                    mainCourse = 13.95;
                    lblMainCourse.Text = "$ 13.95";
                    CalculateResults();
                    break;
                case 3:
                    mainCourse = 11.95;
                    lblMainCourse.Text = "$ 11.95";
                    CalculateResults();
                    break;
                case 4:
                    mainCourse = 19.95;
                    lblMainCourse.Text = "$ 19.95";
                    CalculateResults();
                    break;
                case 5:
                    mainCourse = 20.95;
                    lblMainCourse.Text = "$ 20.95";
                    CalculateResults();
                    break;
                case 6:
                    mainCourse = 18.95;
                    lblMainCourse.Text = "$ 18.95";
                    CalculateResults();
                    break;
                case 7:
                    mainCourse = 13.95;
                    lblMainCourse.Text = "$ 13.95";
                    CalculateResults();
                    break;
                case 8:
                    mainCourse = 14.95;
                    lblMainCourse.Text = "$ 14.95";
                    CalculateResults();
                    break;
                    
            }
        }

        private void comboBoxDessert_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxDessert.SelectedIndex)
            {
                case 0:
                    desert = 5.95;
                    lblDessert.Text = "$ 5.95";
                    CalculateResults();
                    break;
                case 1:
                    desert = 3.95;
                    lblDessert.Text = "$ 3.95";
                    CalculateResults();
                    break;
                case 2:
                    desert = 5.95;
                    lblDessert.Text = "$ 5.95";
                    CalculateResults();
                    break;
                case 3:
                    appetizer = 4.95;
                    lblDessert.Text = "$ 4.95";
                    CalculateResults();
                    break;
                case 4:
                    appetizer = 5.95;
                    lblDessert.Text = "$ 5.95";
                    CalculateResults();
                    break;
                
            }
        }

        private void CalculateResults()
        {
            double total;
            double subtotal;
            double taxResult;
            
            subtotal = beverage + appetizer + mainCourse + desert;
            taxResult = subtotal * tax;
            total = subtotal + taxResult;

            txtBoxSubtotal.Text = Convert.ToString(subtotal);
            txtBoxTax.Text = Convert.ToString(taxResult);
            txtBoxTotal.Text = Convert.ToString(total);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            comboBoxBeverage.SelectedIndex = 0;
            comboBoxAppetizer.SelectedIndex=0;
            comboBoxMainCourse.SelectedIndex=0;
            comboBoxDessert.SelectedIndex = 0;

            txtBoxSubtotal.Text = "";
            txtBoxTax.Text = "";
            txtBoxTotal.Text = "";
        }

                      

        }

    }
