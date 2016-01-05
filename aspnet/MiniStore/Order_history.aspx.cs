using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniStore
{
    public partial class Order_history : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string jump = "";
                if (Comm.User_ID() == -1)
                {
                    jump = "../Login/m-login.aspx?done=" + HttpUtility.UrlEncode("../MiniStore/Order_history.aspx") + "&jump=store";
                    Response.Write("<Script>alert('請先登入');window.open('" + jump + "','_self')</Script>");
                    return;
                }


                Main.FillDDP(DL_Payment, "Select Memo,Status from def_Status where Col_Name='Payment'", "Memo", "Status");

                Main.ParaClear();
                Main.ParaAdd("@SNID", Request.QueryString["SN"], System.Data.SqlDbType.NVarChar);
                Main.ParaAdd("@UID", Comm.User_ID(), System.Data.SqlDbType.NVarChar);

                Lbonus.Text = Main.Scalar("select isnull(sum(point),0) from Bonuspoint where Store_ID in (select IDNo from Store where Store_NID=@SNID) and User_ID=@UID ");

 
                L.Text = "Select IDNo,Order_No,CONVERT(varchar(12),Creat_Date, 111) CDate,b.Memo,Total_AMT " +
                    ",(select top 1 FilePath from Product_Img where Product_ID in ( select top 1 Item_ID from Order_Content where Order_Content.Order_ID=a.IDNo ) ) FilePath from Orders a " +
                         "inner join (select Memo,Status from def_Status where Title='Order_STA') b on a.Status=b.Status " +
                " Where a.Customer_ID='" + Comm.User_ID() + "'  and DATEDIFF(MONTH,a.Creat_Date,getdate()) < 3 and a.Store_ID in (select IDNo from Store where Store_NID='" + Request.QueryString["SN"] + "')";
                SD1.ConnectionString = Main.ConnStr;
                SD1.SelectCommand = L.Text;
                RP1.DataSourceID = SD1.ID;
                ShowNoData(L.Text);
            }
          
        }

        protected void BT_Search_Click(object sender, EventArgs e)
        {

            str = "Select IDNo,Order_No,CONVERT(varchar(12),Creat_Date, 111) CDate,b.Memo,Total_AMT " +
                ",(select top 1 FilePath from Product_Img where Product_ID in ( select top 1 Item_ID from Order_Content where Order_Content.Order_ID=a.IDNo ) ) FilePath from Orders a " +
                 "inner join (select Memo,Status from def_Status where Title='Order_STA') b on a.Status=b.Status " +
            " Where a.Customer_ID='" + Comm.User_ID() + "'  and DATEDIFF(MONTH,a.Creat_Date,getdate()) < 3 and a.Store_ID in (select IDNo from Store where Store_NID='" + Request.QueryString["SN"] + "')";
            
            if (DLDate.SelectedValue != null)
            {
                str += " and DATEDIFF(MONTH,a.Creat_Date,getdate()) " + DLDate.SelectedValue + "3";
            }
            if (DL_Payment.SelectedValue.ToString() != "")
            {
                str += " and Payment_ID='" + DL_Payment.SelectedValue + "'";
            }
            if (TB_Search.Text != "")
            {
                str += " and IDNo in (Select distinct a.Order_ID from Order_Content a inner join product b on a.Item_ID=b.IDNo where b.Product_Name like '%" + TB_Search.Text + "%') ";
               // L.Text += " and Product_Name like '%" + TB_Search.Text + "%'";
            }
            L.Text = str;
            SD1.ConnectionString = Main.ConnStr;
            SD1.SelectCommand = L.Text;
            RP1.DataSourceID = SD1.ID;
            ShowNoData(L.Text);
        }
        void ShowNoData(string aa) {
            System.Data.DataTable DT = Main.GetDataSetNoNull(aa);
            if (DT.Rows.Count > 0)
            { 
             
            }
            else {
                Response.Write("<script>alert('查無資料')</script>");
                 
            }
        }
        protected void RP1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal LIDNO = (Literal)e.Item.FindControl("LIDNO");
                if (Main.Scalar("select sum(1) from Orders where idno=" + LIDNO.Text + " and Payment_ID='5' ") == "1")
                {
                    if (Main.Scalar("select count(1) from Orders where idno=" + LIDNO.Text + " and Payment_ID='5' and status=1") != "1")
                    {
                        Session["OrderID"] = LIDNO.Text;
                        Response.Redirect("Buy_CtrlR.aspx?SN=" + Request.QueryString["SN"]);
                    }
                    else
                    {
                        Session["Order_entry"] = LIDNO.Text;
                        Response.Redirect("Order_prn.aspx?SN=" + Request.QueryString["SN"]);
                    }
                }
                else
                {
                    Session["Order_entry"] = LIDNO.Text;
                    Response.Redirect("Order_prn.aspx?SN=" + Request.QueryString["SN"]);
                }
                
                 

            
            }
        }
         

         
        //public string ShowDetail(object IDNO)
        //{
        //    if (IDNO.ToString().Length > 0)
        //        return "Order_prn.aspx?entry=" + IDNO + "&SN=" + Request.QueryString["SN"] + "";
        //    else
        //        return "";
        //}
    }
}