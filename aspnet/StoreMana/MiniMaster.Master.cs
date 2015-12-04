using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreMana.Mini
{
    public partial class MiniMaster : System.Web.UI.MasterPage
    {
        JDB Main =new JDB();
        CommTool Comm = new CommTool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 

                //asdasdasdasdasd
                if (Comm.Store_ID() == -1)
                {
                    Response.Write("<Script>window.open('" + "../Login/m-login.aspx?s=1&done=" + HttpUtility.UrlEncode("../StoreMana/default.aspx") + "&jump=store','_self')</Script>");
                }

                Main.ParaClear();
                Main.ParaAdd("@SID", Comm.Store_ID(), System.Data.SqlDbType.Int);
                if (Main.Scalar("Select isnull(sum(ckStep),0) from Store_info where store_id=@SID") == "0")
                {
                    Response.Redirect("ThreeOpen.aspx"); 
                } 
                Store_Name.Text = Main.Scalar("Select Store_Name from store_info where Store_ID=@SID");
                string SNID = Main.Scalar("Select Store_NID from Store where idno=@SID");
                menu_QR.Text = "<a href=\"" + Comm.MiStoreUrl + "Default.aspx?SN=" + SNID + "&Intr=" + Comm.User_ID() + "\" target=\"_blank\" ><img src=\"QRcode.ashx?t=" + Comm.MiStoreUrl + "Default.aspx?SN=" + SNID + "&Intr=" + Comm.User_ID() + "\" alt=\"\" class=\"QRcode\"> </a>" +
                    "<a href=\"http://line.naver.jp/R/msg/text/?" + Comm.MiStoreUrl + "Default.aspx?SN=" + SNID + "\"> " +
                     "           <img src=\"img/lineicon.png\" alt=\"用LINE傳送\" class=\"line\" /> </a>";
                
                LGoMini.Text = "<li><a href=\"../../MiniStore/Default.aspx?SN=" + SNID + "\"><span class=\"glyphicon glyphicon-home\" aria-hidden=\"true\"></span>前往我的iApp微店</a></li>";
            }
        }

        protected void LBLogout_Click(object sender, EventArgs e)
        {
            if (Comm.DeleCoookie("iapp_sid") == 1)
            {
                Response.Write("<Script>window.open('" + "../Login/m-login.aspx?s=1&done=" + HttpUtility.UrlEncode("../StoreMana/default.aspx") + "&jump=store','_self')</Script>"); 
            } 
        }
    }
}