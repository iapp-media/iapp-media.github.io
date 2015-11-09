using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniStore
{
    public partial class Join : System.Web.UI.Page
    {
        CommTool Comm = new CommTool();
        JDB Main = new JDB();
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["join"] != null)
                {
                    switch (Request.QueryString["join"])
                    {
                        case "0":
                            string SID = "";
                            SID = Main.Scalar("select idno from Store where User_ID='" + Comm.User_ID() + "'");
                            if (SID != "")
                            {
                              
                                int c = Comm.DeleCoookie("iapp_sid"); //暫時確保 1106
                                int a = Comm.SaveCookie("iapp_sid", SID, 365);
                              
                                Response.Write("jump");
                            }
                            else
                            {
                                Response.Write("join"); 
                            }
                            break;
                        case "1":
                            break;
                    }
                }
            }
        }
    }
}