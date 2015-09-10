using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace AppPortal
{
    public partial class User_Detail : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool comm = new CommTool();
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                StringBuilder L = new StringBuilder();
                str = "Select * from Users a inner join User_App b on a.IDNo=b.User_ID where a.IDNo=" + Session["IDNo"];
                System.Data.DataTable dr = Main.GetDataSet(str);
                if (dr.Rows.Count > 0)
                {
                    for (int i = 0; i < dr.Rows.Count; i++)
                    {
                        L.Append("<li><a href=\"" + dr.Rows[i]["App_URL"] + "\"><img src=\"img/avatar.png\" width=\"22\" height=\"22\">" + dr.Rows[i]["App_Name"] + "</a></li>" + "\n");
                    }
                    AppsL.Text = L.ToString();

                    L.Clear();

                    L.Append("<p class=\"setting\">" + "\n");
                    L.Append("<span>E-mail Address <img src=\"img/edit.png\" alt=\"*Edit*\"></span>");
                    L.Append(""+ dr.Rows[0]["Account"] +"</p>" + "\n");
                    L.Append("<p class=\"setting\">" + "\n");
                    L.Append("<span>User Name <img src=\"img/edit.png\" alt=\"*Edit*\"></span>");
                    L.Append("" + dr.Rows[0]["User_Name"] + "</p>" + "\n");

                    SettingL.Text = L.ToString();
                }

            }
        }
    }
}