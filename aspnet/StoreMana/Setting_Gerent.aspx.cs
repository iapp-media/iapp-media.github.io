using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreMana
{
    public partial class Setting_Gerent : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SD1.SelectParameters.Clear();
                SD1.SelectParameters.Add("Store_ID", Comm.Store_ID().ToString());
                L1.Text = "select * from Store_User where store_id=@Store_ID";
                SD1.SelectCommand = L1.Text;
                SD1.ConnectionString = Main.ConnStr;
                RP1.DataSourceID = SD1.ID;
            }
            
        }

        protected void BT_Confirm_Click(object sender, EventArgs e)
        {
            if (TB_ACC.Text != "")
            {
                Main.ParaClear();
                Main.ParaAdd("@Store_ID", Comm.Store_ID(), System.Data.SqlDbType.Int);
                Main.ParaAdd("@ACC", TB_ACC.Text, System.Data.SqlDbType.NVarChar);
                Main.NonQuery("Insert into Store_User (Store_ID,Account) values (@Store_ID,@ACC)");
                SD1.SelectCommand = L1.Text;
                SD1.ConnectionString = Main.ConnStr;
                RP1.DataSourceID = SD1.ID;
            }
        }
    }
}