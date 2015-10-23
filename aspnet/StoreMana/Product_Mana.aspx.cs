using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreMana
{
    public partial class Product_Mana : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Main.FillDDP(DL, "select * from Product_Cate", "Cate_Name", "IDNO");
                L.Text = "select IDNo,Product_Name,Price,CONVERT(varchar(12), Creat_Date, 111) AS CDate  from product where Tmp_IDNo > 0 ";
                SD1.SelectCommand = L.Text;
                SD1.ConnectionString = Main.ConnStr;
                RP1.DataSourceID = SD1.ID;
            }
        }

        protected void BT_Search_Click(object sender, EventArgs e)
        {
            L.Text = "select IDNo,Product_Name,Price,CONVERT(varchar(12), Creat_Date, 111) AS CDate  from product where Tmp_IDNo > 0";

            if (DL.SelectedValue != "")
            {
                L.Text += " and Cate_ID= '" + DL.SelectedValue + "'";
            }

            L.Text += " order by Creat_Date DESC";

            SD1.SelectCommand = L.Text;
            SD1.ConnectionString = Main.ConnStr;
            RP1.DataSourceID = SD1.ID;
        }

        public string ShowDetail(object IDNO)
        {
            if (IDNO.ToString().Length > 0)
                return "Product_Add.aspx?entry=" + IDNO + "";
            else
                return "";
        } 
    }
}