using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Act
{
    public partial class Click : System.Web.UI.Page
    {
        CommTool Comm = new CommTool();
        JDB Main = new JDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Response.Write(Request.UrlReferrer.ToString());
            if (!IsPostBack)
            { 
                Uri u = Request.UrlReferrer;
                if (u != null)
                {
                    //if (Comm.URL.IndexOf(u.Host) < 0) { return; }
                    int AppID = 0;// Comm.Cint2(u.LocalPath.Substring(1, u.LocalPath.IndexOf(".") - 1));
                    if (u.LocalPath.IndexOf(".") > 1)
                    {
                        AppID = Comm.Cint2(u.LocalPath.Substring(1, u.LocalPath.IndexOf(".") - 1));
                    }
                    else
                    {
                        AppID = Comm.Cint2(u.LocalPath.Substring(u.LocalPath.LastIndexOf("/") + 1));
                    }

                    if (AppID <= 0) { return; }
                    string IP = Request.UserHostAddress;

                    Main.ParaClear();
                    Main.ParaAdd("@AppID", AppID, System.Data.SqlDbType.Int);
                    Main.ParaAdd("@UserID", Comm.User_ID(), System.Data.SqlDbType.Int);
                    Main.ParaAdd("@IP", IP, System.Data.SqlDbType.VarChar);
                    string str = "Insert into User_App_Click (User_App_ID,User_ID,Geo,IP,Creat_Date) values " +
                                 " (@AppID, @UserID,'',@IP,getdate())";
                    Main.NonQuery(str);
                    Response.Write("success");
                }
                else
                {
                    Response.Write("error");
                }
              // Response.End();
            }
        }
    }
}