using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Ex14_11
{
    public partial class ChildForm1 : Form
    {
        bool shouldPaint = false;
        private Color brushColor=Color.Red;
        private int brushSize=4;

        public ChildForm1()
        {
            InitializeComponent();
        }



        private void PainterForm_MouseDown(object sender, MouseEventArgs e)
        {
            shouldPaint = true;
        }

        //stop painting when mouse button is released
        private void PainterForm_MouseUp(object sender, MouseEventArgs e)
        {
            shouldPaint = false;
        }

        //draw circule whenever mouse moves with its button held down
        private void PainterForm_MouseMove(object sender, MouseEventArgs e)
        {

            if (shouldPaint)
            {
                //class name with upper case and object with lower case
                Graphics graphics = CreateGraphics();

                graphics.FillEllipse(
                    new SolidBrush(this.brushColor), e.X, e.Y, this.brushSize, this.brushSize);
                graphics.Dispose();
                
            }
        }

        public Color BrushColor
        {
            get
            {
                return this.brushColor;
            }
            set
            {
                this.brushColor = value;
            }
        }

        public int BrushSize
        {
            get 
            {
                return this.brushSize;
            
            }
            set 
            {
                this.brushSize = value;
            } 
        }

        private void ChildForm1_FormClosed(object sender, FormClosedEventArgs e)
        {
        
        }
    
    }
}