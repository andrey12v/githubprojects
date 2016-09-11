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
using db;
using System.Collections.Generic;

public partial class visitorsreport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int i;
        BIRegistration bir = new BIRegistration(Convert.ToInt32(Request.QueryString["id"]));

        string[] arrProdInterest = new string[11];
        string strTemp = bir.ProductInterest;
        arrProdInterest = strTemp.Split(';');
        int counter = 0;
        for (i = 0; i < arrProdInterest.Length; i++)
        {
            if (arrProdInterest[i] != null) { counter++; }
        }

        int tmpExpID = 0;
        int tmpParentID = 0;
        
        if ((Request.QueryString["id"] != null) && (Request.QueryString["view"] == "0"))
        {
            List<CompanyProducts> CP = CompanyProducts.GetAllDataForReport(0);
            if (Request.QueryString["translator"] == "0")
            {
                ProductsPlaceHolder.Text += "<center><b style='font-size: 16pt'>Visitor's name:  <u>" + bir.FirstName + " " + bir.LastName + "</u></b></center><br />";
            }
            else if (Request.QueryString["translator"] == "1")
            {
                ProductsPlaceHolder.Text += "<center><b style='font-size: 16pt'>Visitor's name:  <u>" + Translator.DirectTranslation(bir.FirstName) + " " + Translator.DirectTranslation(bir.LastName) + "</u></b></center><br />";
            }

            for (i = 0; i < CP.Count; i++)
            {
                if (CP[i].ExpID!=tmpExpID)
                {
                    if (SearchCompany(arrProdInterest, counter, CP, CP[i].ExpID)==true) 
                    {
                        ProductsPlaceHolder.Text += "<br /><br />";
                        ProductsPlaceHolder.Text += "<u><b>" + CP[i].CompanyName + "</b></u><br />";
                        ProductsPlaceHolder.Text += "<b>Products description:</b> " + CP[i].ProductDescription + "<br />";
                        ProductsPlaceHolder.Text += "<b>Contact:</b> " + CP[i].ContactPersonName + "<br/><b>Phone:</b> " + CP[i].Phone + ", ";
                        if(CP[i].Fax!="")
                        {
                            ProductsPlaceHolder.Text += " <b>Fax:</b> " + CP[i].Fax + ",";
                        }
                        if(CP[i].CellPhone!="")
                        {
                            ProductsPlaceHolder.Text += " <b>Cell:</b> " + CP[i].CellPhone;
                        }
                        ProductsPlaceHolder.Text += "<br /><b>Email:</b> " + CP[i].Email; 
                        ProductsPlaceHolder.Text += "<br /><b>Location on Big Iron:</b> " + CP[i].Location + "<br /><br /> <b>Products produced by the company:</b> <br />";
                        
                    }
                    tmpExpID = CP[i].ExpID;
                    tmpParentID = 0;
                }
                if (SearchVisitorProduct(arrProdInterest, counter, Convert.ToString(CP[i].ParentID)) == true) 
                {   
                    if(tmpParentID!=CP[i].ParentID)
                    {
                        ProductsPlaceHolder.Text += CP[i].ProductName + "<br />";
                        tmpParentID = CP[i].ParentID;
                    }
                    ProductsPlaceHolder.Text += "&nbsp;&nbsp; * <i>" + CP[i].CategoryProductName + "</i><br />"; 
                }
            
            
            }
                
        }
        else if ((Request.QueryString["id"] != null) && (Request.QueryString["view"] == "1")) 
        {
            List<CompanyProducts> CP = CompanyProducts.GetAllDataForReport(1);
            int numOutputs = 1;
            
            if (Request.QueryString["translator"] == "0")
            {
                ProductsPlaceHolder.Text += "<center><b style='font-size: 16pt'>Visitor's name:  <u>" + bir.FirstName + " " + bir.LastName + "</u></b></center><br />";
            }
            else if (Request.QueryString["translator"] == "1")
            {
                ProductsPlaceHolder.Text += "<center><b style='font-size: 16pt'>Visitor's name:  <u>" + Translator.DirectTranslation(bir.FirstName) + " " + Translator.DirectTranslation(bir.LastName) + "</u></b></center><br />";
            }
           
            for (i = 0; i < CP.Count; i++)
            {
                if (SearchVisitorProduct(arrProdInterest, counter, Convert.ToString(CP[i].ParentID)) == true)
                {
                    if(tmpExpID!=CP[i].ExpID)
                    {
                        tmpParentID = 0;
                        tmpExpID = CP[i].ExpID;
                        numOutputs = 1;
                    }
                    
                    if (tmpParentID != CP[i].ParentID)
                    {
                        ProductsPlaceHolder.Text += "<u><b>" + CP[i].ProductName + "</b></u><br />";
                        tmpParentID = CP[i].ParentID;
                        numOutputs = 1;
                    }
                    ProductsPlaceHolder.Text += "&nbsp;&nbsp; * <i>" + CP[i].CategoryProductName + "</i>" + GetNumberOfSubcotegories(CP, CP[i].ParentID, CP[i].ExpID) + " " + CP[i].ParentID + " " + CP[i].ExpID + "<br />";
                    if (GetNumberOfSubcotegories(CP, CP[i].ParentID, CP[i].ExpID) == numOutputs) 
                    {
                        ProductsPlaceHolder.Text += "<br />";
                        ProductsPlaceHolder.Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>" + CP[i].CompanyName + "</b><br />";
                        ProductsPlaceHolder.Text += "<table><tr><td>&nbsp;&nbsp;&nbsp;</td><td><b>Products description:</b> " + CP[i].ProductDescription + "<br /></td></tr></table>";
                        ProductsPlaceHolder.Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Contact:</b> " + CP[i].ContactPersonName + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Phone:</b> " + CP[i].Phone + ", ";
                        if (CP[i].Fax != "")
                        {
                            ProductsPlaceHolder.Text += " <b>Fax:</b> " + CP[i].Fax + ",";
                        }
                        if (CP[i].CellPhone != "")
                        {
                            ProductsPlaceHolder.Text += " <b>Cell:</b> " + CP[i].CellPhone;
                        }
                        ProductsPlaceHolder.Text += "<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Email:</b> " + CP[i].Email;
                        ProductsPlaceHolder.Text += "<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Location on Big Iron:</b> " + CP[i].Location + "<br /><br /> ";
                        
                        numOutputs = 0;
                        tmpParentID = 0;
                    }
                    numOutputs++;
                
                }
            }
        }
    }


    private int GetNumberOfSubcotegories(List<CompanyProducts> inpCP, int inpParentID, int inpExpID) 
    {
        int counter = 0;
        for (int i = 0; i < inpCP.Count; i++)
        {
            if ((inpCP[i].ExpID==inpExpID) && (inpCP[i].ParentID==inpParentID))
            {
                counter++;
            }
        }
        return counter;
    }

    private bool SearchVisitorProduct(string[] inpArrProdInterest, int inpCounter, string inpParentID) 
    {
        for (int i = 0; i < inpCounter; i++)
        {
            if(inpArrProdInterest[i]==inpParentID)
            {
                //ProductsPlaceHolder.Text += inpParentID + "<br />";
                return true;
            }
        }

        return false;
    }

    private bool SearchCompany(string[] inpArrProdInterest, int inpCounter, List<CompanyProducts> inpCP, int inpExpID) 
    {
        for (int i = 0; i < inpCP.Count; i++) 
        { 
            if (inpCP[i].ExpID==inpExpID) 
            {
                for (int j = 0; j < inpCounter; j++) 
                {
                    if(Convert.ToString(inpCP[i].ParentID)==inpArrProdInterest[j])
                    {
                        return true;
                    }
                
                }
            }
        }
        return false;
    }


}
