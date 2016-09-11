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
using System.Data.SqlClient;
using System.Collections.Generic;
using db;


public partial class rusprintform : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int tmp = 0;

        if (Request.QueryString["id"] == "blank")
        {
            goto Finish;
        }
        else
        {
            tmp = Convert.ToInt32(Session["userID"]);
        }
        
        
        BIRegistration bir = new BIRegistration(tmp);
        //BIRegistration bir = new BIRegistration(1);
        lblFirstName.Text = bir.FirstName;
        lblLastName.Text = bir.LastName;
        lblJobTitle.Text = bir.JobTitle;
        lblCompany.Text = bir.Company;
        lblAddress.Text = bir.UserAddress;
        lblCity.Text = bir.City;
        lblState.Text = bir.StateProvince;
        lblCountry.Text = bir.Country;
        lblPostalCode.Text = bir.PostalCode;
        lblEmail.Text = bir.Email;
        lblWebSite.Text = bir.Website;
        lblPhone.Text = bir.Phone;
        lblFax.Text = bir.Fax;

        string[] arrProdInterest = new string[cblProductInterest.Items.Count];
        string strTemp = bir.ProductInterest;
        arrProdInterest = strTemp.Split(';');
        int j = 0;
        int i;

        for (i = 0; i < cblProductInterest.Items.Count; i++)
        {
            if (arrProdInterest[j] == cblProductInterest.Items[i].Value)
            {
                cblProductInterest.Items[i].Selected = true;
                j++;
            }
        }

        if (bir.OtherProductInterest.Length != 0)
        {
            cbOtherProductInterest.Checked = true;
            lblOtherProductInterest.Text = bir.OtherProductInterest;
        }

        strTemp = "";
        string[] arrVisitorStatus = new string[cblVisitorStatus.Items.Count];
        strTemp = bir.VisitorStatus;
        arrVisitorStatus = strTemp.Split(';');
        j = 0;

        for (i = 0; i < cblVisitorStatus.Items.Count; i++)
        {
            if (arrVisitorStatus[j] == cblVisitorStatus.Items[i].Value)
            {
                cblVisitorStatus.Items[i].Selected = true;
                j++;
            }
        }

        if (bir.OtherVisitorStatus.Length != 0)
        {
            cbOtherVisitorStatus.Checked = true;
            lblOtherVisitorStatus.Text = bir.OtherVisitorStatus;
        }


        strTemp = "";
        string[] arrPurposeVisit = new string[cblPurposeVisit.Items.Count];
        strTemp = bir.PurposeVisit;
        arrPurposeVisit = strTemp.Split(';');
        j = 0;

        for (i = 0; i < cblPurposeVisit.Items.Count; i++)
        {
            if (arrPurposeVisit[j] == cblPurposeVisit.Items[i].Value)
            {
                cblPurposeVisit.Items[i].Selected = true;
                j++;
            }
        }

        if (bir.OtherPurposeVisit.Length != 0)
        {
            cbOtherPurposeVisit.Checked = true;
            lblOtherPurposeVisit.Text = bir.OtherPurposeVisit;
        }

        strTemp = "";
        string[] arrCropInterest = new string[cblCropInterest.Items.Count];
        strTemp = bir.CropInterest;
        arrCropInterest = strTemp.Split(';');
        j = 0;

        for (i = 0; i < cblCropInterest.Items.Count; i++)
        {
            if (arrCropInterest[j] == cblCropInterest.Items[i].Value)
            {
                cblCropInterest.Items[i].Selected = true;
                j++;
            }
        }

        if (bir.OtherCropInterest.Length != 0)
        {
            cbOtherCropInterest.Checked = true;
            lblOtherCropInterest.Text = bir.OtherCropInterest;
        }

        if (bir.Interpreter == 1)
        {
            rblInterpreter.Items[0].Selected = true;
            lblLanguage.Text = bir.UserLanguage;
        }
        else
        {
            rblInterpreter.Items[1].Selected = true;
        }
    Finish: ;
    
    }
}
