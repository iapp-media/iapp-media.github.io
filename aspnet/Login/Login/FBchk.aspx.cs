using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class FBchk : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string UID = "";
                string UName = Request.QueryString["name"].ToString();
                string FBID = Request.QueryString["id"].ToString();


                JDB main = new JDB();
                main.ParaAdd("@fbId", FBID, SqlDbType.NVarChar);
                main.ParaAdd("@User_Name", UName, SqlDbType.NVarChar);
                main.ParaAdd("@email", HttpUtility.UrlDecode(Request.QueryString["email"]), SqlDbType.NVarChar);
                main.ParaAdd("@User_Type", 2, SqlDbType.Int);
                main.ParaAdd("@AccessToken", HttpUtility.UrlDecode(Request.QueryString["token"]), SqlDbType.NVarChar);
                main.ParaAdd("@gender", Request.QueryString["gender"], SqlDbType.NVarChar);
                main.ParaAdd("@link", HttpUtility.UrlDecode(Request.QueryString["link"]), SqlDbType.NVarChar);

                str = "Select IDNo from Users where fbId=@fbId";
                UID = main.Scalar(str);

                if (string.IsNullOrEmpty(UID))
                {
                    str = "if not exists (select * from Users where fbId=@fbId) " +
                          "Insert into Users (fbId,User_Name,Account,User_Type,AccessToken,gender,link) " +
                          "           values (@fbId,@User_Name,@email,@User_Type,@AccessToken,@gender,@link)";
                    main.NonQuery(str);
                    str = "Select IDNo from  Users where fbId=@fbId";
                    UID = main.Scalar(str);
                }
                else
                {
                    str = "Update Users set AccessToken=@AccessToken where fbId=@fbId";
                    main.NonQuery(str);
                }
                if (Comm.IsNumeric(UID))
                {
                    Comm.SaveUserCookies(UID, UName, FBID);
                    Response.Write("success");
                }
                else
                {
                    Response.Write("error");
                }
            }
            Response.End();

        }
    }
}