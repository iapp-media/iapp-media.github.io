using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StoreMana
{
    public partial class Setting_Bonus : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Store_ID"] != null)
                {
                    Main.ParaClear();
                    Main.ParaAdd("@Store_ID", Main.Cint2(Session["Store_ID"].ToString()), SqlDbType.Int);

                    if (Main.Scalar("select 1 from Store_Bonus where Store_ID=@Store_ID") != "")
                    {
                        DataTable DT = Main.GetDataSetNoNull("select * from Store_Bonus");
                        if (DT.Rows.Count > 0)
                        {
                            if (DT.Rows[0]["Isable"].ToString() == "1") { ISBonus.Checked = true; } else { ISBonus.Checked = false; }
                            TBPoint.Text = DT.Rows[0]["Bpoint"].ToString();
                            TBPrice.Text = DT.Rows[0]["Discount"].ToString();
                        }
                    }
                }
            }
        }

        protected void BTSave_Click(object sender, EventArgs e)
        {
            string tmp = "";
            int Isable = 0;
            if (ISBonus.Checked == true) { 
                Isable = 1;
                if (TBPoint.Text == "") { tmp += ",折扣點數"; }
                if (TBPrice.Text == "") { tmp += ",折扣金額"; }
            } else { Isable = 0; }

            if (tmp != "")
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "String", "<script>alert('請輸入" + tmp + "');</script>");
                return;
            }

            Main.ParaClear();
            Main.ParaAdd("@Store_ID", Main.Cint2(Session["Store_ID"].ToString()), SqlDbType.Int);
            Main.ParaAdd("@Isable", Isable, SqlDbType.Int);
            Main.ParaAdd("@Bpoint", Main.Cint2(TBPoint.Text), SqlDbType.Int);
            Main.ParaAdd("@Discount", Main.Cint2(TBPrice.Text), SqlDbType.Int);

            Main.NonQuery("if not exists (select 1 from Store_Bonus where Store_ID=@Store_ID) " +
                          "insert into Store_Bonus(Store_ID, Isable, Bpoint, Discount) values " +
                          "(@Store_ID, @Isable, @Bpoint, @Discount) else " +
                          "update Store_Bonus set Isable=@Isable, Bpoint=@Bpoint, Discount=@Discount where Store_ID=@Store_ID");
        }
    }
}