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

public partial class Admin : System.Web.UI.MasterPage
{
	private bool useAuthenticationCheck;
	
	protected void Page_Load(object sender, EventArgs e)
    {
		/*if (useAuthenticationCheck)
		{
			if (Convert.ToInt32(Session["Authorization"]) == 0)
			{
				Response.Redirect("adminlogin.aspx?unauthorized=1");
			}
		}*/
		Page.Title = "NDTO Admin Area";
	}

	#region properties
	/*public bool UseAuthenticationCheck
	{
		get
		{
			return this.useAuthenticationCheck;
		}
		set
		{
			this.useAuthenticationCheck = value;
		}
	}*/
	#endregion
}
