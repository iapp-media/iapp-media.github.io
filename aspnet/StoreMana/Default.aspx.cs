using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreMana
{
    public partial class Default : System.Web.UI.Page
    {

        JDB Main = new JDB();
        CommTool Comm = new CommTool();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Store_ID"] != null)
                {
                    string num = "", num2 = "";
                    Main.ParaClear();
                    Main.ParaAdd("@Store_ID", Main.Cint2(Session["Store_ID"].ToString()), System.Data.SqlDbType.Int);
                    num = Main.Scalar("Select case when count(1) > 99 then '99+' else Convert(varchar(10),count(1)) end " +
                        "from Product_MSG where Product_ID in (select IDNo from Product where Store_ID=@Store_ID ) and isnull(IsReplay,0)!=1");

                    if (num != "0")
                    {
                        MCount.Text = "<span class='MenuNum'>" + num + "</span>";

                    }
                    num2 = Main.Scalar("select count(1) from orders where Store_ID=@Store_ID and Status!=30 ");
                    if (num2 != "0")
                    {
                        OCount.Text = "<span class='MenuNum'>" + num2 + "</span>";
                    }
                }

            }
        }
    }
}