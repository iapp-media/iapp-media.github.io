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

                string jump = "";
                if (Comm.User_ID() == -1)
                {
                    jump = "../Login/m-login.aspx?done=" + HttpUtility.UrlEncode("../MiniStore/default.aspx?SN=" + Request.QueryString["SN"] + "") + "";
                    Response.Write("<Script>window.open('" + jump + "','_self')</Script>");
                    return;
                }


                LCarLink.Text = " <a href=\"Buy_Ctrl.aspx?SN=" + Request.QueryString["SN"] + "\"> <img class=\"back-top\" src=\"img/cart.png\" /> </a>";


                L_MyStore.Text = " <li class='SandTitle'>我的帳戶</li>" +
                 " <li><a href='../Login/me/m-profile.aspx?done=" + HttpUtility.UrlEncode("../../MiniStore/default.aspx?SN=" + Request.QueryString["SN"].ToString()) + "'> 編輯會員資料</a></li> " +
                 " <li><a href='Order_history.aspx?SN=" + Request.QueryString["SN"].ToString() + "'>訂單查詢</a></li>";



                Main.ParaClear();
                Main.ParaAdd("@SN", Request.QueryString["SN"].ToString(), SqlDbType.NVarChar);

                Store_Name.Text = Main.Scalar("Select Store_Name from Store_info where Store_ID in (select IDNo from Store where Store_NID=@SN )");
                DataTable DT = Main.GetDataSetNoNull("select * from product_cate where Store_ID in (select IDNo from Store where Store_NID=@SN )");
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    L_Cate.Text += " <div class=\"swiper-slide\"><a href=\"Default.aspx?SN=" + Request.QueryString["SN"] + "&C=" + DT.Rows[i]["IDNo"] + "\" style=\"color: white\">" + DT.Rows[i]["Cate_Name"] + "</a></div> ";
                }


            }
        }

        protected void LBLogout_Click(object sender, EventArgs e)
        {
            if (Comm.DeleCoookie("iapp_uid") == 1)
            {
                Response.Write("<Script>window.open('" + "../Login/m-login.aspx?s=1&done=" + HttpUtility.UrlEncode("../Ministore/default.aspx?SN=" + Request.QueryString["SN"] + "") + "','_self')</Script>");
                //
            }
        }

        //protected void BT_SNAME_Click(object sender, EventArgs e)
        //{
        //    if (Comm.User_ID() != -1)
        //    {
        //        Main.ParaClear();
        //        Main.ParaAdd("@UID", Comm.User_ID(), System.Data.SqlDbType.Int);

        //        Main.NonQuery("Insert into Store (User_ID,Creat_Date) values " +
        //         " (@UID,getdate())   ");
        //        string SID = "";
        //        SID = Main.Scalar("select IDNo from Store where User_ID='" + Comm.User_ID() + "'");
        //        if (SID != "")
        //        {

        //            Main.ParaClear();
        //            Main.ParaAdd("@SID", Main.Cint2(SID), System.Data.SqlDbType.Int);
        //            Main.ParaAdd("@Store_No", Comm.StoreSN(Main.Cint2(SID)), System.Data.SqlDbType.NVarChar);
        //            Main.ParaAdd("@Store_Name", TB_SNAME.Text, System.Data.SqlDbType.NVarChar);
        //            Main.NonQuery("update Store set Store_No=@Store_No where idno=@SID");
        //            Main.NonQuery("insert into Store_info (Store_ID,Store_Name) values(@SID,@Store_Name)");
        //            Comm.SaveCookie("iapp_sid", SID);
        //        }
        //        if (SID != "")
        //        {
        //            Response.Redirect(HttpUtility.UrlDecode(HttpUtility.UrlEncode("../StoreMana/default.aspx")));
        //        }
        //    }
        //}
    }
}