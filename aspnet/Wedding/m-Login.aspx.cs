using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wedding
{
    public partial class m_Login : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // if (Comm.CheckMobile() == false) { Response.Redirect(Request.RawUrl.ToLower().Replace("m-login.aspx", "login.aspx")); }
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

            if (Main.Scalar("Select 1 from Couple where User_id='" + Comm.User_ID() + "'")=="1")
            {
                Response.Write("<Script>window.open('Maker.aspx','_self')</Script>");
            }
            else
            { 
                 Response.Write("<Script>window.open('verify.aspx','_self')</Script>");
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
            if (Main.NonQuery(sql) > 0)
            {
                Response.Write("<script>alert('註冊成功');</script>");
                accBox.Text = User_Name.Text;
                pwBox.Text = Pw.Text;
                DoLogin();
                //Response.Write("<script>alert('寫入成功');location.href='login.aspx'</script>");
                //Response.End();
            }
            else
            {
                Response.Write("<script>alert('寫入失敗')</script>");
            }
        }

        protected void LB3_Click(object sender, EventArgs e)
        {
            AfterLogin();
        }

    }
}