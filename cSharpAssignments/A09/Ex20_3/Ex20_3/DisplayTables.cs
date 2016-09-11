using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex20_3
{
    public partial class DisplayTables : Form
    {
        public DisplayTables()
        {
            InitializeComponent();
        }

        private void authorsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.authorsBindingSource.EndEdit();
            this.authorsTableAdapter.Update(this.booksDataSet.Authors);

        }

        private void DisplayTables_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'booksDataSet.Authors' table. You can move, or remove it, as needed.
            this.authorsTableAdapter.Fill(this.booksDataSet.Authors);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "")
            {
                this.authorsTableAdapter.Fill(this.booksDataSet.Authors);
            }
            else
            {
                this.authorsTableAdapter.FillByLastName(this.booksDataSet.Authors, textBoxSearch.Text);
            }
       
        }
    }
}