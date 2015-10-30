﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
 

namespace MiniStore
{
    public partial class Buy_Ctrl : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        string SID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 
                Main.ParaClear();
                Main.ParaAdd("@Store_NID", Request.QueryString["SN"], SqlDbType.NVarChar);
                SID = Main.Scalar("select IDNo from store where Store_NID=@Store_NID");
                GetCar(); 
            }
            SD1.ConnectionString = Main.ConnStr;
            SD1.SelectCommand = L.Text;
            RP1.DataSourceID = SD1.ID;
        }
        public string ShowImg(object IDNO)
        {
            if (IDNO.ToString().Length > 0)
                return Main.Scalar("Select FilePath from Product_Img where Product_ID='" + IDNO + "' and Num=1");
            else
                return "";
        }
        void GetCar()
        {
            SD1.SelectParameters.Clear();
            SD1.SelectParameters.Add("user_id", Comm.User_ID().ToString());
            SD1.SelectParameters.Add("store_id", SID);

            L.Text = "select a.idno carID, b.idno ItemID,b.Product_Name Name,a.qty AMT,b.Price,a.qty*b.Price as total  " +
                " from ShoppingCart a inner join Product b on a.Product_ID=b.IDNo where a.user_id=@user_id and a.store_id=@store_id ";
            Main.WriteLog(SID);
            Main.WriteLog(Comm.User_ID().ToString());
            Main.WriteLog(L.Text);
            SD1.ConnectionString = Main.ConnStr;
            SD1.SelectCommand = L.Text;
            RP1.DataSourceID = SD1.ID;

            Main.ParaClear();
            Main.ParaAdd("@u_id", Main.Cint2(Comm.User_ID().ToString()), SqlDbType.Int);
            Main.ParaAdd("@SID", Main.Cint2(SID), SqlDbType.Int);
          
            //str = "Select b.Product_Name,sum(a.qty) * b.Price as total ,b.Payment,b.delivery " +
            //      "from ShoppingCart a inner join Product b on a.Product_ID=b.IDNo where a.user_id=@u_id    " +
            //      "group by Product_Name,Payment,delivery,Price ";
            str = " select SUM(total) from ( " +
                  "select sum(a.qty) * b.Price total from ShoppingCart a inner join Product b on a.Product_ID=b.IDNo " +
                  "  where a.user_id=@u_id and a.store_id=@SID  group by  b.IDNo,b.Price ) a ";
            TB_Paysum.Text = Main.Scalar(str);

            DataTable DT = Main.GetDataSetNoNull("select * from Store_info where Store_ID =@SID");
            if (DT.Rows.Count > 0)
            {
               //TB_Paysum.Text = DT.Rows[0]["total"].ToString(); //應負金額

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
            if (CBinfo.Checked == true)
            {
                Main.ParaClear();
                Main.ParaAdd("@Customer_ID", Main.Cint2(Comm.User_ID()), SqlDbType.Int);
                Main.ParaAdd("@Num", 1, SqlDbType.Int);      //常用設定組別 先暫時都給1 之後要改
                Main.ParaAdd("@Contact_Name", TB_Name.Text, SqlDbType.NVarChar);
                Main.ParaAdd("@TEL", TB_Tel.Text, SqlDbType.NVarChar);
                Main.ParaAdd("@MNO", TB_MNO.Text, SqlDbType.NVarChar);
                Main.ParaAdd("@Addr", TB_Addr.Text, SqlDbType.NVarChar);

                Main.NonQuery("Insert into Customer_info (Customer_ID, Num, Contact_Name, TEL, MNO, Addr) Values " +
                              " (@Customer_ID, @Num, @Contact_Name, @TEL, @MNO, @Addr)");
            }
             
            //金額資料直接再DB撈已防client竄改值??
            string OrderNo = "", strOrderID = null; //訂單編號之後也要SQL 處理?
            //Object OrderID = "";

            OrderNo = Comm.GetOrdersNO(Comm.User_ID().ToString(), System.DateTime.Today);  

            SqlConnection conn = new SqlConnection(Main.ConnStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@User_ID", Comm.User_ID());
            cmd.Parameters.AddWithValue("@OrderNo", OrderNo);
            cmd.Parameters.AddWithValue("@Delivery_ID", Main.Cint2(DL_Delivery.SelectedValue.ToString()));
            cmd.Parameters.AddWithValue("@Payment_ID", Main.Cint2(DL_Payment.SelectedValue.ToString()));
            cmd.Parameters.AddWithValue("@Contact_Name", TB_Name.Text);
            cmd.Parameters.AddWithValue("@TEL", TB_Tel.Text);
            cmd.Parameters.AddWithValue("@MNO", TB_MNO.Text);
            cmd.Parameters.AddWithValue("@Addr", TB_Addr.Text);


            cmd.Parameters.AddWithValue("@Ans", "22");  //為了轉型用的 但還是失敗先留著


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CreatOrders";
            object OrderID = cmd.ExecuteScalar();

            //轉型一直失敗 暫時這樣寫
           strOrderID = Main.Scalar("select max(idno) from orders where Customer_ID ='" + Comm.User_ID() + "' ");
           Response.Write("<script>alert('結帳成功');window.open('Order_prn.aspx?entry=" + strOrderID + "&SN=" + Request.QueryString["SN"] + "','_self');</script>");
          //

            //strOrderID = (string)OrderID;
            //if (strOrderID != "") //----執行回傳成功  ---
            //{

            //    Response.Write("<script>alert('結帳成功');window.open('Order_prn.aspx?entry=" + strOrderID + "','_self');</script>");
            //}

            conn.Close(); 
        }

        protected void RP1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal BTminus = (Literal)e.Item.FindControl("L_BTminus");
                Literal BTplus = (Literal)e.Item.FindControl("L_BTplus");
                Label P_IDNo = (Label)e.Item.FindControl("Lb_Item");
                Literal BTDELE = (Literal)e.Item.FindControl("L_DELE");
                Label CarBabyID = (Label)e.Item.FindControl("Lb_Carbaby");

                BTminus.Text = "<span class='input-number-decrement' onclick='minus(" + e.Item.ItemIndex + ",2," + CarBabyID.Text + ")'>–</span>";

                //數量有要卡嗎?
                //plus(商品數量上限,RP1項,動作ADD,CarID)
                BTplus.Text = "<span class='input-number-increment' onclick='plus(" +
                    Main.Scalar("select qty from product where idno='" + P_IDNo.Text + "'") + "," + e.Item.ItemIndex + ",1," + CarBabyID.Text + ")'>+ </span>";

                //第幾項,1,carID,Pid (carID&Pid 都對ajax才刪)
                BTDELE.Text = "<span class='glyphicon glyphicon-remove cancelTransaction' style='cursor: pointer;' aria-hidden='true' " +
                    " onclick='putDELE(" + e.Item.ItemIndex + ",0," + CarBabyID.Text + "," + P_IDNo.Text + ")'></span>";
             
            }
        }

        protected void SD1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            LCount.Text = e.AffectedRows.ToString(); 
        } 
    }
}