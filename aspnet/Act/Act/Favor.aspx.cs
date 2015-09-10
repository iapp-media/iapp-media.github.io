using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Act
{
    public partial class Favor : System.Web.UI.Page
    {
        CommTool Comm = new CommTool();
        JDB Main = new JDB();
        string str = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Response.Write(Request.UrlReferrer.ToString());
            if (!IsPostBack)
            {
                Uri u = Request.UrlReferrer;
                if (u != null && Comm.IsNumeric(Request.QueryString["i"]))
                {
                    //if (Comm.URL.IndexOf(u.Host) < 0) { return; }
                    bool fn = false;
                    if (Comm.Cint2(Request.QueryString["fn"]) == 1) { fn = true; }
                    int AppID = Comm.Cint2(Request.QueryString["i"]);
                    string IP = Request.UserHostAddress; 

                    Main.ParaClear();
                    Main.ParaAdd("@AppID", AppID, System.Data.SqlDbType.Int);
                    Main.ParaAdd("@UserID", Comm.User_ID(), System.Data.SqlDbType.Int);
                    Main.ParaAdd("@IP", IP, System.Data.SqlDbType.VarChar); 
                    if (fn)
                    {
                        str = "if not exists (Select * from User_App_Favor where User_App_ID=@AppID and User_ID=@UserID) " +
                              "Insert into User_App_Favor (User_App_ID,User_ID,Geo,IP,Creat_Date) values " +
                              " (@AppID, @UserID,'',@IP,getdate())";
                    }
                    else
                    {
                        str = "delete from User_App_Favor where User_App_ID=@AppID and User_ID=@UserID";
                    }
                    Main.NonQuery(str);
                    Response.Write("success");
                }
                else
                {
                    Response.Write("error");
                }
                Response.End();
            }
        }
    }
}