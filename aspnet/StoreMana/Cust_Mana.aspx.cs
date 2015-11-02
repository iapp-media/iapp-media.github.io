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
                if (Request.QueryString["act"] != null)
                {
                    SD1.SelectParameters.Clear();
                    SD1.SelectParameters.Add("SID", Comm.Store_ID().ToString());
                    L1.Text = "Select ROW_NUMBER() OVER(ORDER BY ck desc) AS ROWID,a.Product_Name,b.ck,c.User_Name " +
                             "from Product a inner join (select count(1) ck,Product_ID,Cust_ID from Product_Click group by Product_ID,Cust_ID) b" +
                             " on a.IDNo=b.Product_ID " +
                             " left join users c on c.IDNo=b.Cust_ID where a.Store_ID=@SID";

                    SD1.SelectCommand = L1.Text;
                    SD1.ConnectionString = Main.ConnStr;
                    RP1.DataSourceID = SD1.ID;

                }

                if (Request.QueryString["com"] != null)
                {
                    SD2.SelectParameters.Clear();
                    SD2.SelectParameters.Add("SID", Comm.Store_ID().ToString());

                    L2.Text = "Select ROW_NUMBER() OVER(ORDER BY ck desc) AS ROWID,ck,b.User_Name  " +
                             " from (select COUNT(1) ck,FromUser_ID,Store_ID from Store_Customer group by FromUser_ID,Store_ID) a" +
                             " left join users b on b.IDNo=a.FromUser_ID where a.Store_ID=@SID"; 

                    SD2.SelectCommand = L2.Text;
                    SD2.ConnectionString = Main.ConnStr;
                    RP2.DataSourceID = SD2.ID;
                }

                if (Request.QueryString["com"] == null && Request.QueryString["act"] == null)
                {
                    SD3.SelectParameters.Clear();
                    SD3.SelectParameters.Add("SID", Comm.Store_ID().ToString());

                    L3.Text = " select Account,User_Name,User_Icon from Store_Customer a " +
                             " left  join users b on a.Customer_ID=b.IDNo where Store_ID=@SID";

                    SD3.SelectCommand = L3.Text;
                    SD3.ConnectionString = Main.ConnStr;
                    RP3.DataSourceID = SD3.ID;

                }
                 
            } 
        } 
    }
}