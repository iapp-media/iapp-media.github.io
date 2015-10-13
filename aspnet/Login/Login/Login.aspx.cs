using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class Login : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        int CookieDays = 30;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Comm.IsNumeric(Request.QueryString["i"]))
            //{
            //    if (Comm.ThemeConflict(Comm.Cint2(Request.QueryString["i"]))) { return; }
            //}
            if (!IsPostBack) {
                if (Comm.CheckMobile()) {
                    //Response.Write("!!!!" + Request.RawUrl.ToLower().Replace("login.aspx", "m-login.aspx"));
                    Response.Redirect(Request.RawUrl.ToLower().Replace("login.aspx", "m-login.aspx")); 
                } 
            }
        }
          
        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            if (Comm.UserLogin(accBox.Text, pwBox.Text))
            {
                AfterLogin();
            }
            else
            {
                Response.Write("<script>alert('帳號或密碼錯誤')</script>");
            }
           // Response.End();
        }

        void AfterLogin()
        {

            int NewAppId = 0;
            int ThemeID = 2;
            if (Comm.IsNumeric(Request.QueryString["t"])) { ThemeID = Comm.Cint2(Request.QueryString["t"]); }
            if (Comm.IsNumeric(Request.QueryString["c"]))
            {
                NewAppId = Comm.CreateNewApp("我的iApp", Comm.Cint2(Request.QueryString["c"]));
                //>>>這裡沒有複製圖片，之後參考capp來修改
                str = "Insert into User_Page (User_ID,Page_ID,User_App_ID,Sort,SessionID,Img01,Img02,Img03,h1,h2,Theme_ID,IsCopy) " +
                      "Select @User_Id,Page_ID," + NewAppId.ToString() + ",Sort,SessionID,Img01,Img02,Img03,h1,h2,Theme_ID,1 from User_Page where User_App_ID=@Ref_App_ID";
                Main.NonQuery(str);
            }
            else
            {
                NewAppId = Comm.MyLastApp(ThemeID);
            }


            string Target = "_parent";
            if (Request.QueryString["open"] == "_top") { Target = "_top"; }
            string Tm = Main.Scalar("Select FoderName from Theme where IDNo=" + ThemeID);
            if (Request.QueryString["done"] != null)
            {
                Response.Write("<Script>window.open('" + HttpUtility.UrlDecode(Request.QueryString["done"]) + "','" + Target + "')</Script>");
            }
            else
            {
                Response.Write("<Script>window.open('" + Comm.URL + "portal/portal.aspx','" + Target + "')</Script>");
               // Response.Write("<Script>window.open('" + Comm.URL + "','" + Target + "')</Script>");
            }
            Response.End();
        }

        protected void LB2_Click(object sender, EventArgs e)
        {
            AfterLogin();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}