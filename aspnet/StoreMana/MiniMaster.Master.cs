using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreMana.Mini
{
    public partial class MiniMaster : System.Web.UI.MasterPage
    {
        CommTool Comm = new CommTool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Comm.Store_ID() == -1)
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "if(confirm('請先登入')){window.open('http://localhost:18429/Default.aspx?SN=Straight5','_self');}else{window.open('http://localhost:18429/Default.aspx?SN=Straight5','_self');}", true);
                }
            }
        }

        protected void LBLogout_Click(object sender, EventArgs e)
        {
            Comm.DeleCoookie("iapp_sid");
            Response.Redirect(Request.RawUrl);
        }
    }
}