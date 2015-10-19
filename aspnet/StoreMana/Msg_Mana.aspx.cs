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
                Main.FillDDP(DL_Pname, " select IDNO,(Product_No+'-'+Product_Name) name from Product  where Store_ID=1 ", "name", "IDNO"); 
                L.Text = "select idno,Question,isnull(Ans,'尚未回覆') Ans,(CONVERT(nvarchar, DATEDIFF(DAY,CreatDate,getdate()))+'天前') agoday from product_msg order by CreatDate DESC";

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

        protected void BT_Search_Click(object sender, EventArgs e)
        {
            L.Text = "select idno,Question,isnull(Ans,'尚未回覆') Ans,(CONVERT(nvarchar, DATEDIFF(DAY,CreatDate,getdate()))+'天前') agoday from product_msg  where 1=1 ";

            SD1.SelectParameters.Clear();

            if (DL_Pname.SelectedValue != "")
            {
                SD1.SelectParameters.Add("PID", DL_Pname.SelectedValue.ToString());
                L.Text += " and product_id=@PID ";
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