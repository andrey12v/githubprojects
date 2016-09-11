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
using System.Web.Security;
using System.Collections.Generic;
using db;

public partial class exportbiusers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string[] tmpArray = new string[10];
        string strTmp;
        
        List<BIRegistration> BIR = BIRegistration.GetAll();

        VisitorsPlaceholder.Text += "<table border=1>";
        VisitorsPlaceholder.Text += "<tr>";
        VisitorsPlaceholder.Text += "<td> <strong>First name</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td> <strong>Last name</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td> <strong>Job title</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td> <strong>Company</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td> <strong>Visitor's address</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td> <strong>City</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td> <strong>State/Province</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td> <strong>Country</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td> <strong>Postal code</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td> <strong>Email</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td> <strong>Web site</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td> <strong>Phone</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td> <strong>Fax</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td> <strong>Product Interest</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td> <strong>Visitor Status</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td> <strong>Purpose of Visit</strong>";
        VisitorsPlaceholder.Text += "</td>";
        VisitorsPlaceholder.Text += "<td> <strong>Crop Interest</strong>";
        VisitorsPlaceholder.Text += "</td>";

        VisitorsPlaceholder.Text += "</tr>";


        foreach (BIRegistration B in BIR)
        {
            if (Request.QueryString["translator"] == "0")
            {
                VisitorsPlaceholder.Text += "<tr>";
                VisitorsPlaceholder.Text += "<td>" + B.FirstName + "</a> ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td>" + B.LastName + "</a> ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td> " + B.JobTitle + " ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td> " + B.Company + " ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td>" + B.UserAddress + " ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td>" + B.City + " ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td>" + B.StateProvince + " ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td>" + B.Country + " ";
                VisitorsPlaceholder.Text += "</td>";
            }
            else if(Request.QueryString["translator"] == "1")
            {
                VisitorsPlaceholder.Text += "<tr>";
                VisitorsPlaceholder.Text += "<td>" + Translator.DirectTranslation(B.FirstName) + "</a> ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td>" + Translator.DirectTranslation(B.LastName) + "</a> ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td> " + Translator.DictionaryTranslation(B.JobTitle) + " ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td> " + Translator.DictionaryTranslation(B.Company) + " ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td>" + Translator.DictionaryTranslation(B.UserAddress) + " ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td>" + Translator.DictionaryTranslation(B.City) + " ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td>" + Translator.DictionaryTranslation(B.StateProvince) + " ";
                VisitorsPlaceholder.Text += "</td>";
                VisitorsPlaceholder.Text += "<td>" + Translator.DictionaryTranslation(B.Country) + " ";
                VisitorsPlaceholder.Text += "</td>";
            }

            
            VisitorsPlaceholder.Text += "<td>" + B.PostalCode + " ";
            VisitorsPlaceholder.Text += "</td>";
            VisitorsPlaceholder.Text += "<td>" + B.Email + " ";
            VisitorsPlaceholder.Text += "</td>";
            VisitorsPlaceholder.Text += "<td>" + B.Website + " ";
            VisitorsPlaceholder.Text += "</td>";
            VisitorsPlaceholder.Text += "<td>" + B.Phone + " ";
            VisitorsPlaceholder.Text += "</td>";
            VisitorsPlaceholder.Text += "<td>" + B.Fax + " ";
            VisitorsPlaceholder.Text += "</td>";
            
            //Display product interest
            VisitorsPlaceholder.Text += "<td> ";
            strTmp = B.ProductInterest;
            tmpArray = strTmp.Split(';');
            getProductInterest(tmpArray);
            if (B.OtherProductInterest != "") 
            {
                VisitorsPlaceholder.Text += B.OtherProductInterest;
            }
            VisitorsPlaceholder.Text += "</td>";
            
            //Display visitor's status
            VisitorsPlaceholder.Text += "<td> ";
            strTmp = B.VisitorStatus;
            tmpArray = strTmp.Split(';');
            getVisitorStatus(tmpArray);
            if (B.OtherVisitorStatus != "")
            {
                VisitorsPlaceholder.Text += B.OtherVisitorStatus;
            }
            VisitorsPlaceholder.Text += "</td>";

            //Display purpose of visit
            VisitorsPlaceholder.Text += "<td> ";
            strTmp = B.PurposeVisit;
            tmpArray = strTmp.Split(';');
            getPurposeOfVisit(tmpArray);
            if (B.OtherPurposeVisit != "")
            {
                VisitorsPlaceholder.Text += B.OtherPurposeVisit;
            }
            VisitorsPlaceholder.Text += "</td>";

            //Display crop interest
            VisitorsPlaceholder.Text += "<td> ";
            strTmp = B.CropInterest;
            tmpArray = strTmp.Split(';');
            getCropInterest(tmpArray);
            if (B.OtherCropInterest != "")
            {
                VisitorsPlaceholder.Text += B.OtherCropInterest;
            }
            VisitorsPlaceholder.Text += "</td>";

            VisitorsPlaceholder.Text += "</tr>";
        }

        VisitorsPlaceholder.Text += "</table>";

    }


    private void getProductInterest(string[] inpArray) 
    {
        for (int i = 0; i < inpArray.Length; i++)
        {
            switch (inpArray[i])
            {
                case "1":
                    VisitorsPlaceholder.Text += "Tractors; ";
                    goto ExitProduct;
                case "2":
                    VisitorsPlaceholder.Text += "Seeders/Planters; ";
                    goto ExitProduct;
                case "3":
                    VisitorsPlaceholder.Text += "Trucks/Trailers; ";
                    goto ExitProduct;
                case "4":
                    VisitorsPlaceholder.Text += "Seeds/Chemicals/ Fertilizers/Pesticides; ";
                    goto ExitProduct;
                case "5":
                    VisitorsPlaceholder.Text += "Combines/Harvesters; ";
                    goto ExitProduct;
                case "6":
                    VisitorsPlaceholder.Text += "Haying Equipment; ";
                    goto ExitProduct;
                case "7":
                    VisitorsPlaceholder.Text += "Sprayers/ Fertilizer Applicators; ";
                    goto ExitProduct;
                case "8":
                    VisitorsPlaceholder.Text += "Material Handling; ";
                    goto ExitProduct;
                case "9":
                    VisitorsPlaceholder.Text += "Grain Handling (augers, conveyors, bins, dryers); ";
                    goto ExitProduct;
                case "10":
                    VisitorsPlaceholder.Text += "Tillage Equipment; ";
                    goto ExitProduct;
            }
        ExitProduct: ;
        }
    }

    private void getVisitorStatus(string[] inpArray)
    {
        for (int i = 0; i < inpArray.Length; i++)
        {
            switch (inpArray[i])
            {
                case "1":
                    VisitorsPlaceholder.Text += "Distributor/Wholesaler; ";
                    goto ExitProduct;
                case "2":
                    VisitorsPlaceholder.Text += "Manufacturer Representative/ Sale Agent; ";
                    goto ExitProduct;
                case "3":
                    VisitorsPlaceholder.Text += "State Farm; ";
                    goto ExitProduct;
                case "4":
                    VisitorsPlaceholder.Text += "Equipment Dealer; ";
                    goto ExitProduct;
                case "5":
                    VisitorsPlaceholder.Text += "Manufacturer; ";
                    goto ExitProduct;
                case "6":
                    VisitorsPlaceholder.Text += "Import/Export Organization; ";
                    goto ExitProduct;
                case "7":
                    VisitorsPlaceholder.Text += "Corporate Farm; ";
                    goto ExitProduct;
            }
        ExitProduct: ;
        }
    }

    private void getPurposeOfVisit(string[] inpArray)
    {
        for (int i = 0; i < inpArray.Length; i++)
        {
            switch (inpArray[i])
            {
                case "1":
                    VisitorsPlaceholder.Text += "Purchase/Place Orders; ";
                    goto ExitProduct;
                case "2":
                    VisitorsPlaceholder.Text += "Gather Information; ";
                    goto ExitProduct;
                case "3":
                    VisitorsPlaceholder.Text += "Evaluate show for future participation; ";
                    goto ExitProduct;
                case "4":
                    VisitorsPlaceholder.Text += "Source new equipment suppliers/new products; ";
                    goto ExitProduct;
                case "5":
                    VisitorsPlaceholder.Text += "Visit exisiting suppliers and business associates; ";
                    goto ExitProduct;
              
            }
        ExitProduct: ;
        }
    }

    private void getCropInterest(string[] inpArray)
    {
        for (int i = 0; i < inpArray.Length; i++)
        {
            switch (inpArray[i])
            {
                case "1":
                    VisitorsPlaceholder.Text += "Barley; ";
                    goto ExitProduct;
                case "2":
                    VisitorsPlaceholder.Text += "Potatoes; ";
                    goto ExitProduct;
                case "3":
                    VisitorsPlaceholder.Text += "Sugar Beets; ";
                    goto ExitProduct;
                case "4":
                    VisitorsPlaceholder.Text += "Canola/Rapeseed; ";
                    goto ExitProduct;
                case "5":
                    VisitorsPlaceholder.Text += "Soybeans; ";
                    goto ExitProduct;
                case "6":
                    VisitorsPlaceholder.Text += "Winter Wheat; ";
                    goto ExitProduct;
                case "7":
                    VisitorsPlaceholder.Text += "Corn; ";
                    goto ExitProduct;
                case "8":
                    VisitorsPlaceholder.Text += "Spring Wheat; ";
                    goto ExitProduct;
                case "9":
                    VisitorsPlaceholder.Text += "Oats; ";
                    goto ExitProduct;
                case "10":
                    VisitorsPlaceholder.Text += "Sunflowers; ";
                    goto ExitProduct;
            }
        ExitProduct: ;
        }
    }


}
