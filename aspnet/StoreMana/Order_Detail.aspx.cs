using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StoreMana.Mini
{
    public partial class Order_Detail : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        DataTable d = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Comm.IsNumeric(Request.QueryString["entry"]))
                {
                          L1.Text = "Select a.IDNo,d.Memo,c.Product_Name,b.AMT,a.Order_No,b.Total,CONVERT(varchar(12),a.Creat_Date, 111) CDate from Orders a " +
         " inner join Order_Content b on a.IDNo=b.Order_ID" +
         " inner join Product c on b.Item_ID=c.IDNo" +
         " inner join (select Memo,Status from def_Status where Title='Order_STA') d on d.Status=a.Status" +
         " Where a.IDNo=" + Request.QueryString["entry"] + " and DATEDIFF(MONTH,a.Creat_Date,getdate()) < 3 ";
             

          
                }
                //if (Comm.IsNumeric(Request.QueryString["entry"]))
                //{
                //    str = "SELECT * FROM orders,Order_Content,Product where orders.IDNo = Order_Content.Order_ID and Order_Content.Item_ID=Product.IDNo and Orders.IDNo=" + Request.QueryString["entry"] + "";

                //    d = Main.GetDataSetNoNull(str);
                //    if (d.Rows.Count > 0)
                //    {
                //        DataRow dw = d.Rows[0];
                //        L_ProductName.Text = dw["Product_Name"].ToString();
                //        L_AMT.Text = dw["AMT"].ToString();
                //        L_Total.Text = dw["Total"].ToString();
                //        //L_Payment.Text = dw["Payment"].ToString();
                //        //L_Delivery.Text = dw["Delivery"].ToString();
                //        L_OrderNo.Text = dw["Order_No"].ToString();
                //        DDL_Status.SelectedValue = dw["Status"].ToString();
                //        L_Contact_ID.Text = dw["Contact_ID"].ToString();
                //        L_Email.Text = dw["Email"].ToString();
                //        L_TEL.Text = dw["TEL"].ToString();
                //        L_Addr.Text = dw["Addr"].ToString();
                //    }
                //}
            }
            SD1.SelectCommand = L1.Text;
            SD1.ConnectionString = Main.ConnStr;
            RP1.DataSourceID = SD1.ID;

        }

        protected void Bt_Leave_Click(object sender, EventArgs e)
        {
           // str = "update Orders set status=" + DDL_Status.SelectedValue + " where IDno = " + Request.QueryString["entry"] + "";
            //if (Main.NonQuery(str) > 0)
            //{
            //    Response.Write("<script language='javascript'> history.go(-2); </script>");
            //}
            //else
            //{
            //    ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入失敗');</script>");
            //}
        }

        protected void RP1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            DropDownList DL_STAt = (DropDownList)e.Item.FindControl("DL_STA");
           //Response.Write(DL_STAt.SelectedIndex);
            //Comm.GetDDL(DL_STA, "4");


          //  Main.FillDDP(DL_STA, "select Memo,Status from def_Status where Title='Order_STA'", "Memo", "Status");
            
        }
    }
}