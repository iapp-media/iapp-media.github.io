using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MiniStore
{
    public partial class StoreFront : System.Web.UI.MasterPage
    {
        CommTool Comm = new CommTool();
        JDB Main = new JDB();

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
                    if (Main.Scalar("select 1 from store where Store_NID='" + Request.QueryString["SN"].ToString() + "'") != "1")
                    {
                        Response.Redirect("Default.aspx?SN=OfficACC");
                    }
                }

                //
                if (Request.QueryString["Intr"] != null && Comm.User_ID() != -1)
                {
                    string a = Main.Scalar("select IDNo from Store where Store_NID='" + Request.QueryString["SN"] + "' ");


                    if (Main.Scalar("select 1 from Store_Customer where  store_id='" + a + "' and Customer_ID='" + Comm.User_ID() + "'") == "")
                    {
                        if (Main.Scalar("Select 1 from users where IDNo='" + Request.QueryString["Intr"] + "'") != "")
                        {
                            Main.ParaClear();
                            Main.ParaAdd("@Store_ID", Main.Cint2(a), SqlDbType.Int);
                            Main.ParaAdd("@FromUser_ID", Main.Cint2(Request.QueryString["Intr"].ToString()), SqlDbType.NVarChar);
                            Main.ParaAdd("@Customer_ID", Comm.User_ID(), SqlDbType.Int);

                            Main.NonQuery(" insert Store_Customer(Store_ID, FromUser_ID, Customer_ID) values (@Store_ID, @FromUser_ID, @Customer_ID)");

                        }
                    }
                }
                //string jump = "";
                //if (Comm.User_ID() == -1)
                //{
                //    jump = "../Login/m-login.aspx?done=" + HttpUtility.UrlEncode("../MiniStore/default.aspx?SN=" + Request.QueryString["SN"] + "") + "";
                //    Response.Write("<Script>window.open('" + jump + "','_self')</Script>");
                //    return;
                //}

                menu_QR.Text = "<a href=\"" + Comm.URL + "Default.aspx?SN=" + Request.QueryString["SN"] + "&Intr=" + Comm.User_ID() + "\" target=\"_blank\" ><img src=\"QRcode.ashx?t=" + Comm.URL + "Default.aspx?SN=" + Request.QueryString["SN"] + "&Intr=" + Comm.User_ID() + "\" alt=\"\" class=\"QRcode\"> </a>";


                LCarLink.Text = " <a id=\"Buycar\"  href=\"Buy_Ctrl.aspx?SN=" + Request.QueryString["SN"] + "\">" +
                    " <img class=\"back-top\" src=\"img/cart.png\" /><span/>" +
                    Main.Scalar("Select case when COUNT(1) > 99 then '99+' else Convert(varchar,COUNT(1) ) end from ShoppingCart where User_ID='" + Comm.User_ID() + "' and Store_ID in ( select IDNo from Store where Store_NID='" + Request.QueryString["SN"] + "')") +
                    "</span> </a>";


                L_MyStore.Text = " <li class='SandTitle'>我的帳戶</li>" +
                 " <li><a href='../Login/me/m-profile.aspx?done=" + HttpUtility.UrlEncode("../../MiniStore/default.aspx?SN=" + Request.QueryString["SN"].ToString()) + "'> 編輯會員資料</a></li> " +
                 " <li><a href='Order_history.aspx?SN=" + Request.QueryString["SN"].ToString() + "'>訂單查詢</a></li>";



                Main.ParaClear();
                Main.ParaAdd("@SN", Request.QueryString["SN"].ToString(), SqlDbType.NVarChar);

                Store_Name.Text = "<a class=\"navbar-brand\" href=\"default.aspx?sn=" + Request.QueryString["SN"] + "\"> <img class=\"iapplogo\" src=\"img/ministorelogo.png\" />" +
           " </a><div><h3 class=\"FixTitle\">" + Main.Scalar("Select Store_Name from Store_info where Store_ID in (select IDNo from Store where Store_NID=@SN )") + "</h3></div>";

                DataTable DT = Main.GetDataSetNoNull("select IDNo,Cate_Name from Product_Cate  where IDNo in ( " +
                                                     "select Cate_ID from Product where Store_ID in (select IDNo from Store where Store_NID=@SN ))");
                if (DT.Rows.Count > 0)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        L_Cate.Text += " <div class=\"swiper-slide\"><a href=\"Default.aspx?SN=" + Request.QueryString["SN"] + "&C=" + DT.Rows[i]["IDNo"] + "\" style=\"color: white\">" + DT.Rows[i]["Cate_Name"] + "</a></div> ";
                    }
                } 
            }
        }

        protected void LBLogout_Click(object sender, EventArgs e)
        {
            if (Comm.DeleCoookie("iapp_uid") == 1)
            {
                Response.Write("<Script>window.open('" + "../Login/m-login.aspx?done=" + HttpUtility.UrlEncode("../Ministore/default.aspx?SN=" + Request.QueryString["SN"] + "") + "','_self')</Script>");

                //  Response.Write("<Script>window.open('" + "../Login/m-login.aspx?s=1&done=" + HttpUtility.UrlEncode("../Ministore/default.aspx?SN=" + Request.QueryString["SN"] + "") + "','_self')</Script>");

            }
        }

     }
}