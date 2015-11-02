using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wedding
{
    public partial class Couple_list : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CID"] == null) { Response.Write("<Script>alert('連線逾時，請重新登入。');window.open('Login.aspx','_self');</Script>"); return; }
            }
            L.Text = " select * from Couple where Company_id='" + Session["CID"].ToString() + "'";

            SD.ConnectionString = Main.ConnStr;
            SD.SelectCommand = L.Text;
            GV.DataSourceID = SD.ID;
        }
    }
}