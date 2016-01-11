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
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Comm.User_ID() == -1)
            {
                Response.Write("<Script>window.open('" + "../Login/m-login.aspx?done=" + HttpUtility.UrlEncode("../StoreMana/default.aspx") + "&jump=store','_self')</Script>");
            }
            else
            {
                Session["Store_ID"] = Main.Scalar("select idno from Store where User_ID='" + Comm.User_ID() + "'");
                if (Main.Scalar("Select 1 from Store_info where Store_ID='" + Session["Store_ID"] + "' and lv in ('1','9')") == "1")
                {
                    licustmana.Visible = true;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                

                if (Session["Store_ID"] == null)
                {
                    Response.Write("<Script>window.open('" + "../Login/m-login.aspx?done=" + HttpUtility.UrlEncode("../StoreMana/default.aspx") + "&jump=store','_self')</Script>");
                }
                else
                { 
                    Main.ParaClear();
                    Main.ParaAdd("@SID", Main.Cint2(Session["Store_ID"].ToString()), System.Data.SqlDbType.Int);
                    if (Main.Scalar("Select isnull(sum(ckStep),0) from Store_info where store_id=@SID") == "0")
                    {
                        Response.Redirect("ThreeOpen.aspx");
                    }
                    Store_Name.Text = Main.Scalar("Select Store_Name from store_info where Store_ID=@SID");
                    string SNID = Main.Scalar("Select Store_NID from Store where idno=@SID");
                    menu_QR.Text = "<a href=\"" + Comm.MiStoreUrl + "Default.aspx?SN=" + SNID + "&Intr=" + Comm.User_ID() + "\" target=\"_blank\" ><img src=\"QRcode.ashx?t=" + Comm.MiStoreUrl + "Default.aspx?SN=" + SNID + "&Intr=" + Comm.User_ID() + "\" alt=\"\" class=\"QRcode\"> </a>" +
                        "<a  class=\"line\" href=\"http://line.naver.jp/R/msg/text/?" + Comm.MiStoreUrl + "Default.aspx?SN=" + SNID + "\"> " +
                         " </a>";

                    LGoMini.Text = "<li><a href=\"../../MiniStore/Default.aspx?SN=" + SNID + "\"><span class=\"glyphicon glyphicon-home\" aria-hidden=\"true\"></span>前往我的iApp微店</a></li>";
                }
            }
        }

        protected void LBLogout_Click(object sender, EventArgs e)
        {
            if (Comm.DeleCoookie("iapp_uid") == 1)
            {
                Response.Write("<Script>window.open('" + "../Login/m-login.aspx?done=" + HttpUtility.UrlEncode("../StoreMana/default.aspx") + "&jump=store','_self')</Script>");
            }
        }
    }
}