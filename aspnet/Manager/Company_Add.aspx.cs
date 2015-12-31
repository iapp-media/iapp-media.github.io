using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Company_Add : System.Web.UI.Page
{
    JDB Main = new JDB();
    CommTool Comm = new CommTool();
    string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Main.IsNumeric(Request.QueryString["i"]))
            {
                DataTable DT = Main.GetDataSetNoNull("select * from company where idno='" + Request.QueryString["i"].ToString() + "'");
                if (DT.Rows.Count > 0)
                {

                    T_Company.Text = DT.Rows[0]["Name"].ToString();
                    T_ACC.Text = DT.Rows[0]["ACC"].ToString();
                    T_PassWord.Text = DT.Rows[0]["PassWord"].ToString();
                    T_Addr.Text = DT.Rows[0]["Addr"].ToString();
                    T_BossName.Text = DT.Rows[0]["BossName"].ToString();
                    T_Tel.Text = DT.Rows[0]["Tel"].ToString();
                    T_FAX.Text = DT.Rows[0]["FAX"].ToString();
                }
            }
            //Main.FillDDP(DL_Theme, "select idno,Theme_Name from Theme ", "Theme_Name", "idno");
        }
    }
    protected void BT_Send_Click(object sender, EventArgs e)
    {
        int c = 0;
        string tmp = "";
        if (T_ACC.Text == "") { tmp += ",帳號"; }
        if (T_PassWord.Text == "") { tmp += ",密碼"; }
        if (T_Company.Text == "") { tmp += ",公司名稱"; }

        if (tmp != "") { Response.Write("<Script>alert('請輸入" + tmp.Substring(1) + "。');</Script>"); return; }

        Main.ParaClear();
        Main.ParaAdd("@Name", T_Company.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@ACC", T_ACC.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@PassWord", T_PassWord.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@Addr", T_Addr.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@BossName", T_BossName.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@Tel", T_Tel.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@FAX", T_FAX.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@Theme_id", 3, System.Data.SqlDbType.Int);

        if (Main.IsNumeric(Request.QueryString["i"]))
        {
            Main.ParaAdd("@comid", Main.Cint2(Request.QueryString["i"].ToString()), System.Data.SqlDbType.Int);
            if (Main.Scalar("Select 1 from Company where ACC=@ACC and idno!=@comid") == "1")
            {
                Response.Write("<Script>alert('帳號已有人使用。');</Script>");
                return;
            }
            str = "update Company set Name=@Name, ACC=@ACC, PassWord=@PassWord, Addr=@Addr, BossName=@BossName, Tel=@Tel, FAX=@FAX where idno=@comid";
            c = Main.NonQuery(str);
        }
        else
        {
            if (Main.Scalar("Select 1 from Company where ACC=@ACC") == "1")
            {
                Response.Write("<Script>alert('帳號已有人使用。');</Script>");
                return;
            }
            str = "Insert into Company (Name, ACC, PassWord, Addr, BossName, Tel, FAX,Theme_id)values" +
                  "(@Name,@ACC,@PassWord,@Addr,@BossName,@Tel,@FAX,@Theme_id)";
            c = Main.NonQuery(str);
        }

        if (c > 0)
        {
            Response.Redirect("Company_Mana.aspx");
        }
        else
        {
            Response.Write("alert('發生錯誤了');");
        }
    }
}