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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["From"] != null && Request["To"] != null)
                {
                    Main.ParaClear();
                    Main.ParaAdd("@FromUrl",Request["From"],System.Data.SqlDbType.NVarChar);
                    Main.ParaAdd("@ToUrl",Request["To"],System.Data.SqlDbType.NVarChar); 
                    Main.NonQuery("insert into UrlRefer (FromUrl,ToUrl,Date) values (@FromUrl,@ToUrl,getdate())"); 
                }
            }
        }
    }
}