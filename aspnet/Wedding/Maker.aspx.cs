using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wedding
{
    public partial class Maker : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                L1.Text = " Select Name,Tel,Attendance from wedding_attn ";

                L2.Text = " Select Name,Tel,Memo  from Wedding_bless ";

                SD1.SelectCommand = L1.Text;
                SD1.ConnectionString = Main.ConnStr;
                RP_attn.DataSourceID = SD1.ID;

                SD2.SelectCommand = L2.Text;
                SD2.ConnectionString = Main.ConnStr;
                RP_bless.DataSourceID = SD2.ID;
            }
        }
    }
}