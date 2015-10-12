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
            if (!Comm.IsNumeric(Request.QueryString["entry"])) { Response.Redirect("Buy_Car.aspx"); }
            CarouselPic();
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
                str = "select a.Total_AMT,Payment_ID,HowTake,Contact_Name,TEL,Email,MNO,County,City,Addr,(select isnull(Product_Name,'') from Product where IDNo=b.Item_ID) as ItemName,AMT,Price,b.Item_ID,(AMT*Price) as total " +
                    " from Orders a inner join Order_Content b on a.IDNo=b.Order_ID where a.idno='" + Request.QueryString["entry"].ToString() + "'";

                DataTable DT = Main.GetDataSetNoNull(str);
                if (DT.Rows.Count > 0)
                {
                    TB_Paysum.Text = DT.Rows[0]["Total_AMT"].ToString();
                    TB_Payment.Text = DT.Rows[0]["Payment_ID"].ToString();
                    switch (DT.Rows[0]["Payment_ID"].ToString().Trim())
                    {
                        case "1":
                            TB_Payment.Text = "面交";
                            break;                        case "2":
                            TB_Payment.Text = "7-11 ibon";
                            break;    case "3":
                            TB_Payment.Text = "銀行轉帳";
                            break;
                    }                     
                    switch (DT.Rows[0]["HowTake"].ToString().Trim())
                    {
                        case "1":
                            TB_Delivery.Text = "面交自取";
                            break;                        case "2":
                            TB_Delivery.Text = "7-11";
                            break;    case "3":
                            TB_Delivery.Text = "寄送到府";
                            break;
                    }                     
                     
                    TB_Tel.Text = DT.Rows[0]["TEL"].ToString();
                    TB_MNO.Text = DT.Rows[0]["MNO"].ToString();
                    TB_Addr.Text = DT.Rows[0]["Addr"].ToString(); 
                }

            }
        }

        protected void BT_Confirm_Click(object sender, EventArgs e)
        {
            int c = 0;
            c = Main.NonQuery("update Orders set status='1' where IDNo='" + Request.QueryString["entry"].ToString() + "'");
            if (c > 0) { Response.Write("<script>alert('結帳成功');window.open('Default.aspx','_self');</script>"); }
        } 
    }
}