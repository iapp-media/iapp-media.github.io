using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniStore
{
    public partial class StoreFront : System.Web.UI.MasterPage
    {
        CommTool Comm = new CommTool();
        JDB Main = new JDB();
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Comm.User_ID().ToString() != "")
                {
                    
                }
            }
        }
    }
}