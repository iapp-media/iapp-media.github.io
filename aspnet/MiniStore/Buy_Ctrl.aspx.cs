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
              if (!Comm.IsNumeric(Request.QueryString["entry"])) { Response.Redirect("Buy_Car.aspx"); }
            CarouselPic();
              
            }
        }
        void CarouselPic()
        {
            if (Comm.IsNumeric(Request.QueryString["entry"]))
            {
                L.Text = "select IDNo as ItemID,(select Product_Name from Product where IDNo=Item_ID) Name,Price,AMT,  Total from Order_Content where Order_ID ='" + Request.QueryString["entry"].ToString() + "'";

                SD1.ConnectionString = Main.ConnStr;
                SD1.SelectCommand = L.Text;
               GV.DataSourceID = SD1.ID; 

                //--商品名稱(如果Product被刪 訂單會拉不到記錄)? 
               str = "select a.Total_AMT,Contact_Name,TEL,Email,MNO,County,City,Addr, " +
                   " (select isnull(Product_Name,'') from Product where IDNo=b.Item_ID) as ItemName,AMT,Price, " +
                   " b.Item_ID,(AMT*Price) as total , (select Delivery from Product where IDNo=b.Item_ID) Delivery  " +
                   ",(select Payment from Product where IDNo=b.Item_ID) Payment " +
                    " from Orders a inner join Order_Content b on a.IDNo=b.Order_ID where a.idno='" + Request.QueryString["entry"].ToString() + "'";

                DataTable DT = Main.GetDataSetNoNull(str);
                if (DT.Rows.Count > 0)
                {
                    TB_Paysum.Text = DT.Rows[0]["Total_AMT"].ToString();
                    

                    string listDelivery = DT.Rows[0]["delivery"].ToString().Replace(",", "','");
                    listDelivery = listDelivery.Substring(2).ToString() + "'";
                    Main.FillDDP(RBL_Delivery, "select Status,Memo from def_Status where Col_Name='Delivery' and Status in(" + listDelivery + ") ", "Memo", "Status");
                    string listRB_Payment = DT.Rows[0]["Payment"].ToString().Replace(",", "','");
                    listRB_Payment = listRB_Payment.Substring(2).ToString() + "'";
                    Main.FillDDP(RBL_Payment, "select Status,Memo from def_Status where Col_Name='Payment' and Status in(" + listRB_Payment + ") ", "Memo", "Status");

                                       
                }

            }
        }

        protected void BT_Confirm_Click(object sender, EventArgs e)
        {
            int c = 0;
            Main.ParaClear();
            //            --,Contact_Name,TEL,Email,MNO,County,City,Addr,Memo
            //,@Contact_Name,@TEL,@Email,@MNO,@County,@City,@Addr,@Memo

            Main.ParaAdd("@Delivery_ID", Main.Cint2(RBL_Delivery.SelectedValue), SqlDbType.Int);
            Main.ParaAdd("@Payment_ID", Main.Cint2(RBL_Payment.SelectedValue), SqlDbType.Int);

            Main.ParaAdd("@Contact_Name", TB_Name.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@MNO", TB_MNO.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@TEL", TB_Tel.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@Addr", TB_Addr.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@entry", Main.Cint2(Request.QueryString["entry"]), SqlDbType.Int);
            c = Main.NonQuery("Update Orders set status='1',Contact_Name=@Contact_Name,MNO=@MNO,TEL=@TEL,Addr=@Addr " +
                              ",Delivery_ID=@Delivery_ID,Payment_ID=@Payment_ID where IDNo=@entry");

            if (c > 0) { Response.Write("<script>alert('結帳成功');window.open('Order_prn.aspx','_self');</script>"); }
        }
    }
}