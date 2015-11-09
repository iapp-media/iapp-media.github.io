using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class m_login : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Comm.CheckMobile() == false) { Response.Redirect(Request.RawUrl.ToLower().Replace("m-login.aspx", "login.aspx")); }
                 
            }
        }
 
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            DoLogin();
        }

        void DoLogin()
        { 
            if (Comm.UserLogin(accBox.Text, pwBox.Text))
            {
                AfterLogin();
            }
            else
            {
                Response.Write("<script>alert('帳號或密碼錯誤')</script>");
            }

            Response.End();
        }

        void AfterLogin()
        { 
            string ThemeFolder = "basic";
            string TS = "";
            string TID = "2";

            if (Request.QueryString["done"] != null)
            {
                if (Request.QueryString["s"] != null)
                {
                    if (Request.QueryString["s"] == "1")
                    {
                        JDB Main2 = new JDB(System.Configuration.ConfigurationManager.AppSettings.Get("Database2")); 
                        if (Main2.Scalar("select 1 from Store where User_ID='" + Comm.User_ID() + "'") != "1")
                        {
                            Main2.ParaClear();
                            Main2.ParaAdd("@UID", Comm.User_ID(), System.Data.SqlDbType.Int);
                            Main2.ParaAdd("@Name", Comm.User_Name() + "的商店", System.Data.SqlDbType.NVarChar);
                            Main2.NonQuery("Insert into Store (User_ID, Store_Name,Creat_Date) values " +
                             " (@UID, @Name,getdate())   ");
                        }

                        string SID = "";
                        SID = Main2.Scalar("select IDNo from Store where User_ID='" + Comm.User_ID() + "'");
                        if (SID != "")
                        {
                            Main2.ParaClear();
                            Main2.ParaAdd("@SID", Main.Cint2(SID), System.Data.SqlDbType.Int);
                            Main2.ParaAdd("@Store_No", Comm.StoreSN(Main.Cint2(SID)), System.Data.SqlDbType.NVarChar);
                            Main2.NonQuery("update Store set Store_No=@Store_No where idno=@SID");
                            //  Response.Write(SID); 
                            Comm.SaveCookie("iapp_sid", SID);
                        }
                    }
                }
                Main.WriteLog(HttpUtility.UrlDecode(Request.QueryString["done"]));
                Response.Redirect(HttpUtility.UrlDecode(Request.QueryString["done"]));
    
            }


            if (Comm.IsNumeric(Request.QueryString["t"]))
            {
                TID = Request.QueryString["t"];
                TS = "&t=" + Request.QueryString["t"];
            }
            if (Comm.IsNumeric(Request.QueryString["c"]))
            {
                TID = Main.Scalar("Select Theme_ID from User_App where IDNo=" + Request.QueryString["c"]);
                ThemeFolder = Main.Scalar("Select FoderName from Theme where IDNo=" + TID);
                Response.Write("<Script>window.open('" + Comm.URL + ThemeFolder + "/Apps/Me/capp.aspx?i=" + Request.QueryString["c"] + "','_self')</Script>");
            }
            else
            {
                Response.Write("<Script>window.open('" + Comm.URL + "portal/portal.aspx?op=" + Guid.NewGuid().GetHashCode().ToString() + TID + "','_self')</Script>");
            }
            Response.End();
        }


        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Main.ParaClear();
            Main.ParaAdd("@Account", Email.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Pw", Pw.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@User_Name", User_Name.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@User_Type", 1, System.Data.SqlDbType.Int);
            string sql = "Insert into Users(Account,Password,User_Name,User_Type) Values (@Account,@Pw,@User_Name,@User_Type)";
            if (Main.NonQuery(sql) > 0) {
                Response.Write("<script>alert('註冊成功');</script>");
                accBox.Text = User_Name.Text;
                pwBox.Text = Pw.Text;
                DoLogin();
                //Response.Write("<script>alert('寫入成功');location.href='login.aspx'</script>");
                //Response.End();
            } else {
                Response.Write("<script>alert('寫入失敗')</script>");
            } 
        }

        protected void LB3_Click(object sender, EventArgs e)
        {
            AfterLogin();
        }
         
    }
}