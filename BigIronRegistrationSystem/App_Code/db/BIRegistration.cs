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

/// <summary>
/// Summary description for BIRegistration
/// </summary>
public class BIRegistration
{
    private int id;
    private string firstName;
    private string lastName;
    private string jobTitle;
    private string company;
    private string userAddress;
    private string city;
    private string stateProvince;
    private string country;
    private string postalCode;
    private string email;
    private string website;
    private string phone;
    private string fax;
    private string productInterest;
    private string otherProductInterest;
    private string visitorStatus;
    private string otherVisitorStatus;
    private string purposeVisit;
    private string otherPurposeVisit;
    private string cropInterest;
    private string otherCropInterest;
    private int interpreter;
    private string userLanguage;

	public BIRegistration()
	{
    }

    public BIRegistration(int id) 
    {
        SqlConnection conn = ConnectionHelper.GetSQLConnection();
        SqlCommand command = new SqlCommand("select * from BIUsers where UserID = @id", conn);
        command.Parameters.AddWithValue("@id", id);

        conn.Open();

        SqlDataReader rs = command.ExecuteReader();

        if (rs.Read())
        {
            this.id = Convert.ToInt32(rs["UserID"]);
            this.firstName = Convert.ToString(rs["FirstName"]);
            this.lastName = Convert.ToString(rs["LastName"]);
            this.jobTitle = Convert.ToString(rs["JobTitle"]);
            this.company = Convert.ToString(rs["Company"]);
            this.userAddress = Convert.ToString(rs["UserAddress"]);
            this.city = Convert.ToString(rs["City"]);
            this.stateProvince = Convert.ToString(rs["StateProvince"]);
            this.country = Convert.ToString(rs["Country"]);
            this.postalCode = Convert.ToString(rs["PostalCode"]);
            this.email = Convert.ToString(rs["Email"]);
            this.website = Convert.ToString(rs["Website"]);
            this.phone = Convert.ToString(rs["Phone"]);
            this.fax = Convert.ToString(rs["Fax"]);
            this.productInterest = Convert.ToString(rs["ProductInterest"]);
            this.otherProductInterest = Convert.ToString(rs["OtherProductInterest"]);
            this.visitorStatus = Convert.ToString(rs["VisitorStatus"]);
            this.otherVisitorStatus = Convert.ToString(rs["OtherVisitorStatus"]);
            this.purposeVisit = Convert.ToString(rs["PurposeVisit"]);
            this.otherPurposeVisit = Convert.ToString(rs["OtherPurposeVisit"]);
            this.cropInterest = Convert.ToString(rs["CropInterest"]);
            this.otherCropInterest = Convert.ToString(rs["OtherCropInterest"]);
            this.interpreter = Convert.ToInt32(rs["Interpreter"]);
            this.userLanguage = Convert.ToString(rs["UserLanguage"]);

        }
        rs.Close();
        conn.Close();
    }


    #region collection methods
    
    public static List<BIRegistration> GetAll()
    {
        SqlConnection conn = ConnectionHelper.GetSQLConnection();
        SqlCommand command = new SqlCommand("select * from BIUsers Order By FirstName", conn);
               
        List<BIRegistration> retVal = new List<BIRegistration>();

        command.Connection.Open();

        SqlDataReader rs = command.ExecuteReader();

        while (rs.Read())
        {
            BIRegistration SN = new BIRegistration();

            SN.id = Convert.ToInt32(rs["UserID"]);
            SN.firstName = Convert.ToString(rs["FirstName"]);
            SN.lastName = Convert.ToString(rs["LastName"]);
            SN.jobTitle = Convert.ToString(rs["JobTitle"]);
            SN.company = Convert.ToString(rs["Company"]);
            SN.userAddress = Convert.ToString(rs["UserAddress"]);
            SN.city = Convert.ToString(rs["City"]);
            SN.stateProvince = Convert.ToString(rs["StateProvince"]);
            SN.country = Convert.ToString(rs["Country"]);
            SN.postalCode = Convert.ToString(rs["PostalCode"]);
            SN.email = Convert.ToString(rs["Email"]);
            SN.website = Convert.ToString(rs["Website"]);
            SN.phone = Convert.ToString(rs["Phone"]);
            SN.fax = Convert.ToString(rs["Fax"]);
            SN.productInterest = Convert.ToString(rs["ProductInterest"]);
            SN.otherProductInterest = Convert.ToString(rs["OtherProductInterest"]);
            SN.visitorStatus = Convert.ToString(rs["VisitorStatus"]);
            SN.otherVisitorStatus = Convert.ToString(rs["OtherVisitorStatus"]);
            SN.purposeVisit = Convert.ToString(rs["PurposeVisit"]);
            SN.otherPurposeVisit = Convert.ToString(rs["OtherPurposeVisit"]);
            SN.cropInterest = Convert.ToString(rs["CropInterest"]);
            SN.otherCropInterest = Convert.ToString(rs["OtherCropInterest"]);
            SN.interpreter = Convert.ToInt32(rs["Interpreter"]);
            SN.userLanguage = Convert.ToString(rs["UserLanguage"]);

            retVal.Add(SN);
        }
        rs.Close();
        command.Connection.Close();

        return retVal;
    }

    public int Insert()
    {
        int retVal = 0;

        SqlConnection conn = ConnectionHelper.GetSQLConnection();
        SqlCommand command = new SqlCommand("BIUsersINSERT", conn);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        SqlParameter param1 = new SqlParameter("FirstName", SqlDbType.VarChar, 50);
        param1.Value = this.firstName;
        command.Parameters.Add(param1);

        SqlParameter param2 = new SqlParameter("LastName", SqlDbType.VarChar, 50);
        param2.Value = this.lastName;
        command.Parameters.Add(param2);

        SqlParameter param3 = new SqlParameter("JobTitle", SqlDbType.VarChar, 50);
        param3.Value = this.jobTitle;
        command.Parameters.Add(param3);

        SqlParameter param4 = new SqlParameter("Company", SqlDbType.VarChar, 50);
        param4.Value = this.company;
        command.Parameters.Add(param4);

        SqlParameter param5 = new SqlParameter("UserAddress", SqlDbType.VarChar, 50);
        param5.Value = this.userAddress;
        command.Parameters.Add(param5);

        SqlParameter param6 = new SqlParameter("City", SqlDbType.VarChar, 50);
        param6.Value = this.city;
        command.Parameters.Add(param6);

        SqlParameter param7 = new SqlParameter("StateProvince", SqlDbType.VarChar, 50);
        param7.Value = this.stateProvince;
        command.Parameters.Add(param7);

        SqlParameter param8 = new SqlParameter("Country", SqlDbType.VarChar, 50);
        param8.Value = this.country;
        command.Parameters.Add(param8);

        SqlParameter param9 = new SqlParameter("PostalCode", SqlDbType.VarChar, 50);
        param9.Value = this.postalCode;
        command.Parameters.Add(param9);

        SqlParameter param10 = new SqlParameter("Email", SqlDbType.VarChar, 50);
        param10.Value = this.email;
        command.Parameters.Add(param10);

        SqlParameter param11 = new SqlParameter("Website", SqlDbType.VarChar, 50);
        param11.Value = this.website;
        command.Parameters.Add(param11);

        SqlParameter param12 = new SqlParameter("Phone", SqlDbType.VarChar, 50);
        param12.Value = this.phone;
        command.Parameters.Add(param12);

        SqlParameter param13 = new SqlParameter("Fax", SqlDbType.VarChar, 50);
        param13.Value = this.fax;
        command.Parameters.Add(param13);

        SqlParameter param14 = new SqlParameter("ProductInterest", SqlDbType.VarChar, 50);
        param14.Value = this.productInterest;
        command.Parameters.Add(param14);

        SqlParameter param15 = new SqlParameter("OtherProductInterest", SqlDbType.VarChar, 50);
        param15.Value = this.otherProductInterest;
        command.Parameters.Add(param15);

        SqlParameter param16 = new SqlParameter("VisitorStatus", SqlDbType.VarChar, 50);
        param16.Value = this.visitorStatus;
        command.Parameters.Add(param16);

        SqlParameter param17 = new SqlParameter("OtherVisitorStatus", SqlDbType.VarChar, 50);
        param17.Value = this.otherVisitorStatus;
        command.Parameters.Add(param17);

        SqlParameter param18 = new SqlParameter("PurposeVisit", SqlDbType.VarChar, 50);
        param18.Value = this.purposeVisit;
        command.Parameters.Add(param18);

        SqlParameter param19 = new SqlParameter("OtherPurposeVisit", SqlDbType.VarChar, 50);
        param19.Value = this.otherPurposeVisit;
        command.Parameters.Add(param19);

        SqlParameter param20 = new SqlParameter("CropInterest", SqlDbType.VarChar, 50);
        param20.Value = this.cropInterest;
        command.Parameters.Add(param20);

        SqlParameter param21 = new SqlParameter("OtherCropInterest", SqlDbType.VarChar, 50);
        param21.Value = this.otherCropInterest;
        command.Parameters.Add(param21);

        SqlParameter param22 = new SqlParameter("Interpreter", SqlDbType.VarChar, 50);
        param22.Value = this.interpreter;
        command.Parameters.Add(param22);

        SqlParameter param23 = new SqlParameter("UserLanguage", SqlDbType.VarChar, 50);
        param23.Value = this.userLanguage;
        command.Parameters.Add(param23);

        conn.Open();

        SqlDataReader rs = command.ExecuteReader();
        rs.Read();
        int sqlRetVal = Convert.ToInt32(rs["retVal"]);
        if (sqlRetVal == 0)
        {
            retVal = 0;
        }
        else
        {
            this.id = Convert.ToInt32(rs["UserID"]);
            retVal = this.id;
        }
        rs.Close();
        conn.Close();

        return retVal;
    }

    public static bool Delete(int id)
    {
        bool retVal = false;

        SqlConnection conn = ConnectionHelper.GetSQLConnection();
        SqlCommand command = new SqlCommand("BIUsersDELETE", conn);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        SqlParameter param1 = new SqlParameter("UserID", SqlDbType.Int);
        param1.Value = id;
        command.Parameters.Add(param1);

        conn.Open();

        SqlDataReader rs = command.ExecuteReader();
        rs.Read();
        int sqlRetVal = Convert.ToInt32(rs["retVal"]);
        if (sqlRetVal == 1)
        {
            retVal = true;
        }
        rs.Close();
        conn.Close();

        return retVal;
    }



    #endregion
    
    # region properties

    public int ID
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }
    
    
    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            this.lastName = value;
        }
    }

    public string JobTitle
    {
        get
        {
            return this.jobTitle;
        }
        set
        {
            this.jobTitle = value;
        }
    }

    public string Company
    {
        get
        {
            return this.company;
        }
        set
        {
            this.company = value;
        }
    }

    public string UserAddress
    {
        get
        {
            return this.userAddress ;
        }
        set
        {
            this.userAddress = value;
        }
    }

    public string City
    {
        get
        {
            return this.city;
        }
        set
        {
            this.city = value;
        }
    }

    public string StateProvince
    {
        get
        {
            return this.stateProvince;
        }
        set
        {
            this.stateProvince = value;
        }
    }

    public string Country
    {
        get
        {
            return this.country;
        }
        set
        {
            this.country = value;
        }
    }

    public string PostalCode
    {
        get
        {
            return this.postalCode;
        }
        set
        {
            this.postalCode = value;
        }
    }

    public string Email
    {
        get
        {
            return this.email;
        }
        set
        {
            this.email = value;
        }
    }

    public string Website
    {
        get
        {
            return this.website;
        }
        set
        {
            this.website = value;
        }
    }

    public string Phone
    {
        get
        {
            return this.phone;
        }
        set
        {
            this.phone = value;
        }
    }

    public string Fax
    {
        get
        {
            return this.fax;
        }
        set
        {
            this.fax = value;
        }
    }

    public string ProductInterest
    {
        get
        {
            return this.productInterest;
        }
        set
        {
            this.productInterest = value;
        }
    }

    public string OtherProductInterest
    {
        get
        {
            return this.otherProductInterest;
        }
        set
        {
            this.otherProductInterest = value;
        }
    }

    public string VisitorStatus
    {
        get
        {
            return this.visitorStatus;
        }
        set
        {
            this.visitorStatus = value;
        }
    }

    public string OtherVisitorStatus
    {
        get
        {
            return this.otherVisitorStatus;
        }
        set
        {
            this.otherVisitorStatus = value;
        }
    }

    public string PurposeVisit
    {
        get
        {
            return this.purposeVisit;
        }
        set
        {
            this.purposeVisit = value;
        }
    }

    public string OtherPurposeVisit
    {
        get
        {
            return this.otherPurposeVisit;
        }
        set
        {
            this.otherPurposeVisit = value;
        }
    }

    public string CropInterest
    {
        get
        {
            return this.cropInterest;
        }
        set
        {
            this.cropInterest = value;
        }
    }

    public string OtherCropInterest
    {
        get
        {
            return this.otherCropInterest;
        }
        set
        {
            this.otherCropInterest = value;
        }
    }

    public int Interpreter
    {
        get
        {
            return this.interpreter;
        }
        set
        {
            this.interpreter = value;
        }
    }

    public string UserLanguage
    {
        get
        {
            return this.userLanguage;
        }
        set
        {
            this.userLanguage = value;
        }
    }

    #endregion
}
