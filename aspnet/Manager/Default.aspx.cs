using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    JDB Main = new JDB(System.Configuration.ConfigurationManager.AppSettings.Get("Database2"));
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LUserCt.Text = Main.Scalar("select count(1) from users");
            LProductCt.Text = Main.Scalar("select count(1) from product where Tmp_IDNo>0");
            LUrlCt.Text = Main.Scalar("select count(1) from UrlRefer");
            LStoreCt.Text = Main.Scalar("select count(1) from Store_info where ckStep=1");
        }
    }
}