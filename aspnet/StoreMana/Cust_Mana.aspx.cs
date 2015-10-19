using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreMana
{
    public partial class Cust_Mana : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                L.Text = "select Account,User_Name,User_Icon from Store_Customer a " +
                         "inner join [AppWeb].dbo.Users b on a.Customer_ID=b.IDNo where Store_ID='1'";
            }
            SD1.SelectCommand = L.Text;
            SD1.ConnectionString = Main.ConnStr;
            RP1.DataSourceID = SD1.ID;

        }

        protected void BT_Search_Click(object sender, EventArgs e)
        {
            L.Text = "select Account,User_Name,User_Icon from Store_Customer a " +
         "inner join [AppWeb].dbo.Users b on a.Customer_ID=b.IDNo where Store_ID='1'";

            SD1.SelectCommand = L.Text;
            SD1.ConnectionString = Main.ConnStr;
            RP1.DataSourceID = SD1.ID;

        }
    }
}