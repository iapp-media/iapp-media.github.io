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

                //string jump = "";
                //if (Comm.User_ID() == -1)
                //{
                //    jump = "../Login/m-login.aspx?done=" + HttpUtility.UrlEncode("../MiniStore/default.aspx?SN=" + Request.QueryString["SN"] + "") + "";

                //    Response.Write("<Script>window.open('" + jump + "','_self')</Script>");
                //    return;
                //}

                menu_QR.Text = "<a href=\"Default.aspx?SN=" + Request.QueryString["SN"] + "&Intr=" + Comm.User_ID() + "\" target=\"_blank\" ><img src=\"QRcode.ashx?t=" + Comm.MiStoreUrl + "Default.aspx?SN=" + Request.QueryString["SN"] + "&Intr=" + Comm.User_ID() + "\" alt=\"\" class=\"QRcode\"> </a>";


                LCarLink.Text = " <a href=\"Buy_Ctrl.aspx?SN=" + Request.QueryString["SN"] + "\"> <img class=\"back-top\" src=\"img/cart.png\" /> </a>";

                Main.ParaClear();
                Main.ParaAdd("@SN", Request.QueryString["SN"].ToString(), System.Data.SqlDbType.NVarChar);

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
                Response.Write("<Script>window.open('" + "../Login/m-login.aspx?done=" + HttpUtility.UrlEncode("../Ministore/default.aspx?SN=" + Request.QueryString["SN"] + "") + "','_self')</Script>");

            }
        }
    }
}