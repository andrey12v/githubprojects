using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;


public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Init(object sender, EventArgs e)
    {
        timeLabel.Text = String.Format("{0:D2}:{1:D2}:{2:D2}",
           DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //ddBackColor.SelectedValue = Request.Form["ctl00$ContentPlaceHolder1$ddBackColor"];



        if (ddBackColor.SelectedValue == "Red")
        {
            timeLabel.BackColor = Color.Red;
        }
        else if (ddBackColor.SelectedValue == "Green")
        {
            timeLabel.BackColor = Color.Green;
        }
        else if (ddBackColor.SelectedValue == "Yellow")
        {
            timeLabel.BackColor = Color.Yellow;
        }
        else if (ddBackColor.SelectedValue == "Black")
        {
            timeLabel.BackColor = Color.Black;
        }


        if (ddForeColor.SelectedValue == "White")
        {
            timeLabel.ForeColor = Color.White;
        }
        else if (ddForeColor.SelectedValue == "Black")
        {
            timeLabel.ForeColor = Color.Black;
        }
        else if (ddForeColor.SelectedValue == "Green")
        {
            timeLabel.ForeColor = Color.Green;
        }
        else if (ddForeColor.SelectedValue == "Blue")
        {
            timeLabel.ForeColor = Color.Blue;
        }

        if (ddFontSize.SelectedValue=="25 pixel")
        {
            timeLabel.Font.Size = 25;
        }
        else if (ddFontSize.SelectedValue == "30 pixel") 
        {
            timeLabel.Font.Size = 30;
        }
        else if (ddFontSize.SelectedValue == "35 pixel")
        {
            timeLabel.Font.Size = 35;
        }
        else if (ddFontSize.SelectedValue == "40 pixel")
        {
            timeLabel.Font.Size = 40;
        }





    }

}
