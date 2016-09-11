using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BankLibrary;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Ex18_6
{
    public partial class ReadWriteFile : BankUIForm
    {
        //private StreamWriter fileWriter; // writes data to text file

        private BinaryFormatter formatter = new BinaryFormatter();
        private BinaryFormatter reader = new BinaryFormatter();
        private FileStream input; // maintains connection to a file
        private FileStream output; // maintains connection to file
                        
        //private FileStream output; // maintains connection to file
        //private StreamReader fileReader; // reads data from a text file
        
        public ReadWriteFile()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //btnLoad.Enabled = false;
            btnNext.Enabled = false;
            btnEnter.Enabled = true;
            
            
            // create dialog box enabling user to save file
            SaveFileDialog fileChooser = new SaveFileDialog();
            DialogResult result = fileChooser.ShowDialog();
            string fileName; // name of file to save data

            fileChooser.CheckFileExists = false; // allow user to create file

            // exit event handler if user clicked "Cancel"
            if (result == DialogResult.Cancel)
                return;

            fileName = fileChooser.FileName; // get specified file name

            // show error if user specified invalid file
            if (fileName == "" || fileName == null)
                MessageBox.Show("Invalid File Name", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // save file via FileStream if user specified valid file
                try
                {
                    // open file with write access
                    output = new FileStream(fileName,
                       FileMode.OpenOrCreate, FileAccess.Write);

                    // sets file to where data is written
                    // fileWriter = new StreamWriter( output );

                    // disable Save button and enable Enter button
                    btnSave.Enabled = false;
                    btnEnter.Enabled = true;
                } // end try
                // handle exception if there is a problem opening the file
                catch (IOException)
                {
                    // notify user if file does not exist
                    MessageBox.Show("Error opening file", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                } // end catch
            } // end else

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            
            // store TextBox values string array
            string[] values = GetTextBoxValues();

            // Record containing TextBox values to serialize
            RecordSerrializable record = new RecordSerrializable();

            // determine whether TextBox account field is empty
            if (values[(int)TextBoxIndices.ACCOUNT] != "")
            {
                // store TextBox values in Record and serialize Record
                try
                {
                    // get account number value from TextBox
                    int accountNumber = Int32.Parse(
                       values[(int)TextBoxIndices.ACCOUNT]);

                    // determine whether accountNumber is valid
                    if (accountNumber > 0)
                    {
                        // store TextBox fields in Record
                        record.Account = accountNumber;
                        record.FirstName = values[(int)TextBoxIndices.FIRST];
                        record.LastName = values[(int)TextBoxIndices.LAST];
                        record.Balance = Decimal.Parse(
                           values[(int)TextBoxIndices.BALANCE]);

                        if (checkBoxProtection.Checked) 
                        { 
                            record.Protection=true;
                        }
                        else
                        {
                            record.Protection = false;
                        }

                        // write Record to file, fields separated by commas
                        formatter.Serialize(output, record);

                    } // end if
                    else
                    {
                        // notify user if invalid account number
                        MessageBox.Show("Invalid Account Number", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } // end else
                } // end try
                // notify user if error occurs in serialization
                catch (SerializationException)
                {
                    MessageBox.Show("Error Writing to File", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                } // end catch
                // notify user if error occurs regarding parameter format
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Format", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                } // end catch
            } // end if

            ClearTextBoxes(); 
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            checkBoxProtection.Checked = false;
            btnSave.Enabled = true;
            btnEnter.Enabled = false;
            btnNext.Enabled = true;

            if (output != null)
            {
                output.Close(); // close file
            } 

            // create dialog box enabling user to open file
            OpenFileDialog fileChooser = new OpenFileDialog();
            DialogResult result = fileChooser.ShowDialog();
            string fileName; // name of file containing data

            // exit event handler if user clicked Cancel
            if (result == DialogResult.Cancel)
                return;

            fileName = fileChooser.FileName; // get specified file name
            ClearTextBoxes();

            // show error if user specified invalid file
            if (fileName == "" || fileName == null)
                MessageBox.Show("Invalid File Name", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // create FileStream to obtain read access to file
                input = new FileStream(fileName, FileMode.Open,
                   FileAccess.Read);

                // set file from where data is read
                //fileReader = new StreamReader( input );

                btnNext.Enabled = true; // enable Next Record button
            } // end else

        }

       
        private void buttonExit_Click(object sender, EventArgs e)
        {
            // determine whether file exists
            if (output != null)
            {
                try
                {
                    //fileWriter.Close(); // close StreamWriter
                    output.Close(); // close file
                } // end try
                // notify user of error closing file
                catch (IOException)
                {
                    MessageBox.Show("Cannot close file", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                } // end catch
            } // end if

            Application.Exit();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                RecordSerrializable record = (RecordSerrializable)reader.Deserialize(input);

                string[] values = new string[] {
                record.Account.ToString(),
                record.FirstName.ToString(),
                record.LastName.ToString(),
                record.Balance.ToString()
                 };

                if (record.Protection == true)
                {
                    checkBoxProtection.Checked = true;
                }
                else 
                {
                    checkBoxProtection.Checked = false;
                }

                SetTextBoxValues(values);



            } // end try
            catch (SerializationException)
            {
                input.Close(); // close FileStream if no Records in file
                btnLoad.Enabled = true; // enable Open File button
                //btnNext.Enabled = false; // disable Next Record button
                ClearTextBoxes();

                MessageBox.Show("Error Reading from File", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            } // end catch


        }

      
        private void ReadWriteFile_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxProtection_CheckedChanged(object sender, EventArgs e)
        {

        }        
    }
}