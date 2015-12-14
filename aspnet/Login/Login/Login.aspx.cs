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
            //--------------趕效果先這樣放
            if (Request.QueryString["s"] != null)
            { 
                if (Request.QueryString["s"] == "1")
                { 
                    JDB Main2 = new JDB(System.Configuration.ConfigurationManager.AppSettings.Get("Database2"));
                    string SID = "";
                    SID = Main2.Scalar("select IDNo from Store where User_ID='" + Comm.User_ID() + "'");
                    if (SID != "")
                    {
                        if (Main2.Scalar("select Store_NID from Store where User_ID='" + Comm.User_ID() + "'") == "")
                        {
                            Main2.ParaClear();
                            Main2.ParaAdd("@SID", Main.Cint2(SID), System.Data.SqlDbType.Int);
                            Main2.ParaAdd("@Store_No", Comm.StoreSN(Main.Cint2(SID)), System.Data.SqlDbType.NVarChar);
                            Main2.NonQuery("update Store set Store_No=@Store_No,Store_NID=@Store_No  where idno=@SID");
                        }
                        Comm.SaveCookie("iapp_sid", Main.EnCrypTo(SID)); 
                        Response.Write("<Script>window.open('" + Comm.URL + HttpUtility.UrlDecode(Request.QueryString["done"]) + "','_top')</Script>");
                        
                        return;
                    }
                }
            }
            //-----------------
            
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