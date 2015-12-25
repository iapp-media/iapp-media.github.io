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
    public partial class Order_prn : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["Order_entry"] == null)
                {
                    Response.Redirect("Order_history.aspx?SN=" + Request.QueryString["SN"] + "");
                }
                SD1.SelectParameters.Clear();
                SD2.SelectParameters.Clear();
                SD4.SelectParameters.Clear();
                SD1.SelectParameters.Add("IDNo", Session["Order_entry"].ToString());
                SD2.SelectParameters.Add("IDNo", Session["Order_entry"].ToString());
                SD4.SelectParameters.Add("IDNo", Session["Order_entry"].ToString());

                if (Main.Scalar("select Payment_ID from orders where idno='" + Session["Order_entry"].ToString() + "'") != "3")
                {
                    Div_Store_ACInfo.Visible = false;
                    Div_Send_AC.Visible = false;
                }
                else
                {
                    TBACCDate.Text = DateTime.Today.Date.ToShortTimeString();

                    SD3.SelectParameters.Clear();
                    SD3.SelectParameters.Add("IDNo", Session["Order_entry"].ToString());
                    L3.Text = " Select b.Bank_Name,b.Bank_No,b.Bank_ACName,b.Bank_ACC from orders a inner join Store_info b on a.Store_ID=b.Store_ID where a.IDNo=@IDNo";
                    SD3.SelectCommand = L3.Text;
                    SD3.ConnectionString = Main.ConnStr;
                    RP3.DataSourceID = SD3.ID;
                }

                L.Text = "Select (select Memo from def_Status where Col_Name='Payment' and Status=Payment_ID) Payment" +
                         ",(select Memo from def_Status where Col_Name='Delivery' and Status=Delivery_ID) Delivery,sum(b.Price) Cost " +
                         " from orders a inner join Order_Content b on a.IDNo=b.Order_ID " +
                         "where a.IDNo=@IDNo group by Payment_ID,Delivery_ID";

                L2.Text = " Select  Contact_Name,TEL,Addr from orders  where IDNo=@IDNo";

                L4.Text = " Select Item_ID,sum(qty) qty,SUM(Total) total,(select product_name from Product where IDNo=Item_ID) name,SPEC_Group " +
                          "from Order_Content  where Order_ID=@IDNo group by Item_ID,SPEC_Group";

                Main.ParaClear();
                Main.ParaAdd("@IDNo", Main.Cint2(Session["Order_entry"].ToString()), SqlDbType.Int);

                DataTable DT = Main.GetDataSetNoNull("select *,CONVERT(varchar(12), ACC_Date, 111) AS sdate from orders where IDNo=@IDNo");
                if (DT.Rows.Count > 0)
                {
                    TBTotal.Text = DT.Rows[0]["AC_AMT"].ToString();
                    TBACC.Text = DT.Rows[0]["ACC_AMT"].ToString();
                    TBACCDate.Text = DT.Rows[0]["sdate"].ToString();
                }

            }
            SD1.SelectCommand = L.Text;
            SD1.ConnectionString = Main.ConnStr;
            RP1.DataSourceID = SD1.ID;

            SD2.SelectCommand = L2.Text;
            SD2.ConnectionString = Main.ConnStr;
            RP2.DataSourceID = SD2.ID;

            SD4.SelectCommand = L4.Text;
            SD4.ConnectionString = Main.ConnStr;
            RP4.DataSourceID = SD4.ID;

        }
        public string ShowName(object PName, object SPECids)
        {
            string a = "";
            if (SPECids.ToString().Length > 0)
            {
                DataTable DT = Main.GetDataSetNoNull("Select Item from Product_SPEC_Item Where IDNo in ('" + SPECids.ToString().Substring(1).Replace(",", "','") + "')");
                if (DT.Rows.Count > 0)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        a += "(" + DT.Rows[i]["Item"].ToString() + ")";
                    }
                }
            }
            return PName.ToString() + a;
        }

        protected void BTsend_Click(object sender, EventArgs e)
        {
            if (Div_Send_AC.Visible == true)
            {
                string tmp = "";
                if (TBACC.Text == "") { tmp += ",銀行帳號"; }
                else
                {
                    if (TBACC.Text.Length < 5 || TBACC.Text.Length > 5)
                    {
                        tmp += ",銀行帳號";
                    }
                }
                if (TBTotal.Text == "" || !Main.IsNumeric(TBTotal.Text)) { tmp += ",轉帳金額"; }
                else
                {
                    if (Main.Cint2(TBTotal.Text) < 0)
                    {
                        tmp += ",轉帳金額";
                    }
                }

                if (TBACCDate.Text == "") { tmp += ",轉帳日期1"; }
                else
                {
                    if (!Main.IsDate(TBACCDate.Text)) { tmp += ",轉帳日期2"; }
                }
                if (tmp != "")
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "alert('" + tmp.Substring(1) + ",格式有誤');", true);
                    return; 
                }
                Main.ParaClear();
                Main.ParaAdd("@AC_AMT", Main.Cint2(TBTotal.Text), SqlDbType.Int);
                Main.ParaAdd("@IDNo", Main.Cint2(Session["Order_entry"].ToString()), SqlDbType.Int);
                Main.ParaAdd("@ACC_AMT", TBACC.Text, SqlDbType.NVarChar);
                Main.ParaAdd("@ACC_Date", TBACCDate.Text, SqlDbType.NVarChar);

                int c = Main.NonQuery("update orders set AC_AMT=@AC_AMT ,ACC_AMT=@ACC_AMT,ACC_Date=@ACC_Date,status='5' where IDNo=@IDNo");
                if (c > 0)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "String", "<script>alert('已成功送出通知');window.open('Order_history.aspx?sn=" + Request.QueryString["SN"] + "','_self')</script>");
 
                }
            }
            else
            {
                Response.Redirect("Order_history.aspx?sn=" + Request.QueryString["SN"] + "");
            }

        }

        public string ShowImg(object IDNO)
        {
            if (IDNO.ToString().Length > 0)
                return Main.Scalar("Select FilePath from Product_Img where Product_ID='" + IDNO + "' and Num=1");
            else
                return "";
        }

        protected void RP1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal L_Fee = (Literal)e.Item.FindControl("L_Fee");
                Literal L_SumTotal = (Literal)e.Item.FindControl("L_SumTotal");

                int T1 = 0;
                DataTable DT = Main.GetDataSetNoNull("select * from order_Fee where order_ID='" + Session["Order_entry"].ToString() + "'");
                if (DT.Rows.Count > 0)
                {
                    StringBuilder SB = new StringBuilder();
                    SB.Clear();
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        SB.Append("<div class=\"ListLen\">");
                        SB.Append("   <div class=\"col-xs-4\"> ");
                        SB.Append("       <p class=\"BoxLeft TBC\">" + DT.Rows[0]["Memo"] + "</p> ");
                        SB.Append("   </div> ");
                        SB.Append("   <div class=\"col-xs-8\"> ");
                        SB.Append("       <div class=\"ValueRight TRC\"> ");
                        SB.Append("           <label>" + DT.Rows[0]["total"] + "</label> ");
                        SB.Append("       </div> ");
                        SB.Append("   </div> ");
                        SB.Append("</div>");
                        T1 += Main.Cint2(DT.Rows[0]["total"].ToString());
                    }
                    L_SumTotal.Text = (Main.Cint2(L_SumTotal.Text) + T1).ToString();
                    L_Fee.Text = SB.ToString();
                }
            }
        } 
    }
}