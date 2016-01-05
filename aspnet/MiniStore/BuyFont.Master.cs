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
                    Response.Redirect("StoreFair.aspx?t=10");
                }
                else
                {
                    if (Main.Scalar("select 1 from store where Store_NID='" + Request.QueryString["SN"] + "'") != "1")
                    {
                        Response.Redirect("StoreFair.aspx?t=10");
                    }
                }
               
                //string jump = "";
                //if (Comm.User_ID() == -1)
                //{
                //    jump = "../Login/m-login.aspx?done=" + HttpUtility.UrlEncode("../MiniStore/default.aspx?SN=" + Request.QueryString["SN"] + "") + "";

                //    Response.Write("<Script>window.open('" + jump + "','_self')</Script>");
                //    return;
                //} 

                menu_QR.Text = "<a href=\"Default.aspx?SN=" + Request.QueryString["SN"] + "&Intr=" + Comm.User_ID() + "\" target=\"_blank\" ><img src=\"QRcode.ashx?t=" + Comm.URL + "Default.aspx?SN=" + Request.QueryString["SN"] + "&Intr=" + Comm.User_ID() + "\" alt=\"\" class=\"QRcode\"> </a>" +
                    " <a class=\"line\" href=\"http://line.naver.jp/R/msg/text/?" + Comm.URL + "Default.aspx?SN=" + Request.QueryString["SN"] + "\">" +
                              " </a>";
                Main.ParaClear();
                Main.ParaAdd("@SN", Request.QueryString["SN"].ToString(), System.Data.SqlDbType.NVarChar);

                LSinfo.Text = "<li class=\"SandTitle PCright\"> " + Main.Scalar("Select Store_Name from Store_info where Store_ID in (select IDNo from Store where Store_NID=@SN )") + " </li>" +
                    "<li class=\"PCright\"><a href=\"SInfo.aspx?SN=" + Request.QueryString["SN"] + "\">微店資訊</a></li>" +
                    "<li class=\"PCright\"><a href='Order_history.aspx?SN=" + Request.QueryString["SN"] + "'>購買紀錄</a></li>" +
                    "<li class=\"PCright\"><a href=\"default.aspx?SN=" + Request.QueryString["SN"] + "\">回首頁</a></li>";

                Main.ParaClear();
                Main.ParaAdd("@SN", Request.QueryString["SN"].ToString(), System.Data.SqlDbType.NVarChar);



                Store_Name.Text = "<div class=\"iapplogo\"></div>" +
           "  <a href=\"SInfo.aspx?SN=" + Request.QueryString["SN"] + "\"><div><h3 class=\"FixTitle\">" + Main.Scalar("Select Store_Name from Store_info where Store_ID in (select IDNo from Store where Store_NID=@SN )") + "</h3></div></a>";


                if (Comm.User_ID() == -1)
                {
                    //未登入
                    L_MyStore.Text = "   <li><a href=\"JoinAs.aspx\">打造行動微店</a></li>" +
                                     "   <li class=\"disabled\">加入行動分店</li>" +
                                     "   <li><a href=\"www.iapp-media.com\">微店市集</a></li> " +
                   "   <li><a href='../Login/me/m-profile.aspx?done=" + HttpUtility.UrlEncode("../../MiniStore/default.aspx?SN=" + Request.QueryString["SN"]) + "'> 個人檔案</a></li> ";
                }
                else
                {
                    if (Main.Scalar("select 1 from store where Store_NID = '" + Request.QueryString["SN"] + "' and User_ID='" + Comm.User_ID() + "' ") != "")
                    {
                        // 已登入(管理者)
                        L_MyStore.Text = "  <li><a href=\"http://www.iapp-media.com/StoreMana/\">我的微店後台 <span>(" + Main.Scalar("select Store_Name from Store_info where Store_ID in (select IDNo from Store where User_ID=" + Comm.User_ID() + ")") + ")</span></a></li>" +
                                         "  <li><a href=\"http://www.iapp-media.com/MiniStore/StoreFair.aspx?t=10\">微店市集</a></li> " +
                                         "  <li><a href='../Login/me/m-profile.aspx?done=" + HttpUtility.UrlEncode("../../MiniStore/default.aspx?SN=" + Request.QueryString["SN"]) + "'> 個人檔案</a></li> ";
                        lilogout.Visible = true;
                    }
                    else
                    {
                        // 已登入(非管理者)
                        if (Main.Scalar("Select count(1) from store where User_ID='" + Comm.User_ID() + "' ") == "0")
                        {
                            L_MyStore.Text = "   <li><a onclick=\"LeftMenuJump(1)\">打造行動微店</a></li>";
                        }
                        else
                        {
                            L_MyStore.Text = "   <li><a onclick=\"LeftMenuJump(2)\">打造行動微店</a></li>";
                        }
                        //<li><a href=\"JoinAs.aspx\">打造行動微店</a></li>
                        L_MyStore.Text += "  <li class=\"disabled\">加入行動分店</li>" +
                              "  <li><a href=\"http://www.iapp-media.com/MiniStore/StoreFair.aspx?t=10\">微店市集</a></li> " +
                              "  <li><a href='../Login/me/m-profile.aspx?done=" + HttpUtility.UrlEncode("../../MiniStore/default.aspx?SN=" + Request.QueryString["SN"]) + "'> 個人檔案</a></li> ";
                        lilogout.Visible = true;
                    }
                }
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "writeUrl();", true);

        }

        protected void LBLogout_Click(object sender, EventArgs e)
        {
            if (Comm.DeleCoookie("iapp_uid") == 1)
            {
                Response.Write("<Script>window.open('" + "../Login/m-login.aspx?done=" + HttpUtility.UrlEncode("../Ministore/default.aspx?SN=" + Request.QueryString["SN"] + "") + "&jump=store','_self')</Script>");

            }
        }
    }
}