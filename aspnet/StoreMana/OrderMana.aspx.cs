using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StoreMana.Mini
{
    public partial class OrderMana : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        DataTable d = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                L.Text = "select * ,CONVERT(varchar(10), Creat_Date, 120) AS CD " +
    ",(select Memo from def_Status where  Col_Name='Payment' and Status=Payment_ID ) Payment " +
    ",(Select Memo from def_Status where Title='Order_STA' and status=orders.Status) NSta" +
    ",( select User_Name from users where IDNo=Customer_ID) User_name " +
    " from orders where store_ID ='" + Comm.Store_ID() + "'";
                SD1.SelectCommand = L.Text;
                SD1.ConnectionString = Main.ConnStr;
                RP1.DataSourceID = SD1.ID;
            }

        }

        protected void BT_Search_Click(object sender, EventArgs e)
        {
            L.Text = "select * ,CONVERT(varchar(10), Creat_Date, 120) AS CD " +
                ",(select Memo from def_Status where  Col_Name='Payment' and Status=Payment_ID ) Payment "+
                ",(Select Memo from def_Status where Title='Order_STA' and status=orders.Status) NSta" +
                ",( select User_Name from users where IDNo=Customer_ID) User_name "+
                " from orders where store_ID ='" + Comm.Store_ID() + "'";

            if (TextBox1.Text != "")
            {
                L.Text += " and Order_No= '" + TextBox1.Text + "'";
            }
            if (DropDownList1.SelectedValue != "")
            {
                L.Text += " and status= '" + DropDownList1.SelectedValue + "'";
            }
            L.Text += " order by Creat_Date DESC";

            SD1.SelectCommand = L.Text;
            SD1.ConnectionString = Main.ConnStr;
            RP1.DataSourceID = SD1.ID;
        }
         
        public string ShowDetail(object IDNO)
        {
            if (IDNO.ToString().Length > 0)
                return "Order_Detail.aspx?entry=" + IDNO + "";
            else
                return "";
        }

        protected void BTCHK_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "String", "<script>alert('saYES" + sender + "');</script>");

        } 

        protected void RP1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "CN1":  //面交 訂單確認

                    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                    {
                        Literal Order_Key = (Literal)e.Item.FindControl("LIDNO");
                        // ((Literal)e.Item.FindControl("LIDNO")).Text = ((Literal)e.Item.FindControl("LIDNO")).Text + "??";
                       // this.ClientScript.RegisterStartupScript(this.GetType(), "String", "<script>alert('" + btnNewNumber0.Text + "');</script>");
                      int c=  Main.NonQuery("update orders set status='3' where idno='" + Order_Key.Text + "'"); 
                      if (c > 0)
                      {
                          this.ClientScript.RegisterStartupScript(this.GetType(), "String", "<script>alert('寄信/簡訊通知取貨時間地點??');</script>");
                      }
                    }
                    break;
                case "CN2":  //結案 
                    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                    {
                        Literal Order_Key = (Literal)e.Item.FindControl("LIDNO");
                        int c = Main.NonQuery("update orders set status='30' where idno='" + Order_Key.Text + "'");
                        if (c > 0)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "String", "<script>alert('訂單結案');</script>");
                        }
                    }
                    break;
                case "CN3":  //入帳確認 
                    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                    {
                        Literal Order_Key = (Literal)e.Item.FindControl("LIDNO");
                        int c = Main.NonQuery("update orders set status='10',AC_Date=getdate() where idno='" + Order_Key.Text + "'");
                        if (c > 0)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "String", "<script>alert('訂單入帳確認');</script>");
                        }
                    }
                    break;
                case "CN4":  //出貨單列印 
                   
                    break;
                case "CN5":  //出貨確認 
                    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                    {
                        Literal Order_Key = (Literal)e.Item.FindControl("LIDNO");
                        int c = Main.NonQuery("update orders set status='15',Delivery_Date=getdate() where idno='" + Order_Key.Text + "'");
                        if (c > 0)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "String", "<script>alert('訂單出貨確認');</script>");
                        }
                    }
                    break;
            } 
        }

        protected void RP1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //卡按鈕 還沒用好等套完再用
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal Order_Key = (Literal)e.Item.FindControl("LIDNO");
                Button BTCHK = (Button)e.Item.FindControl("BTCHK");
                Button BTEND = (Button)e.Item.FindControl("BTEND");
                Button BT1 = (Button)e.Item.FindControl("BT1");
                Button BT2 = (Button)e.Item.FindControl("BT2");
                Button BT3 = (Button)e.Item.FindControl("BT3"); 
 
                //sta control
                if (Main.Scalar("select status from orders where Payment_ID=1 and idno='" + Order_Key.Text + "'") == "1")
                {
                    BTEND.Visible = false;
                }
                if (Main.Scalar("select status from orders where Payment_ID=1 and idno='" + Order_Key.Text + "'") == "0") //訂單成立
                {
                    BTCHK.Visible = true;
                }

                if (Main.Scalar("select status from orders where Payment_ID=1 and idno='" + Order_Key.Text + "'") == "3") //訂單確認
                { 
                    BTEND.Visible = true;
                }


                if (Main.Scalar("select status from orders where  Payment_ID=3 and idno='" + Order_Key.Text + "'") == "5") //入帳確認
                {
                    BT1.Visible = true;
                }
                if (Main.Scalar("select status from orders where  Payment_ID=3 and idno='" + Order_Key.Text + "'") == "10") //出貨確認
                {
                    BT3.Visible = true;
                }
                if (Main.Scalar("select status from orders where  Payment_ID=3 and idno='" + Order_Key.Text + "'") == "15") //出貨確認
                {
                    BT2.Visible = true;
                } 
            }
        } 
     }
}