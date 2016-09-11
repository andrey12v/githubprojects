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

    protected void clearButton_Click(object sender, EventArgs e)
    {
        nameTextBox.Text = "";
        emailTextBox.Text = "";
        messageTextBox.Text = "";
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        // create a date parameter to store the current date
        System.Web.UI.WebControls.Parameter date =
           new System.Web.UI.WebControls.Parameter(
           "Date", TypeCode.String, DateTime.Now.ToShortDateString());

        // set the @Date parameter to the date parameter
        messagesSQLDataSource.InsertParameters.RemoveAt(0);
        messagesSQLDataSource.InsertParameters.Add(date);

        // execute an INSERT SQL statement to add a new row to the 
        // Messages table in the Guestbook database that contains the
        // current date and the user's name, e-mail address and message
        messagesSQLDataSource.Insert();

        // clear the TextBoxes
        nameTextBox.Text = "";
        emailTextBox.Text = "";
        messageTextBox.Text = "";

        // update the GridView with the new database table contents
        messagesGridView.DataBind();
    }
}
