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
                if (Comm.CheckMobile() == false)
                {
                    if (Request.QueryString["jump"] != null)
                    {
                        switch (Request.QueryString["jump"])
                        {
                            case "store":
                                Response.Redirect(Request.RawUrl.ToLower().Replace("m-login.aspx", "pclogin/login.aspx"));
                                break;
                            default:
                                Response.Redirect(Request.RawUrl.ToLower().Replace("m-login.aspx", "login.aspx"));
                                break;
                        }
                    } 
                }
 
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
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "alert('帳號或密碼錯誤');", true);
                //ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('帳號或密碼錯誤')</script>");
               // Response.Write("<script>alert('帳號或密碼錯誤')</script>");
               // return;
            }

           // Response.End();
        }

        void AfterLogin()
        { 
            string ThemeFolder = "basic";
            string TS = "";
            string TID = "2";

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
                if (Request.QueryString["done"] != null)
                { 
                    Response.Write("<Script>window.open('" + Comm.URL + HttpUtility.UrlDecode(Request.QueryString["done"]) + "','_self')</Script>"); 
                }
                else
                {
                    Response.Write("<Script>window.open('" + Comm.URL + "portal/portal.aspx?op=" + Guid.NewGuid().GetHashCode().ToString() + TID + "','_self')</Script>");
                }
            }
            Response.End();
        }


        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (CB.Checked == false)
            {
                  ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('請閱讀並同意Iapp合約')</script>");
                  return;
            }
            Main.ParaClear();
            Main.ParaAdd("@Account", Email.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Pw", Pw.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@User_Name", User_Name.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@User_Type", 1, System.Data.SqlDbType.Int);
            if (Main.Scalar("select 1 from Users where Account=@Account ") != "")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('此帳號已註冊過')</script>");
            }
            else {
                string sql = "Insert into Users(Account,Password,User_Name,User_Type) Values (@Account,@Pw,@User_Name,@User_Type)";
                if (Main.NonQuery(sql) > 0)
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('註冊成功')</script>");
                    accBox.Text = Email.Text;
                    pwBox.Text = Pw.Text;
                    DoLogin(); 
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入失敗')</script>"); 
                }
            }
        }

        protected void LB3_Click(object sender, EventArgs e)
        {
            AfterLogin();
        } 
    }
}