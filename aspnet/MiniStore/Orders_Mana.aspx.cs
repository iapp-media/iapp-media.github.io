using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MiniStore.Mana
{
    public partial class Orders_Mana : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        DataTable d = new DataTable(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Comm.IsNumeric(Request.QueryString["entry"]))
                {
                    L.Text = "select * ,CONVERT(varchar(10), Creat_Date, 120) AS CD from orders where store_ID =1 order by Creat_Date DESC";
                    d = Main.GetDataSetNoNull(L.Text);
                    if (d.Rows.Count > 0)
                    {
                        Literal1.Text = "";
                        for (int i = 0; i < d.Rows.Count; i++)
                        {
                            DataRow dw = d.Rows[i];

                            Literal1.Text += "<a href=\"Order_Detail.aspx?entry=" + dw["IDNo"].ToString() + "\" class=\"list-group-item\"><div class=\"row\"><div class=\"col-xs-4\">" +
                                dw["Order_No"].ToString() + "</div><div class=\"col-xs-3\">" + dw["Contact_ID"].ToString() +
                                "</div><div class=\"col-xs-2\">" + dw["status"].ToString() + "</div><div class=\"col-xs-3\">" +
                                dw["CD"].ToString() + "</div></div></a>";
                        }
                    }
                }
            }
        }

        protected void BT_Search_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "" & DropDownList1.SelectedValue == "")
            {
                L.Text = "select * ,CONVERT(varchar(10), Creat_Date, 120) AS CD from orders where store_ID =1 order by Creat_Date DESC";
                d = Main.GetDataSetNoNull(L.Text);
                if (d.Rows.Count > 0)
                {
                    Literal1.Text = "";
                    for (int i = 0; i < d.Rows.Count; i++)
                    {
                        DataRow dw = d.Rows[i];

                        Literal1.Text += "<a href=\"Order_Detail.aspx?entry=" + dw["IDNo"].ToString() + "\" class=\"list-group-item\"><div class=\"row\"><div class=\"col-xs-4\">" +
                            dw["Order_No"].ToString() + "</div><div class=\"col-xs-3\">" + dw["Contact_ID"].ToString() +
                            "</div><div class=\"col-xs-2\">" + dw["status"].ToString() + "</div><div class=\"col-xs-3\">" +
                            dw["CD"].ToString() + "</div></div></a>";
                    }
                }
                return; 
            }

            L.Text = "select * ,CONVERT(varchar(10), Creat_Date, 120) AS CD from orders where store_ID =1";

            if (TextBox1.Text != "") 
            {
                L.Text += " and Order_No= '" + TextBox1.Text + "'";
            }
            if (DropDownList1.SelectedValue != "") 
            {
                L.Text += " and status= '" + DropDownList1.SelectedValue + "'";
            }
            L.Text += " order by Creat_Date DESC";

            d = Main.GetDataSetNoNull(L.Text);
            if (d.Rows.Count > 0)
            {
                Literal1.Text = "";
                for (int i = 0; i < d.Rows.Count; i++)
                {
                    DataRow dw = d.Rows[i];

                    Literal1.Text += "<a href=\"Order_Detail.aspx?entry=" + dw["IDNo"].ToString() + "\" class=\"list-group-item\"><div class=\"row\"><div class=\"col-xs-4\">" +
                        dw["Order_No"].ToString() + "</div><div class=\"col-xs-3\">" + dw["Contact_ID"].ToString() +
                        "</div><div class=\"col-xs-2\">" + dw["status"].ToString() + "</div><div class=\"col-xs-3\">" +
                        dw["CD"].ToString() + "</div></div></a>";

                }
            }
        }
    }
}