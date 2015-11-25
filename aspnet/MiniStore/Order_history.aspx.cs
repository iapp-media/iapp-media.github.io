﻿using System;
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

                Lbonus.Text = Main.Scalar("select point from Bonuspoint where Store_ID in (select IDNo from Store where Store_NID=@SNID) and User_ID=@UID ");


                //L.Text = "Select a.IDNo,d.Memo,c.Product_Name,b.AMT,a.Order_No,b.Total,CONVERT(varchar(12),a.Creat_Date, 111) CDate from Orders a " +
                //         " inner join Order_Content b on a.IDNo=b.Order_ID" +
                //         " inner join Product c on b.Item_ID=c.IDNo" +
                //         " inner join (select Memo,Status from def_Status where Title='Order_STA') d on d.Status=a.Status" +
                //         " Where a.Customer_ID='" + Comm.User_ID() + "'  and DATEDIFF(MONTH,a.Creat_Date,getdate()) < 3 ";
                L.Text = "Select IDNo,Order_No,CONVERT(varchar(12),Creat_Date, 111) CDate,b.Memo,Total_AMT " +
                    ",(select top 1 FilePath from Product_Img where Product_ID in ( select top 1 Item_ID from Order_Content where Order_Content.Order_ID=a.IDNo ) ) FilePath from Orders a " +
                         "inner join (select Memo,Status from def_Status where Title='Order_STA') b on a.Status=b.Status " +
                " Where a.Customer_ID='" + Comm.User_ID() + "'  and DATEDIFF(MONTH,a.Creat_Date,getdate()) < 3 ";
                SD1.SelectCommand = L.Text;
                SD1.ConnectionString = Main.ConnStr;
                RP1.DataSourceID = SD1.ID;
            }
        }

        protected void BT_Search_Click(object sender, EventArgs e)
        {
            //   L.Text = "Select a.IDNo,d.Memo,c.Product_Name,b.AMT,a.Order_No,b.Total,CONVERT(varchar(12),a.Creat_Date, 111) CDate from Orders a " +
            //" inner join Order_Content b on a.IDNo=b.Order_ID" +
            //" inner join Product c on b.Item_ID=c.IDNo" +
            //" inner join (select Memo,Status from def_Status where Title='Order_STA') d on d.Status=a.Status" +
            //" Where a.Customer_ID='" + Comm.User_ID() + "'  ";

            L.Text = "Select IDNo,Order_No,CONVERT(varchar(12),Creat_Date, 111) CDate,b.Memo,Total_AMT " +
                ",(select top 1 FilePath from Product_Img where Product_ID in ( select top 1 Item_ID from Order_Content where Order_Content.Order_ID=a.IDNo ) ) FilePath from Orders a " +
                 "inner join (select Memo,Status from def_Status where Title='Order_STA') b on a.Status=b.Status " +
            " Where a.Customer_ID='" + Comm.User_ID() + "'  and DATEDIFF(MONTH,a.Creat_Date,getdate()) < 3 ";
            if (DLDate.SelectedValue != null)
            {
                L.Text += " and DATEDIFF(MONTH,a.Creat_Date,getdate()) " + DLDate.SelectedValue + "3";
            }
            if (DL_Payment.SelectedValue != "")
            {
                L.Text += " and Payment_ID='" + DL_Payment.SelectedValue + "'";
            }
            if (TB_Search.Text != "")
            {
                L.Text += " and Product_Name like '%" + TB_Search.Text + "'%";
            }
            SD1.SelectCommand = L.Text;
            SD1.ConnectionString = Main.ConnStr;
            RP1.DataSourceID = SD1.ID;
        }
        public string ShowDetail(object IDNO)
        {
            if (IDNO.ToString().Length > 0)
                return "Order_prn.aspx?entry=" + IDNO + "&SN=" + Request.QueryString["SN"] + "";
            else
                return "";
        }
    }
}