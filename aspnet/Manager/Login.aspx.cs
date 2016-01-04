using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        Main.ParaClear();
        Main.ParaAdd("@acc", ACC.Value, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@pw", PW.Value, System.Data.SqlDbType.NVarChar);
        str = "Select Mag_Acc from Manager where Mag_Acc=@acc and Mag_Pw=@pw";
        Main.NonQuery(str);

        if (Main.Scalar(str) != "")
        {
            Session["ACC"] = ACC.Value;
            Session["OK"] = "OK";
            Response.Write("<script language=javascript>alert('登入成功');location.href='Default.aspx'</script>"); 
        }
        else
        {
            Response.Write("<Script>alert('沒帳號or欄位為空');</Script>");
        }
    }
}