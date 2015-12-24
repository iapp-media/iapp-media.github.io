using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace MiniStore
{
    public partial class Default : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        string SID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["SN"] != null)
                {
                    Main.ParaClear();
                    Main.ParaAdd("@Store_NID", Request.QueryString["SN"].ToString(), SqlDbType.NVarChar);
                    SID = Main.Scalar("select IDNo from store where Store_NID=@Store_NID");
                    if (SID != "")
                    {
                        Main.ParaAdd("@SID", Main.Cint2(SID), SqlDbType.Int);
                          ShowData(Main.Scalar("select layout from store_info where store_id=@SID")); 
                       
                        LCarLink.Text = " <a id=\"Buycar\"  href=\"Buy_Ctrl.aspx?SN=" + Request.QueryString["SN"] + "\">" +
                            " <img class=\"back-top\" src=\"img/cart.png\" /><span/><label id=\"IconCar\">" +
                            Main.Scalar("Select case when COUNT(1) > 99 then '99+' else Convert(varchar,COUNT(1) ) end from ShoppingCart where User_ID='" + Comm.User_ID() + "' and Store_ID in ( select IDNo from Store where Store_NID='" + Request.QueryString["SN"] + "')") +
                            "</label></span> </a>";
                    }
                    Main.ParaClear();
                    Main.ParaAdd("@Store_NID", Request.QueryString["SN"].ToString(), SqlDbType.NVarChar);
                    str = "select IDNo,Cate_Name from Product_Cate  where IDNo in ( " +
                         "select Cate_ID from Product where Store_ID in (select IDNo from Store where Store_NID=@Store_NID )) ";
                    if (Request.QueryString["c"] != null)
                    {
                        Main.ParaAdd("@cate_id", Request.QueryString["c"], SqlDbType.NVarChar);
                        str += " and idno!=@cate_id ";
                    }
                    DataTable DT = Main.GetDataSetNoNull(str);
                    if (DT.Rows.Count > 0)
                    {
                        for (int i = 0; i < DT.Rows.Count; i++)
                        {
                            if (i == 1 && Request.QueryString["c"] != null)
                            {
                                //L_Cate.Text += " <div class=\"swiper-slide\"><a href=\"Default.aspx?SN=" + Request.QueryString["SN"] + "&C=" + Request.QueryString["c"] + "\" style=\"color: white\">" + Main.Scalar("select Cate_Name from product_cate where idno=" + Request.QueryString["c"] + "") + "</a></div> ";
                                L_Cate.Text += " <div class=\"swiper-slide\" data-src=\"Default.aspx?SN=" + Request.QueryString["SN"] + "&C=" + Request.QueryString["c"] + "\">" + Main.Scalar("select Cate_Name from product_cate where idno=" + Request.QueryString["c"] + "") + "</div>";
                            }
                            //    L_Cate.Text += " <div class=\"swiper-slide\"><a href=\"Default.aspx?SN=" + Request.QueryString["SN"] + "&C=" + DT.Rows[i]["IDNo"] + "\" style=\"color: white\">" + DT.Rows[i]["Cate_Name"] + "</a></div> ";
                            L_Cate.Text += " <div class=\"swiper-slide\" data-src=\"Default.aspx?SN=" + Request.QueryString["SN"] + "&C=" + DT.Rows[i]["IDNo"] + "\">" + DT.Rows[i]["Cate_Name"] + "</div>";

                        }

                    }
                }
            }
        }

        void ShowData(string obj)
        {
            SD.SelectParameters.Clear();
            Main.ParaClear();
            Main.ParaAdd("@SID", SID, SqlDbType.NVarChar);
            Main.ParaAdd("@MyID", Comm.User_ID(), SqlDbType.Int);
            SD.SelectParameters.Add("SID", SID);
            SD.SelectParameters.Add("MyID", Comm.User_ID().ToString());
            if (obj == "5")
            {


                str = "select a.IDNo,Product_Name,Price,b.FilePath,a.qty,isnull(c.qty,0) as carbaby ,(Select Count(1) from Product_Like where Product_ID=a.IDNo and User_ID=@MyID) as iLK" +
    " from Product a inner join Product_Img b on a.IDNo=b.Product_ID " +
    "  left join ShoppingCart c on c.Product_ID=a.IDNo and c.User_ID=@MyID where b.Num=1 and a.store_id=@SID ";

                if (Request.QueryString["c"] != null)
                {
                    SD.SelectParameters.Add("cate_id", Request.QueryString["c"]);
                    Main.ParaAdd("@cate_id", Request.QueryString["c"], SqlDbType.NVarChar);
                    str += " and cate_id=@cate_id ";
                }
                if (Request.QueryString["w"] != null)               //關鍵字
                {
                    SD.SelectParameters.Add("KW", "%" + HttpUtility.UrlDecode(Request.QueryString["w"]) + "%");
                    str += " and ( Product_Name Like @KW or Price like @KW )  ";
                    //HL1.NavigateUrl += "&t=" + Request.QueryString["w"];
                    Main.ParaAdd("@KW", "%" + HttpUtility.UrlDecode(Request.QueryString["w"]) + "%", SqlDbType.NVarChar);
                }

                Fast.Visible = true;
                Basic.Visible = false;
                StringBuilder ss = new StringBuilder();
                DataTable dr = Main.GetDataSetNoNull(str);
                if (dr.Rows.Count > 0)
                {
                    Basic.Visible = false;
                    for (int i = 0; i < dr.Rows.Count; i++)
                    {
                        DataRow dw = dr.Rows[i];

                        //string iLK = "";
                        //if (Comm.Cint2(dw["iLK"].ToString()) > 0) { iLK = " checked"; } 
                        ss.Append("        <div class=\"details col-xs-12\">" + "\n\r");
                        ss.Append("            <div class=\"DTimg\">" + "\n\r");
                        ss.Append("<a href='Buy_detail.aspx?entry=" + dw["IDNo"].ToString() + "&SN=" + Request.QueryString["SN"] + "'>" + "\n\r");
                        ss.Append("                <img class=\"productSize imgH\" src='" + dw["FilePath"].ToString() + "'/></a>" + "\n\r");
                        ss.Append("            </div>" + "\n\r");
                        ss.Append("            <div class=\"Detailsmid\">" + "\n\r");
                        ss.Append("                <h3>" + dw["Product_Name"].ToString() + "</h3>" + "\n\r");
                        ss.Append("                <div class=\"MonBoxL\">" + "\n\r");
                        ss.Append("                    <span class=\"TOC\">$" + string.Format("{0:#,##0}", Main.Cint2(dw["Price"].ToString())) + "</span>" + "\n\r");
                        ss.Append("                </div>" + "\n\r");
                        ss.Append("<div class=\"MonBoxR\">");
                        ss.Append("                <span class=\"input-number-decrement\" onclick='minus(" + dw["IDNo"].ToString() + ")'>–</span>" + "\n\r");
                        ss.Append("                <input id=\"Num_" + dw["IDNo"].ToString() + "\" name=\"\" type=\"number\" value=\"" + dw["carbaby"].ToString() + "\" class=\"input-number\"  disabled=\"disabled\"/>" + "\n\r");
                        ss.Append("                <span class=\"input-number-increment\" onclick='plus(" + dw["IDNo"].ToString() + "," + dw["qty"].ToString() + ")'>+ </span>" + "\n\r");
                        ss.Append("</div>");
                        ss.Append("            </div>" + "\n\r");
                        // ss.Append("            </span>" + "\n\r");
                        ss.Append("        </div> " + "\n\r");
                    }
                }
                else
                {
                    ss.Clear();
                }
                //Layout_fast.Text = ss.ToString();
                Layout_fast.Text = str;
                SD.SelectCommand = Layout_fast.Text;
                SD.ConnectionString = Main.ConnStr;
                RPFast_Drink.DataSourceID = SD.ID;
            }
            else
            {
                str = "select a.IDNo,Product_Name,Price,b.FilePath,a.qty ,(Select Count(1) from Product_Like where Product_ID=a.IDNo and User_ID=@MyID) as iLK" +
                      " from Product a inner join Product_Img b on a.IDNo=b.Product_ID where b.Num=1 and a.store_id=@SID ";

                if (Request.QueryString["c"] != null)
                {
                    Main.ParaAdd("@cate_id", Request.QueryString["c"], SqlDbType.NVarChar);
                    str += " and cate_id=@cate_id ";
                }
                if (Request.QueryString["w"] != null)               //關鍵字
                {
                    str += " and ( Product_Name Like @KW or Price like @KW )  ";
                    //HL1.NavigateUrl += "&t=" + Request.QueryString["w"];
                    Main.ParaAdd("@KW", "%" + HttpUtility.UrlDecode(Request.QueryString["w"]) + "%", SqlDbType.NVarChar);
                }

                Fast.Visible = false;
                Basic.Visible = true;
                StringBuilder ss = new StringBuilder();
                DataTable dr = Main.GetDataSetNoNull(str);
                if (dr.Rows.Count > 0)
                {
                    Fast.Visible = false;
                    for (int i = 0; i < dr.Rows.Count; i++)
                    {
                        DataRow dw = dr.Rows[i];

                        string iLK = "";
                        if (Comm.Cint2(dw["iLK"].ToString()) > 0) { iLK = " checked"; }

                        ss.Append("<div class='item'>" + "\n\r");
                        ss.Append("  <div class='imgcenter'>\n\r");
                        ss.Append("     <div>" + "\n\r");
                        ss.Append("        <a href='Buy_detail.aspx?entry=" + dw["IDNo"].ToString() + "&SN=" + Request.QueryString["SN"] + "'><img class=\"item-pic\" src='" + dw["FilePath"].ToString() + "'/></a>" + "\n\r");


                        ss.Append("     </div>\n\r");
                        ss.Append("     <div class='col-xs-12 description'>" + "\n\r");
                        ss.Append("         <div class='col-xs-12'>" + "\n\r");
                        ss.Append("             <div class='row'>" + "\n");
                        ss.Append("             <p class='describe'>" + dw["Product_Name"].ToString() + "</p>" + "\n\r");
                        ss.Append("             </div>" + "\n");
                        ss.Append("         </div>" + "\n");
                        ss.Append("         <div class='col-xs-12'>" + "\n\r");
                        ss.Append("             <div class='row'>" + "\n");

                        // ss.Append("                <label class=\"label--checkbox\">\n\r");
                        ss.Append("                    <input type=\"checkbox\" class=\"like\" onclick=\"likeit(this)\" id=\"k" + dw["IDNo"].ToString() + "\"" + iLK + "> \n\r");
                        // ss.Append("                </label>\n\r");
                        // ss.Append("             <input type='checkbox' id='c3'  name='CC' />" + "\n");
                        ss.Append("             <label for='k" + dw["IDNo"].ToString() + "'></label>" + "\n");

                        ss.Append("             </div>" + "\n");
                        ss.Append("         </div>" + "\n");
                        ss.Append("     </div>" + "\n");
                        ss.Append("     <div class='col-xs-12 FrontBot'>" + "\n\r");
                        ss.Append("         <p class='iapp-name col-xs-8'>NT$" + string.Format("{0:#,##0}", Main.Cint2(dw["Price"].ToString())) + "</p>" + "\n\r");
                        ss.Append("        <button  class='col-xs-4'> <a href='Buy_Add.aspx?entry=" + dw["IDNo"].ToString() + "&SN=" + Request.QueryString["SN"] + "'>購買</a></button>" + "\n\r");
                        ss.Append("     </div>" + "\n");
                        ss.Append("  </div>" + "\n");
                        ss.Append("</div>" + "\n");
                    }
                }
                else
                {
                    ss.Clear();
                }
                LData.Text = ss.ToString();
            }

        }

        protected void BTFast_Click(object sender, EventArgs e)
        {
            Response.Redirect("Buy_Ctrl.aspx?sn=" + Request.QueryString["SN"] + "");
        }
        void bubbleSort(int[] list)
        {
            int n = list.Length;
            int temp;
            int Flag = 1; //旗標
            int i;
            for (i = 1; i <= n - 1 && Flag == 1; i++)
            {    // 外層迴圈控制比較回數
                Flag = 0;
                for (int j = 1; j <= n - i; j++)
                {  // 內層迴圈控制每回比較次數            
                    if (list[j] < list[j - 1])
                    {  // 比較鄰近兩個物件，右邊比左邊小時就互換。	       
                        temp = list[j];
                        list[j] = list[j - 1];
                        list[j - 1] = temp;
                        Flag = 1;
                    }
                }
            }
        } 
        protected void RPFast_Drink_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Literal ItemIDNo = (Literal)e.Item.FindControl("ItemIDNo");
                RadioButtonList RB1 = (RadioButtonList)e.Item.FindControl("RB_DrinkSize");
                RadioButtonList RB2 = (RadioButtonList)e.Item.FindControl("RB_DrinkIce");
                RadioButtonList RB3 = (RadioButtonList)e.Item.FindControl("RB_DrinkSugar");

                if (e.CommandName == "CNplus")
                {
                    if (!string.IsNullOrEmpty(RB1.SelectedValue) && !string.IsNullOrEmpty(RB2.SelectedValue) && !string.IsNullOrEmpty(RB3.SelectedValue))
                    {
                        Main.ParaClear();
                        Main.ParaAdd("@PID", Main.Cint2(ItemIDNo.Text), SqlDbType.Int);
                        Main.ParaAdd("@UID", Main.Cint2(Comm.User_ID()), SqlDbType.Int);
                        string SPEC_Group = "";
                        int[] RBlist = new int[3];

                        RBlist[0] = Main.Cint2(RB1.SelectedValue.ToString());
                        RBlist[1] = Main.Cint2(RB2.SelectedValue.ToString());
                        RBlist[2] = Main.Cint2(RB3.SelectedValue.ToString());
                        bubbleSort(RBlist);
                        for (int n = 0; n < RBlist.Length; n++)
                        {
                            SPEC_Group += "," + RBlist[n].ToString();
                        }
                        Main.ParaAdd("@SPEC_Group", SPEC_Group, SqlDbType.NVarChar);
                        int c = Main.NonQuery("if not exists ( select '1' from ShoppingCart where Product_ID=@PID and user_id=@UID and SPEC_Group=@SPEC_Group) " +
                                              " insert into ShoppingCart (Store_ID,Product_ID,User_ID,qty,SPEC_Group) values " +
                                              "((select Store_ID from Product where idno=@PID),@PID,@UID,1,@SPEC_Group) " +
                                              "else Update ShoppingCart set qty=qty+1 where Product_ID=@PID and user_id=@UID and SPEC_Group=@SPEC_Group ");
                        if (c > 0)
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "ajaxCarItem();", true);
                        }
                        else
                        {
                            //Response.Write("err");
                        }
                        // System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "alert('CNplus" + ItemIDNo.Text + "');", true);

                    }
                    else {
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "alert('請選擇甜度冰塊');", true);
                    }
                }
            }
        }

        protected void RPFast_Drink_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RadioButtonList RB_DrinkSize = (RadioButtonList)e.Item.FindControl("RB_DrinkSize");
                RadioButtonList RB_DrinkIce = (RadioButtonList)e.Item.FindControl("RB_DrinkIce");
                RadioButtonList RB_DrinkSugar = (RadioButtonList)e.Item.FindControl("RB_DrinkSugar");
                Main.FillDDP(RB_DrinkSize, "select IDNo,Item from Product_SPEC_Item where SPEC_ID=1 order by Sort", "Item", "IDNo");
                Main.FillDDP(RB_DrinkIce, "select IDNo,Item from Product_SPEC_Item where SPEC_ID=2 order by Sort", "Item", "IDNo");
                Main.FillDDP(RB_DrinkSugar, "select IDNo,Item from Product_SPEC_Item where SPEC_ID=3 order by Sort", "Item", "IDNo");

            }
        }
    }
}