using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex20_4
{
    public partial class DisplayQueryResult : Form
    {
        public DisplayQueryResult()
        {
            InitializeComponent();
        }

        private void titlesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.titlesBindingSource.EndEdit();
            this.titlesTableAdapter.Update(this.booksDataSet.Titles);

        }

        private void DisplayQueryResult_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'booksDataSet.Titles' table. You can move, or remove it, as needed.
            this.titlesTableAdapter.Fill(this.booksDataSet.Titles);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.titlesTableAdapter.FillByTitle(this.booksDataSet.Titles, textBoxSearch.Text);
        }
    }
}