using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MiniStore
{
    public partial class P_MSG : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["entry"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                DataTable DT = Main.GetDataSetNoNull("Select a.Product_Name,a.Price,b.FilePath from product a inner join Product_Img b on a.IDNo=b.Product_ID and b.Num=1 where a.idno='" + Request.QueryString["entry"] + "'");
                if (DT.Rows.Count > 0)
                {
                    L_Puc.Text = "<div class='col-xs-4 leftbox'>" +
                                 "<img src='" + DT.Rows[0]["FilePath"] + "' alt='Alternate Text' class='imgH' />" +
                                 "</div>" +
                                 "<div class='rightbox col-xs-8'>" +
                                 "    <h4>" + DT.Rows[0]["Product_Name"] + "</h4>" +
                                 "    <span>$" + DT.Rows[0]["Price"] + "</span>" +
                                 "    <p></p>" +
                                 "</div>";
                }
                L_Back.Text = "<a href=\"Buy_detail.aspx?entry=" + Request.QueryString["entry"] + "&SN=" + Request.QueryString["SN"] + "\"> <img src=\"img/backarrow.png\" alt=\"Alternate Text\" class=\"col-xs-2\" /></a> ";
                L.Text = "select Question,isnull(Ans,'尚未回覆') Ans,(CONVERT(nvarchar, DATEDIFF(DAY,CreatDate,getdate()))+'天前') agoday from product_msg where product_id='" + Request.QueryString["entry"] + "' order by CreatDate DESC ";
            }


            SD1.SelectCommand = L.Text;
            SD1.ConnectionString = Main.ConnStr;
            RP1.DataSourceID = SD1.ID;
        }

        protected void btsend_Click(object sender, ImageClickEventArgs e)
        {
            string jump = "";
            if (Comm.User_ID() == -1)
            {
                jump = "../Login/m-login.aspx?done=" + HttpUtility.UrlEncode("../MiniStore/p_msg.aspx") + "&jump=store";
                Response.Write("<Script>alert('請先登入');window.open('" + jump + "','_self')</Script>");
                return;
            }

            if (tbQuen.Text != "")
            {
                if (tbQuen.Text == "")
                {
                   System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "alert('請填選商店類別');", true);
                    return;
                }

                Main.ParaClear();
                Main.ParaAdd("@Product_ID", Main.Cint2(Request.QueryString["entry"].ToString()), System.Data.SqlDbType.Int);
                Main.ParaAdd("@Question", tbQuen.Text, System.Data.SqlDbType.NVarChar);

                Main.NonQuery("insert into product_msg (Product_ID, Question, CreatDate) values " +
                    "(@Product_ID, @Question, getdate())");

                SD1.SelectCommand = L.Text;
                SD1.ConnectionString = Main.ConnStr;
                RP1.DataSourceID = SD1.ID;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string jump = "";
            if (Comm.User_ID() == -1)
            {
                jump = "../Login/m-login.aspx?done=" + HttpUtility.UrlEncode("../MiniStore/p_msg.aspx") + "&jump=store";
                Response.Write("<Script>alert('請先登入');window.open('" + jump + "','_self')</Script>");
                return;
            }

            if (tbQuen.Text != "")
            {
                if (tbQuen.Text == "")
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "alert('請填選商店類別');", true);
                    return;
                }

                Main.ParaClear();
                Main.ParaAdd("@Product_ID", Main.Cint2(Request.QueryString["entry"].ToString()), System.Data.SqlDbType.Int);
                Main.ParaAdd("@Question", tbQuen.Text, System.Data.SqlDbType.NVarChar);

                Main.NonQuery("insert into product_msg (Product_ID, Question, CreatDate) values " +
                    "(@Product_ID, @Question, getdate())");

                SD1.SelectCommand = L.Text;
                SD1.ConnectionString = Main.ConnStr;
                RP1.DataSourceID = SD1.ID;
            }
        } 
    }
}