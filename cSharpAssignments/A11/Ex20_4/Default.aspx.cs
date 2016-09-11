using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        int tmpCounter;
        
        HttpCookieCollection getCookie = Request.Cookies;

        if (getCookie.Count!=0)
        {
            tmpCounter = Convert.ToInt32(getCookie["counter"].Value);
            tmpCounter = tmpCounter + 1;
            HttpCookie cookie = new HttpCookie("counter", Convert.ToString(tmpCounter));
            cookie.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(cookie);
            Label1.Text = "Current number of visits: " + getCookie["counter"].Value;
        }
        else
        {
            HttpCookie cookie = new HttpCookie("counter", "1");
            cookie.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(cookie);
            Label1.Text = "Current number of visits: " + cookie.Value;
        }        
 
    }

}
