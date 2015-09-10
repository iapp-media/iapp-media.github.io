using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_Add: System.Web.UI.Page
{
    JDB Main = new JDB();
    CommTool comm = new CommTool();
    string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["OK"] != "OK")
            {
                Response.Write("<script language=javascript>alert('請重新登入');location.href='Login.aspx'</script>");
            }
            Label6.Text = "修改使用者";
            // Response.Write(Request.QueryString["entry"]);
            if (Main.IsNumeric(Request.QueryString["entry"]))
            {
                str = "Select * from Users where IDNo=" + Request.QueryString["entry"];
                DataTable dr = Main.GetDataSet(str);
                if (dr.Rows.Count > 0)
                {
                    //Response.Write(dr.Rows[0]["Accounte"].ToString());
                    Account.Text = dr.Rows[0]["Account"].ToString();
                    Password.Text = dr.Rows[0]["Password"].ToString();
                    User_Name.Text = dr.Rows[0]["User_Name"].ToString();
                    fbID.Text = dr.Rows[0]["fbID"].ToString();
                    User_Type.Text = dr.Rows[0]["User_Type"].ToString();

                }
            }
            else
            {
                Label6.Text = "使用者新增頁面";
            }
        }

    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        Main.ParaClear();
        Main.ParaAdd("@Account", Account.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@Password", Password.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@User_Name", User_Name.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@fbID", fbID.Text, System.Data.SqlDbType.Char);
        Main.ParaAdd("@User_Type", Convert.ToInt32(User_Type.Text), System.Data.SqlDbType.Int);
        if (Main.IsNumeric(Request.QueryString["entry"]))
        {
            //有傳值過來做修改
            str = "Update Users SET Account=@Account,Password=@Password,User_Name=@User_Name,fbID=@fbID,User_Type=@User_Type where IDNo=" + Request.QueryString["entry"];
        }
        else
        {// 沒傳值做新增

            str = "insert into Users(Account,Password,User_Name,User_Type,fbID) Values(@Account,@Password,@User_Name,@User_Type,@fbID)";
        }

        if (Main.NonQuery(str) == 1)
        {
            Response.Write("<script language=javascript>alert('寫入成功');location.href='User_List.aspx'</script>");
        }
        else
        {
            Response.Write(str);
            Response.Write("<script language=javascript>alert('寫入失敗，請檢查欄位是否均已填寫');</script>");
        }
    }
}