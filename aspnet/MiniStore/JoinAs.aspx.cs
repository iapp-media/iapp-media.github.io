using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniStore
{
    public partial class JoinAs : System.Web.UI.Page
    {
        CommTool Comm = new CommTool();
        JDB Main = new JDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Comm.User_ID() == -1)
                {
                    string jump = "";
                    jump = "../Login/m-login.aspx?done=" + HttpUtility.UrlEncode("../MiniStore/JoinAs.aspx") + "&jump=store";
                    Response.Write("<Script>alert('請先登入');window.open('" + jump + "','_self')</Script>");
                    return;
                }
                string SID = "";
                SID = Main.Scalar("select idno from Store where User_ID='" + Comm.User_ID() + "'");
                if (SID != "")
                {
                    Session["Store_ID"] = SID;
                    Response.Redirect(HttpUtility.UrlDecode(HttpUtility.UrlEncode("../StoreMana/default.aspx")));
                }
            }
        }
        protected void BT_SNAME_Click(object sender, EventArgs e)
        {
            if (CB.Checked == false)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "alert('須同意服務條款後才能註冊');", true);
                return;
            }
            if (TB_SNAME.Text.Trim() == "")
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "alert('請輸入您的微店店名');", true);
                return;
            }

            if (Comm.User_ID() != -1)
            {
                Main.ParaClear();
                Main.ParaAdd("@UID", Comm.User_ID(), System.Data.SqlDbType.Int);

                Main.NonQuery("Insert into Store (User_ID,Creat_Date) values " +
                 " (@UID,getdate())   ");
                string SID = "";
                SID = Main.Scalar("select IDNo from Store where User_ID='" + Comm.User_ID() + "'");
                if (SID != "")
                {
                    Main.ParaClear();
                    Main.ParaAdd("@SID", Main.Cint2(SID), System.Data.SqlDbType.Int);
                    Main.ParaAdd("@Store_No", Comm.StoreSN(Main.Cint2(SID)), System.Data.SqlDbType.NVarChar);
                    Main.ParaAdd("@Store_Name", TB_SNAME.Text, System.Data.SqlDbType.NVarChar);
                    Main.NonQuery("update Store set Store_No=@Store_No,Store_NID=@Store_No where idno=@SID");
                    Main.NonQuery("insert into Store_info (Store_ID,Store_Name) values(@SID,@Store_Name)");
                    Comm.SaveCookie("iapp_sid", SID);
                }
                if (SID != "")
                {
                    Response.Redirect(HttpUtility.UrlDecode(HttpUtility.UrlEncode("../StoreMana/default.aspx")));
                }
            }
        }

    }
}
