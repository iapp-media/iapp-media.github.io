using System;
using System.IO;
using System.Collections.Generic;
using System.Linq; 
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreMana
{
    public partial class Product_Img : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Comm.IsNumeric(Request.QueryString["PID"]) & Comm.IsNumeric(Request.QueryString["Img"]))
                {
                    string pimg = Main.Scalar("select FilePath from Product_Img where Product_ID='" + Request.QueryString["PID"].ToString() + "'  and Num='" + Request.QueryString["Img"] + "'");
                    if (pimg != "")
                    {
                        L.Text = "<a id='show-upload' href='#'>" +
                                    "<label for='FU'>" +
                                        "<img   height='250' width='200'  src='" + pimg + "' />" +
                                    " </label>" +
                                 "</a>";
                    }
                    else
                    {
                        L.Text = "<a id='show-upload'  href='#'>" +
                                    " " +
                                        "<img class='upload' src='img/Noodles.jpg' />" +
                                    " " +
                                 "</a>";
                    } 
                }
            }
        }

     }
}