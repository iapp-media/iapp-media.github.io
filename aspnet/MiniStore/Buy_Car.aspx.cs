using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace MiniStore
{
    public partial class Buy_Car : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        DataTable Car_table = new DataTable();
        DataTable dtResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCarBaby();

            }

        }
        void GetCarBaby()
        {
            string Car_baby = "";
            if (Request.Cookies["Car_baby"] != null)
            {
                //load cookies
                Car_baby = HttpContext.Current.Request.Cookies["Car_baby"].Value;
                string[] OrderContent = Car_baby.Substring(1).Split(',');
                if (OrderContent.Length > 0)
                {
                    Car_table.Columns.AddRange(new DataColumn[] { new DataColumn("ItemID", typeof(string)), 
                                                  new DataColumn("AMT", typeof(int)) });
                    DataRow workRow;
                    for (int i = 0; i < OrderContent.Length; i++)
                    {
                        string[] a1 = OrderContent[i].Split('-');
                        workRow = Car_table.NewRow();
                        workRow[0] = a1[0].ToString();
                        workRow[1] = Main.Cint2(a1[1]);
                        Car_table.Rows.Add(workRow[0], workRow[1]);
                    }
                    //DataTable group by 數量
                    dtResult = Car_table.Clone();
                    DataTable dtName = Car_table.DefaultView.ToTable(true, "ItemID"); // ==where
                    for (int i = 0; i < dtName.Rows.Count; i++)
                    {
                        DataRow[] rows = Car_table.Select("ItemID='" + dtName.Rows[i][0] + "' ");
                        //temp用來儲存篩選出來的數據
                        DataTable temp = dtResult.Clone();
                        foreach (DataRow row in rows)
                        {
                            temp.Rows.Add(row.ItemArray);
                        }
                        DataRow dr = dtResult.NewRow();
                        dr[0] = dtName.Rows[i][0].ToString();
                        dr[1] = temp.Compute("sum(AMT)", "");
                        dtResult.Rows.Add(dr);
                    }

                    if (dtResult.Rows.Count > 0)
                    {
                        Car_table.Clear();
                        for (int i = 0; i < dtResult.Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                str = "select IDNo as ItemID,Product_Name,Price,'" + dtResult.Rows[i]["AMT"] + "' as AMT,'' as Total from product where idno='" + dtResult.Rows[i]["ItemID"] + "'";
                            }
                            else
                            {
                                str += "union select IDNo as ItemID,Product_Name,Price,'" + dtResult.Rows[i]["AMT"] + "','' from product where idno='" + dtResult.Rows[i]["ItemID"] + "'";
                            }
                        }
                        Car_table = Main.GetDataSetNoNull(str);
                    }
                }
            }
            else
            {
                //沒有的話?? 
            }
            GV.DataSource = Car_table;
            GV.DataBind();
        }

        protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                int a = Main.Cint2(e.Row.Cells[1].Text.Replace(",", ""));       //單價
                int b = Main.Cint2(e.Row.Cells[2].Text.Replace(",", ""));       //購買數量
                e.Row.Cells[3].Text = (string.Format("{0:#,##0}", (a * b)));    //Total

            }
        }

        protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int i = Comm.Cint2(e.CommandArgument);
            if (e.CommandName == "DELE")
            {



            }
        }

        protected void BT_Confirm_Click(object sender, EventArgs e)
        { 
            ////貨物數量還沒控制
            string OrderNo = "", OrderID = "";
            int c = 0, Total_AMT = 0;
            OrderNo = Comm.GetOrdersNO("1", System.DateTime.Today);

            Main.ParaClear();
            Main.ParaAdd("@Order_No", OrderNo, SqlDbType.NVarChar);
            Main.ParaAdd("@Total_AMT", Total_AMT, SqlDbType.Int);
            Main.ParaAdd("@Delivery_Date", System.DateTime.Today.AddDays(3).ToShortDateString(), SqlDbType.DateTime);
            Main.ParaAdd("@Store_ID", "1", SqlDbType.Int);             //用意? 跟 users ID 疑惑
            Main.ParaAdd("@Customer_ID", Comm.User_ID(), SqlDbType.NVarChar);
            Main.ParaAdd("@Contact_Name", TB_Name.Text, SqlDbType.NVarChar);//暫時寫 要拉會員表
            Main.ParaAdd("@TEL", TB_Tel.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@Email", "jason", SqlDbType.NVarChar);       //暫時寫 要拉會員表
            Main.ParaAdd("@MNO", TB_MNO.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@County", "Taoyuan ", SqlDbType.NVarChar);   //暫時寫 要拉會員表?
            Main.ParaAdd("@City", "Zhongli", SqlDbType.NVarChar);      //暫時寫 要拉會員表?
            Main.ParaAdd("@Addr", TB_Addr.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@Memo", "", SqlDbType.NVarChar);             //??
            Main.ParaAdd("@Status", "-1", SqlDbType.NVarChar);         //暫時寫-1 待結帳改1(未付款)
            Main.ParaAdd("@HowTake", DL_Delivery.SelectedValue.ToString(), SqlDbType.NVarChar);
            Main.ParaAdd("@Payment_ID", DL_Payment.SelectedValue.ToString(), SqlDbType.NVarChar);

            c = Main.NonQuery("insert into Orders(Order_No,Total_AMT,Delivery_Date,Store_ID,Customer_ID,Contact_Name,TEL,Email,MNO,County,City,Addr,Memo,Creat_Date,Last_Update,Status,HowTake,Payment_ID) " +
                          "values(@Order_No,@Total_AMT,@Delivery_Date,@Store_ID,@Customer_ID,@Contact_Name,@TEL,@Email,@MNO,@County,@City,@Addr,@Memo,GETDATE(),GETDATE(),@Status,@HowTake,@Payment_ID)");

            if (GV.Rows.Count > 0)
            {
                for (int i = 0; i < GV.Rows.Count; i++)
                {
                    Main.ParaClear();
                    OrderID = Main.Scalar("select max(idno) from orders where Customer_ID ='1' and Status='-1'");

                    Main.ParaAdd("@Order_ID", OrderID, SqlDbType.Int);
                    Main.ParaAdd("@Order_No", OrderNo, SqlDbType.NVarChar);
                    Main.ParaAdd("@Item_ID", Main.Cint2(GV.DataKeys[i][0].ToString()), SqlDbType.Int);
                    Main.ParaAdd("@AMT", Main.Cint2(GV.Rows[i].Cells[2].Text), SqlDbType.Int);
                    Main.ParaAdd("@Price", Main.Cint2(GV.Rows[i].Cells[1].Text), SqlDbType.Int);
                    Main.ParaAdd("@Total", (Main.Cint2(GV.Rows[i].Cells[3].Text.Replace(",", ""))), SqlDbType.Int);
                    Main.ParaAdd("@Memo", "", SqlDbType.NVarChar);
                    c += Main.NonQuery("insert into Order_Content (Order_ID,Order_No,Item_ID,AMT,Price,Total,Memo)" +
                                    "values(@Order_ID,@Order_No,@Item_ID,@AMT,@Price,@Total,@Memo)");
                    Total_AMT += (Main.Cint2(GV.Rows[i].Cells[3].Text.Replace(",", "")));
                }
            } 

            if (c > 1)
            {
                c = 0;
                Main.ParaClear();
                Main.ParaAdd("@Total_AMT", Total_AMT, SqlDbType.Int);
                Main.ParaAdd("@Order_ID", OrderID, SqlDbType.Int);
                c = Main.NonQuery("update Orders set Total_AMT=@Total_AMT where IDNo=@Order_ID"); 
                if (c > 0)
                {
                    Comm.DeleCoookie("Car_baby");
                    Response.Redirect("Buy_Ctrl.aspx?entry=" + HttpUtility.JavaScriptStringEncode(OrderID) + ""); 
                }
            }
        }
    }
}