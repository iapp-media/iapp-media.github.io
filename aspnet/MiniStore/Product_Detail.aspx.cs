using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MiniStore
{
    public partial class Product_Detail : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["entry"] == null || Request.QueryString["view"] == null)
            {
                Response.Redirect("Default.aspx"); 
            }
            ShowTable();
        }
        void ShowTable()
        {
            switch (Request.QueryString["view"])
            {
                case "2":
                    view2.Visible = true;
                    //view2.Attributes.CssStyle.Clear();
                    DataTable DT = Main.GetDataSetNoNull("select payment,delivery from Product where idno='" + Request.QueryString["entry"] + "' ");
                    if (DT.Rows.Count > 0)
                    {
                        string listPayment = DT.Rows[0]["payment"].ToString().Replace(",", "','");
                        listPayment = listPayment.Substring(2).ToString() + "'";

                        string listDelivery = DT.Rows[0]["delivery"].ToString().Replace(",", "','");
                        listDelivery = listDelivery.Substring(2).ToString() + "'";

                        L.Text = " select Status,Memo from def_Status where Col_Name='Payment' and Status in(" + listPayment + ") ";
                        SD1.SelectCommand = L.Text;
                        SD1.ConnectionString = Main.ConnStr;
                        RP1.DataSourceID = SD1.ID;

                        L2.Text = "select Status,Memo from def_Status where Col_Name='Payment' and Status in(" + listDelivery + ")";
                        SD2.SelectCommand = L2.Text;
                        SD2.ConnectionString = Main.ConnStr;
                        RP2.DataSourceID = SD2.ID;
                    }
                    break;


            }

        }
    }
}