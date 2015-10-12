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

            }
        }

        protected void BT_Search_Click(object sender, EventArgs e)
        {
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



    }
}