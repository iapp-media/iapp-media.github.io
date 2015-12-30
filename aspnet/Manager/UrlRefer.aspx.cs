using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrlRefer : System.Web.UI.Page
{
    JDB Main = new JDB(System.Configuration.ConfigurationManager.AppSettings.Get("Database2")); 
    string Constr = System.Configuration.ConfigurationManager.AppSettings.Get("Database2");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LB1.Text = Main.Scalar("select count(1) from UrlRefer");

            L.Text = "select fromurl ,tourl,date  from UrlRefer";

            SD.ConnectionString = Constr;
            SD.SelectCommand = L.Text;
            GV.DataSourceID = SD.ID;
        }
    }
}