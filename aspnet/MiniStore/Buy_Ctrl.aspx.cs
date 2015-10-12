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
                //--商品名稱(如果Product被刪 訂單會拉不到記錄)?
                //SHOW 總金額 -付款方式 -寄送方式 -收件人資訊 -購買商品明細( name*qty* price=total)
                str = "select a.Total_AMT,Payment_ID,HowTake,Contact_Name,TEL,Email,MNO,County,City,Addr,(select isnull(Product_Name,'') from Product where IDNo=b.Item_ID) as ItemName,AMT,Price,b.Item_ID,(AMT*Price) as total " +
                    " from Orders a inner join Order_Content b on a.IDNo=b.Order_ID where a.idno='" + Request.QueryString["entry"].ToString() + "'";

                DataTable DT = Main.GetDataSetNoNull(str);
                if (DT.Rows.Count > 0)
                {
                    TB_Paysum.Text = DT.Rows[0]["Total_AMT"].ToString();
                    TB_Payment.Text = DT.Rows[0]["Payment_ID"].ToString();
                    TB_Delivery.Text = DT.Rows[0]["HowTake"].ToString();
                    TB_Tel.Text = DT.Rows[0]["TEL"].ToString();
                    TB_MNO.Text = DT.Rows[0]["MNO"].ToString();
                    TB_Addr.Text = DT.Rows[0]["Addr"].ToString();
 
                    //還要商品輪播圖嗎?只撈訂單第一筆
                    for (int i = 1; i <= 4; i++)
                    {
                        if (i == 1)
                        {
                            L.Text += "<div class=\"item active\"><iframe src=\"Product_Img.aspx?PID=" + DT.Rows[0]["Item_ID"].ToString() + "&Img=1\" scrolling=\"no\" id=\"Iframe1\" style=\"width:100%;height:350px\"></iframe></div>";
                        }
                        else
                        {
                            L.Text += "<div class=\"item\"><iframe src=\"Product_Img.aspx?PID=" + DT.Rows[0]["Item_ID"].ToString() + "&Img=" + i + "\" scrolling=\"no\" id=\"Iframe" + i + "\" style=\"width:100%;height:350px\"></iframe></div>";
                        }
                    }
                    string tmpDetail = "";
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        DataRow dw = DT.Rows[i];
                        tmpDetail += dw["ItemName"] + "*" + dw["AMT"] + "*" + dw["Price"] + "=" + dw["total"] + "</br>";

                    }
                    L_Detail.Text = tmpDetail;
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