using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex14_11
{
    public partial class ParentForm : Form
    {
        public ChildForm1 formChild1;
        public ChildForm2 formChild2;
        public bool formOneShowed=false;
        public bool formTwoShowed = false;

        public ParentForm()
        {
            InitializeComponent();
        }

        private void childForm1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formChild1 = new ChildForm1();
            formChild1.MdiParent = this;
            formChild1.Show();
            formOneShowed = true;
            childForm1ToolStripMenuItem.Visible = false;
        }

        private void childForm2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formChild2 = new ChildForm2();
            formChild2.MdiParent = this;
            formChild2.Show();
            formTwoShowed = true;
            childForm2ToolStripMenuItem.Visible = false;
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formOneShowed == true && formTwoShowed == false)
            {
                formChild1.BrushColor = Color.Red;
            }
            else if (formOneShowed == false && formTwoShowed == true)
            {
                formChild2.BrushColor = Color.Red;
            }
            else if (formOneShowed == true && formTwoShowed == true) 
            {
                formChild1.BrushColor = Color.Red;
                formChild2.BrushColor = Color.Red;
            }
        
        }

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formOneShowed == true && formTwoShowed == false)
            {
                formChild1.BrushColor = Color.Yellow;
            }
            else if (formOneShowed == false && formTwoShowed == true)
            {
                formChild2.BrushColor = Color.Yellow;
            }
            else if (formOneShowed == true && formTwoShowed == true)
            {
                formChild1.BrushColor = Color.Yellow;
                formChild2.BrushColor = Color.Yellow;
            }
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formOneShowed == true && formTwoShowed == false)
            {
                formChild1.BrushColor = Color.Green;
            }
            else if (formOneShowed == false && formTwoShowed == true)
            {
                formChild2.BrushColor = Color.Green;
            }
            else if (formOneShowed == true && formTwoShowed == true)
            {
                formChild1.BrushColor = Color.Green;
                formChild2.BrushColor = Color.Green;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            if (formOneShowed == true && formTwoShowed == false)
            {
                formChild1.BrushSize = 4;
            }
            else if (formOneShowed == false && formTwoShowed == true)
            {
                formChild2.BrushSize = 4;
            }
            else if (formOneShowed == true && formTwoShowed == true)
            {
                formChild1.BrushSize = 4;
                formChild2.BrushSize = 4;
            }
            
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (formOneShowed == true && formTwoShowed == false)
            {
                formChild1.BrushSize = 10;
            }
            else if (formOneShowed == false && formTwoShowed == true)
            {
                formChild2.BrushSize = 10;
            }
            else if (formOneShowed == true && formTwoShowed == true)
            {
                formChild1.BrushSize = 10;
                formChild2.BrushSize = 10;
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (formOneShowed == true && formTwoShowed == false)
            {
                formChild1.BrushSize = 20;
            }
            else if (formOneShowed == false && formTwoShowed == true)
            {
                formChild2.BrushSize = 20;
            }
            else if (formOneShowed == true && formTwoShowed == true)
            {
                formChild1.BrushSize = 20;
                formChild2.BrushSize = 20;
            }
        }

        private void openFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((childForm1ToolStripMenuItem.Visible == false) && (childForm2ToolStripMenuItem.Visible == false))
            {
                toolStripMenuItem1.Visible = true;
                formChild1.Close();
                formChild2.Close();
            }
            else 
            {
                toolStripMenuItem1.Visible = false;
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            childForm1ToolStripMenuItem.Visible = true;
            childForm2ToolStripMenuItem.Visible = true;
        }
  
    
    }
}