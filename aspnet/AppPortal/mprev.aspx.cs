using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppPortal
{
    public partial class mprev : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Comm.IsNumeric(Request.QueryString["i"])) {
                string App_Url = Main.Scalar("Select App_Url from User_App where IDNo=" + Request.QueryString["i"]);
                if (App_Url != "")
                {
                    LApp.Text = " <embed class=\"iframe\" src=\"" + App_Url + "\"></embed>";
                }
            }
        }
    }
}