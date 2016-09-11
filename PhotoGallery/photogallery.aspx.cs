using db;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    private int i;
    private string image;
    private int count;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["gallery"] == null)
        {
            populateGallery();
        }
        if ((Request.QueryString["gallery"] != null) && (Request.QueryString["picture"] == null))
        {
            populateGalleryPriviews();
        }
        if ((Request.QueryString["gallery"] != null) && (Request.QueryString["picture"] != null))
        {
            displayOnePicture();
        }

    
    }

    private void displayOnePicture()
    {
        i = 1;
        int back = 0;
        int next = 0;
       
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
            literalGallery.Text += "<center><table>";
            if (i - 1 >= 0)
            {
                back = i - 1;
            }
            else if (i - 1 < 0)
            {
                back = P.Count - 1;
            }

            literalGallery.Text += "<tr><td  style=\"text-align:center; font-size: 15px; font-weight:700;\" colspan=\"3\">" + P[i].Title + "</td></tr>";
            literalGallery.Text += "<tr><td style=\"font-size: 20px; font-weight: 700;\"><a class=\"galleryNav\" href=\"photogallery.aspx?gallery=" + P[back].GalleryID + "&picture=" + P[back].ID + "\">&lt;&lt;</a>&nbsp;&nbsp;</td><td>";
            literalGallery.Text += "<img src=\"gallery/" + P[i].GalleryID + "/main_" + P[i].ID + ".jpg\"/>";
            //txtPicture.Text = P[i].Title;
            //txtDescription.Text = P[i].PictureDescription;
                       
            if (i + 1 < P.Count)
            {
                next = i + 1;
            }
            else if (i + 1 >= P.Count)
            {
                i = 0;
            }
            literalGallery.Text += "</td><td style=\"font-size: 20px; font-weight: 700;\">&nbsp;&nbsp;<a class=\"galleryNav\" href=\"photogallery.aspx?gallery=" + P[next].GalleryID + "&picture=" + P[next].ID + "\">&gt;&gt;</a></td></tr>";
            literalGallery.Text += "<tr><td  style=\"text-align:center; font-size: 15px; font-weight:700;\" colspan=\"3\">" + P[i].PictureDescription + "</td></tr>";
            literalGallery.Text += "</table></center>";
        }
    }
    
    
    
    private void populateGalleryPriviews()
    {
        count = 1;
        literalGallery.Text = "";
        
        List<Picture> Pc = Picture.GetPictures(Convert.ToInt32(Request.QueryString["gallery"]));

        literalGallery.Text += "<table>";
        literalGallery.Text += "<tr>";
        foreach (Picture P in Pc)
        {
            if (File.Exists(Server.MapPath("~/gallery/") + P.GalleryID + "/" + "frontthumb_" + P.ID + ".jpg"))
            {
                image = "<img src=\"gallery/" + P.GalleryID + "/frontthumb_" + P.ID + ".jpg\" />";
                if (count < 4)
                {
                    literalGallery.Text += "<td>" + P.Title + "<div style=\"height: 240px; overflow: hidden; \"><a href=\"photogallery.aspx?gallery=" + P.GalleryID + "&picture=" + P.ID + "\">" + image + "</a></div>";
                    literalGallery.Text += "</td>";
                }
                else if (count == 4)
                {
                    literalGallery.Text += "<td>" + P.Title + "<div style=\"height: 240px; overflow: hidden; \"><a href=\"photogallery.aspx?gallery=" + P.GalleryID + "&picture=" + P.ID + "\">" + image + "</a></div>";
                    literalGallery.Text += "</td></tr><tr>";
                    count = 0;
                }
                count++;
            }
        }
        literalGallery.Text += "</tr>";
        literalGallery.Text += "<table>";
        
    }


    private void populateGallery()
    {
        i = 0;
        count = 1;
        bool pictureExist = false;

        List<Gallery> Gl = Gallery.GetAll();
        List<Picture> Pic = Picture.GetAllFrontImages();
        literalGallery.Text += "<table>";
        literalGallery.Text += "<tr>";
        foreach (Gallery G in Gl)
        {
            for (i = 0; i<Pic.Count; i++)
            {
                if (Convert.ToInt32(G.ID) == Convert.ToInt32(Pic[i].GalleryID))
                {
                    if (File.Exists(Server.MapPath("~/gallery/" + G.ID + "/" + "frontthumb_" + Pic[i].ID + ".jpg")))
                    {
                        pictureExist = true;
                        break;
                    }
                }
            }
            if (pictureExist==false)
            {
                image = "No pictures in the gallery!";
                i = 0;
            }
            else
            {
                image = "<img src=\"gallery/" + G.ID + "/frontthumb_" + Pic[i].ID + ".jpg\" /> ";
            }
                if (count < 3)
                {
                    literalGallery.Text += "<td style=\"text-align:center;\">" + G.Title + "<div style=\"height: 240px; overflow: hidden; border-radius: 5px; \"><a href=\"photogallery.aspx?gallery=" + G.ID + "\">" + image + "</a></div>";
                    literalGallery.Text += "</td>";
                }
                else if (count == 3)
                {
                    literalGallery.Text += "<td style=\"text-align:center;\">" + G.Title + "<div style=\"height: 240px; overflow: hidden; border-radius: 5px; \"><a href=\"photogallery.aspx?gallery=" + G.ID + "\">" + image + "</a></div>";
                    literalGallery.Text += "</td></tr><tr>";
                    count = 1;
                }
                count++;
                pictureExist = false;
        }  
        literalGallery.Text += "</tr>";
        literalGallery.Text += "</table>";
 
    }
}
