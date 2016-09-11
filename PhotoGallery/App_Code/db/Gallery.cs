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

    public class Gallery : DBBase
    {

        private string title;
        private int orderNumber;

        public Gallery()
        {
        }

        public Gallery(int id)
        {
            SqlConnection conn = ConnectionHelper.GetSQLConnection();
            SqlCommand command = new SqlCommand("select * from Gallery where GalleryID = @id", conn);
            command.Parameters.AddWithValue("@id", id);

            conn.Open();

            SqlDataReader rs = command.ExecuteReader();

            if (rs.Read())
            {
                this.id = Convert.ToInt32(rs["GalleryID"]);
                this.title = Convert.ToString(rs["Title"]);
                //this.orderNumber = Convert.ToInt32(rs["OrderNumber"]);
            }
            rs.Close();
            conn.Close();

        }

        #region collection methods
        
        public static List<Gallery> GetAll()
        {
            SqlConnection conn = ConnectionHelper.GetSQLConnection();
            SqlCommand command = new SqlCommand("select * from Gallery", conn);

            return baseCollectionCreator(command);
        }

        /// <returns>A collection of objects that corrispond to results of the SQL Statement</returns>
        private static List<Gallery> baseCollectionCreator(SqlCommand command)
        {
            List<Gallery> retVal = new List<Gallery>();

            command.Connection.Open();

            SqlDataReader rs = command.ExecuteReader();

            while (rs.Read())
            {
                Gallery SN = new Gallery();

                SN.id = Convert.ToInt32(rs["GalleryID"]);
                SN.title = Convert.ToString(rs["Title"]);
                //SN.orderNumber = Convert.ToInt32(rs["OrderNumber"]);
        
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
            SqlCommand command = new SqlCommand("GalleryINSERT", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("Title", SqlDbType.VarChar, 150);
            param1.Value = this.title;
            command.Parameters.Add(param1);
            
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
                this.id = Convert.ToInt32(rs["GalleryID"]);
                retVal = this.id;
            }
            rs.Close();
            conn.Close();

            return retVal;
        }


        public bool Update()
        {
            bool retVal = false;

            SqlConnection conn = ConnectionHelper.GetSQLConnection();
            SqlCommand command = new SqlCommand("GalleryUPDATE", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("Title", SqlDbType.VarChar, 150);
            param1.Value = this.title;
            command.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter("GalleryID", SqlDbType.Int);
            param2.Value = this.id;
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
        }

        public static bool Delete(int id)
        {
            bool retVal = false;

            SqlConnection conn = ConnectionHelper.GetSQLConnection();
            SqlCommand command = new SqlCommand("GalleryDELETE", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("GalleryID", SqlDbType.Int);
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
        

        #region properties
                
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }
         

        #endregion
        
       
        
    }


}