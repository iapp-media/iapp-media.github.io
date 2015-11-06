using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreMana
{
    public partial class Msg_Mana : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();

        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                Main.FillDDP(DL_Pname, " select IDNO,(Product_No+'-'+Product_Name) name from Product  where Store_ID='" + Comm.Store_ID() + "' ", "name", "IDNO"); ;
                L.Text = "Select a.idno,Question,isnull(Ans,'尚未回覆') Ans,(CONVERT(nvarchar, DATEDIFF(DAY,CreatDate,getdate()))+'天前') agoday "+
                         ",isnull((CONVERT(nvarchar, DATEDIFF(DAY,RDate,getdate()))+'天前'),'') reday  ,(select top 1 FilePath from Product_Img b  where b.Product_ID=a.Product_ID) FilePath" +
                         " from product_msg a where a.Product_ID in (select IDNo from Product where store_id='" + Comm.Store_ID() + "') order by CreatDate DESC";

            }

            SD1.SelectCommand = L.Text;
            SD1.ConnectionString = Main.ConnStr;
            RP1.DataSourceID = SD1.ID;

        }
        public string ShowDetail(object IDNO)
        {
            if (IDNO.ToString().Length > 0)
                return "Msg_Add.aspx?entry=" + IDNO + "";
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
        protected void BT_Search_Click(object sender, EventArgs e)
        {
            L.Text = "Select a.idno,Question,isnull(Ans,'尚未回覆') Ans,(CONVERT(nvarchar, DATEDIFF(DAY,CreatDate,getdate()))+'天前') agoday " +
                     ",isnull((CONVERT(nvarchar, DATEDIFF(DAY,RDate,getdate()))+'天前'),'') reday  ,(select top 1 FilePath from Product_Img b  where b.Product_ID=a.Product_ID) FilePath" +
                     " from product_msg a  where a.Product_ID in (select IDNo from Product where store_id='" + Comm.Store_ID() + "') ";

            SD1.SelectParameters.Clear();

            if (DL_Pname.SelectedValue != "")
            {
                SD1.SelectParameters.Add("PID", DL_Pname.SelectedValue.ToString());
                L.Text += " and a.product_id=@PID ";
            } 


            if (DL.SelectedValue != "")
            {
                SD1.SelectParameters.Add("IsReplay", DL.SelectedValue.ToString());
                L.Text += " and isnull(IsReplay,0)=@IsReplay ";
            }
 
            L.Text += " order by CreatDate DESC";
             
            SD1.SelectCommand = L.Text;
            SD1.ConnectionString = Main.ConnStr;
            RP1.DataSourceID = SD1.ID;

        }
    }
}