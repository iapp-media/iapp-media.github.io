﻿using System;
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
                    }
                }
            }
        }

        void ShowData(string obj)
        {
 
            Main.ParaClear();
            Main.ParaAdd("@SID", SID, SqlDbType.NVarChar);
            Main.ParaAdd("@MyID", Comm.User_ID(), SqlDbType.Int);
            str = "select a.IDNo,Product_Name,Price,b.FilePath,a.qty,isnull(c.qty,0) as carbaby ,(Select Count(1) from Product_Like where Product_ID=a.IDNo and User_ID=@MyID) as iLK" +
                " from Product a inner join Product_Img b on a.IDNo=b.Product_ID " +
                "  left join ShoppingCart c on c.Product_ID=a.IDNo and c.User_ID=@MyID where b.Num=1 and a.store_id=@SID ";
             
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

            if (obj == "5")
            {
                
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
                        ss.Append("                <div class=\"MonBox\">" + "\n\r"); 
                        ss.Append("                    <span class=\"TOC\">NT$" + string.Format("{0:#,##0}", Main.Cint2(dw["Price"].ToString())) + "</span>" + "\n\r");
                        ss.Append("                </div>" + "\n\r");
                        ss.Append("                <span class=\"input-number-decrement\" onclick='minus(" + dw["IDNo"].ToString() + ")'>–</span>" + "\n\r");
                        ss.Append("                <input id=\"Num_" + dw["IDNo"].ToString() + "\" name=\"\" type=\"number\" value=\"" + dw["carbaby"].ToString() + "\" class=\"input-number\">" + "\n\r");
                        ss.Append("                <span class=\"input-number-increment\" onclick='plus(" + dw["IDNo"].ToString() + "," + dw["qty"].ToString() + ")'>+ </span>" + "\n\r");
                        ss.Append("            </div>" + "\n\r");
                        ss.Append("            <span class=\"cancelTransaction\">" + "\n\r");
                        ss.Append("            </span>" + "\n\r");
                        ss.Append("        </div> " + "\n\r");
                     }
                }
                else
                { 
                    ss.Clear();
                }
                Layout_fast.Text = ss.ToString();
            }
            else
            {
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
    }
}