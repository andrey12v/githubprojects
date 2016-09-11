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

public partial class registeredvisitors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Request.QueryString["expid"] != "0")
        {
            List<CompanyProducts> CP = CompanyProducts.GetProductsByCompanyID(Convert.ToInt32(Request.QueryString["expid"]));
            List<BIRegistration> BIU = BIRegistration.GetAll();

            string[] arrProdInterest = new string[10];
            string strTemp = "";
            int i, j, k, l;
            int counter = 0;
            bool check = false;
            bool newLine = false;
            string[] arrPhraseWords = new string[2];
            
            
            if (CP.Count > 0)
            {
                VisitorsPlaceHolder.Text += "<center><b style='font-size: 16pt'><u>" + CP[0].CompanyName + "</u></b></center><br />";
                VisitorsPlaceHolder.Text += "<br />";

                for (i = 0; i < BIU.Count; i++)
                {
                    strTemp = BIU[i].ProductInterest;
                    arrProdInterest = strTemp.Split(';');
                    for (l = 0; l < arrProdInterest.Length; l++)
                    {
                        if (arrProdInterest[l] != null)
                        {
                            counter++;
                        }
                    }

                    for (j = 0; j < counter; j++)
                    {
                        for (k = 0; k < CP.Count; k++)
                        {
                            if (arrProdInterest[j] == Convert.ToString(CP[k].ParentID))
                            {
                                if (check == false)
                                {
                                    VisitorsPlaceHolder.Text += "<strong><u>" + Translator.DirectTranslation(BIU[i].FirstName) + " " + Translator.DirectTranslation(BIU[i].LastName) + "</u></strong><br />";
                                    VisitorsPlaceHolder.Text += "Job Title " + Translator.DictionaryTranslation(BIU[i].JobTitle) + " Company " + Translator.DictionaryTranslation(BIU[i].Company) + "<br />";
                                    VisitorsPlaceHolder.Text += "Country " + Translator.DictionaryTranslation(BIU[i].Country) + " City " + Translator.DictionaryTranslation(BIU[i].City) + "<br />";
                                    VisitorsPlaceHolder.Text += "Email " + BIU[i].Email + " Web Site " + BIU[i].Website + "<br />";
                                    VisitorsPlaceHolder.Text += "Phone: " + BIU[i].Phone + " Fax: " + BIU[i].Fax + "<br /><br />";
                                    VisitorsPlaceHolder.Text += "<strong>Interested Products:</strong><br/>";
                                    check = true;
                                    newLine = true;
                                }

                                strTemp = CP[k].ProductName;
                                arrPhraseWords = strTemp.Split('(');
                                VisitorsPlaceHolder.Text += " * " + arrPhraseWords[0] + "<br />";
                            }
                        }
                    }
                    check = false;
                    counter = 0;
                    if (newLine == true)
                    {
                        VisitorsPlaceHolder.Text += "<br />";
                        newLine = false;
                    }
                }

            }
            else
            {
                VisitorsPlaceHolder.Text += "<b>Equipment was not chosen for the company</b>";
            }

        }
        else 
        {
            VisitorsPlaceHolder.Text += "<b>The company was not chosen</b>";
        }
    
    }
}
