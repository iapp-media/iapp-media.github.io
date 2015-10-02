using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wedding
{
    public partial class verify : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BT_Send_Click(object sender, EventArgs e)
        {
            string tmp = "";
            if (T_No.Text == "") { tmp += ",序號"; }
            //if (T_Email.Text == "") { tmp += ",註冊信箱"; }
            if (tmp != "") { Response.Write("<Script>alert('請輸入" + tmp.Substring(1) + "。');</Script>"); return; }

            if (Main.Scalar("select 1 from Couple  where IDNu='" + T_No.Text + "'") == "1")
            {
               int c= Main.NonQuery("Update Couple set User_id='" + Comm.User_ID() + "' where IDNu='" + T_No.Text + "'");
               if (c > 0)
               {
                   Response.Write("<Script>window.open('Maker.aspx','_self')</Script>");
               }
            }
            



        }
    }
}