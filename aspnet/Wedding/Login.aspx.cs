using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wedding
{
    public partial class Login : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BT1_Click(object sender, EventArgs e)
        {
            string CID = "";
            Main.ParaClear();
            Main.ParaAdd("@acc", ACC.Value, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@pw", PW.Value, System.Data.SqlDbType.NVarChar);
            
            CID = Main.Scalar("Select IDNo from Company where ACC=@acc and PassWord=@pw");

            if (CID != "")
            {
                Session["CID"] = CID; 
                Response.Write("<script language=javascript>alert('登入成功');location.href='Couple_add.aspx'</script>");
            }
            else
            {
                Response.Write("<Script>alert('帳號或密碼錯誤');</Script>");
            }
        }
    }
}