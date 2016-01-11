using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Act
{
    public partial class SendSMS : System.Web.UI.Page
    {
        CommTool Comm = new CommTool();
        JDB Main = new JDB();
         

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["n"] != null)
                {
                    if (Request["n"] != "")
                    {
                        Response.Write("79812");
                        Response.End();　
                    }
                    else
                    {
                        Response.Write("err");
                        Response.End();

                    } 
                }
                else
                {
                    Response.Write("err");
                    Response.End();

                }
            }
        }
    }
}