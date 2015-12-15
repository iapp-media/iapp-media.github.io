using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login.PClogin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["done"] != null)
                {
                    Literal1.Text = "<iframe src=\"../login.aspx?jump=store&done=" +  HttpUtility.UrlEncode(Request.QueryString["done"]) + "\"></iframe>";
                }
                else
                {
                    Literal1.Text = "<iframe src=\"http://www.iapp-media.com/login/login.aspx\"></iframe>";
                }
            }
        }
    }
}