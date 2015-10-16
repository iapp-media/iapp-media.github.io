using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StoreMana
{
    public partial class Msg_Add : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["entry"] == null)
                {
                    Response.Redirect("Msg_Mana.aspx");
                }
                Main.ParaClear();
                Main.ParaAdd("@idno", Main.Cint2(Request.QueryString["entry"].ToString()), System.Data.SqlDbType.Int);

                DataTable DT = Main.GetDataSetNoNull("select idno,Question,Ans from product_msg where idno=@idno");
                if (DT.Rows.Count > 0)
                {
                    TB_Qen.Text = DT.Rows[0]["Question"].ToString();
                    TB_Ans.Text = DT.Rows[0]["Ans"].ToString();
                }

            }
        }

        protected void BT_Confirm_Click(object sender, EventArgs e)
        {
            if (TB_Ans.Text != "")
            {
                Main.ParaClear();
                Main.ParaAdd("@ans", TB_Ans.Text, System.Data.SqlDbType.NVarChar);
                Main.ParaAdd("@idno", Main.Cint2(Request.QueryString["entry"].ToString()), System.Data.SqlDbType.Int);
                Main.NonQuery("update product_msg set ans=@ans,RDate=GETDATE(),IsReplay='1' where idno=@idno");

                Response.Redirect("Msg_Mana.aspx");
                //回覆通知 ??

            }
        }
    }
}