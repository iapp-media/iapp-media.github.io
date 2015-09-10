using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Act
{
    public partial class Share : System.Web.UI.Page
    {
        CommTool Comm = new CommTool();
        JDB Main = new JDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Response.Write(Request.UrlReferrer.ToString());
            if (!IsPostBack)
            {
                Uri u = Request.UrlReferrer;
                if (u != null && Comm.IsNumeric(Request.QueryString["i"]))
                {
                    int ShareTo = 0;
                    if (Comm.IsNumeric(Request.QueryString["to"])) { ShareTo = Comm.Cint2(Request.QueryString["to"]); }
                    //if (Comm.URL.IndexOf(u.Host) < 0) { return; }
                    int AppID = Comm.Cint2(Request.QueryString["i"]);
                    if (AppID <= 0) { return; }
                    string IP = Request.UserHostAddress;

                    Main.ParaClear();
                    Main.ParaAdd("@AppID", AppID, System.Data.SqlDbType.Int);
                    Main.ParaAdd("@UserID", Comm.User_ID(), System.Data.SqlDbType.Int);
                    Main.ParaAdd("@ShareTo", ShareTo, System.Data.SqlDbType.Int);
                    Main.ParaAdd("@IP", IP, System.Data.SqlDbType.VarChar);
                    string str = "Insert into User_App_Share (User_App_ID,User_ID,Geo,IP,Creat_Date,ShareTo) values " +
                                 " (@AppID, @UserID,'',@IP,getdate(),@ShareTo)";
                    Main.NonQuery(str);

                    Response.Write("success");
                    //string TM = Main.Scalar("Select FoderName from Theme where IDNo=(Select Theme_ID from User_App where IDNo=@AppID)");

                    //if (ShareTo == 1) {
                        
                    //}
                    //Response.Redirect("https://www.facebook.com/sharer.php?u=" + Comm.URL + TM + "/" + AppID);


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