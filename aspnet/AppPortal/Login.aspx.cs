using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AppPortal
{
    public partial class Login : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool comm = new CommTool();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Main.ParaClear();
            Main.ParaAdd("@Account", accBox.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Pw", pwBox.Text, System.Data.SqlDbType.NVarChar);

            string sql = "Select * from Users where Account=@Account And Password=@Pw";
            DataTable dr = Main.GetDataSet(sql);
            if ((dr.Rows.Count > 0))
            {
                Session["IDNo"] = dr.Rows[0]["IDNo"];
                Session["User_Name"] = dr.Rows[0]["User_Name"];
                //Session["OK"] = "OK";
                //comm.SaveCookie(Me, "ThisPC", Session["IDNo"])
                //Session["OK"] = "OK"
                // Response.Redirect("Default.aspx")
                Response.Write("<Script>window.open('portal.aspx','_top')</Script>");
                Response.End();


            }
            else
            {
                Response.Write("<script>alert('帳號密碼錯誤')</script>");
            }
        }
    }
}