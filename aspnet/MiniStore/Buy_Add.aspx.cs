using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MiniStore
{
    public partial class Buy_Add : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Comm.IsNumeric(Request.QueryString["entry"])) { Response.Redirect("Default.aspx"); }
                CarouselPic();

                DataTable DT = Main.GetDataSetNoNull("select payment,delivery from Product where idno='" + Request.QueryString["entry"] + "' ");
                if (DT.Rows.Count > 0)
                {  
                    string listPayment =  DT.Rows[0]["payment"].ToString().Replace(",","','");
                    listPayment = listPayment.Substring(2).ToString() + "'";
                    listPayment = Main.Scalar("select Memo from def_Status where Col_Name='Payment' and Status in(" + listPayment + ")");

                    string listDelivery = DT.Rows[0]["delivery"].ToString().Replace(",", "','");
                    listDelivery = listDelivery.Substring(2).ToString() + "'";
                    listDelivery = Main.Scalar("select Memo from def_Status where Col_Name='Payment' and Status in(" + listDelivery + ")");

                    L_view.Text = "<a href='Product_Detail.aspx?entry=" + Request.QueryString["entry"] + "&view=2'>  <div class='col-xs-12 libor paytheway'>" +
                             "      <label   class='col-xs-6'>運費規則</label>" +
                             "      <p>" + listDelivery + " </p>" +
                             "  </div> " +
                             "  <div class='col-xs-12 libor sendtheway'>" +
                             "      <label  class='col-xs-6'>付款方式</label>" +
                             "      <p>" + listPayment + " </p>" +
                             "  </div></a>";


                }


                
             this.DL_qty.Attributes.Add("onchange", "loadPriceScript();");
            }
        }
        void CarouselPic()
        {
            if (Comm.IsNumeric(Request.QueryString["entry"]))
            {
                str = "select * from product where idno=" + Request.QueryString["entry"] + "";
                DataTable DT = Main.GetDataSetNoNull(str);
                if (DT.Rows.Count > 0)
                {
                    L_Name.Text = DT.Rows[0]["Product_Name"].ToString();  
                    L_Price.Text = DT.Rows[0]["Price"].ToString();
                    TB_Dimension.Text = DT.Rows[0]["dimension"].ToString();
                    TB_Price.Text = DT.Rows[0]["Price"].ToString();
                    TB_Description.Text = DT.Rows[0]["description"].ToString();

                    for (int i = 1; i <= 4; i++)
                    {
                        if (i == 1)
                        {
                            L.Text += "<div class=\"item active\"><iframe src=\"Product_Img.aspx?PID=" + DT.Rows[0]["IDNo"].ToString() + "&Img=1\" scrolling=\"no\" id=\"Iframe1\" style=\"width:100%;height:350px\"></iframe></div>";
                        }
                        else
                        {
                            L.Text += "<div class=\"item\"><iframe src=\"Product_Img.aspx?PID=" + DT.Rows[0]["IDNo"].ToString() + "&Img=" + i + "\" scrolling=\"no\" id=\"Iframe" + i + "\" style=\"width:100%;height:350px\"></iframe></div>";
                        }
                    }
                }

            }
        }

        protected void BT_Confirm_Click(object sender, EventArgs e)
        {
            //貨物數量還沒控制
            string OrderNo = "", OrderID = "";
            int c = 0;
            OrderNo = Comm.GetOrdersNO("1", System.DateTime.Today);

            Main.ParaClear();
            Main.ParaAdd("@Order_No", OrderNo, SqlDbType.NVarChar);
            Main.ParaAdd("@Total_AMT", TB_Paysum.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@Delivery_Date", System.DateTime.Today.AddDays(3).ToShortDateString(), SqlDbType.DateTime);
            Main.ParaAdd("@Store_ID", "1", SqlDbType.Int);             //用意? 跟 users ID 疑惑 151014 要改為appweb 的 user_id
            Main.ParaAdd("@Customer_ID", "1", SqlDbType.NVarChar);     //暫時寫1 待購物user 處理好要改
            //Main.ParaAdd("@Contact_Name", TB_Name.Text, SqlDbType.NVarChar); 
            //Main.ParaAdd("@TEL", TB_Tel.Text, SqlDbType.NVarChar);
            //Main.ParaAdd("@Email", "jason", SqlDbType.NVarChar);       //暫時寫 要拉會員表
            //Main.ParaAdd("@MNO", TB_MNO.Text, SqlDbType.NVarChar);
            //Main.ParaAdd("@County", "Taoyuan ", SqlDbType.NVarChar);   //暫時寫 要拉會員表?
            //Main.ParaAdd("@City", "Zhongli", SqlDbType.NVarChar);      //暫時寫 要拉會員表?
            //Main.ParaAdd("@Addr", TB_Addr.Text, SqlDbType.NVarChar);
            //Main.ParaAdd("@Memo", "", SqlDbType.NVarChar);             //??
            Main.ParaAdd("@Status", "-1", SqlDbType.NVarChar);         //暫時寫-1 待結帳改1(未付款)
 
            c = Main.NonQuery("insert into Orders(Order_No,Total_AMT,Delivery_Date,Store_ID,Customer_ID,Creat_Date,Last_Update,Status ) " +
                          "values(@Order_No,@Total_AMT,@Delivery_Date,@Store_ID,@Customer_ID,GETDATE(),GETDATE(),@Status )");
            //,Contact_Name,TEL,Email,MNO,County,City,Addr,Memo
            //,@Contact_Name,@TEL,@Email,@MNO,@County,@City,@Addr,@Memo

            Main.ParaClear();
            OrderID = Main.Scalar("select max(idno) from orders where Customer_ID ='1' and Status='-1'");

            Main.ParaAdd("@Order_ID", OrderID, SqlDbType.Int);
            Main.ParaAdd("@Order_No", OrderNo, SqlDbType.NVarChar);
            Main.ParaAdd("@Item_ID", Main.Cint2(Request.QueryString["entry"].ToString()), SqlDbType.Int);
            Main.ParaAdd("@AMT", Main.Cint2(DL_qty.SelectedValue), SqlDbType.Int);
            Main.ParaAdd("@Price", Main.Cint2(TB_Price.Text), SqlDbType.Int);
            Main.ParaAdd("@Total", (Main.Cint2(DL_qty.SelectedValue) * Main.Cint2(TB_Price.Text)), SqlDbType.Int);
            Main.ParaAdd("@Memo", "", SqlDbType.NVarChar);
            c += Main.NonQuery("insert into Order_Content (Order_ID,Order_No,Item_ID,AMT,Price,Total,Memo)" +
                            "values(@Order_ID,@Order_No,@Item_ID,@AMT,@Price,@Total,@Memo)");

            if (c == 2)
            {
                Response.Redirect("Buy_Ctrl.aspx?entry=" + HttpUtility.JavaScriptStringEncode(OrderID) + "");
            }
        }

        protected void BT_InCar_Click(object sender, EventArgs e)
        {
            //Write cookie include(,item_id-AMT ) 再觀察(付款方式,寄送方式) 
            string Car_baby = "";
            if (Request.Cookies["Car_baby"] != null)
            {
                Car_baby = HttpContext.Current.Request.Cookies["Car_baby"].Value; 
            }
            
            Car_baby += "," + Request.QueryString["entry"] + "-" + DL_qty.SelectedValue + "";
            Comm.SaveCookie("Car_baby", Car_baby, 30); 
            Response.Redirect("Default.aspx");
        }

        protected void BT_MSG_Click(object sender, EventArgs e)
        {
            Response.Redirect("P_MSG.aspx?entry=" + Request.QueryString["entry"] + "");
        }

        protected void DL_qty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DL_qty.SelectedValue!="")
            {
                int a = Main.Cint2(DL_qty.SelectedValue.ToString()) * Main.Cint2(TB_Price.Text);
                TB_Paysum.Text = a.ToString();
            }
        }
    }
}