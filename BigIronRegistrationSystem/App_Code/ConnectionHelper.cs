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

/// <summary>
/// A collection of methods relating to database connections
/// </summary>
public class ConnectionHelper
{
	/// <summary>
	/// default constructor, initializes nothing
	/// </summary>
	public ConnectionHelper()
	{		
	}

	/// <summary>
	/// Gets a connection to a MySQL database based on the contents of web.config
	/// </summary>
	/// <returns>A connection to a MySQL database</returns>
	//public static MySqlConnection GetMySQLConnection()
	//{
	//    return new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString);
	//}

	/// <summary>
	/// Gets a connection to a SQL database based on the contents of web.config
	/// </summary>
	/// <returns>A connection to a SQL database</returns>
	public static SqlConnection GetSQLConnection()
	{
        
		return new SqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString);
	}
}
