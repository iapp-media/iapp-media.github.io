using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class Register : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void regBtn1_Click(object sender, EventArgs e)
        {
            if (Email.Text != "" && Pw.Text != "" && User_Name.Text != "")
            {
                Main.ParaClear();
                Main.ParaAdd("@Account", Email.Text, System.Data.SqlDbType.NVarChar);
                Main.ParaAdd("@Pw", Pw.Text, System.Data.SqlDbType.NVarChar);
                Main.ParaAdd("@User_Name", User_Name.Text, System.Data.SqlDbType.NVarChar);
                Main.ParaAdd("@User_Type", 1, System.Data.SqlDbType.Int);
                string sql = "Insert into Users(Account,Password,User_Name,User_Type) Values (@Account,@Pw,@User_Name,@User_Type)";
                if (Main.NonQuery(sql) > 0)
                {
                    Response.Write("<script>alert('註冊成功');location.href='login.aspx'</script>");
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert('寫入失敗')</script>");
                }
            }

        }

        
    }
}