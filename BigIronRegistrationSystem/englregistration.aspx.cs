using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using db;


public partial class Default2 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        btnLiteral.Text = "<input id=\"btnPrint\" type=\"button\" value=\"Print the form\" disabled=\"disabled\" onclick=\"window.open('englprintform.aspx', '_blank');\">";
    }
      
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if ((rblInterpreter.Items[0].Selected == true) && (txtLanguage.Text == ""))
        {
            lblMessage.Text = "Please, fill out the field \"what language do you need for translation?\"";
        }
        else
        {

            string strProdInterest = "";
            string strVisitorStatus = "";
            string strPurposeVisit = "";
            string strCropInterest = "";

            for (int i = 0; i < cblProductInterest.Items.Count; i++)
            {
                if (cblProductInterest.Items[i].Selected)
                {
                    strProdInterest += cblProductInterest.Items[i].Value + ";";
                }
            }

            for (int i = 0; i < cblVisitorStatus.Items.Count; i++)
            {
                if (cblVisitorStatus.Items[i].Selected)
                {
                    strVisitorStatus += cblVisitorStatus.Items[i].Value + ";";
                }
            }

            for (int i = 0; i < cblPurposeVisit.Items.Count; i++)
            {
                if (cblPurposeVisit.Items[i].Selected)
                {
                    strPurposeVisit += cblPurposeVisit.Items[i].Value + ";";
                }
            }

            for (int i = 0; i < cblCropInterest.Items.Count; i++)
            {
                if (cblCropInterest.Items[i].Selected)
                {
                    strCropInterest += cblCropInterest.Items[i].Value + ";";
                }
            }

            BIRegistration bir = new BIRegistration();
            bir.FirstName = txtFirstName.Text;
            bir.LastName = txtLastName.Text;
            bir.JobTitle = txtJobTitle.Text;
            bir.Company = txtCompany.Text;
            bir.UserAddress = txtAddress.Text;
            bir.City = txtCity.Text;
            bir.StateProvince = txtState.Text;
            bir.Country = txtCountry.Text;
            bir.PostalCode = txtPostalCode.Text;
            bir.Email = txtEmail.Text;
            bir.Website = txtWebSite.Text;
            bir.Phone = txtPhone.Text;
            bir.Fax = txtFax.Text;
            bir.ProductInterest = strProdInterest;
            bir.OtherProductInterest = txtProdInterest.Text;
            bir.VisitorStatus = strVisitorStatus;
            bir.OtherVisitorStatus = txtVisitorStatus.Text;
            bir.PurposeVisit = strPurposeVisit;
            bir.OtherPurposeVisit = txtPurposeVisit.Text;
            bir.CropInterest = strCropInterest;
            bir.OtherCropInterest = txtCropInterest.Text;
            bir.Interpreter = Convert.ToInt32(rblInterpreter.Text);
            bir.UserLanguage = txtLanguage.Text;

            int temp = bir.Insert();

            if (temp == 0)
            {
                lblMessage.Text = "Insert Failed, please try again";
            }
            else
            {
                lblMessage.Text = "Insert Successful";
                btnSubmit.Enabled = false;
                Session["userID"] = temp;
                btnLiteral.Text = "<input id=\"btnPrint\" type=\"button\" value=\"Print the form\" onclick=\"window.open('englprintform.aspx', '_blank');\">";
            }

        }    
        
    }


    
}
