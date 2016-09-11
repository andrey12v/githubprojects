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
using System.Data.SqlClient;
using System.Text;


public partial class admincompanies : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        populateExporters();
    
    }



    private void populateExporters()
    {
        List<Exporter> Es = Exporter.GetAll();
        Es.Sort(new Exporter.AscendingNameSorter());
        ddExporter.Items.Clear();
        ddExporter.Items.Add(new ListItem("Please, Choose Exporter", "0"));
        foreach (Exporter E in Es)
        {
            ddExporter.Items.Add(new ListItem(E.Name, E.ID.ToString()));
        }
        ddExporter.SelectedValue=Request.Form["ctl00$ContentPlaceHolder1$ddExporter"];
    }

    private void populateCompanyProducts()
    {
        cblProducts.Items.Clear();
        int tmp=0;
        int i=0;
        List<CompanyProducts> CP = CompanyProducts.GetAll();         
        foreach(CompanyProducts P in CP)
        {
            if (tmp != Convert.ToInt32(P.ParentID))
            {
                cblProducts.Items.Add(new ListItem("<u><b style=\"font-size: large\">" + P.ProductName + "</b></u>", "0"));
            }
            tmp = Convert.ToInt32(P.ParentID);
            cblProducts.Items.Add(new ListItem(P.CategoryProductName, P.ChildID.ToString()));
            
        }

        for (i = 0; i < cblProducts.Items.Count; i++) 
        {
            if (cblProducts.Items[i].Value == "0")
            {
                cblProducts.Items[i].Enabled = false;
            }
        }
    }

    private void populateCheckedCompanyProducts() 
    { 
        int selectedID = Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$ddExporter"]);
        List<CompanyProducts> CPC = CompanyProducts.GetProductCategories(selectedID);
        txtLocation.Text = "";
        if (CPC.Count > 0)
        {
            txtLocation.Text = CPC[0].Location;
            int j = 0;
            for (int i = 0; i < cblProducts.Items.Count; i++)
            {
                if (Convert.ToInt32(cblProducts.Items[i].Value) == CPC[j].ChildEquipID)
                {
                    cblProducts.Items[i].Selected = true;
                    if (j < CPC.Count - 1) { j++; }
                }
            }
        }
    }

    protected void ddExporter_SelectedIndexChanged(object sender, EventArgs e)
    {
        populateCompanyProducts();
        populateCheckedCompanyProducts();
        LinkToReportPlaceHolder.Text = "<a href=registeredvisitors.aspx?expid=" + Request.Form["ctl00$ContentPlaceHolder1$ddExporter"] + " target='_blank' style='font-size: 11pt'>Generate Report</a>";
        //LinkToReportPlaceHolder.Text = Request.Form["ctl00$ContentPlaceHolder1$ddExporter"];
    }
    

    protected void btnSaveData_Click(object sender, EventArgs e)
    {
        List<CompanyProducts> CPC = CompanyProducts.GetProductCategories(Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$ddExporter"]));
        int i;
        int j = 0;
        
       
        SqlConnection conn = ConnectionHelper.GetSQLConnection();
        SqlCommand command = new SqlCommand("UPDATE Exporters SET Location= @Location WHERE ExporterID = @ExpID", conn);

        command.Parameters.AddWithValue("@Location", txtLocation.Text);
        command.Parameters.AddWithValue("@ExpID", Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$ddExporter"]));
        command.Connection.Open();
        SqlDataReader rs = command.ExecuteReader();
        rs.Read();
        rs.Close();
        
        if (CPC.Count > 0)
        {
            for (i = 0; i < cblProducts.Items.Count; i++)
            {
                if ((Convert.ToInt32(cblProducts.Items[i].Value) == CPC[j].ChildEquipID) && (cblProducts.Items[i].Selected == false))
                {
                    CompanyProducts.Delete(CPC[j].ChildEquipID);
                    if (j < CPC.Count - 1) { j++; }
                }
                else if ((Convert.ToInt32(cblProducts.Items[i].Value) == CPC[j].ChildEquipID) && (cblProducts.Items[i].Selected == true))
                {
                    if (j < CPC.Count - 1) { j++; }
                }
            }

            j = 0;
            for (i = 0; i < cblProducts.Items.Count; i++)
            {
                if ((cblProducts.Items[i].Selected == true) && (Convert.ToInt32(cblProducts.Items[i].Value) != CPC[j].ChildEquipID))
                {

                    CompanyProducts.Insert(Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$ddExporter"]), Convert.ToInt32(cblProducts.Items[i].Value));
                    //ProductsPlaceHolder.Text += cblProducts.Items[i].Value + "<br />";
                }
                else if ((cblProducts.Items[i].Selected == true) && (Convert.ToInt32(cblProducts.Items[i].Value) == CPC[j].ChildEquipID))
                {

                    if (j < CPC.Count - 1) { j++; }
                }
            }
        }
        else
        {

            for (i = 0; i < cblProducts.Items.Count; i++)
            {
                if (cblProducts.Items[i].Selected == true)
                {
                    CompanyProducts.Insert(Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$ddExporter"]), Convert.ToInt32(cblProducts.Items[i].Value));
                }

            }
        }

    }

   
}
