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
using db;

public partial class ascx_MasterPage : System.Web.UI.MasterPage
{
	private bool isMainPage;
	private int firstAd;
	
	protected void Page_Load(object sender, EventArgs e)
    {
        Random R = new Random();

        RandomImage.Text = "<img src=\"images/random/" + R.Next(1, 6) + ".jpg\" alt=\"Random Image\" width=\"616\" height=\"135\" />";
        
        /*LargeBannerSqlDataSource.ConnectionString = ConnectionHelper.GetSQLConnection().ConnectionString;
		LargeBannerSqlDataSource.SelectCommand = "SELECT [ImageUrl], [NavigateUrl], [AlternateText], [Impressions] FROM [viewAds] where AdLevel = 1";
		SmallBannerSqlDataSource.ConnectionString = ConnectionHelper.GetSQLConnection().ConnectionString;
		if (isMainPage)
		{
			SmallBannerSqlDataSource.SelectCommand = "SELECT [ImageUrl], [NavigateUrl], [AlternateText], [Impressions] FROM [viewAds] where AdLevel = 2";
		}
		else
		{
			SmallBannerSqlDataSource.SelectCommand = "SELECT [ImageUrl], [NavigateUrl], [AlternateText], [Impressions] FROM [viewAds] where AdLevel = 2 or AdLevel = 3";
        }

        //DYNAMIC LINKS
        List<PageContent> DynamicMenuItems = PageContent.GetAllMenuItems();

        if (DynamicMenuItems.Count > 0)
        {
            DynLinksLiteral.Text = "<div id=\"rightNavDyn\">\n";
            foreach (PageContent PC in DynamicMenuItems)
            {
                DynLinksLiteral.Text += "<a href=\"" + PC.GenericHandlerPageName + "\">" + PC.Name + "</a>\n";
            }
            DynLinksLiteral.Text += "</div>\n";
        }

        //FAST FACT
		List<FastFact> FastFacts = (List<FastFact>)Application["FastFacts"];
		Random r = new Random();
		FastFactPlaceholder.Text = FastFacts[r.Next(0,FastFacts.Count-1)].Text;

		YearText.Text = DateTime.Now.Year.ToString();

		Random R = new Random();
		
		RandomImage.Text = "<img src=\"images/random/"+R.Next(1,6)+".jpg\" alt=\"Random Image\" width=\"616\" height=\"135\" />";

        //FEATURE
		List<Exporter> Es = Exporter.GetFeatured();
		if (Es.Count > 0)
		{
			FeaturedBioContent.Visible = true;
			FeaturedBusinessName.Visible = true;
			FeaturedLink.Visible = true;
			Exporter E = Es[R.Next(Es.Count - 1)];
			FeaturedBusinessName.Text = ""; //E.Name;
			FeaturedBioContent.Text = E.ProductDescription;
			FeaturedLink.NavigateUrl = "http://" + E.Website;
			FeaturedLink.Target = "_blank";
			FeaturedLink.Text = E.Website;
		}
		else
		{
			FeaturedBioContent.Visible = false;
			FeaturedBusinessName.Visible = false;
			FeaturedLink.Visible = false;			
		}*/
    }

	protected void Rotator_AdCreated(object sender, AdCreatedEventArgs e)
	{		
		/*string NavUrl = e.NavigateUrl;
		NavUrl = NavUrl.Replace("~/aspx/adredirector.aspx?id=", "");
		string[] parts = NavUrl.Split('&');

		if (firstAd == 0)
		{
			firstAd = Convert.ToInt32(parts[0]);
		}
		else
		{
			if (firstAd == Convert.ToInt32(parts[0]))
			{
				//Response.Write("DUP");
				Ad sub = Ad.GetNewAd(2, Convert.ToInt32(parts[0]));
				e.NavigateUrl = sub.NavigateUrl;
				e.ImageUrl = sub.ImageUrl;
				NavUrl = NavUrl.Replace("~/aspx/adredirector.aspx?id=", "");
				parts = NavUrl.Split('&');
			}
		}

		Ad A = new Ad(Convert.ToInt32(parts[0]));
		A.DisplayedCount++;
		A.Update();*/
	}

	#region properties
	public bool IsMainPage
	{
		get
		{
			return this.isMainPage;
		}
		set
		{
			this.isMainPage = value;
		}
	}
	#endregion
}
