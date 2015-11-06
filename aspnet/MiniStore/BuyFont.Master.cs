using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniStore
{
    public partial class BuyFont : System.Web.UI.MasterPage
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Comm.DeleCoookie("iapp_uid");
                //  Comm.SaveCookie("iapp_uid", "2"); 
                string jump = "";
                if (Comm.User_ID() == -1)
                {
                    jump = "../Login/m-login.aspx?done=" + HttpUtility.UrlEncode("../MiniStore/default.aspx?SN=" + Request.QueryString["SN"] + "") + "";

                    Response.Write("<Script>window.open('" + jump + "','_self')</Script>");
                    return;
                    //System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String",
                    //    "if(confirm('請先登入')){window.open('" + jump + "','_self');}else{window.open('" + jump + "','_self');}", true); 
                }

                if (Request.QueryString["SN"] == null)
                {
                    Response.Redirect("Default.aspx?SN=OfficACC"); 
                }
                else
                {
                    if (Main.Scalar("select 1 from store where Store_NID='" + Request.QueryString["SN"] + "'") != "1")
                    {
                        Response.Redirect("Default.aspx?SN=OfficACC");
                    }
                }
                LCarLink.Text = " <a href=\"Buy_Ctrl.aspx?SN=" + Request.QueryString["SN"] + "\"> <img class=\"back-top\" src=\"img/cart.png\" /> </a>";

                jump = "../Login/m-login.aspx?s=1&done=" + HttpUtility.UrlEncode("../StoreMana/default.aspx") + "";

                Store_Name.Text = Main.Scalar("Select Store_Name from Store_info where Store_ID in (select IDNo from Store where Store_NID=@SN )");

                L_MyStore.Text = " <li class='SandTitle'>我的帳戶</li>" +
                      " <li><a href='../Login/me/m-profile.aspx?done=" + HttpUtility.UrlEncode("../../MiniStore/default.aspx?SN=" + Request.QueryString["SN"]) + "'> 編輯會員資料</a></li> " +
                      " <li><a href='Order_history.aspx?SN=" + Request.QueryString["SN"] + "'>訂單查詢</a></li>";


            }
        }

        protected void LBLogout_Click(object sender, EventArgs e)
        {
            if (Comm.DeleCoookie("iapp_uid") == 1)
            {
                Response.Write("<Script>window.open('" + "../Login/m-login.aspx?s=1&done=" + HttpUtility.UrlEncode("../Ministore/default.aspx?SN=" + Request.QueryString["SN"] + "") + "','_self')</Script>");
            
            }
        }
        protected void BT_SNAME_Click(object sender, EventArgs e)
        {
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
                    Main.NonQuery("update Store set Store_No=@Store_No where idno=@SID");
                    Main.NonQuery("insert into Store_info (Store_ID,Store_Name) values(@SID,@Store_Name)");
                    Comm.SaveCookie("iapp_sid", SID);
                }
                if (SID != "")
                {
                    Response.Redirect(HttpUtility.UrlDecode(HttpUtility.UrlEncode("../Ministore/default.aspx?SN=" + Request.QueryString["SN"] + "")));
                }
            }
        }
    }
}