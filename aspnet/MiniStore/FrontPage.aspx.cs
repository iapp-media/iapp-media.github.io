using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniStore
{
    public partial class FrontPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Literal1.Text = "<img src=\"QRcode.ashx?t=Default.aspx?SN=OfficACC\" alt=\"\" class=\"QRcode\" />";
            }
        }
    }
}