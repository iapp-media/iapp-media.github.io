using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Login
{
    public partial class AUL : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ImgShow();
        }
        void ImgShow()
        {
            if (Main.IsNumeric(Request.QueryString["Profile"]))
            {
                str = "select * from User_App where IDNo=" + Request.QueryString["Profile"];
            }
            DataTable DT = Main.GetDataSetNoNull(str);
            if (DT.Rows.Count > 0)
            {
                showImg.Src = "UserIcon.ashx?i=" + Request.QueryString["Profile"] + "";
            }

        }
        protected void BTN_Click(object sender, EventArgs e)
        {
            if (Main.IsNumeric(Request.QueryString["Profile"]))
            {
                DoProfile();
                Response.Redirect("Profile.aspx");
                //Response.Write("<Script>window.parent.ref()</Script>");
            }
        }

        void DoProfile() {
            Main.ParaClear(); 
            Main.ParaAdd("@User_ID", Request.QueryString["Profile"], System.Data.SqlDbType.Int);
            if (Main.IsNumeric(Request.QueryString["Profile"]))
            { 
                byte[] buf = System.Convert.FromBase64String(TS.Text.Trim());
                Main.ParaAdd("@User_Icon", buf, System.Data.SqlDbType.Image);
                str = "Update Users set User_Icon=@User_Icon where IDNo=@User_ID";
                Main.NonQuery(str);
            }
        }
    }
}