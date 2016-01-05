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
        string str = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Store_ID"] != null)
                {
                    Main.ParaClear();
                    Main.ParaAdd("@SID", Session["Store_ID"].ToString(), System.Data.SqlDbType.Int);

                    str = "select * from Product_Cate where store_id=@SID  union all " +
                          " select * from Product_Cate where ref in ( " +
                          " select Store_Cate from Store_info where Store_ID=@SID)";

                    Main.FillDDP(DL, str, "Cate_Name", "IDNO");


                    L.Text = " Select a.IDNo,a.Product_Name,Replace(Convert(varchar(20),CONVERT(money,Price),1),'.00','') Price,CONVERT(varchar(12), a.Creat_Date, 111) AS CDate ,b.FilePath " +
                            " From product a inner join Product_Img b on a.IDNo=b.Product_ID and b.Num=1 " +
                            " where Tmp_IDNo > 0 AND  STORE_ID='" + Session["Store_ID"].ToString() + "' ";
                    SD1.SelectCommand = L.Text;
                    SD1.ConnectionString = Main.ConnStr;
                    RP1.DataSourceID = SD1.ID;
                }
            }
        }

        protected void BT_Search_Click(object sender, EventArgs e)
        {
            L.Text = " Select a.IDNo,a.Product_Name,Replace(Convert(varchar(20),CONVERT(money,Price),1),'.00','') Price,CONVERT(varchar(12), a.Creat_Date, 111) AS CDate ,b.FilePath " +
                     " From product a inner join Product_Img b on a.IDNo=b.Product_ID and b.Num=1 " +
                     " where Tmp_IDNo > 0 AND  STORE_ID='" + Session["Store_ID"].ToString() + "' ";

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
        public string ShowImg(object road)
        {
            if (road.ToString().Length > 0)
                return Comm.MiStoreUrl + road.ToString();
            else
                return "";
        }
        public string ShowName(object name)
        {
            if (name.ToString().Length > 12)
                return name.ToString().Substring(0, 10) + "...";
            else
                return name.ToString();
        }
        public string ShowPrice(object Price)
        {
            if (Price.ToString().Length > 10)
                return Price.ToString().Substring(0, 10) + "...";
            else
                return Price.ToString();
        }

        protected void SD1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (Main.Cint2(e.AffectedRows.ToString()) == 0)
            {
                PNodate.Visible = true;
            } 
        }
    }
}
