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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Main.FillDDP(DL_Payment, "Select Memo,Status from def_Status where Col_Name='Payment'", "Memo", "Status");
                //L.Text = "Select a.IDNo,d.Memo,c.Product_Name,b.AMT,a.Order_No,b.Total,CONVERT(varchar(12),a.Creat_Date, 111) CDate from Orders a " +
                //         " inner join Order_Content b on a.IDNo=b.Order_ID" +
                //         " inner join Product c on b.Item_ID=c.IDNo" +
                //         " inner join (select Memo,Status from def_Status where Title='Order_STA') d on d.Status=a.Status" +
                //         " Where a.Customer_ID='" + Comm.User_ID() + "'  and DATEDIFF(MONTH,a.Creat_Date,getdate()) < 3 ";
                L.Text = "Select IDNo,Order_No,CONVERT(varchar(12),Creat_Date, 111) CDate,b.Memo,Total_AMT  from Orders a " +
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

            L.Text = "Select IDNo,Order_No,CONVERT(varchar(12),Creat_Date, 111) CDate,b.Memo,Total_AMT  from Orders a " +
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