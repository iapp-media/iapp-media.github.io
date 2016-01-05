using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniStore
{
    public partial class WriteUrl : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["From"] != null && Request["To"] != null)
                {
                    Main.ParaClear();
                    Main.ParaAdd("@FromUrl", Server.UrlDecode(Request["From"]), System.Data.SqlDbType.NVarChar);
                    Main.ParaAdd("@ToUrl", Server.UrlDecode(Request["To"]), System.Data.SqlDbType.NVarChar);
                    Main.ParaAdd("@SN", Request["SN"], System.Data.SqlDbType.NVarChar);
                    Main.ParaAdd("@IP", Request.UserHostAddress, System.Data.SqlDbType.NVarChar);
                    Main.ParaAdd("@Cust_ID", Comm.User_ID(), System.Data.SqlDbType.Int);
                    Main.NonQuery("insert into UrlRefer (FromUrl,ToUrl,Date,SN,IP,Cust_ID) values (@FromUrl,@ToUrl,getdate(),@SN,@IP,@Cust_ID)");
                }
            }
        }
    }
}