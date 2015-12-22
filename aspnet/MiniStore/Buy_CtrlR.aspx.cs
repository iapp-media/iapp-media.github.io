using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MiniStore
{
    public partial class Buy_CtrlR : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        string SID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SD4.SelectParameters.Clear();
                SD4.SelectParameters.Add("IDNo", Request.QueryString["entry"]);
                L4.Text = " Select Item_ID,sum(qty) qty,SUM(Total) total,(select product_name from Product where IDNo=Item_ID) name " +
                          "from Order_Content  where Order_ID=@IDNo group by Item_ID";

                Main.ParaClear();
                Main.ParaAdd("@Store_NID", Request.QueryString["SN"], SqlDbType.NVarChar);
                SID = Main.Scalar("select IDNo from store where Store_NID=@Store_NID");
                Main.ParaAdd("@SID", Main.Cint2(SID), SqlDbType.Int);



                DataTable DT = Main.GetDataSetNoNull("select * from Store_info where Store_ID =@SID");
                if (DT.Rows.Count > 0)
                {
                    string listDelivery = DT.Rows[0]["delivery"].ToString().Replace(",", "','");
                    listDelivery = listDelivery.Substring(2).ToString() + "'";
                    Main.FillDDP(DL_Delivery, "select Status,Memo from def_Status where Col_Name='Delivery' and Status in(" + listDelivery + ") ", "Memo", "Status");
                    string listRB_Payment = DT.Rows[0]["Payment"].ToString().Replace(",", "','");
                    listRB_Payment = listRB_Payment.Substring(2).ToString() + "'";
                    Main.FillDDP(DL_Payment, "select Status,Memo from def_Status where Col_Name='Payment' and Status in(" + listRB_Payment + ") ", "Memo", "Status");

                }


                DataTable DTinfo = Main.GetDataSetNoNull("select Contact_Name,TEL,Addr,MNO,Delivery_ID,Payment_ID,Total_AMT from Orders where IDNo=" + Request.QueryString["entry"] + " ");
                if (DTinfo.Rows.Count > 0)
                {
                    TB_Name.Text = DTinfo.Rows[0]["Contact_Name"].ToString();
                    TB_Tel.Text = DTinfo.Rows[0]["TEL"].ToString();
                    TB_MNO.Text = DTinfo.Rows[0]["MNO"].ToString();
                    TB_Addr.Text = DTinfo.Rows[0]["Addr"].ToString();
                    TB_Paysum.Text = DTinfo.Rows[0]["Total_AMT"].ToString(); //應負金額
                    LTotal.Text = DTinfo.Rows[0]["Total_AMT"].ToString();
                }
                Main.ParaClear();
                Main.ParaAdd("@SNID", Request.QueryString["SN"], System.Data.SqlDbType.NVarChar);
                Main.ParaAdd("@UID", Comm.User_ID(), System.Data.SqlDbType.NVarChar);

                AllBpoin.Text = Main.Scalar("select  isnull(sum(point),0)  from Bonuspoint where Store_ID in (select IDNo from Store where Store_NID=@SNID) and User_ID=@UID ");
                if (AllBpoin.Text == "0")
                {
                    ChBonus.Visible = false;
                }
                BpoinRule.Text = Main.Scalar("Select Convert(varchar,Bpoint) + '點折' + Convert(varchar,Discount) + '元' from Store_bonus");

                LBpoint.Text = "折價點數抵扣(-" +
                    Main.Scalar("Select Point from Bonuspoint where Store_ID in (select IDNo from Store where Store_NID=@SNID) and User_ID=@UID") + "點)";
                LBprice.Text = "-" + Main.Scalar("Select Discount*(Point/Bpoint) from Bonuspoint a inner join Store_bonus b on a.Store_ID=b.Store_ID where a. Store_ID in (select IDNo from Store where Store_NID=@SNID) and a.User_ID=@UID") + "";


            }

            SD4.SelectCommand = L4.Text;
            SD4.ConnectionString = Main.ConnStr;
            RP4.DataSourceID = SD4.ID;

        }
        public string ShowImg(object IDNO)
        {
            if (IDNO.ToString().Length > 0)
                return Main.Scalar("Select FilePath from Product_Img where Product_ID='" + IDNO + "' and Num=1");
            else
                return "";
        }

        protected void BT_Confirm_Click(object sender, EventArgs e)
        {
            Main.ParaClear();
            Main.ParaAdd("@Delivery_ID", Main.Cint2(DL_Delivery.SelectedValue.ToString()), SqlDbType.NVarChar);
            Main.ParaAdd("@Payment_ID", Main.Cint2(DL_Payment.SelectedValue.ToString()), SqlDbType.NVarChar);
            Main.ParaAdd("@Contact_Name", TB_Name.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@TEL", TB_Tel.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@MNO", TB_MNO.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@Addr", TB_Addr.Text, SqlDbType.NVarChar);

            if (DL_Payment.SelectedValue.ToString() == "3")  //  銀行轉帳直接給1 (未付款)
            {
                Main.ParaAdd("@Status", "1", SqlDbType.NVarChar);
            }
            else if (DL_Payment.SelectedValue.ToString() == "5") //Visa信用卡直接給1 (未付款)(付款中)
            {
                Main.ParaAdd("@Status", "1", SqlDbType.NVarChar);
            }
            else
            {
                Main.ParaAdd("@Status", "0", SqlDbType.NVarChar);        //面交值皆給0 訂單成立 (賣家確認中)
            }


            Main.NonQuery("update Orders set Status=@Status,Contact_Name=@Contact_Name,TEL=@TEL,Addr=@Addr,MNO=@MNO,Delivery_ID=@Delivery_ID,Payment_ID=@Payment_ID where IDNo=" + Request.QueryString["entry"] + "");

            if (DL_Payment.SelectedValue.ToString() == "5")
            {
                Session["Order_Url"] = "http://220.132.67.201:88/ministore/Order_prn.aspx?entry=" + Request.QueryString["entry"] + "&SN=" + Request.QueryString["SN"] + "";
                Session["OrderID"] = Request.QueryString["entry"];
                Response.Redirect("CreditCard.aspx");
            }
            else
            {
                Response.Write("<script>alert('結帳成功');window.open('Order_prn.aspx?entry=" + Request.QueryString["entry"] + "&SN=" + Request.QueryString["SN"] + "','_self');</script>");
            }
        }

        protected void ChBonus_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBonus.Checked == true)
            {
                BonusDiscount.Visible = true;
                LTotal.Text = (Main.Cint2(TB_Paysum.Text) + Main.Cint2(LBprice.Text)).ToString();
            }
            else
            {
                BonusDiscount.Visible = false;
                LTotal.Text = TB_Paysum.Text;
            }
        }
    }
}