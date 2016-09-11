using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using db;
using System.IO;
using System.Drawing.Imaging;


public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VisitorsPlaceholder.Text = "";   
        PopulateVisitors();
        
    }

    private void PopulateVisitors()
    {


        if ((Request.QueryString["id"] != null) && (Request.QueryString["status"] == "1"))
        {
            BIRegistration.Delete(Convert.ToInt32(Request.QueryString["id"]));
            Response.Redirect("~/adminbiregistration.aspx");
        }

        
        List<BIRegistration> BIR = BIRegistration.GetAll();
        
        VisitorsPlaceholder.Text += "<table border=1 width=95%>";
        VisitorsPlaceholder.Text += "<tr>";
        VisitorsPlaceholder.Text += "<td>Num</td>";
        VisitorsPlaceholder.Text += "<td width=22%> <strong>Visitor's name</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td width=22%> <strong>Job position</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td width=22%> <strong>Company</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td width=12%> <strong>Remove visitor</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td width=12%> <strong>Report</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "</tr>";
        int num = 1;
                
        if (Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$rblLanguage"]) == 0)
        {
            linkPlaceHolder.Text = "<a href=exportbiusers.aspx?translator=0 target='_blank'>Generate report to export Big Iron visitors from the database into another appliaction</a>";
            foreach (BIRegistration B in BIR)
            {
                VisitorsPlaceholder.Text += "<tr>";
                VisitorsPlaceholder.Text += "<td>" + num + "</td>";
                VisitorsPlaceholder.Text += "<td width=22%><a href=\"englprintform.aspx?id=" + B.ID + "\" \" target=\"_blank\">" + B.FirstName + " " + B.LastName + "</a> ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td width=22%> " + B.JobTitle + " ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td width=22%> " + B.Company + " ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td><input id=\"btnDelete\" type=\"button\" value=\"Delete\" onClick='if(confirm(\"Remove visitor?\")) window.location=\"adminbiregistration.aspx?id=" + B.ID + "&status=1\"; else alert(\"The visitor was not removed!\")' />";
                VisitorsPlaceholder.Text += "</td>";
                if (Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$rblReportView"]) == 0)
                {
                    VisitorsPlaceholder.Text += "<td><a href=\"visitorsreport.aspx?id=" + B.ID + "&view=0&translator=0 \" \" target=\"_blank\">Company=>Products</a>";
                    VisitorsPlaceholder.Text += "</td>";
                }
                else
                {
                    VisitorsPlaceholder.Text += "<td><a href=\"visitorsreport.aspx?id=" + B.ID + "&view=1&translator=0 \" \" target=\"_blank\">Product=>Companies</a>";
                    VisitorsPlaceholder.Text += "</td>";
                }
                VisitorsPlaceholder.Text += "</tr>";
                num = num + 1;
            }

            VisitorsPlaceholder.Text += "</table>";
        }
        else if (Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$rblLanguage"]) == 1) 
        {
            linkPlaceHolder.Text = "<a href=exportbiusers.aspx?translator=1 target='_blank'>Generate report to export Big Iron visitors from the database into another appliaction</a>";
            foreach (BIRegistration B in BIR)
            {
                VisitorsPlaceholder.Text += "<tr>";
                VisitorsPlaceholder.Text += "<td>" + num + "</td>";
                VisitorsPlaceholder.Text += "<td width=22%><a href=\"englprintform.aspx?id=" + B.ID + "&translator=1 \" \" target=\"_blank\">" + Translator.DirectTranslation(B.FirstName) + " " + Translator.DirectTranslation(B.LastName) + "</a> ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td width=22%> " + Translator.DictionaryTranslation(B.JobTitle) + " ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td width=22%> " + Translator.DictionaryTranslation(B.Company) + " ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td><input id=\"btnDelete\" type=\"button\" value=\"Delete\" onClick='if(confirm(\"Remove visitor?\")) window.location=\"adminbiregistration.aspx?id=" + B.ID + "&status=1\"; else alert(\"The visitor was not removed!\")' />";
                VisitorsPlaceholder.Text += "</td>";
                if (Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$rblReportView"]) == 0)
                {
                    VisitorsPlaceholder.Text += "<td><a href=\"visitorsreport.aspx?id=" + B.ID + "&view=0&translator=1 \" \" target=\"_blank\">Company=>Products</a>";
                    VisitorsPlaceholder.Text += "</td>";
                }
                else
                {
                    VisitorsPlaceholder.Text += "<td><a href=\"visitorsreport.aspx?id=" + B.ID + "&view=1&translator=1 \" \" target=\"_blank\">Product=>Companies</a>";
                    VisitorsPlaceholder.Text += "</td>";
                }
                VisitorsPlaceholder.Text += "</tr>";
                num = num + 1;
            }
            VisitorsPlaceholder.Text += "</table>";
        }
    }
}
   
    

