using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void RegisterButton_Click(object sender, EventArgs e)
    {
        registrationDataSetTableAdapters.UsersTableAdapter usersTableAdapter =
            new registrationDataSetTableAdapters.UsersTableAdapter();
        registrationDataSet.UsersDataTable dataTable = 
            new registrationDataSet.UsersDataTable();
        usersTableAdapter.FillbyINSERT(dataTable, FirstNameTextBox.Text, LastNameTextBox.Text, EmailTextBox.Text, PhoneTextBox.Text, BooksDropDownList.Text, OperatingSystemRadioButtonList.Text);
        Response.Redirect("~/resultform.aspx");
    }
}
