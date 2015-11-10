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
                Dataload();
            }
        } 
        protected void BT_Search_Click(object sender, EventArgs e)
        {
            Dataload();
        }
        void Dataload()
        {
            if (Request.QueryString["act"] != null)
            {
                SD1.SelectParameters.Clear();
                SD1.SelectParameters.Add("SID", Comm.Store_ID().ToString());
                L1.Text = "Select ROW_NUMBER() OVER(ORDER BY ck desc) AS ROWID,a.Product_Name,b.ck,c.User_Name " +
                         "from Product a inner join (select count(1) ck,Product_ID,Cust_ID from Product_Click group by Product_ID,Cust_ID) b" +
                         " on a.IDNo=b.Product_ID " +
                         " left join users c on c.IDNo=b.Cust_ID where a.Store_ID=@SID";

                if (TBName.Text != "")
                { 
                    L1.Text += " and c.User_Name like '%" + TBName.Text + "%' ";
                }

                SD1.SelectCommand = L1.Text;
                SD1.ConnectionString = Main.ConnStr;
                RP1.DataSourceID = SD1.ID;

                Sub_Menu.Text = " <li class=\"swiper-slide col-xs-4\"><a href=\"Cust_Mana.aspx?com=1\" style=\"color: white\">社群力排行</a></li>  " +
                                " <li class=\"swiper-slide col-xs-4\"><a href=\"Cust_Mana.aspx?act=1\" style=\"color: white\">活動力排行</a></li>" +
                                " <li class=\"swiper-slide col-xs-4\"><a href=\"Cust_Mana.aspx\" style=\"color: white\">客戶列表</a></li>";
            }

            if (Request.QueryString["com"] != null)
            {
                SD2.SelectParameters.Clear();
                SD2.SelectParameters.Add("SID", Comm.Store_ID().ToString());

                L2.Text = "Select ROW_NUMBER() OVER(ORDER BY ck desc) AS ROWID,ck,b.User_Name  " +
                         " from (select COUNT(1) ck,FromUser_ID,Store_ID from Store_Customer group by FromUser_ID,Store_ID) a" +
                         " left join users b on b.IDNo=a.FromUser_ID where a.Store_ID=@SID ";

                if (TBName.Text != "")
                { 
                    L2.Text += " and b.User_Name like '%" + TBName.Text + "%' ";
                }

                SD2.SelectCommand = L2.Text;
                SD2.ConnectionString = Main.ConnStr;
                RP2.DataSourceID = SD2.ID;
                Sub_Menu.Text = " <li class=\"swiper-slide col-xs-4\"><a href=\"Cust_Mana.aspx\" style=\"color: white\">客戶列表</a></li>  " +
                                " <li class=\"swiper-slide col-xs-4\"><a href=\"Cust_Mana.aspx?com=1\" style=\"color: white\">社群力排行</a></li>" +
                                " <li class=\"swiper-slide col-xs-4\"><a href=\"Cust_Mana.aspx?act=1\" style=\"color: white\">活動力排行</a></li>";

            }

            if (Request.QueryString["com"] == null && Request.QueryString["act"] == null)
            {
                SD3.SelectParameters.Clear();
                SD3.SelectParameters.Add("SID", Comm.Store_ID().ToString());

                L3.Text = " Select Account,User_Name , case when isnull(b.Tel,'')='' then c.TEL else b.Tel end TEL " +
                          " From Store_Customer a left  join users b  on a.Customer_ID=b.IDNo" +
                          " left  join Customer_info c  on c.Customer_ID=b.IDNo where a.Store_ID=@SID";

                if (TBName.Text != "")
                { 
                    L3.Text += " and User_Name like '%" + TBName.Text + "%' ";
                }

                SD3.SelectCommand = L3.Text;
                SD3.ConnectionString = Main.ConnStr;
                RP3.DataSourceID = SD3.ID;

                Sub_Menu.Text = " <div class=\"swiper-slide\"><a href=\"Cust_Mana.aspx?com=1\" style=\"color: white\">社群力排行</a></div>  " +
                                " <div class=\"swiper-slide\"><a href=\"Cust_Mana.aspx\" style=\"color: white\">客戶列表</a></div>" +
                                " <div class=\"swiper-slide\"><a href=\"Cust_Mana.aspx?act=1\" style=\"color: white\">活動力排行</a></div>";
 
            }
        }

    }
}