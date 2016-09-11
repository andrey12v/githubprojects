using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex20_5
{
    public partial class Baseball : Form
    {
        public Baseball()
        {
            InitializeComponent();
        }

        private void playersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.playersBindingSource.EndEdit();
            this.playersTableAdapter.Update(this.baseballDataSet.Players);

        }

        private void Baseball_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'baseballDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.baseballDataSet.Players);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtLastName.Text == "")
            {
                this.playersTableAdapter.Fill(this.baseballDataSet.Players);
            }
            else
            {
                this.playersTableAdapter.FillByLastName(this.baseballDataSet.Players, txtLastName.Text);
            }
        }
    }
}