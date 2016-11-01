using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using IMS;
using System.IO;
using System.Configuration;


namespace DivaReports
{
    public partial class FormDivaReports : Form
    {
        public FormDivaReports()
        {
            InitializeComponent();
            
            //set the conection with the database
            DivaLink divl = new DivaLink();
            divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
            string conString = divl.GetConnectionString();
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            
            string temp;

            // enable and disable controls on the form to choose accounts first and then items
            lblWaitMessage.Visible = false;
            progressBar1.Visible = false;
            lblWaitMessageCS.Visible = false;
            progressBarCS.Visible = false;
            lblWaitOutOfStock.Visible = false;
            progressBar2.Visible = false;
            

            TimeSpan oneWeek = new TimeSpan(4, 12, 0, 0) + new TimeSpan(2, 12, 0, 0);
            DateTime now = DateTime.Now;
            // Create a DateTime representing 1 week ago.
            DateTime past = now - oneWeek;
            dtpDateFrom.Text = past.ToString();
            dtpSetDateFrom.Text = past.ToString();
            
            // add sets to the tab "Sales Of Sets" 
            temp = "select SetName from Sets where Discontinued=0 Order By SetName";
            // the condition selects include discontinued sets also
            if (cbxIncludeDiscontinued.Checked == true)
            {
                temp = "select SetName from Sets Order By SetName";
            }
            SqlCommand commandSets = new SqlCommand(temp, conn);
            SqlDataReader rs2 = commandSets.ExecuteReader();
            while (rs2.Read())
            {
                cblSets.Items.Add(Convert.ToString(rs2["SetName"]));
            }
            rs2.Close();
            
            // add accounts to the tabs "Sales of Items" and "sales Of Sets"
            SqlCommand commandAccount = new SqlCommand("select AccountName from Accounts Order By AccountName", conn);
            SqlDataReader rs3 = commandAccount.ExecuteReader();
            while (rs3.Read())
            {
                cblAccount.Items.Add(Convert.ToString(rs3["AccountName"]));
                cblAccountCS.Items.Add(Convert.ToString(rs3["AccountName"]));
                cblSetAccount.Items.Add(Convert.ToString(rs3["AccountName"]));
                cbAccountsExport.Items.Add(Convert.ToString(rs3["AccountName"]));
            }
            rs3.Close();
            cbAccountsExport.Items.Add("All Accounts");
            cbAccountsExport.Text = "All Accounts";
            
            //cbAccountsExport.SelectedItem == "All Accounts";

            // add comopanies to the tabs "Sales Of Items", "Par percentage" and "Out Of Stock"
            SqlCommand commandCompany = new SqlCommand("select CoName from Company Order By CoName", conn);
            SqlDataReader rs4 = commandCompany.ExecuteReader();
            cmbCompany.Items.Add("All companies");
            cmbCompany.SelectedItem = "All companies";
            cmbCompanyCS.Items.Add("All companies");
            cmbCompanyCS.Text = "All companies";
            
            while (rs4.Read())
            {
                cmbCompany.Items.Add(Convert.ToString(rs4["CoName"]));
                cmbCompanyCS.Items.Add(Convert.ToString(rs4["CoName"]));
                
                cblCompany.Items.Add(Convert.ToString(rs4["CoName"]));
                cblCompanyStock.Items.Add(Convert.ToString(rs4["CoName"]));
                cblCompaniesExport.Items.Add(Convert.ToString(rs4["CoName"]));
            }
            rs4.Close();
            
            // add locations to the tabs "Par Percentage" and "Out Of Stock"
            SqlCommand commandStockLocation = new SqlCommand("select LocationName from StockLocation Order By LocationName", conn);
            SqlDataReader rs5 = commandStockLocation.ExecuteReader();
            while (rs5.Read())
            {
                cbStockLocation.Items.Add(Convert.ToString(rs5["LocationName"]));
                cbLocationsOutOfStock.Items.Add(Convert.ToString(rs5["LocationName"]));
                cbInStockExport.Items.Add(Convert.ToString(rs5["LocationName"]));
                // if location is warehose set it as a default to be displayed in the controls
                if (Convert.ToString(rs5["LocationName"]) == "Warehouse")
                {
                    cbStockLocation.Text = Convert.ToString(rs5["LocationName"]);
                    cbLocationsOutOfStock.Text = Convert.ToString(rs5["LocationName"]);
                    cbInStockExport.Text = Convert.ToString(rs5["LocationName"]);
                }
            }
            rs5.Close();
            btnSales.Enabled = false;
            btnSearch.Enabled = false;
     
            conn.Close();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            if(cblItems.CheckedItems.Count==0)
            {
                MessageBox.Show("Please choose at least one item");
                return;
            }

            DialogResult dResult;
            TimeSpan fourMonths = new TimeSpan(450, 12, 0, 0);
            DateTime now = DateTime.Now;
            DateTime past = now - fourMonths;
            if (Convert.ToDateTime(dtpDateFrom.Text)<=past)
            {
                dResult = MessageBox.Show("The chosen time period might take more time to get the results. Do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dResult==DialogResult.No)
                {
                    return;
                }
            }

            this.Cursor = Cursors.WaitCursor;

            dgvItems.Columns.Clear();

            // initialize progress bar variables
            lblWaitMessage.Visible = true;
            progressBar1.Visible = true;
            progressBar1.Maximum = 1000;
            progressBar1.Minimum = 1;
            progressBar1.Value = 1;
            progressBar1.Step = 1;
            
            string accounts = "";
            string temp = "";
            int i = 0;
            // concatenate checked account names from the check box list into one string variable
            // the string variable is used in SQL query 
            for (i = 0; i < cblAccount.CheckedItems.Count; i++)
            {
                if (accounts == "")
                {
                    accounts = "'" + cblAccount.CheckedItems[i].ToString() + "'";
                }
                else
                {
                    accounts = accounts + ", '" + cblAccount.CheckedItems[i].ToString() + "'";
                }
            }
            
            // set the SQL connection
            DivaLink divl = new DivaLink();
            divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
            string conString = divl.GetConnectionString();
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            
            temp = "Select CoName, ItemNumber, Description, WeekDate, AccountName, TotalSold " + 
            "From Items I Left Join SalesHistory SH ON I.ItemIndexPK=SH.ItemIndexFK Left Join Accounts A " +
            "ON SH.AccountIndexFK=A.AccountIndexPK Left Join Company C ON C.CoIndexPK=I.CoIndexFK " +
            "Where WeekDate>='" + dtpDateFrom.Text + "' and WeekDate<='" + dtpDateTo.Text + "' and AccountName IN (" + accounts + ") " +
            "and (ItemNumber Like '%" + txtItemSearch.Text + "%' or Description Like '%" + txtItemSearch.Text + "%')";
            
            if ((cmbCompany.SelectedItem.ToString() != "All companies"))
            {
                temp+=" and CoName='" + cmbCompany.SelectedItem.ToString() + "'";
            }
            if ((cbxIncludeDiscontinued.Checked == false) && (cbxOnlyDiscontinuedSalesOfItems.Checked==false))
            {
                temp += " and Discontinued=0";
            }
            if (cbxOnlyDiscontinuedSalesOfItems.Checked == true)
            {
                temp += " and Discontinued=1";
            }
            temp += " Order By ItemNumber";

            if (cbxSumOfTotalSales.Checked == true)
            {
                temp = "Select CoName, ItemNumber, Description, WeekDate, Sum(TotalSold) As TotalSold " +
                "From Items I Left Join SalesHistory SH ON I.ItemIndexPK=SH.ItemIndexFK Left Join Company C ON C.CoIndexPK=I.CoIndexFK " +
                "Where WeekDate>='" + dtpDateFrom.Text + "' and WeekDate<='" + dtpDateTo.Text + "' " +
                "and (ItemNumber Like '%" + txtItemSearch.Text + "%' or Description Like '%" + txtItemSearch.Text + "%')";

                if ((cmbCompany.SelectedItem.ToString() != "All companies"))
                {
                    temp += " and CoName='" + cmbCompany.SelectedItem.ToString() + "'";
                }

                if ((cbxIncludeDiscontinued.Checked == false) && (cbxOnlyDiscontinuedSalesOfItems.Checked == false))
                {
                    temp += " and Discontinued=0";
                }
                if (cbxOnlyDiscontinuedSalesOfItems.Checked == true)
                {
                    temp += " and Discontinued=1";
                }
                temp += "Group By CoName, ItemNumber, Description, WeekDate " +
                "Order By ItemNumber";
            }
            
            // add headers to the data grid view
            dgvItems.Columns.Add("ItemNumber", "Item");
            dgvItems.Columns.Add("CoName", "Company");
            if (cbxSumOfTotalSales.Checked == false)
            {
                dgvItems.Columns.Add("AccountName", "Account");
            }
            dgvItems.Columns.Add("WeekDate", "Week Date");
            dgvItems.Columns.Add("TotalSold", "Total Sold");
            dgvItems.Columns.Add("Description", "Description");


            SqlCommand commandItems = new SqlCommand(temp, conn);
            SqlDataReader rs1 = commandItems.ExecuteReader();
            i = 0;
            // the cycle iterates through iterates through chosen items in check box list and outputs
            // the resul of SQL Query in data grid view - total sold from sales history table
            while (rs1.Read())
            {
                this.Refresh();
                progressBar1.PerformStep();
                if (progressBar1.Value >= 1000)
                {
                    progressBar1.Value = 1;
                }

                if (cblItems.Items[i].ToString() != Convert.ToString(rs1["ItemNumber"]))
                {
                    i++;
                }
                
                if ((cblItems.Items[i].ToString() == Convert.ToString(rs1["ItemNumber"]))
                    && (cblItems.GetItemCheckState(i) == CheckState.Checked))
                {
                    this.Refresh();
                    if (cbxSumOfTotalSales.Checked == false)
                    {
                        dgvItems.Rows.Add(Convert.ToString(rs1["ItemNumber"]),
                        Convert.ToString(rs1["CoName"]),
                        Convert.ToString(rs1["AccountName"]),
                        Convert.ToDateTime(rs1["WeekDate"]),
                        Convert.ToString(rs1["TotalSold"]),
                        Convert.ToString(rs1["Description"]));
                    }
                    else 
                    {
                        dgvItems.Rows.Add(Convert.ToString(rs1["ItemNumber"]),
                        Convert.ToString(rs1["CoName"]),
                        Convert.ToDateTime(rs1["WeekDate"]),
                        Convert.ToString(rs1["TotalSold"]),
                        Convert.ToString(rs1["Description"]));
                    }

                }
                
            }
            rs1.Close();
            conn.Close();
            dgvItems.Columns[3].DefaultCellStyle.Format = "MM/dd/yyyy";
            lblWaitMessage.Visible = false;
            progressBar1.Visible = false;
            this.Cursor = Cursors.Arrow;
            if ((dgvItemsCS.RowCount - 1) > 0)
            {
                label7.Text = "SALES OF ITEMS (" + (dgvItems.RowCount - 1) + ")";
            }
            else 
            {
                label7.Text = "SALES OF ITEMS ";
            }
            
          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cblItems.Items.Clear();
            //unselect check box if new search is called
            cbxAllItems.Checked = false;
            DivaLink divl = new DivaLink();
            divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
            string conString = divl.GetConnectionString();
            SqlConnection conn = new SqlConnection(conString);

            string accounts = "";
            int i = 0;
 
            // concatenate checked account names from the check box list into one string variable
            // the string variable is used in SQL query 
            for (i = 0; i < cblAccount.CheckedItems.Count; i++)
            {
                if (accounts == "")
                {
                    accounts = "'" + cblAccount.CheckedItems[i].ToString() + "'";
                }
                else
                {
                    accounts = accounts + ", '" + cblAccount.CheckedItems[i].ToString() + "'";
                }
            }
            
            conn.Open();
            
            // the query is assigned to string
            // get all items that have search text in the description or in item name 
            string temp = "Select Distinct ItemNumber From Items I Left Join SalesHistory SH ON I.ItemIndexPK=SH.ItemIndexFK Left Join Accounts A " +
            "ON SH.AccountIndexFK=A.AccountIndexPK Left Join Company C ON C.CoIndexPK=I.CoIndexFK " +
            "Where WeekDate>='" + dtpDateFrom.Text + "' and WeekDate<='" + dtpDateTo.Text + "' and AccountName IN (" + accounts + ") " +
            "and (ItemNumber Like '%" + txtItemSearch.Text + "%' or Description Like '%" + txtItemSearch.Text + "%')";

            if ((cmbCompany.SelectedItem.ToString() != "All companies"))
            {
                temp += " and CoName='" + cmbCompany.SelectedItem.ToString() + "'";
            }

            if ((cbxIncludeDiscontinued.Checked == false) && (cbxOnlyDiscontinuedSalesOfItems.Checked == false))
            {
                temp += " and Discontinued=0";
            }
            if (cbxOnlyDiscontinuedSalesOfItems.Checked == true)
            {
                temp += " and Discontinued=1";
            }
            temp += " Order By ItemNumber";

            if (cbxSumOfTotalSales.Checked==true)
            {
                temp = "Select Distinct ItemNumber From Items I Left Join SalesHistory SH ON I.ItemIndexPK=SH.ItemIndexFK Left Join Accounts A " +
                "ON SH.AccountIndexFK=A.AccountIndexPK Left Join Company C ON C.CoIndexPK=I.CoIndexFK " +
                "Where WeekDate>='" + dtpDateFrom.Text + "' and WeekDate<='" + dtpDateTo.Text + "' and AccountName IN (" + accounts + ") " +
                " and (ItemNumber Like '%" + txtItemSearch.Text + "%' or Description Like '%" + txtItemSearch.Text + "%')";
                
                if ((cmbCompany.SelectedItem.ToString() != "All companies"))
                {
                    temp += " and CoName='" + cmbCompany.SelectedItem.ToString() + "'";
                }

                if ((cbxIncludeDiscontinued.Checked == false) && (cbxOnlyDiscontinuedSalesOfItems.Checked == false))
                {
                    temp += " and Discontinued=0";
                }
                if (cbxOnlyDiscontinuedSalesOfItems.Checked == true)
                {
                    temp += " and Discontinued=1";
                }
                temp += "Group By CoName, ItemNumber, Description, WeekDate, AccountName " +
                "Order By ItemNumber";
            }
            

            SqlCommand commandItems = new SqlCommand(temp, conn);
            SqlDataReader rs1 = commandItems.ExecuteReader();
            // go through all items that the SQL Query returned and add items to the check box list
            while (rs1.Read())
            {
                this.Refresh();

                cblItems.Items.Add(Convert.ToString(rs1["ItemNumber"]));
                
            }
            rs1.Close();
            conn.Close();
        
        }

        
        // the function is called when the button Enter was hit 
        private void txtItemSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // call the function to search items 
                btnSearch_Click(sender, e);
            } 
        }

        // the function is called when the button Enter was hit
        private void txtSetSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // search sets
                btnSetSearch_Click(sender, e);
            }
        }

        // the function selects or deselects all items in the check box list
        private void cbxAllItems_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAllItems.Checked)
            {
                for (int i = 0; i < cblItems.Items.Count; i++)
                {
                    cblItems.SetItemChecked(i, true);
                }
            }
            else 
            {
                for (int i = 0; i < cblItems.Items.Count; i++)
                {
                    cblItems.SetItemChecked(i, false);
                }
            }
        
        }

        // the function selects or deselects all accounts in the check box list
        private void cbxAllAccounts_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAllAccounts.Checked)
            {
                for (int i = 0; i < cblAccount.Items.Count; i++)
                {
                    cblAccount.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < cblAccount.Items.Count; i++)
                {
                    cblAccount.SetItemChecked(i, false);
                }
            }
        }


        

        // the function to search sets  
        private void btnSetSearch_Click(object sender, EventArgs e)
        {
            cblSets.Items.Clear();
            DivaLink divl = new DivaLink();
            divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
            string conString = divl.GetConnectionString();
            SqlConnection conn = new SqlConnection(conString);

            // search sets inculding discontinued sets
            string commandString = "Select SetName from Sets where SetName Like '%" + txtItemSearch.Text + "%' or " +
            "Description Like '%" + txtItemSearch.Text + "%'";

            // search sets without discontinued sets 
            if (cbxIncludeDiscontinuedSets.Checked == false)
            {
                commandString = "Select SetName from Sets where (SetName Like '%" + txtItemSearch.Text + "%' or " +
                "Description Like '%" + txtItemSearch.Text + "%') and Discontinued=0";
            }

            SqlCommand command = new SqlCommand(commandString, conn);

            conn.Open();

            SqlDataReader rs = command.ExecuteReader();
            while (rs.Read())
            {
                cblSets.Items.Add(Convert.ToString(rs["SetName"]));
            }
            rs.Close();
            conn.Close();
        }

        
        // the function selects or deselects  all sets in the check box list
        private void cbxAllSets_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbxAllSets.Checked)
            {
                for (int i = 0; i < cblSets.Items.Count; i++)
                {
                    cblSets.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < cblSets.Items.Count; i++)
                {
                    cblSets.SetItemChecked(i, false);
                }
            }
        }

        // the function is called when the check box "Discontinued" is selected or deselected on the tab "Sales of Sets"
        private void cbxIncludeDiscontinuedSets_CheckedChanged_1(object sender, EventArgs e)
        {
            txtSetSearch.Text = "";
            cblSets.Items.Clear();
            cbxAllSets.Checked = false;
            DivaLink divl = new DivaLink();
            divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
            string conString = divl.GetConnectionString();
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            
            string itemSrting = "Select SetName from Sets";

            // if discontinued selected or deselected the new serach has to be made again
            // all sets are removed from the check box list and added again according to chosen
            // check box list "Discontinued"
            if (cbxIncludeDiscontinuedSets.Checked==false)
            {
                itemSrting = "Select SetName from Sets where Discontinued=0";
            }
 
            // add item number each time when the check box "Discontinued" selected or
            // deselected
            SqlCommand commandSets = new SqlCommand(itemSrting, conn);
            SqlDataReader rs1 = commandSets.ExecuteReader();
            while (rs1.Read())
            {
                cblSets.Items.Add(Convert.ToString(rs1["SetName"]));
            }
            rs1.Close();
            conn.Close();
        
        }

        // the function selects or deselects  all accounts in the check box list
        private void cbxAllSetAccounts_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAllSetAccounts.Checked)
            {
                for (int i = 0; i < cblSetAccount.Items.Count; i++)
                {
                    cblSetAccount.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < cblSetAccount.Items.Count; i++)
                {
                    cblSetAccount.SetItemChecked(i, false);
                }
            }
        }

        private void btnGetSetSales_Click(object sender, EventArgs e)
        {
            // the conditions requires users to choose at leat one row in check box lists
            if (cblSets.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please choose at least one set");
                return;
            }
            if (cblSetAccount.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please choose at least one account");
                return;
            }


            this.Cursor = Cursors.WaitCursor;
            dgvSets.Columns.Clear();
            DivaLink divl = new DivaLink();
            divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
            string conString = divl.GetConnectionString();
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
           
            // add headers to the data grid view
            dgvSets.Columns.Add("SetName", "Set Name");   
            dgvSets.Columns.Add("Description", "Set Descrip");
            dgvSets.Columns.Add("AccountName", "Account"); 
            dgvSets.Columns.Add("WeekDate", "Week Date");
            dgvSets.Columns.Add("TotalSold", "Total Sold");
           
            int i = 0;
            bool checkItem = false;
            string accounts = "";

            // concatenate checked account names from the check box list into one string variable
            // the string variable is used in SQL query 
            for (i = 0; i < cblSetAccount.CheckedItems.Count; i++)
            {
                if (accounts == "")
                {
                    accounts = "'" + cblSetAccount.CheckedItems[i].ToString() + "'";
                }
                else
                {
                    accounts = accounts + ", '" + cblSetAccount.CheckedItems[i].ToString() + "'";
                }
            }
            

            //********************************* Get Sales for Sets ************************************
            string commandStringSets = "Select SetName, Description, WeekDate, AccountName, TotalSold From Sets S Inner Join SalesHistory SH " +
            "ON S.SetIndexPK=SH.SetIndexFK Inner Join Accounts A ON SH.AccountIndexFK=A.AccountIndexPK " +
            "Where WeekDate>='" + dtpSetDateFrom.Text + "' and WeekDate<='" + dtpSetDateTo.Text + "' and " +
            "AccountName IN (" + accounts + ")";

            if (cbxIncludeDiscontinuedSets.Checked==false)
            {
                commandStringSets = "Select SetName, Description, WeekDate, AccountName, TotalSold From Sets S Inner Join SalesHistory SH " +
                "ON S.SetIndexPK=SH.SetIndexFK Inner Join Accounts A ON SH.AccountIndexFK=A.AccountIndexPK " +
                "Where WeekDate>='" + dtpSetDateFrom.Text + "' and WeekDate<='" + dtpSetDateTo.Text + "' and " +
                "AccountName IN (" + accounts + ") and Discontinued=0";
            }


            SqlCommand commandSets = new SqlCommand(commandStringSets, conn);
            i = 0;
            checkItem = false;
            SqlDataReader rs2 = commandSets.ExecuteReader();

            // the cycle goes through the sets that were returned from the database and if the chosen set from the 
            // check box list is equal to the set name from the database then add the set to the data grid view 
            while (rs2.Read())
            {
                checkItem = false;
                
                // the cycle goes through all sets in the check box list abd compare the item number with
                // results of SQL query
                for (i = 0; i < cblSets.CheckedItems.Count; i++)
                {
                    if ((cblSets.CheckedItems[i].ToString() == Convert.ToString(rs2["SetName"])))
                    {
                        checkItem = true;
                        break;
                    }
                }

                if (checkItem == false)
                {
                    goto EndCycle2;
                }

                // add rows to the data grid view
                dgvSets.Rows.Add(Convert.ToString(rs2["SetName"]),
                Convert.ToString(rs2["Description"]),
                Convert.ToString(rs2["AccountName"]),
                Convert.ToString(rs2["WeekDate"]),
                Convert.ToString(rs2["TotalSold"]));
      
            EndCycle2: ;
            }

            rs2.Close();

            conn.Close();
            this.Cursor = Cursors.Arrow;

        }

        private void btnCSVExport_Click(object sender, EventArgs e)
        {
            // if there is not any rows in the data grid view then output message
            if ((dgvItems.Rows.Count==0) || (dgvItems.Rows.Count==1))
            {
                MessageBox.Show("There is not any data to export");
                return;
            }
            
            // standart functions to call save dialog  
            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.Title = "Save As an export file in CSV format";
            saveFD.InitialDirectory = @"c:\Desktop";
            string fromDate = dtpDateFrom.Value.ToString("MM dd yy");
            string toDate = dtpDateTo.Value.ToString("MM dd yy");
            saveFD.FileName = "Sales Export Report (" + fromDate + " - " + toDate + ")";
            saveFD.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            string filePath="";
            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFD.FileName;

                StreamWriter tw = new StreamWriter(filePath);
                
                // write header to a CSV file
                tw.WriteLine("Item Number, Company Name, Account Name, Week Date, Total Sold, Description");
                // write rows with data to CSV file from data grid view
                for (int i = 0; i < dgvItems.Rows.Count - 1; i++)
                {
                    if (cbxSumOfTotalSales.Checked == false)
                    {
                        tw.WriteLine(dgvItems.Rows[i].Cells["ItemNumber"].Value.ToString() + ", " + dgvItems.Rows[i].Cells["CoName"].Value.ToString() + ", " +
                        dgvItems.Rows[i].Cells["AccountName"].Value.ToString() + ", " + dgvItems.Rows[i].Cells["WeekDate"].Value.ToString() + ", " +
                        dgvItems.Rows[i].Cells["TotalSold"].Value.ToString() + ", " + dgvItems.Rows[i].Cells["Description"].Value.ToString());
                    }
                    else 
                    {
                        tw.WriteLine(dgvItems.Rows[i].Cells["ItemNumber"].Value.ToString() + ", " + dgvItems.Rows[i].Cells["CoName"].Value.ToString() + ", " +
                        dgvItems.Rows[i].Cells["WeekDate"].Value.ToString() + ", " +
                        dgvItems.Rows[i].Cells["TotalSold"].Value.ToString() + ", " + dgvItems.Rows[i].Cells["Description"].Value.ToString());
                    }

                
                }
                tw.Close();
                MessageBox.Show("The data was exported to CSV succesfully.");
            }
        }

        // the functioin selects or deselects all companies in check box list
        private void cbxAllCompanies_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAllCompanies.Checked)
            {
                for (int i = 0; i < cblCompany.Items.Count; i++)
                {
                    cblCompany.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < cblCompany.Items.Count; i++)
                {
                    cblCompany.SetItemChecked(i, false);
                }
            }
        }


        private void btnGetParPercentage_Click(object sender, EventArgs e)
        {
            if (cblCompany.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please choose at least one company");
                return;
            }
            
            
            this.Cursor = Cursors.WaitCursor;
            // if the feild par percentage is empty the message will be displayed 
            if (txtParPercentage.Text=="")
            {
                MessageBox.Show("Please type par percentage value.");
                txtParPercentage.Text = "50";
            }
            dgvParPercentage.Columns.Clear();
            DivaLink divl = new DivaLink();
            divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
            string conString = divl.GetConnectionString();
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            
            decimal parPercentValue=0;  // the variables is required to calculate par  percentage 
            string companies = "";
            int i = 0;

            // concatenate checked companies from the check box list into one string variable
            // the string variable is used in SQL query 
            for (i = 0; i < cblCompany.CheckedItems.Count; i++)
            {
                if (companies == "")
                {
                    companies = "'" + cblCompany.CheckedItems[i].ToString() + "'";
                }
                else
                {
                    companies = companies + ", '" + cblCompany.CheckedItems[i].ToString() + "'";
                }
            }

            
            string stringParPercentage = "select CoName, ItemNumber, LocationName, AmountInStock, OnOrder, NewPar, ParCorrection from StockLocation SL Inner Join InStock S " +
            "ON SL.StockLocationIndexPK=S.StockLocationIndexFK Inner Join Items I " +
            "ON S.ItemIndexFK=I.ItemIndexPK Inner Join Company C " +
            "ON I.CoIndexFK=C.CoIndexPK " +
            "Where CoName IN (" + companies + ") and LocationName='" + cbStockLocation.SelectedItem.ToString() + "'";

            if (cbxIncludeDiscontinuedPar.Checked==false)
            {
                stringParPercentage = "select CoName, ItemNumber, LocationName, AmountInStock, OnOrder, NewPar, ParCorrection from StockLocation SL Inner Join InStock S " +
                "ON SL.StockLocationIndexPK=S.StockLocationIndexFK Inner Join Items I " +
                "ON S.ItemIndexFK=I.ItemIndexPK Inner Join Company C " +
                "ON I.CoIndexFK=C.CoIndexPK " +
                "Where CoName IN (" + companies + ") and LocationName='" + cbStockLocation.SelectedItem.ToString() + "' and Discontinued=0";
            }

            SqlCommand commandParPercentage = new SqlCommand(stringParPercentage, conn);
            SqlDataReader rs1 = commandParPercentage.ExecuteReader();

            // different headers will be added if the user select the check box "Include On Order" or deselect it
                        
            dgvParPercentage.Columns.Add("ItemNumber", "Item Number");
            dgvParPercentage.Columns.Add("InStock", "In Stock");
            if (cbxIncludeOnOrder.Checked == true)
            {
                dgvParPercentage.Columns.Add("OnOrder", "On Order");
            }
            dgvParPercentage.Columns.Add("NewPar", "New Par");
            dgvParPercentage.Columns.Add("ParPercent", "Par %");
            dgvParPercentage.Columns.Add("Company", "Company");
            


            while (rs1.Read())
            {
                // calculate par percent value if On Order is included 
                if ((Convert.ToDecimal(rs1["NewPar"]) + Convert.ToDecimal(rs1["ParCorrection"])) == 0)
                {
                    parPercentValue = 1;
                }
                else 
                { 
                    parPercentValue = ((Convert.ToDecimal(rs1["AmountInStock"]) + Convert.ToDecimal(rs1["OnOrder"])) /
                        (Convert.ToDecimal(rs1["NewPar"]) + Convert.ToDecimal(rs1["ParCorrection"]))) * 100;

                    // calculate par percent value if On Order is not included
                    if(cbxIncludeOnOrder.Checked==false)
                    {
                        parPercentValue = ((Convert.ToDecimal(rs1["AmountInStock"])) /
                        (Convert.ToDecimal(rs1["NewPar"]) + Convert.ToDecimal(rs1["ParCorrection"]))) * 100;
                    }
                }
                
                if(parPercentValue<0)
                {
                    parPercentValue = 0;
                }

                // exit from the cycle if par percent value is less then specified par percent 
                // but the condition is valid if calculated par percent is more than specified par percent 
                if (rbGreaterThan.Checked)
                {
                    if(parPercentValue<=Convert.ToDecimal(txtParPercentage.Text))
                    {
                        goto EndCycle;
                    }
                }
                else if (rbLessThan.Checked)
                {
                    if (parPercentValue >= Convert.ToDecimal(txtParPercentage.Text))
                    {
                        goto EndCycle;
                    }
                }

                // add columns to a data grid view if the column "On Order" was not chosen 
                if (cbxIncludeOnOrder.Checked == false)
                {
                    dgvParPercentage.Rows.Add(Convert.ToString(rs1["ItemNumber"]),
                    Convert.ToString(Decimal.Round(Convert.ToDecimal(rs1["AmountInStock"]))),
                    Convert.ToString(Decimal.Round(Convert.ToDecimal(rs1["NewPar"]))),
                    Convert.ToString(Decimal.Round(parPercentValue)) + " %",
                    Convert.ToString(rs1["CoName"]));
                }
                // add columns to a data grid view if the column "On Order" was chosen
                else if (cbxIncludeOnOrder.Checked == true)
                {
                    dgvParPercentage.Rows.Add(Convert.ToString(rs1["ItemNumber"]),
                    Convert.ToString(Decimal.Round(Convert.ToDecimal(rs1["AmountInStock"]))),
                    Convert.ToString(Decimal.Round(Convert.ToDecimal(rs1["OnOrder"]))),
                    Convert.ToString(Decimal.Round(Convert.ToDecimal(rs1["NewPar"]))),
                    Convert.ToString(Decimal.Round(parPercentValue)) + " %",
                    Convert.ToString(rs1["CoName"]));
                }

            EndCycle: ;
            }
            rs1.Close();
            
            this.Cursor = Cursors.Arrow;
            
            label17.Text = "PERCENTAGE OF SALES (" + dgvParPercentage.RowCount.ToString() + ")";



        }

        // select of deselect all items on the tab "Out Of Stock"
        private void cbxAllItemsStock_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAllItemsStock.Checked)
            {
                for (int i = 0; i < cblItemStock.Items.Count; i++)
                {
                    cblItemStock.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < cblItemStock.Items.Count; i++)
                {
                    cblItemStock.SetItemChecked(i, false);
                }
            }
        }

        // select of deselect all companies on the tab "Out Of Stock"
        private void cbAllCompaniesStock_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAllCompaniesStock.Checked)
            {
                for (int i = 0; i < cblCompanyStock.Items.Count; i++)
                {
                    cblCompanyStock.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < cblCompanyStock.Items.Count; i++)
                {
                    cblCompanyStock.SetItemChecked(i, false);
                }
            }
        }

        private void btnSearchItemsStock_Click(object sender, EventArgs e)
        {
            cblItemStock.Items.Clear();
            cbxAllItemsStock.Checked = false;
            DivaLink divl = new DivaLink();
            divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
            string conString = divl.GetConnectionString();
            SqlConnection conn = new SqlConnection(conString);
            string companies = "";

            // concatination of comanies that were chosen in the check box list
            for (int i = 0; i < cblCompanyStock.CheckedItems.Count; i++)
            {
                if (companies == "")
                {
                    companies = "'" + cblCompanyStock.CheckedItems[i].ToString() + "'";
                }
                else
                {
                    companies = companies + ", '" + cblCompanyStock.CheckedItems[i].ToString() + "'";
                }
            }

            string str = "select ItemNumber from StockLocation SL Inner Join InStock S " +
            "ON SL.StockLocationIndexPK=S.StockLocationIndexFK Inner Join Items I " +
            "ON S.ItemIndexFK=I.ItemIndexPK Inner Join Company C " +
            "ON I.CoIndexFK=C.CoIndexPK Where OOSStatus!='' and CoName IN (" + companies + ") and LocationName='" + cbLocationsOutOfStock.SelectedItem.ToString() + "' ";
 
            if ((cbxIncludeDiscontinuedStock.Checked == false) && (cbxOnlyDiscontinuedStock.Checked == false))
            {
                str += " and Discontinued=0";
            }

            if (cbxOnlyDiscontinuedStock.Checked == true)
            {
                str += " and Discontinued=1";
            }

            str += " Order By ItemNumber"; 


            SqlCommand command = new SqlCommand(str, conn);
            conn.Open();
            
            SqlDataReader rs = command.ExecuteReader();
            while (rs.Read())
            {
                cblItemStock.Items.Add(Convert.ToString(rs["ItemNumber"]));
            }
            rs.Close();
            conn.Close();
        }

        // the function calls another function to serach items on the tab "Out Of Stock" 
        // if the button Enter was pressed
        private void txtSearchItemsStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchItemsStock_Click(sender, e);
            }
        }

        private void btnGetInStock_Click(object sender, EventArgs e)
        {
            // the condition checks if at least one item was chosen in the list
            if (cblItemStock.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please choose at least one item");
                return;
            }
            // the condition checks if at least one company was chosen in the list
            if (cblCompanyStock.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please choose at least one company");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            dgvItemsInStock.Columns.Clear();
            DivaLink divl = new DivaLink();
            divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
            string conString = divl.GetConnectionString();
            decimal parPercentValue = 0;  // the variables is required to calculate par  percentage 
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            int i = 0;
            string companies = "";
            string Discontinued="";

            // concatination of comanies that were chosen in the check box list
            for (i = 0; i < cblCompanyStock.CheckedItems.Count; i++)
            {
                if (companies == "")
                {
                    companies = "'" + cblCompanyStock.CheckedItems[i].ToString() + "'";
                }
                else
                {
                    companies = companies + ", '" + cblCompanyStock.CheckedItems[i].ToString() + "'";
                }
            }

            // SQL query that is saved in the string  
            string str = "select CoName, ItemNumber, OnOrder, NewPar, ParCorrection, Discontinued, " + 
            "LocationName, AmountInStock, OOSStatus from StockLocation SL Inner Join InStock S " +
            "ON SL.StockLocationIndexPK=S.StockLocationIndexFK Inner Join Items I " +
            "ON S.ItemIndexFK=I.ItemIndexPK Inner Join Company C " + 
            "ON I.CoIndexFK=C.CoIndexPK Where OOSStatus!='' and CoName IN (" + companies + ") and LocationName='" + cbLocationsOutOfStock.SelectedItem.ToString() + "' " +
            "and (ItemNumber LIKE '%" + txtSearchItemsStock.Text + "%' or Description Like '%" + txtSearchItemsStock.Text + "%')";

            if ((cbxIncludeDiscontinuedStock.Checked == false) && (cbxOnlyDiscontinuedStock.Checked==false))
            {
                str += " and Discontinued=0";
            }

            if (cbxOnlyDiscontinuedStock.Checked == true)
            {
                str += " and Discontinued=1";
            }

            str += " Order By ItemNumber"; 

            SqlCommand commandStockValue = new SqlCommand(str, conn);
            SqlDataReader rs1 = commandStockValue.ExecuteReader();
            
            // add headers to the data grid view
            dgvItemsInStock.Columns.Add("ItemNumber", "Item Number");
            dgvItemsInStock.Columns.Add("InStock", "In Stock");
            dgvItemsInStock.Columns.Add("NewPar", "New Par");
            dgvItemsInStock.Columns.Add("ParCorrection", "Par Correction");

            dgvItemsInStock.Columns.Add("ParPercentage", "Par Percentage");
            dgvItemsInStock.Columns.Add("OnOrder", "On Order");
            
            dgvItemsInStock.Columns.Add("OOSStatus", "Stock Status");
            dgvItemsInStock.Columns.Add("Discontinued", "Discontinued");
            dgvItemsInStock.Columns.Add("Company", "Company");
            
            // initialization of variables required for progress bar
            lblWaitOutOfStock.Visible = true;
            progressBar2.Visible = true;
            progressBar2.Maximum = 1000;
            progressBar2.Minimum = 1;
            progressBar2.Value = 1;
            progressBar2.Step = 1;
            i = 0;

            while (rs1.Read())
            {
                this.Refresh();
                progressBar2.PerformStep();
                if (progressBar2.Value == 1000)
                {
                    progressBar2.Value = 1;
                }

                if (cblItemStock.Items[i].ToString() != Convert.ToString(rs1["ItemNumber"])) 
                {
                    i++;
                }

                if ((cblItemStock.Items[i].ToString() == Convert.ToString(rs1["ItemNumber"]))
                    && (cblItemStock.GetItemCheckState(i) == CheckState.Checked))
                {
                 
                    if (Convert.ToString(rs1["Discontinued"]) == "True")
                    {
                        Discontinued = "Discontinued";
                    }
                    else
                    {
                        Discontinued = "";
                    }

                    if ((Convert.ToDecimal(rs1["NewPar"]) + Convert.ToDecimal(rs1["ParCorrection"])) == 0)
                    {
                        parPercentValue = 1;
                    }
                    else
                    {
                        parPercentValue = ((Convert.ToDecimal(rs1["AmountInStock"]) + Convert.ToDecimal(rs1["OnOrder"])) /
                            (Convert.ToDecimal(rs1["NewPar"]) + Convert.ToDecimal(rs1["ParCorrection"]))) * 100;
                    }

                    dgvItemsInStock.Rows.Add(Convert.ToString(rs1["ItemNumber"]),
                    Decimal.Round(Convert.ToDecimal(rs1["AmountInStock"])),
                    Convert.ToString(rs1["NewPar"]),
                    Convert.ToString(rs1["ParCorrection"]),
                    Decimal.Round(parPercentValue),
                    Convert.ToString(rs1["OnOrder"]),
                    Convert.ToString(rs1["OOSStatus"]),
                    Discontinued,
                    //Convert.ToString(rs1["Discontinued"]),
                    Convert.ToString(rs1["CoName"]));
                 }
                
              

            }
            rs1.Close();


            lblWaitOutOfStock.Visible = false;
            progressBar2.Visible = false;
            this.Cursor = Cursors.Arrow;

            // remove columns from data grid view according to selection of check boxes 
            if (cbxNewParStock.Checked==false)
            {
                dgvItemsInStock.Columns[3].Visible=false;
            }
            if (cbxParCorrectionStock.Checked==false)
            {
                dgvItemsInStock.Columns[4].Visible = false;
            }
            if (cbxParPercentageStock.Checked==false)
            {
                dgvItemsInStock.Columns[5].Visible = false;
            }
            if (cbxDiscontinuedStock.Checked == false)
            {
                dgvItemsInStock.Columns[8].Visible = false;
            }
            if (cbxOnOrderStock.Checked==false)
            {
                dgvItemsInStock.Columns[6].Visible = false;
            }
            label18.Text = "OUT OF STOCK STATUS (" + (dgvItemsInStock.RowCount-1) + ")"; 

             



        }

        private void btnExportToCSVSets_Click(object sender, EventArgs e)
        {
            if ((dgvSets.Rows.Count == 0) || (dgvSets.Rows.Count == 1))
            {
                MessageBox.Show("There is not any data to export");
                return;
            }
            
            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.Title = "Save As an export file in CSV format";
            saveFD.InitialDirectory = @"c:\Desktop";
            saveFD.FileName = "Sales Of Sets Report (" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" +
               DateTime.Now.Minute + DateTime.Now.Second;
            saveFD.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            string filePath = "";
            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFD.FileName;

                StreamWriter tw = new StreamWriter(filePath);
                tw.WriteLine("Set Name, AccountName, WeekDate, TotalSold, Description");

                for (int i = 0; i < dgvItems.Rows.Count - 1; i++)
                {
                    tw.WriteLine(dgvSets.Rows[i].Cells["SetName"].Value.ToString() + ", " + dgvSets.Rows[i].Cells["AccountName"].Value.ToString() + ", " +
                          ", " + dgvSets.Rows[i].Cells["WeekDate"].Value.ToString() + ", " + dgvSets.Rows[i].Cells["TotalSold"].Value.ToString() +
                          ", " + dgvSets.Rows[i].Cells["Description"].Value.ToString());
                }
                tw.Close();
                MessageBox.Show("The data was exported to CSV succesfully.");
            }
            
        }

        private void btnExportToCSVPar_Click(object sender, EventArgs e)
        {
            if ((dgvParPercentage.Rows.Count == 0) || (dgvParPercentage.Rows.Count == 1))
            {
                MessageBox.Show("There is not any data to export");
                return;
            }
            
            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.Title = "Save As an export file in CSV format";
            saveFD.InitialDirectory = @"c:\Desktop";
            saveFD.FileName = "Par Percentage Report (" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year + ")";
            saveFD.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            string filePath = "";
            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFD.FileName;

                StreamWriter tw = new StreamWriter(filePath);
                if(cbxIncludeOnOrder.Checked==false)
                {
                    tw.WriteLine("Item Number, In Stock, Par %, Company");
                    for (int i = 0; i < dgvParPercentage.Rows.Count - 1; i++)
                    {
                        tw.WriteLine(dgvParPercentage.Rows[i].Cells["ItemNumber"].Value.ToString() + ", " + dgvParPercentage.Rows[i].Cells["InStock"].Value.ToString() + ", " +
                              dgvParPercentage.Rows[i].Cells["ParPercent"].Value.ToString() + ", " + dgvParPercentage.Rows[i].Cells["Company"].Value.ToString());
                    }
                }
                else if (cbxIncludeOnOrder.Checked == true)
                {
                    tw.WriteLine("Item Number, In Stock, On Order, Par %, Company");
                    for (int i = 0; i < dgvParPercentage.Rows.Count - 1; i++)
                    {
                        tw.WriteLine(dgvParPercentage.Rows[i].Cells["ItemNumber"].Value.ToString() + ", " + dgvParPercentage.Rows[i].Cells["InStock"].Value.ToString() + ", " +
                              dgvParPercentage.Rows[i].Cells["OnOrder"].Value.ToString() + ", " + dgvParPercentage.Rows[i].Cells["ParPercent"].Value.ToString() +
                              ", " + dgvParPercentage.Rows[i].Cells["Company"].Value.ToString());
                    }
                }

                tw.Close();
                MessageBox.Show("The data was exported to CSV succesfully.");
            }
            
        }

        private void btnExportToCSVStock_Click(object sender, EventArgs e)
        {
            if ((dgvItemsInStock.Rows.Count == 0) || (dgvItemsInStock.Rows.Count == 1))
            {
                MessageBox.Show("There is not any data to export");
                return;
            }
            
            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.Title = "Save As an export file in CSV format";
            saveFD.InitialDirectory = @"c:\Desktop";
            saveFD.FileName = "Out Of Stock Report (" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" +
               DateTime.Now.Year + ")";
            saveFD.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            string filePath = "";
            string fileHeader = "";
            string fileRow = "";

            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFD.FileName;

                StreamWriter tw = new StreamWriter(filePath);

                // concatenation of different headers according to selected check boxes
                fileHeader = "Item Number, ";
                if (cbxNewParStock.Checked == true)
                {
                    fileHeader += "In Stock, ";
                }
                fileHeader += "New Par, ";
                if (cbxParCorrectionStock.Checked == true)
                {
                    fileHeader += "Par Correction, ";
                }
                if (cbxParPercentageStock.Checked == true)
                {
                    fileHeader += "Par Percentage, ";
                }
                if (cbxOnOrderStock.Checked == true)
                {
                    fileHeader += "On Order, ";
                }
                fileHeader += "Stock Status, ";
                if (cbxIncludeDiscontinuedStock.Checked == true)
                {
                    fileHeader += "Discontinued, ";
                }
                fileHeader += "Company";

                tw.WriteLine(fileHeader);

                for (int i = 0; i < dgvItemsInStock.Rows.Count - 1; i++)
                {
                    // concatenation of different columns from the data grid view according to selected check boxes
                    fileRow = dgvItemsInStock.Rows[i].Cells["ItemNumber"].Value.ToString() + ", ";
                    if (cbxNewParStock.Checked == true)
                    {
                        fileRow += dgvItemsInStock.Rows[i].Cells["InStock"].Value.ToString() + ", ";
                    }
                    
                    fileRow += dgvItemsInStock.Rows[i].Cells["NewPar"].Value.ToString() + ", ";
                    
                    if (cbxParCorrectionStock.Checked == true)
                    {
                        fileRow += dgvItemsInStock.Rows[i].Cells["ParCorrection"].Value.ToString() + ", ";
                    }
                    if (cbxParPercentageStock.Checked == true)
                    {
                        fileRow += dgvItemsInStock.Rows[i].Cells["ParPercentage"].Value.ToString() + ", ";
                    }
                    if (cbxOnOrderStock.Checked == true)
                    {
                        fileRow += dgvItemsInStock.Rows[i].Cells["OnOrder"].Value.ToString() + ", ";
                    }
                    fileRow += dgvItemsInStock.Rows[i].Cells["OOSStatus"].Value.ToString() + ", ";
                    if (cbxIncludeDiscontinuedStock.Checked == true)
                    {
                        fileRow += dgvItemsInStock.Rows[i].Cells["OnOrder"].Value.ToString() + ", ";
                    }
                    fileRow += dgvItemsInStock.Rows[i].Cells["Company"].Value.ToString();
                    
                    tw.WriteLine(fileRow);

                }
                tw.Close();
                MessageBox.Show("The data was exported to CSV succesfully.");
            }
                        
            
        }

        private void btnNewSearch_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("If you make a new search all your items will be removed. Do you want to proceed?",
                "Warrning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.No)
            {
                return;
            }
            
            cblItems.Items.Clear();
            btnSales.Enabled = false;
            btnGetItems.Enabled = true;
            dtpDateFrom.Enabled = true;
            dtpDateTo.Enabled = true;
            cblAccount.Enabled = true;
            cmbCompany.Enabled = true;
            btnSearch.Enabled = true;
            cbxAllAccounts.Checked = false;
            cbxAllItems.Checked = false;
            dgvItems.Rows.Clear();
            cbxIncludeDiscontinued.Enabled = true;
            cbxOnlyDiscontinuedSalesOfItems.Enabled = true;
            cbxAllAccounts.Enabled = false;
            cbxSumOfTotalSales.Enabled = false;
            cbxSumOfTotalSales.Enabled = true;
            cbxAllAccounts.Enabled = true;
            label7.Text = "SALES OF ITEMS";
            txtItemSearch.Text = "";

        }

        private void btnGetItems_Click(object sender, EventArgs e)
        {
            txtItemSearch.Text = "";
            if (cblAccount.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please choose at least one account");
                return;
            }
            
            this.Cursor = Cursors.WaitCursor;
            progressBar1.Visible = true;
            lblWaitMessage.Visible = true;
            progressBar1.Maximum = 1000;
            progressBar1.Minimum = 1;
            progressBar1.Step = 1;

            cblItems.Items.Clear();
            cbxAllItems.Checked = false;
            
            string accounts = "";
            int i = 0;

            for (i = 0; i < cblAccount.CheckedItems.Count; i++)
            {
                if (accounts == "")
                {
                    accounts = "'" + cblAccount.CheckedItems[i].ToString() + "'";
                }
                else
                {
                    accounts = accounts + ", '" + cblAccount.CheckedItems[i].ToString() + "'";
                }
            }
           

            DivaLink divl = new DivaLink();
            divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
            string conString = divl.GetConnectionString();
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            string temp = "Select Distinct ItemNumber From Items I Left Join SalesHistory SH ON I.ItemIndexPK=SH.ItemIndexFK Left Join Accounts A " +
            "ON SH.AccountIndexFK=A.AccountIndexPK Left Join Company C ON C.CoIndexPK=I.CoIndexFK " +
            "Where WeekDate>='" + dtpDateFrom.Text + "' and WeekDate<='" + dtpDateTo.Text + "' and AccountName IN (" + accounts + ")";

            if ((cmbCompany.SelectedItem.ToString() != "All companies"))
            {
                temp += " and CoName='" + cmbCompany.SelectedItem.ToString() + "'";
            } 
            
           if ((cbxIncludeDiscontinued.Checked==false) && (cbxOnlyDiscontinuedSalesOfItems.Checked == false))
           {
               temp += " and Discontinued=0";
           }
           if (cbxOnlyDiscontinuedSalesOfItems.Checked == true)
           {
               temp += " and Discontinued=1";
           }
           
           temp +="Order By ItemNumber";

           if (cbxSumOfTotalSales.Checked == true)
           {
               temp = "Select Distinct ItemNumber From Items I Left Join SalesHistory SH ON I.ItemIndexPK=SH.ItemIndexFK Left Join Accounts A " +
               "ON SH.AccountIndexFK=A.AccountIndexPK Left Join Company C ON C.CoIndexPK=I.CoIndexFK " +
               "Where WeekDate>='" + dtpDateFrom.Text + "' and WeekDate<='" + dtpDateTo.Text + "' and AccountName IN (" + accounts + ") ";

               if ((cmbCompany.SelectedItem.ToString() != "All companies"))
               {
                   temp += " and CoName='" + cmbCompany.SelectedItem.ToString() + "'";
               }

               if ((cbxIncludeDiscontinued.Checked == false) && (cbxOnlyDiscontinuedSalesOfItems.Checked == false))
               {
                   temp += " and Discontinued=0";
               }
               if (cbxOnlyDiscontinuedSalesOfItems.Checked == true)
               {
                   temp += " and Discontinued=1";
               }
               temp += "Group By CoName, ItemNumber, Description, WeekDate, AccountName " +
               "Order By ItemNumber";
           }

            SqlCommand commandItems = new SqlCommand(temp, conn);
            SqlDataReader rs1 = commandItems.ExecuteReader();
            while (rs1.Read())
            {
                this.Refresh();
                progressBar1.PerformStep();
                if(progressBar1.Value==1000)
                {
                    progressBar1.Value = 1;
                }
                
                cblItems.Items.Add(Convert.ToString(rs1["ItemNumber"]));

            }
            rs1.Close();
            conn.Close();
            this.Cursor = Cursors.Arrow;
            lblWaitMessage.Visible = false;
            progressBar1.Visible = false;
                        
            if (cblItems.Items.Count==0)
            {
                MessageBox.Show("No items were found for the chosen time period");
                return;
            }


            btnSales.Enabled = true;
            btnGetItems.Enabled = false;
            dtpDateFrom.Enabled = false;
            dtpDateTo.Enabled = false;
            cblAccount.Enabled = false;
            cmbCompany.Enabled = false;
            btnSearch.Enabled = true;
            cbxIncludeDiscontinued.Enabled = false;
            cbxOnlyDiscontinuedSalesOfItems.Enabled = false;
            cbxAllAccounts.Enabled = false;
            cbxSumOfTotalSales.Enabled = false;
        }

        private void btnSearchCompany_Click(object sender, EventArgs e)
        {
            DivaLink divl = new DivaLink();
            divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
            string conString = divl.GetConnectionString();
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            
            SqlCommand commandCompany = new SqlCommand("select CoName from Company where CoName Like '%" + txtCompanyParSearch.Text + "%'", conn);
            SqlDataReader rs4 = commandCompany.ExecuteReader();
            cblCompany.Items.Clear();

            while (rs4.Read())
            {
                cblCompany.Items.Add(Convert.ToString(rs4["CoName"]));
            }
            rs4.Close();
            conn.Close();
        }

        private void txtCompanyParSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchCompany_Click(sender, e);
            } 
        }

        private void cblCompaniesExport_SelectedIndexChanged(object sender, EventArgs e)
        {
            cblItemsExport.Items.Clear();
            cbxAllItemsExport.Checked = false;
        }

        private void getItemsForBulkExport() 
        {
            DivaLink divl = new DivaLink();
            divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
            string conString = divl.GetConnectionString();
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            string temp = "";
            string companies = "";

            // concatination of comanies that were chosen in the check box list
            for (int i = 0; i < cblCompaniesExport.CheckedItems.Count; i++)
            {
                if (companies == "")
                {
                    companies = "'" + cblCompaniesExport.CheckedItems[i].ToString() + "'";
                }
                else
                {
                    companies = companies + ", '" + cblCompaniesExport.CheckedItems[i].ToString() + "'";
                }
            }

            // add items to the tab "Out Of Stock" when the form is loaded for the first time
            temp = "Select Distinct ItemNumber From Items I Left Join InStock InS ON I.ItemIndexPK = InS.ItemIndexFK Left Join StockLocation SL " +
                "ON InS.StockLocationIndexFK=SL.StockLocationIndexPK Left Join CurrentSold CS ON I.ItemIndexPK = CS.ItemIndexFK Left Join Accounts A " +
                "ON CS.AccountIndexFK = A.AccountIndexPK Left Join Company C ON I.CoIndexFK=C.CoIndexPK " +
                "Where LocationName='" + cbInStockExport.SelectedItem.ToString() + "' and CoName IN (" + companies + ") ";

            if (cbAccountsExport.SelectedItem.ToString() != "All Accounts")
            {
                temp += "and AccountName='" + cbAccountsExport.SelectedItem.ToString() + "' ";
            }


            if ((cbxIncludeDiscontinuedExport.Checked == false) && (cbxOnlyDiscontinued.Checked == false))
            {
                temp += " and Discontinued=0";
            }

            if (cbxOnlyDiscontinued.Checked == true)
            {
                temp += " and Discontinued=1";
            }

            temp += " Order By ItemNumber";

            SqlCommand cmd = new SqlCommand(temp, conn);
            SqlDataReader rs1 = cmd.ExecuteReader();
            while (rs1.Read())
            {
                cblItemsExport.Items.Add(Convert.ToString(rs1["ItemNumber"]));
            }
            rs1.Close();
        
        }

        private void btnGetItemsFromCompanies_Click(object sender, EventArgs e)
        {
            if (cblCompaniesExport.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please choose at least one company.");
                return;
            }
            cblItemsExport.Items.Clear();
            cbxAllItemsExport.Checked = false;
            txtSearchItemsExport.Text = "";

            getItemsForBulkExport();
        }


        private void btnExportToCSVItems_Click(object sender, EventArgs e)
        {
            if (cblCompaniesExport.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please choose at least one company");
                return;
            }
            if (cblItemsExport.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please choose at least one item");
                return;
            }

            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.Title = "Save As an export file in CSV format";
            saveFD.InitialDirectory = @"c:\Desktop";
            saveFD.FileName = "Bulk Export for [" + cbInStockExport.SelectedItem.ToString() +
                "] (" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year + ")";
            saveFD.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            string filePath = "";
            string fileHeader = "";
            string fileRow = "";
            int i = 0;
            string temp = "";
            string companies = "";
            
            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    filePath = saveFD.FileName;

                    StreamWriter tw = new StreamWriter(filePath);

                    fileHeader += "Item Number, ";

                    if (cbxCurrentSoldExport.Checked == true)
                    {
                        if (cbAccountsExport.SelectedItem.ToString() != "All Accounts")
                        {
                            fileHeader += "Current Sold For " + cbAccountsExport.SelectedItem.ToString() + ", ";
                        }
                        else if (cbAccountsExport.SelectedItem.ToString() == "All Accounts")
                        {
                            fileHeader += "Current Sold, ";
                        }
                    }

                    if (cbxParCorrection.Checked == true)
                    {
                        fileHeader += "Par Correction, ";
                    }
                    if (cbxNewPar.Checked == true)
                    {
                        fileHeader += "New Par, ";
                    }
                    if (cbxWarehouseLocation.Checked == true)
                    {
                        fileHeader += "Location, ";
                    }
                    if (cbxDiscontinued.Checked == true)
                    {
                        fileHeader += "Discontinued, ";
                    }
                    if (cbxQuantityControl.Checked == true)
                    {
                        fileHeader += "Quantity Control, ";
                    }

                    if (cbxInStock.Checked == true)
                    {
                        fileHeader += "In Stock, ";
                    }
                    if (cbxOnOrder.Checked == true)
                    {
                        fileHeader += "On Order, ";
                    }
                    if (cbxLastOrder.Checked == true)
                    {
                        fileHeader += "Last Order, ";
                    }
                    if (cbxOutOfStock.Checked == true)
                    {
                        fileHeader += "Out Of Stock, ";
                    }
                    if (cbxCompany.Checked == true)
                    {
                        fileHeader += "Company, ";
                    }
                    if (cbxCost.Checked == true)
                    {
                        fileHeader += "LSP, ";
                    }
                    if (cbxMap.Checked == true)
                    {
                        fileHeader += "Map, ";
                    }
                    if (cbxShippingWeight.Checked == true)
                    {
                        fileHeader += "LBS Shipping, OZ Shipping, ";
                    }
                    if (cbxCaseQuantity.Checked == true)
                    {
                        fileHeader += "Case QTY Minimum, ";
                    }
                    if (cbxNotes.Checked == true)
                    {
                        fileHeader += "Notes, ";
                    }
                    if (cbxDescription.Checked == true)
                    {
                        fileHeader += "Description";
                    }

                    tw.WriteLine(fileHeader);

                    DivaLink divl = new DivaLink();
                    divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
                    string conString = divl.GetConnectionString();
                    SqlConnection conn = new SqlConnection(conString);
                    conn.Open();

                    // concatination of comanies that were chosen in the check box list
                    for (i = 0; i < cblCompaniesExport.CheckedItems.Count; i++)
                    {
                        if (companies == "")
                        {
                            companies = "'" + cblCompaniesExport.CheckedItems[i].ToString() + "'";
                        }
                        else
                        {
                            companies = companies + ", '" + cblCompaniesExport.CheckedItems[i].ToString() + "'";
                        }
                    }

                    temp = "Select SUM(CurSold) CurS, ParCorrection, NewPar, Location, Discontinued, QuantityControlled, ItemNumber, AmountInStock, OnOrder, " +
                        "LastOrdered, OOSStatus, Description, CoName, Cost, MAP, OzShipping, CaseQTY, I.notes " +
                        "From Items I Left Join InStock InS ON I.ItemIndexPK = InS.ItemIndexFK Left Join StockLocation SL " +
                        "ON InS.StockLocationIndexFK=SL.StockLocationIndexPK Left Join CurrentSold CS ON I.ItemIndexPK = CS.ItemIndexFK Left Join Accounts A " +
                        "ON CS.AccountIndexFK = A.AccountIndexPK Left Join Company C ON I.CoIndexFK=C.CoIndexPK " +
                        "Where LocationName='" + cbInStockExport.SelectedItem.ToString() + "' and CoName IN (" + companies + ") " +
                        "and (ItemNumber LIKE '%" + txtSearchItemsExport.Text + "%' or Description Like '%" + txtSearchItemsExport.Text + "%') ";

                    if (cbAccountsExport.SelectedItem.ToString() != "All Accounts")
                    {
                        temp += "and AccountName='" + cbAccountsExport.SelectedItem.ToString() + "' ";
                    }

                    if ((cbxIncludeDiscontinuedExport.Checked == false) && (cbxOnlyDiscontinued.Checked == false))
                    {
                        temp += "and Discontinued=0 ";
                    }

                    if (cbxOnlyDiscontinued.Checked == true)
                    {
                        temp += " and Discontinued=1";
                    }

                    temp += "Group By ItemNumber, ParCorrection, NewPar, Location, Discontinued, QuantityControlled, AmountInStock, OnOrder, " +
                        "LastOrdered, OOSStatus, Description, CoName, Cost, MAP, OzShipping, CaseQTY, I.notes ";

                    if (cbAccountsExport.SelectedItem.ToString() != "All Accounts")
                    {
                        temp += ", AccountName ";
                    }
                    temp += "Order By ItemNumber ";


                    SqlCommand cmd = new SqlCommand(temp, conn);
                    SqlDataReader rs1 = cmd.ExecuteReader();
                    i = 0;
                    while (rs1.Read())
                    {

                        if (cblItemsExport.Items[i].ToString() != Convert.ToString(rs1["ItemNumber"]))
                        {
                            i++;
                        }

                        if ((cblItemsExport.Items[i].ToString() == Convert.ToString(rs1["ItemNumber"]))
                            && (cblItemsExport.GetItemCheckState(i) == CheckState.Checked))
                        {
                            fileRow = Convert.ToString(rs1["ItemNumber"]).Replace(",", "; ") + ", ";

                            if (cbxCurrentSoldExport.Checked == true)
                            {
                                if (rs1["CurS"] == System.DBNull.Value)
                                {
                                    fileRow += "0, ";
                                }
                                else if (rs1["CurS"] != System.DBNull.Value)
                                {
                                    fileRow += Convert.ToString(rs1["CurS"]).Replace(",", "; ") + ", ";
                                }
                            }

                            if (cbxParCorrection.Checked == true)
                            {
                                fileRow += Convert.ToString(rs1["ParCorrection"]).Replace(",", "; ") + ", ";
                            }
                            if (cbxNewPar.Checked == true)
                            {
                                fileRow += Convert.ToString(rs1["NewPar"]).Replace(",", "; ") + ", ";
                            }
                            if (cbxWarehouseLocation.Checked == true)
                            {
                                if (rs1["Location"] == System.DBNull.Value)
                                {
                                    fileRow += ", ";
                                }
                                else
                                {
                                    fileRow += Convert.ToString(rs1["Location"]).Replace(",", "; ") + ", ";
                                }
                            }
                            if (cbxDiscontinued.Checked == true)
                            {

                                if (Convert.ToString(rs1["Discontinued"]) == "True")
                                {
                                    fileRow += "Discontinued, ";
                                }
                                else
                                {
                                    fileRow += " , ";
                                }
                            }
                            if (cbxQuantityControl.Checked == true)
                            {
                                if (Convert.ToString(rs1["QuantityControlled"]) == "true")
                                {
                                    fileRow += "Quantity Controlled, ";
                                }
                                else
                                {
                                    fileRow += " , ";
                                }
                            }

                            if (cbxInStock.Checked == true)
                            {
                                fileRow += Convert.ToString(rs1["AmountInStock"]).Replace(",", "; ") + ", ";
                            }
                            if (cbxOnOrder.Checked == true)
                            {
                                fileRow += Convert.ToString(rs1["OnOrder"]).Replace(",", "; ") + ", ";
                            }
                            if (cbxLastOrder.Checked == true)
                            {
                                if (rs1["LastOrdered"] == System.DBNull.Value)
                                {
                                    fileRow += ", ";
                                }
                                else
                                {
                                    fileRow += Convert.ToString(rs1["LastOrdered"]).Replace(",", "; ") + ", ";
                                }
                            }
                            if (cbxOutOfStock.Checked == true)
                            {
                                if (rs1["OOSStatus"] == System.DBNull.Value)
                                {
                                    fileRow += ", ";
                                }
                                else
                                {
                                    fileRow += Convert.ToString(rs1["OOSStatus"]).Replace(",", "; ") + ", ";
                                }
                            }

                            if (cbxCompany.Checked == true)
                            {
                                fileRow += Convert.ToString(rs1["CoName"]).Replace(",", "; ") + ", ";
                            }
                            if (cbxCost.Checked == true)
                            {
                                double costTemp = Convert.ToDouble(rs1["Cost"]) * 1.265;
                                costTemp = Math.Round(costTemp, 2);
                                fileRow += Convert.ToString(costTemp) + ", ";
                            }
                            if (cbxMap.Checked == true)
                            {
                                fileRow += Convert.ToString(rs1["MAP"]).Replace(",", "; ") + ", ";
                            }
                            if (cbxShippingWeight.Checked == true)
                            {
                                if (rs1["OzShipping"] == System.DBNull.Value)
                                {
                                    fileRow += ", ";
                                }
                                else
                                {
                                    fileRow += Convert.ToString(rs1["OzShipping"]).Replace(",", "; ") + ", ";
                                    fileRow += Convert.ToString(Convert.ToDecimal(rs1["OzShipping"]) * 0.0625M).Replace(",", "; ") + ", ";
                                }
                            }
                            if (cbxCaseQuantity.Checked == true)
                            {
                                fileRow += Convert.ToString(rs1["CaseQTY"]).Replace(",", "; ") + ", ";
                            }
                            if (cbxNotes.Checked == true)
                            {
                                if (rs1["notes"] == System.DBNull.Value)
                                {
                                    fileRow += ", ";
                                }
                                else
                                {
                                    fileRow += Convert.ToString(rs1["notes"]).Replace(",", "; ") + ", ";
                                }
                            }

                            if (cbxDescription.Checked == true)
                            {
                                if (rs1["Description"] == System.DBNull.Value)
                                {
                                    fileRow += "";
                                }
                                else
                                {
                                    fileRow += Convert.ToString(rs1["Description"]).Replace(",", "; ") + "";
                                    //fileRow += Convert.ToString(rs1["Description"]);
                                }
                            }
                            fileRow = fileRow.TrimStart();
                            fileRow = fileRow.TrimEnd();

                            tw.WriteLine(fileRow);



                        }
                    }
                    rs1.Close();
                    tw.Close();
                    conn.Close();
                    MessageBox.Show("The data was exported to CSV succesfully.");

                }
                catch(IOException ex) 
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
                

            } // tghe last one

        }            

        private void getItemsInStock() 
        {
            DivaLink divl = new DivaLink();
            divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
            string conString = divl.GetConnectionString();
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            string temp = "";
            string companies = "";

            // concatination of comanies that were chosen in the check box list
            for (int i = 0; i < cblCompanyStock.CheckedItems.Count; i++)
            {
                if (companies == "")
                {
                    companies = "'" + cblCompanyStock.CheckedItems[i].ToString() + "'";
                }
                else
                {
                    companies = companies + ", '" + cblCompanyStock.CheckedItems[i].ToString() + "'";
                }
            }

            temp = "select ItemNumber from StockLocation SL Inner Join InStock S " +
            "ON SL.StockLocationIndexPK=S.StockLocationIndexFK Inner Join Items I " +
            "ON S.ItemIndexFK=I.ItemIndexPK Inner Join Company C " +
            "ON I.CoIndexFK=C.CoIndexPK Where OOSStatus!='' and CoName IN (" + companies + ") and LocationName='" + cbLocationsOutOfStock.SelectedItem.ToString() + "' ";

            if ((cbxIncludeDiscontinuedStock.Checked == false) && (cbxOnlyDiscontinuedStock.Checked == false))
            {
                temp += " and Discontinued=0";
            }

            if (cbxOnlyDiscontinuedStock.Checked == true)
            {
                temp += " and Discontinued=1";
            }

            temp += " Order By ItemNumber";

            SqlCommand commandItemsStock = new SqlCommand(temp, conn);
            SqlDataReader rs1 = commandItemsStock.ExecuteReader();
            while (rs1.Read())
            {
                cblItemStock.Items.Add(Convert.ToString(rs1["ItemNumber"]));
            }
            rs1.Close();
        
        }


        private void cbxIncludeDiscontinuedStock_CheckedChanged(object sender, EventArgs e)
        {
            if (cblCompanyStock.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please choose at least one company.");
                return;
            }

            txtSearchItemsStock.Text = "";
            cblItemStock.Items.Clear();
            cbxAllItemsStock.Checked = false;
            
            getItemsInStock();
            
        }

       

        private void btnGetItemsForStockCompanies_Click(object sender, EventArgs e)
        {
            if (cblCompanyStock.CheckedItems.Count==0)
            {
                MessageBox.Show("Please choose at least one company.");
                return;
            }

            cblItemStock.Items.Clear();
            cbxAllItemsStock.Checked = false;
            txtSearchItemsStock.Text = "";

            getItemsInStock();
            
        }

        private void cbxIncludeDiscontinuedExport_CheckedChanged(object sender, EventArgs e)
        {
            cblItemsExport.Items.Clear();
            cbxAllItemsExport.Checked = false;
            txtSearchItemsExport.Text = "";

            if (cblCompaniesExport.CheckedItems.Count == 0)
            {
                return;
            }

            getItemsForBulkExport();

        }

        private void btnSearchItemsExport_Click(object sender, EventArgs e)
        {
            cblItemsExport.Items.Clear();
            cbxAllItemsExport.Checked = false;
            DivaLink divl = new DivaLink();
            divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
            string conString = divl.GetConnectionString();
            SqlConnection conn = new SqlConnection(conString);
            string companies = "";

            // concatination of comanies that were chosen in the check box list
            for (int i = 0; i < cblCompaniesExport.CheckedItems.Count; i++)
            {
                if (companies == "")
                {
                    companies = "'" + cblCompaniesExport.CheckedItems[i].ToString() + "'";
                }
                else
                {
                    companies = companies + ", '" + cblCompaniesExport.CheckedItems[i].ToString() + "'";
                }
            }

            string temp = "Select Distinct ItemNumber From Items I Left Join InStock InS ON I.ItemIndexPK = InS.ItemIndexFK Left Join StockLocation SL " +
            "ON InS.StockLocationIndexFK=SL.StockLocationIndexPK Left Join CurrentSold CS ON I.ItemIndexPK = CS.ItemIndexFK Left Join Accounts A " +
            "ON CS.AccountIndexFK = A.AccountIndexPK Left Join Company C ON I.CoIndexFK=C.CoIndexPK " +
            "Where LocationName='" + cbInStockExport.SelectedItem.ToString() + "' and CoName IN (" + companies + ") " +
                           " and (ItemNumber LIKE '%" + txtSearchItemsExport.Text + "%' or Description Like '%" + txtSearchItemsExport.Text + "%')";

            if (cbAccountsExport.SelectedItem.ToString() != "All Accounts")
            {
                temp += "and AccountName='" + cbAccountsExport.SelectedItem.ToString() + "' ";
            }


            if ((cbxIncludeDiscontinuedExport.Checked == false) && (cbxOnlyDiscontinued.Checked == false))
            {
                temp += " and Discontinued=0";
            }

            if (cbxOnlyDiscontinued.Checked == true)
            {
                temp += " and Discontinued=1";
            }

            temp += " Order By ItemNumber";

            SqlCommand command = new SqlCommand(temp, conn);
            conn.Open();

            SqlDataReader rs = command.ExecuteReader();
            while (rs.Read())
            {
                cblItemsExport.Items.Add(Convert.ToString(rs["ItemNumber"]));
            }
            rs.Close();
            conn.Close();
        }

        private void cbxAllItemsExport_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAllItemsExport.Checked)
            {
                for (int i = 0; i < cblItemsExport.Items.Count; i++)
                {
                    cblItemsExport.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < cblItemsExport.Items.Count; i++)
                {
                    cblItemsExport.SetItemChecked(i, false);
                }
            }
        }

        private void txtSearchItemsExport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchItemsExport_Click(sender, e);
            }
        }

        private void cbxAllCompaniesExport_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAllCompaniesExport.Checked)
            {
                for (int i = 0; i < cblCompaniesExport.Items.Count; i++)
                {
                    cblCompaniesExport.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < cblCompaniesExport.Items.Count; i++)
                {
                    cblCompaniesExport.SetItemChecked(i, false);
                }
            }
        }

        private void cbxSelectAllOptions_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSelectAllOptions.Checked == true)
            {
                cbxParCorrection.Checked = true;
                cbxNewPar.Checked = true;
                cbxDiscontinued.Checked = true;
                cbxOnOrder.Checked = true;
                cbxDescription.Checked = true;
                cbxCompany.Checked = true;
                cbxCost.Checked = true;
                cbxMap.Checked = true;
                cbxShippingWeight.Checked = true;
                cbxCaseQuantity.Checked = true;
                cbxNotes.Checked = true;
                cbxOutOfStock.Checked = true;
                cbxQuantityControl.Checked = true;
                cbxLastOrder.Checked = true;
                cbxWarehouseLocation.Checked = true;
                cbxInStock.Checked = true;
                cbxCurrentSoldExport.Checked = true;
            }
            else 
            {
                cbxParCorrection.Checked = false;
                cbxNewPar.Checked = false;
                cbxDiscontinued.Checked = false;
                cbxOnOrder.Checked = false;
                cbxDescription.Checked = false;
                cbxCompany.Checked = false;
                cbxCost.Checked = false;
                cbxMap.Checked = false;
                cbxShippingWeight.Checked = false;
                cbxCaseQuantity.Checked = false;
                cbxNotes.Checked = false;
                cbxOutOfStock.Checked = false;
                cbxQuantityControl.Checked = false;
                cbxLastOrder.Checked = false;
                cbxWarehouseLocation.Checked = false;
                cbxInStock.Checked = false;
                cbxCurrentSoldExport.Checked = false;
            }


        }

        private void cbInStockExport_SelectedIndexChanged(object sender, EventArgs e)
        {
            cblItemsExport.Items.Clear();
            cbxAllItemsExport.Checked = false;
            txtSearchItemsExport.Text = "";
            
            if (cblCompaniesExport.CheckedItems.Count == 0)
            {
                return;
            }

            getItemsForBulkExport();
        }

        private void cbxIncludeOnOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxIncludeOnOrder.Checked == false)
            {
                lblParPercent.Text = "Par % is calculated as follows:     In Stock / (New Par + Par Correction)";
            }
            else if (cbxIncludeOnOrder.Checked == true)
            {
                lblParPercent.Text = "Par % is calculated as follows:     (In Stock + On Order)  / (New Par + Par Correction)";
            }
        }

        private void cblCompanyStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            cblItemStock.Items.Clear();
            cbxAllItemsStock.Checked = false;
        }

        private void cbLocationsOutOfStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            cblItemStock.Items.Clear();
            cbxAllItemsStock.Checked = false;
            txtSearchItemsStock.Text = "";

            if (cblCompanyStock.CheckedItems.Count == 0)
            {
                return;
            }

            getItemsInStock();
        }

        private void cbAccountsExport_SelectedIndexChanged(object sender, EventArgs e)
        {
            cblItemsExport.Items.Clear();
            cbxAllItemsExport.Checked = false;
            txtSearchItemsExport.Text = "";

            if (cblCompaniesExport.CheckedItems.Count == 0)
            {
                return;
            }

            getItemsForBulkExport();
        }

        private void cbxOnlyDiscontinued_CheckedChanged(object sender, EventArgs e)
        {
            cbxAllItemsExport.Checked = false;
            cblItemsExport.Items.Clear();
            txtSearchItemsExport.Text = "";

            if (cbxOnlyDiscontinued.Checked == true)
            {
                cbxIncludeDiscontinuedExport.Checked = false;
                cbxIncludeDiscontinuedExport.Enabled = false;
            }
            else
            {
                cbxIncludeDiscontinuedExport.Enabled = true;
            }

            if (cblCompaniesExport.CheckedItems.Count == 0)
            {
                return;
            }

            getItemsForBulkExport();

        }

        private void cbxOnlyDiscontinuedStock_CheckedChanged(object sender, EventArgs e)
        {
            if (cblCompanyStock.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please choose at least one company.");
                return;
            }
            
            cbxAllItemsStock.Checked = false;
            cblItemStock.Items.Clear();
            txtSearchItemsStock.Text = "";

            if (cbxOnlyDiscontinuedStock.Checked == true)
            {
                cbxIncludeDiscontinuedStock.Checked = false;
                cbxIncludeDiscontinuedStock.Enabled = false;
            }
            else
            {
                cbxIncludeDiscontinuedStock.Enabled = true;
            }

            getItemsInStock();
        }

        private void cbxNewParStock_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvItemsInStock.RowCount==0)
            {
                MessageBox.Show("No items are in the output table");
                return;
            }

            if (cbxNewParStock.Checked == false)
            {
                dgvItemsInStock.Columns[2].Visible = false;
            }
            else 
            {
                dgvItemsInStock.Columns[2].Visible = true;
            }
        }

        private void cbxParCorrectionStock_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvItemsInStock.RowCount == 0)
            {
                MessageBox.Show("No items are in the output table");
                return;
            }
            if (cbxParCorrectionStock.Checked == false)
            {
                dgvItemsInStock.Columns[3].Visible = false;
            }
            else 
            {
                dgvItemsInStock.Columns[3].Visible = true;
            }
        }

        private void cbxParPercentageStock_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvItemsInStock.RowCount == 0)
            {
                MessageBox.Show("No items are in the output table");
                return;
            }
            if (cbxParPercentageStock.Checked == false)
            {
                dgvItemsInStock.Columns[4].Visible = false;
            }
            else 
            {
                dgvItemsInStock.Columns[4].Visible = true;
            }
        }

        private void cbxOnOrderStock_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvItemsInStock.RowCount == 0)
            {
                MessageBox.Show("No items are in the output table");
                return;
            }
            if (cbxOnOrderStock.Checked == false)
            {
                dgvItemsInStock.Columns[5].Visible = false;
            }
            else 
            {
                dgvItemsInStock.Columns[5].Visible = true;
            }
        }

        private void cbxDiscontinuedStock_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDiscontinuedStock.Checked == true)
            {
                cbxIncludeDiscontinuedStock.Checked = false;
                cbxOnlyDiscontinuedStock.Checked = false;
                cbxIncludeDiscontinuedStock.Enabled = true;
                cbxOnlyDiscontinuedStock.Enabled = true;
            }
            else 
            {
                cbxIncludeDiscontinuedStock.Checked = false;
                cbxOnlyDiscontinuedStock.Checked = false;
                cbxIncludeDiscontinuedStock.Enabled = false;
                cbxOnlyDiscontinuedStock.Enabled = false;
            }

            if (dgvItemsInStock.RowCount > 0) 
            { 
                if (cbxDiscontinuedStock.Checked == false)
                {
                    dgvItemsInStock.Columns[7].Visible = false;
                }
                else 
                {
                    dgvItemsInStock.Columns[7].Visible = true;
                }
            }
            
            
        }

        private void cbxOnlyDiscontinuedSalesOfItems_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxOnlyDiscontinuedSalesOfItems.Checked == true)
            {
                cbxIncludeDiscontinued.Checked = false;
                cbxIncludeDiscontinued.Enabled = false;
            }
            else 
            {
                cbxIncludeDiscontinued.Enabled = true;
            }
        }

        private void getItemsForCurrentSold() 
        {
            if (cblAccountCS.CheckedItems.Count==0)
            {
                return;
            }
            
            txtItemSearchCS.Text = "";
            cblItemsCS.Items.Clear();
            cbxAllItemsCS.Checked = false;


            progressBarCS.Visible = true;
            lblWaitMessageCS.Visible = true;
            progressBarCS.Maximum = 1000;
            progressBarCS.Minimum = 1;
            progressBarCS.Step = 1;
            
            string accounts = "";
            int i = 0;

            this.Cursor = Cursors.WaitCursor;
            for (i = 0; i < cblAccountCS.CheckedItems.Count; i++)
            {
                if (accounts == "")
                {
                    accounts = "'" + cblAccountCS.CheckedItems[i].ToString() + "'";
                }
                else
                {
                    accounts = accounts + ", '" + cblAccountCS.CheckedItems[i].ToString() + "'";
                }
            }


            DivaLink divl = new DivaLink();
            divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
            string conString = divl.GetConnectionString();
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            string temp = "Select Distinct ItemNumber From Items I Inner Join CurrentSold CS ON I.ItemIndexPK=CS.ItemIndexFK Inner Join Accounts A " +
            "ON CS.AccountIndexFK=A.AccountIndexPK Inner Join Company C ON C.CoIndexPK=I.CoIndexFK " +
            "Where AccountName IN (" + accounts + ")";

            if ((cmbCompanyCS.SelectedItem.ToString() != "All companies"))
            {
                temp += " and CoName='" + cmbCompanyCS.SelectedItem.ToString() + "'";
            }

            if ((cbxIncludeDiscontinuedCS.Checked == false) && (cbxOnlyDiscontinuedCS.Checked == false))
            {
                temp += " and Discontinued=0";
            }
            if (cbxOnlyDiscontinuedCS.Checked == true)
            {
                temp += " and Discontinued=1";
            }

            temp += "Order By ItemNumber";

            if (cbxSumOfTotalSalesCS.Checked == true)
            {
                temp = "Select Distinct ItemNumber From Items I Inner Join CurrentSold CS ON I.ItemIndexPK=CS.ItemIndexFK Inner Join Accounts A " +
                "ON CS.AccountIndexFK=A.AccountIndexPK Inner Join Company C ON C.CoIndexPK=I.CoIndexFK " +
                "Where AccountName IN (" + accounts + ")";

                if ((cmbCompanyCS.SelectedItem.ToString() != "All companies"))
                {
                    temp += " and CoName='" + cmbCompanyCS.SelectedItem.ToString() + "'";
                }

                if ((cbxIncludeDiscontinuedCS.Checked == false) && (cbxOnlyDiscontinuedCS.Checked == false))
                {
                    temp += " and Discontinued=0";
                }
                if (cbxOnlyDiscontinuedCS.Checked == true)
                {
                    temp += " and Discontinued=1";
                }
                temp += "Group By CoName, ItemNumber, Description, AccountName " +
                "Order By ItemNumber";
            }

            SqlCommand commandItems = new SqlCommand(temp, conn);
            SqlDataReader rs1 = commandItems.ExecuteReader();
            while (rs1.Read())
            {
                this.Refresh();

                this.Refresh();
                progressBarCS.PerformStep();
                if (progressBarCS.Value == 1000)
                {
                    progressBarCS.Value = 1;
                }
                                
                cblItemsCS.Items.Add(Convert.ToString(rs1["ItemNumber"]));
            }
            rs1.Close();
            conn.Close();
            
            lblWaitMessageCS.Visible = false;
            progressBarCS.Visible = false;

            this.Cursor = Cursors.Arrow;
        }

        private void btnGetItemsCS_Click(object sender, EventArgs e)
        {
            if (cblAccountCS.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please choose at least one account");
                return;
            }
            
            getItemsForCurrentSold();
            

            if (cblItemsCS.Items.Count == 0)
            {
                MessageBox.Show("No items were found for the current period");
                return;
            }

        }

        private void cmbCompanyCS_SelectedIndexChanged(object sender, EventArgs e)
        {
            getItemsForCurrentSold();
        }

        private void cbxIncludeDiscontinuedCS_CheckedChanged(object sender, EventArgs e)
        {
            //getItemsForCurrentSold();
            cblItemsCS.Items.Clear();
        }

        private void cbxOnlyDiscontinuedCS_CheckedChanged(object sender, EventArgs e)
        {
            cblItemsCS.Items.Clear();
            if (cbxOnlyDiscontinuedCS.Checked == true)
            {
                cbxIncludeDiscontinuedCS.Checked = false;
                cbxIncludeDiscontinuedCS.Enabled = false;
            }
            else 
            {
                cbxIncludeDiscontinuedCS.Enabled = true;
            }

            //getItemsForCurrentSold();
        }

        private void cbxAllAccountsCS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAllAccountsCS.Checked)
            {
                for (int i = 0; i < cblAccountCS.Items.Count; i++)
                {
                    cblAccountCS.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < cblAccountCS.Items.Count; i++)
                {
                    cblAccountCS.SetItemChecked(i, false);
                }
            }
        }

        private void cbxAllItemsCS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAllItemsCS.Checked)
            {
                for (int i = 0; i < cblItemsCS.Items.Count; i++)
                {
                    cblItemsCS.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < cblItemsCS.Items.Count; i++)
                {
                    cblItemsCS.SetItemChecked(i, false);
                }
            }
        }

        private void btnSearchCS_Click(object sender, EventArgs e)
        {
            cblItemsCS.Items.Clear();
            cbxAllItemsCS.Checked = false;

            string accounts = "";
            int i = 0;

            for (i = 0; i < cblAccountCS.CheckedItems.Count; i++)
            {
                if (accounts == "")
                {
                    accounts = "'" + cblAccountCS.CheckedItems[i].ToString() + "'";
                }
                else
                {
                    accounts = accounts + ", '" + cblAccountCS.CheckedItems[i].ToString() + "'";
                }
            }


            DivaLink divl = new DivaLink();
            divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
            string conString = divl.GetConnectionString();
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            string temp = "Select Distinct ItemNumber From Items I Inner Join CurrentSold CS ON I.ItemIndexPK=CS.ItemIndexFK Inner Join Accounts A " +
            "ON CS.AccountIndexFK=A.AccountIndexPK Inner Join Company C ON C.CoIndexPK=I.CoIndexFK " +
            "Where AccountName IN (" + accounts + ") " +
            "and (ItemNumber Like '%" + txtItemSearchCS.Text + "%' or Description Like '%" + txtItemSearchCS.Text + "%')";

            if ((cmbCompanyCS.SelectedItem.ToString() != "All companies"))
            {
                temp += " and CoName='" + cmbCompanyCS.SelectedItem.ToString() + "'";
            }

            if ((cbxIncludeDiscontinuedCS.Checked == false) && (cbxOnlyDiscontinuedCS.Checked == false))
            {
                temp += " and Discontinued=0";
            }
            if (cbxOnlyDiscontinuedCS.Checked == true)
            {
                temp += " and Discontinued=1";
            }

            temp += "Order By ItemNumber";

            if (cbxSumOfTotalSalesCS.Checked == true)
            {
                temp = "Select Distinct ItemNumber From Items I Inner Join CurrentSold CS ON I.ItemIndexPK=CS.ItemIndexFK Inner Join Accounts A " +
                "ON CS.AccountIndexFK=A.AccountIndexPK Inner Join Company C ON C.CoIndexPK=I.CoIndexFK " +
                "Where AccountName IN (" + accounts + ") " + 
                "and (ItemNumber Like '%" + txtItemSearchCS.Text + "%' or Description Like '%" + txtItemSearchCS.Text + "%')";

                if ((cmbCompanyCS.SelectedItem.ToString() != "All companies"))
                {
                    temp += " and CoName='" + cmbCompanyCS.SelectedItem.ToString() + "'";
                }

                if ((cbxIncludeDiscontinuedCS.Checked == false) && (cbxOnlyDiscontinuedCS.Checked == false))
                {
                    temp += " and Discontinued=0";
                }
                if (cbxOnlyDiscontinuedCS.Checked == true)
                {
                    temp += " and Discontinued=1";
                }
                temp += "Group By CoName, ItemNumber, Description, AccountName " +
                "Order By ItemNumber";
            }

            SqlCommand commandItems = new SqlCommand(temp, conn);
            SqlDataReader rs1 = commandItems.ExecuteReader();
            while (rs1.Read())
            {
                this.Refresh();
                cblItemsCS.Items.Add(Convert.ToString(rs1["ItemNumber"]));
            }
            rs1.Close();
            conn.Close();
        }

        private void btnSalesCS_Click(object sender, EventArgs e)
        {
            if (cblItemsCS.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please choose at least one item");
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            dgvItemsCS.Columns.Clear();

            // initialize progress bar variables
            lblWaitMessageCS.Visible = true;
            progressBarCS.Visible = true;
            progressBarCS.Maximum = 1000;
            progressBarCS.Minimum = 1;
            progressBarCS.Step = 1;

            string accounts = "";
            string temp = "";
            int i = 0;
            // concatenate checked account names from the check box list into one string variable
            // the string variable is used in SQL query 
            for (i = 0; i < cblAccountCS.CheckedItems.Count; i++)
            {
                if (accounts == "")
                {
                    accounts = "'" + cblAccountCS.CheckedItems[i].ToString() + "'";
                }
                else
                {
                    accounts = accounts + ", '" + cblAccountCS.CheckedItems[i].ToString() + "'";
                }
            }

            // set the SQL connection
            DivaLink divl = new DivaLink();
            divl.CheckDataBaseLink("IMS-Server1", "DivaDB");
            string conString = divl.GetConnectionString();
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            temp = "Select CoName, ItemNumber, Description, AccountName, CurSold " +
            "From Items I Inner Join CurrentSold CS ON I.ItemIndexPK=CS.ItemIndexFK Inner Join Accounts A " +
            "ON CS.AccountIndexFK=A.AccountIndexPK Inner Join Company C ON C.CoIndexPK=I.CoIndexFK " +
            "Where AccountName IN (" + accounts + ") " +
            "and (ItemNumber Like '%" + txtItemSearchCS.Text + "%' or Description Like '%" + txtItemSearchCS.Text + "%')";

            if ((cmbCompanyCS.SelectedItem.ToString() != "All companies"))
            {
                temp += " and CoName='" + cmbCompanyCS.SelectedItem.ToString() + "'";
            }
            
            if ((cbxIncludeDiscontinuedCS.Checked == false) && (cbxOnlyDiscontinuedCS.Checked == false))
            {
                temp += " and Discontinued=0";
            }
            
            if (cbxOnlyDiscontinuedCS.Checked == true)
            {
                temp += " and Discontinued=1";
            }
            temp += " Order By ItemNumber";

            if (cbxSumOfTotalSalesCS.Checked == true)
            {
                temp = "Select CoName, ItemNumber, Description, Sum(CurSold) As CurSold " +
                "From Items I Inner Join CurrentSold CS ON I.ItemIndexPK=CS.ItemIndexFK Inner Join Company C ON C.CoIndexPK=I.CoIndexFK " +
                "Where (ItemNumber Like '%" + txtItemSearchCS.Text + "%' or Description Like '%" + txtItemSearchCS.Text + "%')";

                if ((cmbCompanyCS.SelectedItem.ToString() != "All companies"))
                {
                    temp += " and CoName='" + cmbCompanyCS.SelectedItem.ToString() + "'";
                }
                if ((cbxIncludeDiscontinuedCS.Checked == false) && (cbxOnlyDiscontinuedCS.Checked == false))
                {
                    temp += " and Discontinued=0";
                }
                if (cbxOnlyDiscontinuedCS.Checked == true)
                {
                    temp += " and Discontinued=1";
                }
                temp += "Group By CoName, ItemNumber, Description " +
                "Order By ItemNumber";
            }

            // add headers to the data grid view
            dgvItemsCS.Columns.Add("ItemNumber", "Item");
            dgvItemsCS.Columns.Add("CoName", "Company");
            if (cbxSumOfTotalSalesCS.Checked == false)
            {
                dgvItemsCS.Columns.Add("AccountName", "Account");
            }
            dgvItemsCS.Columns.Add("CurrentSold", "Current Sold");
            dgvItemsCS.Columns.Add("Description", "Description");


            SqlCommand commandItems = new SqlCommand(temp, conn);
            SqlDataReader rs1 = commandItems.ExecuteReader();
            i = 0;
            // the cycle iterates through iterates through chosen items in check box list and outputs
            // the resul of SQL Query in data grid view - total sold from sales history table
            while (rs1.Read())
            {
                this.Refresh();
                
                progressBarCS.PerformStep();
                if (progressBarCS.Value >= 1000)
                {
                    progressBarCS.Value = 1;
                }

                if (cblItemsCS.Items[i].ToString() != Convert.ToString(rs1["ItemNumber"]))
                {
                    i++;
                }

                if ((cblItemsCS.Items[i].ToString() == Convert.ToString(rs1["ItemNumber"]))
                    && (cblItemsCS.GetItemCheckState(i) == CheckState.Checked))
                {
                    this.Refresh();
                    if (cbxSumOfTotalSalesCS.Checked == false)
                    {
                        dgvItemsCS.Rows.Add(Convert.ToString(rs1["ItemNumber"]),
                        Convert.ToString(rs1["CoName"]),
                        Convert.ToString(rs1["AccountName"]),
                        Convert.ToString(rs1["CurSold"]),
                        Convert.ToString(rs1["Description"]));
                    }
                    else 
                    {
                        dgvItemsCS.Rows.Add(Convert.ToString(rs1["ItemNumber"]),
                        Convert.ToString(rs1["CoName"]),
                        Convert.ToString(rs1["CurSold"]),
                        Convert.ToString(rs1["Description"]));
                    }

                }

            }
            rs1.Close();
            conn.Close();
            dgvItemsCS.Columns[3].DefaultCellStyle.Format = "MM/dd/yyyy";
            lblWaitMessageCS.Visible = false;
            progressBarCS.Visible = false;
            this.Cursor = Cursors.Arrow;
            
            if ((dgvItemsCS.RowCount - 1) > 0)
            {
                label30.Text = "CURRENT SALES OF ITEMS (" + (dgvItemsCS.RowCount - 1) + ")";
            }
            else 
            {
                label30.Text = "CURRENT SALES OF ITEMS ";
            }
            
        }

        private void txtItemSearchCS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // call the function to search items 
                btnSearchCS_Click(sender, e);
            }
        }

        private void btnCSVExportCS_Click(object sender, EventArgs e)
        {
            // if there is not any rows in the data grid view then output message
            if ((dgvItemsCS.Rows.Count == 0) || (dgvItemsCS.Rows.Count == 1))
            {
                MessageBox.Show("There is not any data to export");
                return;
            }

            // standart functions to call save dialog  
            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.Title = "Save As an export file in CSV format";
            saveFD.InitialDirectory = @"c:\Desktop";
            DateTime now = DateTime.Now;
            
            saveFD.FileName = "Current Sales Export Report (" + now.Month + " " + now.Day + " " + now.Year + ")";
            saveFD.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            string filePath = "";
            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFD.FileName;

                StreamWriter tw = new StreamWriter(filePath);

                // write header to a CSV file
                tw.WriteLine("Item Number, Company Name, Account Name, Current Sold, Description");
                // write rows with data to CSV file from data grid view
                for (int i = 0; i < dgvItemsCS.Rows.Count - 1; i++)
                {
                    if (cbxSumOfTotalSalesCS.Checked == false)
                    {
                        tw.WriteLine(dgvItemsCS.Rows[i].Cells["ItemNumber"].Value.ToString() + ", " + dgvItemsCS.Rows[i].Cells["CoName"].Value.ToString() + ", " +
                        dgvItemsCS.Rows[i].Cells["AccountName"].Value.ToString() + ", " + dgvItemsCS.Rows[i].Cells["CurrentSold"].Value.ToString() + ", " + dgvItemsCS.Rows[i].Cells["Description"].Value.ToString());
                    }
                    else 
                    {
                        tw.WriteLine(dgvItemsCS.Rows[i].Cells["ItemNumber"].Value.ToString() + ", " + dgvItemsCS.Rows[i].Cells["CoName"].Value.ToString() + ", " +
                        dgvItemsCS.Rows[i].Cells["CurrentSold"].Value.ToString() + ", " + dgvItemsCS.Rows[i].Cells["Description"].Value.ToString());
                    }
                }
                tw.Close();
                MessageBox.Show("The data was exported to CSV succesfully.");
            }
        }


       

    }
}
