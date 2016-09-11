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

    public class Picture : DBBase
    {
        private int galleryID;
        private string title;
        private string pictureDescription;
        private int frontImage;

        public Picture()
        {
        }

        public Picture(int id)
        {
            SqlConnection conn = ConnectionHelper.GetSQLConnection();
            SqlCommand command = new SqlCommand("select * from Picture where PictureID = @id", conn);
            command.Parameters.AddWithValue("@id", id);

            conn.Open();
            
            SqlDataReader rs = command.ExecuteReader();

            if (rs.Read())
            {
                this.id = Convert.ToInt32(rs["PictureID"]);
                this.galleryID = Convert.ToInt32(rs["GalleryID"]);
                this.title = Convert.ToString(rs["Title"]);
                this.pictureDescription = Convert.ToString(rs["PictureDescription"]);
                this.frontImage = Convert.ToInt32(rs["FrontImage"]);
            }
            rs.Close();
            conn.Close();

        }


        #region collection methods

        public static List<Picture> GetAllPictures() 
        {
            SqlConnection conn = ConnectionHelper.GetSQLConnection();
            SqlCommand command = new SqlCommand("select * from Picture order by GalleryID", conn);
            int tmpID = 0;
            List<Picture> retVal = new List<Picture>();

            command.Connection.Open();

            SqlDataReader rs = command.ExecuteReader();

            while (rs.Read())
            {
                if (tmpID != Convert.ToInt32(rs["GalleryID"]))
                {
                    Picture SN = new Picture();

                    tmpID = Convert.ToInt32(rs["GalleryID"]);
                    SN.id = Convert.ToInt32(rs["PictureID"]);
                    SN.galleryID = Convert.ToInt32(rs["GalleryID"]);
                    SN.title = Convert.ToString(rs["Title"]);
                    SN.pictureDescription = Convert.ToString(rs["PictureDescription"]);
                    SN.frontImage = Convert.ToInt32(rs["FrontImage"]);
                    retVal.Add(SN);
                }
            }
            rs.Close();
            command.Connection.Close();

            return retVal;
        
        }


        public static List<Picture> GetAllFrontImages()
        {
            SqlConnection conn = ConnectionHelper.GetSQLConnection();
            SqlCommand command = new SqlCommand("select * from Picture where FrontImage=1 order by GalleryID", conn);
            int tmpID = 0;
            List<Picture> retVal = new List<Picture>();

            command.Connection.Open();

            SqlDataReader rs = command.ExecuteReader();

            while (rs.Read())
            {
                if (tmpID != Convert.ToInt32(rs["GalleryID"]))
                {
                    Picture SN = new Picture();

                    tmpID = Convert.ToInt32(rs["GalleryID"]);
                    SN.id = Convert.ToInt32(rs["PictureID"]);
                    SN.galleryID = Convert.ToInt32(rs["GalleryID"]);
                    SN.title = Convert.ToString(rs["Title"]);
                    SN.pictureDescription = Convert.ToString(rs["PictureDescription"]);
                    SN.frontImage = Convert.ToInt32(rs["FrontImage"]);
                    retVal.Add(SN);
                }
            }
            rs.Close();
            command.Connection.Close();

            return retVal;

        }


        
        public static List<Picture> GetPictures(int inpGalleryID)
        {
            SqlConnection conn = ConnectionHelper.GetSQLConnection();
            SqlCommand command = new SqlCommand("select * from Picture where GalleryID = @inpGalleryID", conn);
            command.Parameters.AddWithValue("@inpGalleryID", inpGalleryID);

            return baseCollectionCreator(command);
        }

        /// <returns>A collection of objects that corrispond to results of the SQL Statement</returns>
        private static List<Picture> baseCollectionCreator(SqlCommand command)
        {
            List<Picture> retVal = new List<Picture>();

            command.Connection.Open();

            SqlDataReader rs = command.ExecuteReader();

            while (rs.Read())
            {
                Picture SN = new Picture();

                SN.id = Convert.ToInt32(rs["PictureID"]);
                SN.galleryID = Convert.ToInt32(rs["GalleryID"]);
                SN.title = Convert.ToString(rs["Title"]);
                SN.pictureDescription = Convert.ToString(rs["PictureDescription"]);
                SN.frontImage = Convert.ToInt32(rs["FrontImage"]);
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
            SqlCommand command = new SqlCommand("PictureINSERT", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("GalleryID", SqlDbType.Int);
            param1.Value = this.galleryID;
            command.Parameters.Add(param1);
            
            SqlParameter param2 = new SqlParameter("Title", SqlDbType.VarChar, 150);
            param2.Value = this.title;
            command.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter("PictureDescription", SqlDbType.VarChar, 450);
            param3.Value = this.pictureDescription;
            command.Parameters.Add(param3);

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
                this.id = Convert.ToInt32(rs["PictureID"]);
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
            SqlCommand command = new SqlCommand("PictureUPDATE", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter paramGalleryID = new SqlParameter("GalleryID", SqlDbType.Int);
            paramGalleryID.Value = this.GalleryID;
            command.Parameters.Add(paramGalleryID);

            SqlParameter paramID = new SqlParameter("PictureID", SqlDbType.Int);
            paramID.Value = this.id;
            command.Parameters.Add(paramID);

            SqlParameter param1 = new SqlParameter("Title", SqlDbType.VarChar, 150);
            param1.Value = this.title;
            command.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter("PictureDescription", SqlDbType.VarChar, 450);
            param2.Value = this.pictureDescription;
            command.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter("FrontImage", SqlDbType.VarChar, 450);
            param3.Value = this.frontImage;
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

        public static bool Delete(int id)
        {
            bool retVal = false;

            SqlConnection conn = ConnectionHelper.GetSQLConnection();
            SqlCommand command = new SqlCommand("PictureDELETE", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("PictureID", SqlDbType.Int);
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

        public int GalleryID
        {
            get
            {
                return this.galleryID;
            }
            set
            {
                this.galleryID = value;
            }
        }

        public string PictureDescription
        {
            get 
            {
                return this.pictureDescription;
            }
            set 
            {
                this.pictureDescription = value;
            }
        }

        public int FrontImage
        {
            get
            {
                return this.frontImage;
            }
            set
            {
                this.frontImage = value;
            }
        }

        #endregion

    }

}