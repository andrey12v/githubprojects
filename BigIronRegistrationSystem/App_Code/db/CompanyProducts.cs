using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

namespace db
{

    public class CompanyProducts : DBBase
    {

        private string productName;
        private string categoryProductName;
        private string location;
        private string companyName;
        private string productDescription;
        private string contactPersonName;
        private string phone;
        private string fax;
        private string cellPhone;
        private string email;

        private int expID;
        private int parentID;
        private int childID;
        private int childEquipID;

        public CompanyProducts()
        {
        }

        public static List<CompanyProducts> GetAll()
        {
            SqlConnection conn = ConnectionHelper.GetSQLConnection();
            SqlCommand command = new SqlCommand("SELECT CompanyProducts.ParentID, CompanyProductCategories.ChildID, CompanyProducts.ProductName, CompanyProductCategories.CategoryName " + 
                "FROM CompanyProducts INNER JOIN CompanyProductCategories ON CompanyProducts.ParentID = CompanyProductCategories.ParentID", conn);
            //return baseCollectionCreator(command);
            List<CompanyProducts> retVal = new List<CompanyProducts>();

            command.Connection.Open();

            SqlDataReader rs = command.ExecuteReader();
            while (rs.Read())
            {
                CompanyProducts CP = new CompanyProducts();

                CP.parentID = Convert.ToInt32(rs["ParentID"]);
                CP.childID = Convert.ToInt32(rs["ChildID"]);
                CP.productName = Convert.ToString(rs["ProductName"]);
                CP.categoryProductName = Convert.ToString(rs["CategoryName"]);

                retVal.Add(CP);
            }
            rs.Close();
            command.Connection.Close();

            return retVal;
        }


        public static List<CompanyProducts> GetProductCategories(int inpCompanyID)
        {
            SqlConnection conn = ConnectionHelper.GetSQLConnection();
            SqlCommand command = new SqlCommand("Select Ex.Location, CPID.ExpID, CPID.ChildEquipID, CP.ParentID, CP.ProductName, CPC.ChildID, CPC.CategoryName " + 
                "From Exporters as Ex Left Outer Join CompanyProductID as CPID " +
                    "On (Ex.ExporterID=CPID.ExpID) Left Outer Join CompanyProducts as CP " +
	                "On (CPID.EquipID=CP.ParentID) Left Outer Join CompanyProductCategories as CPC " +
	                "On (CP.ParentID=CPC.ParentID) " +
                "Where ExpID=@id And CPID.ChildEquipID=CPC.ChildID " +
                "Order By CPID.ChildEquipID", conn);
            command.Parameters.AddWithValue("@id", inpCompanyID);

            List<CompanyProducts> retVal = new List<CompanyProducts>();

            command.Connection.Open();

            SqlDataReader rs = command.ExecuteReader();
            
            while (rs.Read())
            {
                CompanyProducts CP = new CompanyProducts();

                CP.Location = Convert.ToString(rs["Location"]); 
                CP.parentID = Convert.ToInt32(rs["ParentID"]);
                CP.childID = Convert.ToInt32(rs["ChildID"]);
                CP.childEquipID = Convert.ToInt32(rs["ChildEquipID"]);
                CP.productName = Convert.ToString(rs["ProductName"]);
                CP.categoryProductName = Convert.ToString(rs["CategoryName"]);
                
                retVal.Add(CP);
            }
            rs.Close();
            command.Connection.Close();

            return retVal;

        }

        public static List<CompanyProducts> GetAllDataForReport(int inpCheck)
        {
            SqlConnection conn = ConnectionHelper.GetSQLConnection();
            if(inpCheck==0)
            {
                SqlCommand command = new SqlCommand("Select Ex.Name, Ex.ProductDescription, Ex.Location, Con.FirstName + ' ' + Con.LastName as ContactPerson, " +
                    "Con.Phone, Con.Fax, Con.CellPhone, Con.Email, CPID.ExpID, CPID.EquipID, CPID.ChildEquipID, CP.ProductName, CPC.CategoryName " +
                    "From Exporters as Ex Left Outer Join Contacts as Con " +
	                    "On (Ex.ExporterID=Con.ExporterID) Left Outer Join CompanyProductID as CPID " +
	                    "On (Ex.ExporterID=CPID.ExpID) Left Outer Join CompanyProducts as CP " +
	                    "On (CPID.EquipID=CP.ParentID) Left Outer Join CompanyProductCategories as CPC " +
	                    "On (CP.ParentID=CPC.ParentID) " +
                    "Where CPID.ChildEquipID=CPC.ChildID AND Con.IsMainContact='1'" +
                    "Order By CPID.ExpID, CPID.EquipID, CPID.ChildEquipID", conn);

                return baseCollectionCreator(command);
            }
            else if (inpCheck == 1) 
            {
                SqlCommand command = new SqlCommand("Select Ex.Name, Ex.ProductDescription, Ex.Location, Con.FirstName + ' ' + Con.LastName as ContactPerson, " +
                    "Con.Phone, Con.Fax, Con.CellPhone, Con.Email, CPID.ExpID, CPID.EquipID, CPID.ChildEquipID, CP.ProductName, CPC.CategoryName " +
                    "From Exporters as Ex Left Outer Join Contacts as Con " +
                        "On (Ex.ExporterID=Con.ExporterID) Left Outer Join CompanyProductID as CPID " +
                        "On (Ex.ExporterID=CPID.ExpID) Left Outer Join CompanyProducts as CP " +
                        "On (CPID.EquipID=CP.ParentID) Left Outer Join CompanyProductCategories as CPC " +
                        "On (CP.ParentID=CPC.ParentID) " +
                    "Where CPID.ChildEquipID=CPC.ChildID AND Con.IsMainContact='1'" +
                    "Order By CP.ProductName, CPID.ExpID", conn);
                return baseCollectionCreator(command);
            }
            List<CompanyProducts> retVal = new List<CompanyProducts>();
            return retVal;
        }


        private static List<CompanyProducts> baseCollectionCreator(SqlCommand command)
        {
            List<CompanyProducts> retVal = new List<CompanyProducts>();

            command.Connection.Open();

            SqlDataReader rs = command.ExecuteReader();

            while (rs.Read())
            {
                CompanyProducts CP = new CompanyProducts();

                CP.ExpID = Convert.ToInt32(rs["ExpID"]);
                CP.CompanyName = Convert.ToString(rs["Name"]);
                CP.ProductDescription = Convert.ToString(rs["ProductDescription"]);
                CP.Location = Convert.ToString(rs["Location"]);
                CP.ContactPersonName = Convert.ToString(rs["ContactPerson"]);
                CP.Phone = Convert.ToString(rs["Phone"]);
                CP.Fax = Convert.ToString(rs["Fax"]);
                CP.CellPhone = Convert.ToString(rs["CellPhone"]);
                CP.Email = Convert.ToString(rs["Email"]);
                CP.ParentID = Convert.ToInt32(rs["EquipID"]);
                CP.productName = Convert.ToString(rs["ProductName"]);
                CP.categoryProductName = Convert.ToString(rs["CategoryName"]);

                retVal.Add(CP);
            }
            rs.Close();
            command.Connection.Close();

            return retVal;
        }

        public static List<CompanyProducts> GetProductsByCompanyID(int inpCompanyID)
        {
            SqlConnection conn = ConnectionHelper.GetSQLConnection();
            SqlCommand command = new SqlCommand("Select Ex.Name, CPID.ExpID, CPID.EquipID, CP.ProductName " +
                "From Exporters as Ex Left Outer Join CompanyProductID as CPID " +
                "On (Ex.ExporterID=CPID.ExpID) Left Outer Join CompanyProducts as CP " +
                "On (CPID.EquipID=CP.ParentID) " +
                "Where ExpID=@id Group BY Ex.Name, CPID.ExpID, CPID.EquipID, CP.ProductName Order By CPID.EquipID", conn);
            command.Parameters.AddWithValue("@id", inpCompanyID);
       
            List<CompanyProducts> retVal = new List<CompanyProducts>();

            command.Connection.Open();

            SqlDataReader rs = command.ExecuteReader();
            while (rs.Read())
            {
                CompanyProducts CP = new CompanyProducts();

                CP.parentID = Convert.ToInt32(rs["EquipID"]);
                CP.productName = Convert.ToString(rs["ProductName"]);
                CP.companyName = Convert.ToString(rs["Name"]);

                retVal.Add(CP);
            }
            rs.Close();
            command.Connection.Close();

            return retVal;
        }




        public static bool Delete(int id)
        {
            bool retVal = false;

            SqlConnection conn = ConnectionHelper.GetSQLConnection();
            SqlCommand command = new SqlCommand("CompanyProductIdDELETE", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("ChildEquipID", SqlDbType.Int);
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

        public static bool Insert(int inpExpID, int inpChildEquipID)
        {
            bool retVal = false;

            SqlConnection conn = ConnectionHelper.GetSQLConnection();
            SqlCommand command = new SqlCommand("CompanyProductIdINSERT", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("ParentID", SqlDbType.Int);
            param1.Value = 0;
            command.Parameters.Add(param1);
            
            SqlParameter param2 = new SqlParameter("ExpID", SqlDbType.Int);
            param2.Value = inpExpID;
            command.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter("ChildEquipID", SqlDbType.Int);
            param3.Value = inpChildEquipID;
            command.Parameters.Add(param3);

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

        /*public static bool UpdateBILocation(int inpExpID, string inpLocation) 
        {
            bool retVal = false;

            SqlConnection conn = ConnectionHelper.GetSQLConnection();
            SqlCommand command = new SqlCommand("BigIronLocationUPDATE", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("ExpID", SqlDbType.Int);
            param1.Value = inpExpID;
            command.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter("Location", SqlDbType.VarChar, 250);
            param2.Value = inpLocation;
            command.Parameters.Add(param2);

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

        }*/



        #region properties
        public string ProductName
        {
            get
            {
                return this.productName;
            }
            set
            {
                this.productName = value;
            }
        }

        public string CategoryProductName
        {
            get
            {
                return this.categoryProductName;
            }
            set
            {
                this.categoryProductName = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }

        public string CompanyName
        {
            get
            {
                return this.companyName;
            }
            set
            {
                this.companyName = value;
            }
        }

        public string ProductDescription
        {
            get
            {
                return this.productDescription;
            }
            set
            {
                this.productDescription = value;
            }
        }
        
        public string ContactPersonName
        {
            get
            {
                return this.contactPersonName;
            }
            set
            {
                this.contactPersonName = value;
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
            
        public string CellPhone
        {
            get
            {
                return this.cellPhone;
            }
            set
            {
                this.cellPhone = value;
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
        
        public int ParentID
        {
            get
            {
                return this.parentID;
            }
            set
            {
                this.parentID = value;
            }
        }

        public int ChildID
        {
            get
            {
                return this.childID;
            }
            set
            {
                this.childID = value;
            }
        }

        public int ChildEquipID 
        {
            get 
            {
                return this.childEquipID;
            }
            set 
            {
                this.childEquipID = value;
            }
        }

        public int ExpID
        {
            get
            {
                return this.expID;
            }
            set
            {
                this.expID = value;
            }
        }



        #endregion

    }

}