using db;
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
using System.IO;
using System.Drawing.Imaging;
using System.Text;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;

public partial class Default2 : System.Web.UI.Page
{
    private int pictureID;
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.Master.UseAuthenticationCheck = true;
        populateDropDownListForGallery();
        fillDropDownListForPictures();
        cbFrontImage.Visible = false;

        int count = 1;
        int inpGalleryID;

        if (Request.QueryString["gallery"] == null)
        {
            FileUpload1.Enabled = false;
            btnAddImage.Enabled = false;
            btnDeleteImage.Enabled = false;
            btnUpdateImage.Enabled = false;
        }
        
        
        if (Request.QueryString["gallery"] != null) 
        {
            FileUpload1.Enabled = true;
            btnAddImage.Enabled = true;
            btnDeleteImage.Enabled = true;
            btnUpdateImage.Enabled = true;
            cbFrontImage.Visible = true;

            PicturesPlaceholder.Text = "";
            Gallery G = new Gallery(Convert.ToInt32(Request.QueryString["gallery"]));
            ddGallery.SelectedValue = Request.QueryString["gallery"];
            txtGallery.Text = G.Title;
                        
            string image = "";
            inpGalleryID = Convert.ToInt32(Request.QueryString["gallery"]);
            
            if (Request.QueryString["picture"] == null)
            {
                ddPictures.SelectedValue = "1";
                List<Picture> Pc = Picture.GetPictures(inpGalleryID);
                PicturesPlaceholder.Text += "<table>";
                PicturesPlaceholder.Text += "<tr>";
                foreach (Picture P in Pc)
                {
                    if (File.Exists(Server.MapPath("~/gallery/") + P.GalleryID + "/" + "frontthumb_" + P.ID + ".jpg"))
                    {
                        image = "<img src=\"gallery/" + P.GalleryID + "/frontthumb_" + P.ID + ".jpg\" />";
                        if (count < 4)
                        {
                            PicturesPlaceholder.Text += "<td>" + P.Title + "<div style=\"height: 240px; overflow: hidden; \"><a href=\"admingallery.aspx?gallery=" + P.GalleryID + "&picture=" + P.ID + "\">" + image + "</a></div>";
                            PicturesPlaceholder.Text += "</td>";
                        }
                        else if (count == 4)
                        {
                            PicturesPlaceholder.Text += "<td>" + P.Title + "<div style=\"height: 240px; overflow: hidden; \"><a href=\"admingallery.aspx?gallery=" + P.GalleryID + "&picture=" + P.ID + "\">" + image + "</a></div>";
                            PicturesPlaceholder.Text += "</td></tr><tr>";
                            count = 0;
                        }
                        count++;
                    }
                }
                PicturesPlaceholder.Text += "</tr>";
                PicturesPlaceholder.Text += "<table>";
            }
            else if (Request.QueryString["picture"] != null) 
            {
                displayOnePicture();
            }
        }
        
    }

   


    private void displayOnePicture()
    {
        int i = 1;
        int back = 0;
        int next = 0;
        cbFrontImage.Visible = true;

        List<Picture> P = Picture.GetPictures(Convert.ToInt32(Request.QueryString["gallery"]));
        for (i = 0; i < P.Count; i++)
        {
            if (P[i].ID == Convert.ToInt32(Request.QueryString["picture"]))
            {
                break;
            }
        }
        
       
        if (File.Exists(Server.MapPath("~/gallery/") + P[i].GalleryID + "/" + "main_" + P[i].ID + ".jpg"))
        {
            PicturesPlaceholder.Text += "<center><table><tr>";
            if (i - 1 >= 0)
            {
                back = i - 1;
            }
            else if (i-1 < 0) 
            {
                back = P.Count - 1; 
            }
            PicturesPlaceholder.Text += "<td style=\"font-size: 20px; font-weight: 700;\"><a class=\"galleryNav\" href=\"admingallery.aspx?gallery=" + P[back].GalleryID + "&picture=" + P[back].ID + "\">&lt;&lt;</a>&nbsp;&nbsp;</td><td>";
            PicturesPlaceholder.Text += "<img src=\"gallery/" + P[i].GalleryID + "/main_" + P[i].ID + ".jpg\"/>";
            txtPicture.Text = P[i].Title;
            txtDescription.Text = P[i].PictureDescription;
            
            if (P[i].FrontImage == 1)
            {
                cbFrontImage.Checked = true;
            }
            else
            {
                cbFrontImage.Checked = false;
            }


            if (i + 1 < P.Count)
            {
                next = i + 1;
            }
            else if (i + 1 >= P.Count)
            {
                i = 0;
            }
            PicturesPlaceholder.Text += "</td><td style=\"font-size: 20px; font-weight: 700;\">&nbsp;&nbsp;<a class=\"galleryNav\" href=\"admingallery.aspx?gallery=" + P[next].GalleryID + "&picture=" + P[next].ID + "\">&gt;&gt;</a></td>";
            PicturesPlaceholder.Text += "</table></tr></center>";
        }
    }


    private void fillDropDownListForPictures()
    {
        if (ddPictures.Items.Count == 0)
        {
            ddPictures.Items.Add(new ListItem("--Selected Image--", "0"));
            ddPictures.Items.Add(new ListItem("--Show All--", "1"));
        }
    }

    private void populateDropDownListForGallery()
    {
        List<Gallery> Gl = Gallery.GetAll();
        ddGallery.Items.Clear();
        ddGallery.Items.Add(new ListItem("--Add New--", "0"));

        foreach (Gallery G in Gl)
        {
            if (G.Title.Length > 30)
            {
                ddGallery.Items.Add(new ListItem(G.Title.Substring(0, 30), G.ID.ToString()));
            }
            else
            {
                ddGallery.Items.Add(new ListItem(G.Title, G.ID.ToString()));
            }
        }
    }

    protected void btnAddGallery_Click(object sender, EventArgs e)
    {
        Gallery G = new Gallery();
        G.Title = txtGallery.Text;
        int galleryID = G.Insert();
        populateDropDownListForGallery();
        if (galleryID == 0)
        {
            Feedback.Text = "Insert Failed, please try again";
        }
        else
        {
            Feedback.Text = "Insert Successful";
            ddGallery.SelectedValue = galleryID.ToString();
            Directory.CreateDirectory(Server.MapPath("~/gallery/") + galleryID.ToString());
            fillDropDownListForPictures();
            FileUpload1.Enabled = true;
            btnAddImage.Enabled = true;
            btnDeleteImage.Enabled = true;
            btnUpdateImage.Enabled = true;
        }
    }

    protected void btnUpdateGallery_Click(object sender, EventArgs e)
    {
        Gallery G = new Gallery(Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$ddGallery"]));
        G.Title = Request.Form["ctl00$ContentPlaceHolder1$txtGallery"];
        G.Update();
        Response.Redirect("~/admingallery.aspx?gallery=" + Request.Form["ctl00$ContentPlaceHolder1$ddGallery"]);
    }

    protected void btnDeleteGallery_Click(object sender, EventArgs e)
    {
        Gallery.Delete(Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$ddGallery"]));
        Directory.Delete(@Server.MapPath("gallery/" + Request.Form["ctl00$ContentPlaceHolder1$ddGallery"]), true);
        Response.Redirect("~/admingallery.aspx");
    }
           
    protected void ddGallery_SelectedIndexChanged(object sender, EventArgs e)
    {
        PicturesPlaceholder.Text = "";
        txtGallery.Text = "";
        txtDescription.Text = "";
        ///ddPictures.Items.Clear();
        ddGallery.SelectedValue = Request.Form["ctl00$ContentPlaceHolder1$ddGallery"];
        if (Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$ddGallery"]) == 0)
        {
            Response.Redirect("~/admingallery.aspx");
        }
        else 
        {
            Response.Redirect("~/admingallery.aspx?gallery=" + Request.Form["ctl00$ContentPlaceHolder1$ddGallery"]);
        }
    }

    protected void btnAddImage_Click(object sender, EventArgs e)
    {
        ddGallery.SelectedValue = Request.Form["ctl00$ContentPlaceHolder1$ddGallery"];
        if (FileUpload1.HasFile)
        {
            Picture P = new Picture();
            P.GalleryID = Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$ddGallery"]);
            P.Title = txtPicture.Text;
            P.PictureDescription = txtDescription.Text;
            pictureID = P.Insert();

            if (pictureID == 0)
            {
                Feedback.Text = "Insert Failed, please try again";
            }
            else
            {
                Feedback.Text = "Insert Successful";
            }

            string galleryID = Request.Form["ctl00$ContentPlaceHolder1$ddGallery"];

            int MAIN_IMAGE_MAX_WIDTH = 600;
            int MAIN_IMAGE_MAX_HEIGHT = 600;

            int FRONTTHUMB_IMAGE_MAX_WIDTH = 230;
            int FRONTTHUMB_IMAGE_MAX_HEIGHT = 230;

            FileUpload1.SaveAs(Server.MapPath("~/gallery/" + galleryID + "/") + "raw_" + pictureID);
            System.Drawing.Image I = System.Drawing.Image.FromFile(Server.MapPath("~/gallery/" + galleryID + "/") + "raw_" + pictureID);

            #region maintain image ratio
            if (I.Height > I.Width)
            {
                FRONTTHUMB_IMAGE_MAX_WIDTH = Convert.ToInt32((FRONTTHUMB_IMAGE_MAX_HEIGHT * I.Width) / I.Height);
                MAIN_IMAGE_MAX_WIDTH = Convert.ToInt32((MAIN_IMAGE_MAX_HEIGHT * I.Width) / I.Height);
            }
            else
            {
                FRONTTHUMB_IMAGE_MAX_HEIGHT = Convert.ToInt32((FRONTTHUMB_IMAGE_MAX_WIDTH * I.Height) / I.Width);
                MAIN_IMAGE_MAX_HEIGHT = Convert.ToInt32((MAIN_IMAGE_MAX_WIDTH * I.Height) / I.Width);
            }
            #endregion

            System.Drawing.Image imgInput = System.Drawing.Image.FromFile(Server.MapPath("~/gallery/" + galleryID + "/") + "raw_" + pictureID);
            Bitmap imgResized1 = new Bitmap(imgInput, MAIN_IMAGE_MAX_WIDTH, MAIN_IMAGE_MAX_HEIGHT);
            imgResized1.SetResolution(MAIN_IMAGE_MAX_WIDTH + 100, MAIN_IMAGE_MAX_HEIGHT + 100);
            imgResized1.Save(Server.MapPath("~/gallery/" + galleryID + "/") + "main_" + pictureID + ".jpg", ImageFormat.Jpeg);
            imgInput.Dispose();
            imgResized1.Dispose();

            System.Drawing.Image thumbImage = System.Drawing.Image.FromFile(Server.MapPath("~/gallery/" + galleryID + "/") + "raw_" + pictureID);
            Bitmap imgResized2 = new Bitmap(thumbImage, FRONTTHUMB_IMAGE_MAX_WIDTH, FRONTTHUMB_IMAGE_MAX_HEIGHT);
            imgResized2.SetResolution(FRONTTHUMB_IMAGE_MAX_WIDTH + 100, FRONTTHUMB_IMAGE_MAX_HEIGHT + 100);
            imgResized2.Save(Server.MapPath("~/gallery/" + galleryID + "/") + "frontthumb_" + pictureID + ".jpg", ImageFormat.Jpeg);
            thumbImage.Dispose();
            imgResized2.Dispose();
         
            I.Dispose();

            File.Delete(Server.MapPath("~/gallery/" + galleryID + "/") + "raw_" + pictureID);
            PicturesPlaceholder.Text = "<div style=\"height: 103px;overflow: hidden; \"><img src=\"gallery/" + P.GalleryID + "/frontthumb_" + P.ID + ".jpg\" /></div>";

            Feedback.Text = "File upload successful.<br/>";
            Response.Redirect("~/admingallery.aspx?gallery=" + P.GalleryID);
        }
        else
        {
            Feedback.Text = "Please select a picture to upload.<br/>";
        }
    }

    public bool ThumbnailCallback()
    {
        return true;
    }
     

    protected void btnUpdateImage_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["picture"] != null)
        {
            Picture P = new Picture(Convert.ToInt32(Request.QueryString["picture"]));
            P.GalleryID = Convert.ToInt32(Request.QueryString["gallery"]);
            P.Title = Request.Form["ctl00$ContentPlaceHolder1$txtPicture"];
            P.PictureDescription = Request.Form["ctl00$ContentPlaceHolder1$txtDescription"];
            if (Request.Form["ctl00$ContentPlaceHolder1$cbFrontImage"] == "on") 
            {
                P.FrontImage = 1;
                cbFrontImage.Checked = true;
            }
            

            /*if (Request.Form["ctl00$ContentPlaceHolder1$cbFrontImage"] == "on")
            {
                SqlConnection conn = ConnectionHelper.GetSQLConnection();
                SqlCommand command1 = new SqlCommand("UPDATE Picture SET FrontImage=0 WHERE FrontImage=1;", conn);
                conn.Open();
                SqlDataReader rs1 = command1.ExecuteReader();
                rs1.Read();
                rs1.Close();
                //Feedback.Text = Request.QueryString["picture"];
                SqlCommand command2 = new SqlCommand("UPDATE Picture SET FrontImage=1 WHERE PictureID=@id;", conn);
                command2.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["picture"]));
                SqlDataReader rs2 = command2.ExecuteReader();
                rs2.Read();
                cbFrontImage.Checked = true;
                rs2.Close();
                conn.Close();
            }*/
            
            
            if (!P.Update())
            {
                Feedback.Text = "Update Failed, please try again";
            }
            else
            {
                Feedback.Text = "Update Successful";
                txtPicture.Text = P.Title;
                txtDescription.Text = P.PictureDescription;
            }
        }
        else 
        {
            Feedback.Text = "Please select picture to update";
        }

    }

    protected void btnDeleteImage_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["picture"]!=null) 
        {
            string galleryID = Request.Form["ctl00$ContentPlaceHolder1$ddGallery"];
            Picture.Delete(Convert.ToInt32(Request.QueryString["picture"]));
            File.Delete(@Server.MapPath("gallery/" + galleryID + "/" + "main_" + Request.QueryString["picture"] + ".jpg"));
            File.Delete(@Server.MapPath("gallery/" + galleryID + "/" + "frontthumb_" + Request.QueryString["picture"] + ".jpg"));
            Response.Redirect("~/admingallery.aspx?gallery=" + galleryID);    
        } 
    }
          

    protected void ddPictures_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddPictures.SelectedValue = Request.Form["ctl00$ContentPlaceHolder1$ddPictures"];
        if(ddPictures.SelectedValue == "1")
        {
            PicturesPlaceholder.Text = "";
            Response.Redirect("~/admingallery.aspx?gallery=" + Request.Form["ctl00$ContentPlaceHolder1$ddGallery"]);
        }
        if (Request.QueryString["picture"]==null)
        {
            ddPictures.SelectedValue = "1";
        }
    }



    
}
