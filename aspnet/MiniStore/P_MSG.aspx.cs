using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniStore
{
    public partial class P_MSG : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["entry"] == null)
            {
                Response.Redirect("Default.aspx"); 
            }
            L.Text = "select Question,isnull(Ans,'尚未回覆') Ans,(CONVERT(nvarchar, DATEDIFF(DAY,CreatDate,getdate()))+'天前') agoday from product_msg order by CreatDate DESC ";


            SD1.SelectCommand = L.Text;
            SD1.ConnectionString = Main.ConnStr;
            RP1.DataSourceID = SD1.ID;
        }

        protected void btsend_Click(object sender, EventArgs e)
        {
            if (tbQuen.Text != "")
            {
                Main.ParaClear();
                Main.ParaAdd("@Product_ID", Main.Cint2(Request.QueryString["entry"].ToString()), System.Data.SqlDbType.Int);
                Main.ParaAdd("@Question", tbQuen.Text, System.Data.SqlDbType.NVarChar);

                Main.NonQuery("insert into product_msg (Product_ID, Question, CreatDate) values " +
                    "(@Product_ID, @Question, getdate())");

                SD1.SelectCommand = L.Text;
                SD1.ConnectionString = Main.ConnStr;
                RP1.DataSourceID = SD1.ID;
            }
        } 
    }
}