using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wedding
{
    public partial class Couple_Add : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BT_Send_Click(object sender, EventArgs e)
        {
            if (Session["CID"] == null) { Response.Write("<Script>alert('連線逾時，請重新登入。');window.open('Login.aspx','_self');</Script>"); return; }
            string tmp = "";
            if (T_Name.Text == "") { tmp += ",姓名"; }
            if (T_Tel.Text == "") { tmp += ",電話"; }
            if (T_Addr.Text == "") { tmp += ",地址"; }
            if (T_Email.Text == "") { tmp += ",信箱"; }
            if (tmp != "") { Response.Write("<Script>alert('請輸入" + tmp.Substring(1) + "。');</Script>"); return; }

            Main.ParaClear();
            Main.ParaAdd("@Email", T_Email.Text, System.Data.SqlDbType.NVarChar);

            if (Main.Scalar("Select 1 from Couple where Email=@Email") == "1")
            {
                Response.Write("<Script>alert('已有此信箱。');</Script>");
                return;
            }

            Main.ParaAdd("@Name", T_Name.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Addr", T_Addr.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@IDNu", Main.Scalar("Select newid()"), System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Tel", T_Tel.Text, System.Data.SqlDbType.NVarChar);

            Main.ParaAdd("@Company_id", Main.Cint2(Session["CID"].ToString()), System.Data.SqlDbType.Int);
            str = " Insert into Couple (Name, Tel, Addr, Email, Company_id, IDNu,CreateDate) values" +
                  " (@Name,@Tel, @Addr, @Email, @Company_id, @IDNu,getdate())";
            int result = Main.NonQuery(str);
            if (result > 0)
            {
                Response.Write("<Script>alert('申請成功，已寄送序號至信箱。');window.open('Couple_list.aspx','_self');</Script>");
            }
            else
            {
                Response.Write("<Script>alert('申請失敗，請洽詢廠商。');</Script>");
            }

        }
    }
}