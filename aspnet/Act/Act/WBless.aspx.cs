using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wedding
{
    public partial class WBless : System.Web.UI.Page
    {
        //User_App_ID, Name, Tel, Memo, Creat_Date
        CommTool Comm = new CommTool();
        JDB Main = new JDB();
        string str = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Comm.IsNumeric(Request.QueryString["C"]) && Request.QueryString["N"] != null && Request.QueryString["T"] != null && Request.QueryString["M"] != null)
                {
                    int AppID = Comm.Cint2(Request.QueryString["C"]);


                    Main.ParaClear();
                    Main.ParaAdd("@AppID", AppID, System.Data.SqlDbType.Int);
                    Main.ParaAdd("@Name", Request.QueryString["N"].ToString(), System.Data.SqlDbType.NVarChar);
                    Main.ParaAdd("@Tel", Request.QueryString["T"].ToString(), System.Data.SqlDbType.Char);
                    Main.ParaAdd("@Memo", Request.QueryString["M"].ToString(), System.Data.SqlDbType.NVarChar);

                    str = "if not exists (Select 1 from Wedding_bless where User_App_ID=@AppID and Tel=@Tel) " +
                              "Insert into Wedding_bless (User_App_ID, Name, Tel, Memo, Creat_Date) values " +
                              " (@AppID, @Name,@Tel,@Memo,getdate()) else " +
                    "Update Wedding_bless set Memo=@Memo where User_App_ID=@AppID and Tel=@Tel";

                    Main.NonQuery(str);

                    //重複送的處理??
                    Response.Write("success");
                    Response.End();
                }
            }
        }
    }
}