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
using System.Data.SqlClient;
using db;



public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnLiteral.Text = "<input id=\"btnPrint\" type=\"button\" value=\"&#1056;&#1072;&#1089;&#1087;&#1077;&#1095;&#1072;" +
                "&#1090;&#1072;&#1090;&#1100; &#1092;&#1086;&#1088;&#1084;&#1091;\" disabled=\"disabled\" onclick=\"window.open('rusprintform.aspx', '_blank');\">";

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if ((rblInterpreter.Items[0].Selected == true) && (txtLanguage.Text == ""))
        {
            //lblMessage.Text = "Âû íå çàïîëíèëè ïîëå “ïåðåâîä ñ àíãëèéñêîãî íà êàêîé ÿçûê âàñ èíòåðåñóåò?”";
            lblMessage.Text = "&#1042;&#1099; &#1085;&#1077; &#1079;&#1072;&#1087;&#1086;&#1083;&#1085;&#1080;&#1083;&#1080; &#1087;&#1086;&#1083;&#1077; " +
                "“&#1087;&#1077;&#1088;&#1077;&#1074;&#1086;&#1076; &#1089; &#1072;&#1085;&#1075;&#1083;&#1080;&#1081;&#1089;&#1082;&#1086;&#1075;&#1086; " +
                "&#1085;&#1072; &#1082;&#1072;&#1082;&#1086;&#1081; &#1103;&#1079;&#1099;&#1082; &#1074;&#1072;&#1089; &#1080;&#1085;&#1090;&#1077;&#1088;" +
                "&#1077;&#1089;&#1091;&#1077;&#1090;?”";
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

            SqlConnection conn = ConnectionHelper.GetSQLConnection();
            SqlCommand command = new SqlCommand("INSERT INTO BIUsers (FirstName, LastName, JobTitle, Company, UserAddress," +
                "City, StateProvince, Country, PostalCode, Email, Website, Phone, Fax, ProductInterest," +
                "OtherProductInterest, VisitorStatus, OtherVisitorStatus, PurposeVisit, OtherPurposeVisit, CropInterest, OtherCropInterest, Interpreter, UserLanguage)" +
                "VALUES (@FirstName, @LastName, @JobTitle, @Company, @UserAddress, @City, @StateProvince, @Country, @PostalCode , @Email, @Website , @Phone, @Fax, @ProductInterest," +
                "@OtherProductInterest ,@VisitorStatus ,@OtherVisitorStatus ,@PurposeVisit ,@OtherPurposeVisit ,@CropInterest ,@OtherCropInterest ,@Interpreter ,@UserLanguage )", conn);

            command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            command.Parameters.AddWithValue("@LastName", txtLastName.Text);
            command.Parameters.AddWithValue("@JobTitle", txtJobTitle.Text);
            command.Parameters.AddWithValue("@Company", txtCompany.Text);
            command.Parameters.AddWithValue("@UserAddress", txtAddress.Text);
            command.Parameters.AddWithValue("@City", txtCity.Text);
            command.Parameters.AddWithValue("@StateProvince", txtState.Text);
            command.Parameters.AddWithValue("@Country", txtCountry.Text);
            command.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
            command.Parameters.AddWithValue("@Email", txtEmail.Text);
            command.Parameters.AddWithValue("@Website", txtWebSite.Text);
            command.Parameters.AddWithValue("@Phone", txtPhone.Text);
            command.Parameters.AddWithValue("@Fax", txtFax.Text);
            command.Parameters.AddWithValue("@ProductInterest", strProdInterest);
            command.Parameters.AddWithValue("@OtherProductInterest", txtProdInterest.Text);
            command.Parameters.AddWithValue("@VisitorStatus", strVisitorStatus);
            command.Parameters.AddWithValue("@OtherVisitorStatus", txtVisitorStatus.Text);
            command.Parameters.AddWithValue("@PurposeVisit", strPurposeVisit);
            command.Parameters.AddWithValue("@OtherPurposeVisit", txtPurposeVisit.Text);
            command.Parameters.AddWithValue("@CropInterest", strCropInterest);
            command.Parameters.AddWithValue("@OtherCropInterest", txtCropInterest.Text);
            command.Parameters.AddWithValue("@Interpreter", Convert.ToInt32(rblInterpreter.Text));
            command.Parameters.AddWithValue("@UserLanguage", txtLanguage.Text);

            command.Connection.Open();
            SqlDataReader rs = command.ExecuteReader();
            rs.Read();
            rs.Close();

            command = new SqlCommand("select * from BIUsers where FirstName = @FirstName", conn);
            command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            rs = command.ExecuteReader();
            rs.Read();
            Session["userID"] = rs["UserID"];
            rs.Close();
            conn.Close();
            lblMessage.Text = "&#1042;&#1072;&#1096;&#1080; &#1076;&#1072;" +
              "&#1085;&#1085;&#1099;&#1077; &#1091;&#1089;&#1087;&#1077;&#1096;&#1085;&#1086; " +
              "&#1089;&#1086;&#1093;&#1088;&#1072;&#1085;&#1077;&#1085;&#1099; !";
            btnSubmit.Enabled = false;
            btnLiteral.Text = "<input id=\"btnPrint\" type=\"button\" value=\"&#1056;&#1072;&#1089;&#1087;&#1077;&#1095;&#1072;" +
                "&#1090;&#1072;&#1090;&#1100; &#1092;&#1086;&#1088;&#1084;&#1091;\" onclick=\"window.open('rusprintform.aspx', '_blank');\">";

        }
    }
}
