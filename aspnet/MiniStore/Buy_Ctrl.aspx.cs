using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MiniStore
{
    public partial class Buy_Ctrl : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
             // if (!Comm.IsNumeric(Request.QueryString["entry"])) { Response.Redirect("Buy_Car.aspx"); }
             //    CarouselPic();
                GetCar();
              
            }
        }
        void GetCar()
        {
            L.Text = "select a.idno carID, b.idno ItemID,b.Product_Name Name,a.qty AMT,b.Price,a.qty*b.Price as total from ShoppingCart a inner join Product b on a.Product_ID=b.IDNo where a.user_id='" + Comm.User_ID() + "' ";
            SD1.ConnectionString = Main.ConnStr;
            SD1.SelectCommand = L.Text;
            GV.DataSourceID = SD1.ID;

            //參數設定要改過
            str = "Select b.Product_Name,sum(a.qty) * b.Price as total ,b.Payment,b.delivery " +
                  "from ShoppingCart a inner join Product b on a.Product_ID=b.IDNo where a.user_id='" + Comm.User_ID() + "' " +
                  "group by Product_Name,Payment,delivery,Price ";

            DataTable DT = Main.GetDataSetNoNull(str);
            if (DT.Rows.Count > 0)
            {
                TB_Paysum.Text = DT.Rows[0]["total"].ToString(); 
                string listDelivery = DT.Rows[0]["delivery"].ToString().Replace(",", "','");
                listDelivery = listDelivery.Substring(2).ToString() + "'";
                Main.FillDDP(DL_Delivery, "select Status,Memo from def_Status where Col_Name='Delivery' and Status in(" + listDelivery + ") ", "Memo", "Status");
                string listRB_Payment = DT.Rows[0]["Payment"].ToString().Replace(",", "','");
                listRB_Payment = listRB_Payment.Substring(2).ToString() + "'";
                Main.FillDDP(DL_Payment, "select Status,Memo from def_Status where Col_Name='Payment' and Status in(" + listRB_Payment + ") ", "Memo", "Status");
                 
            }   
        }
        protected void BT_Confirm_Click(object sender, EventArgs e)
        {
            if (GV.Rows.Count < 0) { return; }
            ////貨物數量還沒控制
            string OrderNo = "", OrderID = "", shopcar = "";
            int c = 0;
            OrderNo = Comm.GetOrdersNO(Comm.User_ID().ToString(), System.DateTime.Today); //user_id

            Main.ParaClear();
            Main.ParaAdd("@Order_No", OrderNo, SqlDbType.NVarChar);
            Main.ParaAdd("@Total_AMT", Main.Cint2(TB_Paysum.Text), SqlDbType.Int);
            Main.ParaAdd("@Delivery_Date", System.DateTime.Today.AddDays(3).ToShortDateString(), SqlDbType.DateTime);
            Main.ParaAdd("@Store_ID", "1", SqlDbType.Int);             //用意? 跟 users ID 疑惑
            Main.ParaAdd("@Customer_ID", Comm.User_ID(), SqlDbType.NVarChar);
            Main.ParaAdd("@Contact_Name", TB_Name.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@TEL", TB_Tel.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@Email", Main.Scalar("select Accounts from users where idno='" + Comm.User_ID() + "'"), SqlDbType.NVarChar); ;      //暫時寫 要拉會員表
            Main.ParaAdd("@MNO", TB_MNO.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@County", " ", SqlDbType.NVarChar);                 //沒資料欄位 要拉會員表?
            Main.ParaAdd("@City", "", SqlDbType.NVarChar);                    //沒資料欄位 要拉會員表?
            Main.ParaAdd("@Addr", TB_Addr.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@Memo", "", SqlDbType.NVarChar);             //??
            Main.ParaAdd("@Status", "1", SqlDbType.NVarChar);         //暫時寫-1 待結帳改1(未付款)
            Main.ParaAdd("@Delivery_ID", DL_Delivery.SelectedValue.ToString(), SqlDbType.NVarChar);
            Main.ParaAdd("@Payment_ID", DL_Payment.SelectedValue.ToString(), SqlDbType.NVarChar);

            c = Main.NonQuery("insert into Orders(Order_No,Total_AMT,Delivery_Date,Store_ID,Customer_ID,Contact_Name,TEL,Email,MNO,County,City,Addr,Memo,Creat_Date,Last_Update,Status,Delivery_ID,Payment_ID) " +
                          "values(@Order_No,@Total_AMT,@Delivery_Date,@Store_ID,@Customer_ID,@Contact_Name,@TEL,@Email,@MNO,@County,@City,@Addr,@Memo,GETDATE(),GETDATE(),@Status,@Delivery_ID,@Payment_ID)");
            if (GV.Rows.Count > 0)
            {
                c = 0;
                for (int i = 0; i < GV.Rows.Count; i++)
                {
                    Main.ParaClear();
                    OrderID = Main.Scalar("select max(idno) from orders where Customer_ID ='" + Comm.User_ID() + "' and Status='1'");

                    Main.ParaAdd("@Order_ID", Main.Cint2(OrderID), SqlDbType.Int);
                    Main.ParaAdd("@Order_No", OrderNo, SqlDbType.NVarChar);
                    Main.ParaAdd("@Item_ID", Main.Cint2(GV.DataKeys[i][0].ToString()), SqlDbType.Int);
                    Main.ParaAdd("@AMT", Main.Cint2(GV.Rows[i].Cells[3].Text), SqlDbType.Int);
                    Main.ParaAdd("@Price", Main.Cint2(GV.Rows[i].Cells[1].Text), SqlDbType.Int);
                    Main.ParaAdd("@Total", Main.Cint2(GV.Rows[i].Cells[5].Text.Replace(",", "")), SqlDbType.Int);
                    Main.ParaAdd("@Memo", "", SqlDbType.NVarChar);
                    c += Main.NonQuery("insert into Order_Content (Order_ID,Order_No,Item_ID,AMT,Price,Total,Memo)" +
                                    "values(@Order_ID,@Order_No,@Item_ID,@AMT,@Price,@Total,@Memo)");
                    shopcar += ",'" + GV.DataKeys[i][1].ToString() + "'";
                }
                if (c > 0)
                {
                    Main.NonQuery("delete ShoppingCart where IDNo in (" + shopcar.Substring(1) + ")");
                    Response.Write("<script>alert('結帳成功');window.open('Order_prn.aspx?entry=" + OrderID + "','_self');</script>");
                } 
            }
        }

        //void CarouselPic()
        //{
        //    if (Comm.IsNumeric(Request.QueryString["entry"]))
        //    {
        //        L.Text = "select IDNo as ItemID,(select Product_Name from Product where IDNo=Item_ID) Name,Price,AMT,  Total from Order_Content where Order_ID ='" + Request.QueryString["entry"].ToString() + "'";

        //        SD1.ConnectionString = Main.ConnStr;
        //        SD1.SelectCommand = L.Text;
        //       GV.DataSourceID = SD1.ID; 

        //        //--商品名稱(如果Product被刪 訂單會拉不到記錄)? 
        //       str = "select a.Total_AMT,Contact_Name,TEL,Email,MNO,County,City,Addr, " +
        //           " (select isnull(Product_Name,'') from Product where IDNo=b.Item_ID) as ItemName,AMT,Price, " +
        //           " b.Item_ID,(AMT*Price) as total , (select Delivery from Product where IDNo=b.Item_ID) Delivery  " +
        //           ",(select Payment from Product where IDNo=b.Item_ID) Payment " +
        //            " from Orders a inner join Order_Content b on a.IDNo=b.Order_ID where a.idno='" + Request.QueryString["entry"].ToString() + "'";

        //        DataTable DT = Main.GetDataSetNoNull(str);
        //        if (DT.Rows.Count > 0)
        //        {
        //            TB_Paysum.Text = DT.Rows[0]["Total_AMT"].ToString();
                    

        //            string listDelivery = DT.Rows[0]["delivery"].ToString().Replace(",", "','");
        //            listDelivery = listDelivery.Substring(2).ToString() + "'";
        //            Main.FillDDP(DL_Delivery, "select Status,Memo from def_Status where Col_Name='Delivery' and Status in(" + listDelivery + ") ", "Memo", "Status");
        //            string listRB_Payment = DT.Rows[0]["Payment"].ToString().Replace(",", "','");
        //            listRB_Payment = listRB_Payment.Substring(2).ToString() + "'";
        //            Main.FillDDP(DL_Payment, "select Status,Memo from def_Status where Col_Name='Payment' and Status in(" + listRB_Payment + ") ", "Memo", "Status");

                                       
        //        }

        //    }
        //}

        //protected void BT_Confirm_Click(object sender, EventArgs e)
        //{
        //    int c = 0;
        //    Main.ParaClear();
        //    //            --,Contact_Name,TEL,Email,MNO,County,City,Addr,Memo
        //    //,@Contact_Name,@TEL,@Email,@MNO,@County,@City,@Addr,@Memo

        //    Main.ParaAdd("@Delivery_ID", Main.Cint2(DL_Delivery.SelectedValue), SqlDbType.Int);
        //    Main.ParaAdd("@Payment_ID", Main.Cint2(DL_Payment.SelectedValue), SqlDbType.Int);

        //    Main.ParaAdd("@Contact_Name", TB_Name.Text, SqlDbType.NVarChar);
        //    Main.ParaAdd("@MNO", TB_MNO.Text, SqlDbType.NVarChar);
        //    Main.ParaAdd("@TEL", TB_Tel.Text, SqlDbType.NVarChar);
        //    Main.ParaAdd("@Addr", TB_Addr.Text, SqlDbType.NVarChar);
        //    Main.ParaAdd("@entry", Main.Cint2(Request.QueryString["entry"]), SqlDbType.Int);
        //    c = Main.NonQuery("Update Orders set status='1',Contact_Name=@Contact_Name,MNO=@MNO,TEL=@TEL,Addr=@Addr " +
        //                      ",Delivery_ID=@Delivery_ID,Payment_ID=@Payment_ID where IDNo=@entry");

        //    if (c > 0) { Response.Write("<script>alert('結帳成功');window.open('Order_prn.aspx?entry=" + Request.QueryString["entry"] + "','_self');</script>"); }

            


        
        //}

        //protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowIndex > -1)
        //    {


        //        Button TT = (Button)e.Row.Cells[2].Controls[1];
        //        TT.OnClientClick = "minus('" + e.Row.RowIndex + "')";
        //        TT.Attributes.Add("onkeyup", "minus('" + e.Row.RowIndex + "');");
        //        Button T2 = (Button)e.Row.Cells[4].Controls[1];
        //        T2.OnClientClick = "plus('" + e.Row.RowIndex + "')";
        //        T2.Attributes.Add("onkeyup", "plus('" + e.Row.RowIndex + "');");
        //    }

        //}
    }
}