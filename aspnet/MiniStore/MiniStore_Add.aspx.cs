using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniStore
{
    public partial class MiniStore_Add : System.Web.UI.Page
    {
        CommTool Comm = new CommTool();
        JDB Main = new JDB();
        string str = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                if (Comm.IsNumeric(Request.QueryString["U"]))
                {
                    int UID = Comm.Cint2(Request.QueryString["U"]);
                    Main.ParaClear();
                    if (Request.QueryString["N"] != null)
                    {
                        Main.ParaAdd("@Name", Request.QueryString["N"].ToString(), System.Data.SqlDbType.NVarChar);
                    }
                    else
                    {
                        Main.ParaAdd("@Name", "我的微商店", System.Data.SqlDbType.NVarChar);
                    }

                    Main.ParaAdd("@UID", UID, System.Data.SqlDbType.Int);
 
                    if (Main.Scalar("select 1 from Store where User_ID=@UID") != "1")
                    { 
                        Main.NonQuery("Insert into Store (User_ID, Store_Name,Creat_Date) values " +
                         " (@UID, @Name,getdate())   "); 
                    }

                    string SID = "";
                    SID = Main.Scalar("select IDNo from Store  where User_ID=@UID");
                    if (SID != "")
                    {
                        Response.Write(SID);
                    }
                    else { Response.Write("ERR"); } 
                    Response.End();
                }
            }
        }
    }
}