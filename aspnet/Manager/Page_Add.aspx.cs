using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Page_Add : System.Web.UI.Page
{
    JDB Main = new JDB();
    CommTool comm = new CommTool();
    string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["OK"] != "OK")
        {
            Response.Write("<script language=javascript>alert('請重新登入');location.href='Login.aspx'</script>");
        }
        if (!IsPostBack)
        {
            // Response.Write(Request.QueryString["entry"]);

            str = "Select * from Theme order by IDNo";
            Main.FillDDP(Theme_ID, str, "Theme_Name", "IDNo");
            if (Main.IsNumeric(Request.QueryString["entry"]))
            {
                Label6.Text = "修改頁面";
                str = "Select * from Pages where IDNo=" + Request.QueryString["entry"];
                DataTable dr = Main.GetDataSet(str);

                if (dr.Rows.Count > 0)
                {
                    //Response.Write(dr.Rows[0]["Page_Name"].ToString());
                    Page_Name.Text = dr.Rows[0]["Page_Name"].ToString();
                    URL.Text = dr.Rows[0]["URL"].ToString();
                    Img01.Text = dr.Rows[0]["Img01"].ToString();
                    Img01_b.Text = dr.Rows[0]["Img01_b"].ToString();
                    Img02_b.Text = dr.Rows[0]["Img02_b"].ToString();
                    Img03_b.Text = dr.Rows[0]["Img03_b"].ToString();
                    h1.Text = dr.Rows[0]["h1"].ToString();
                    h2.Text = dr.Rows[0]["h2"].ToString();
                    Theme_ID.Text = dr.Rows[0]["Theme_ID"].ToString();
                    EditStat.Text = dr.Rows[0]["EditStat"].ToString();

                    Htmltext.Text = HttpUtility.HtmlDecode(dr.Rows[0]["Html"].ToString());

                }
            }
            else
            {
                Label6.Text = "新增頁面";
            }
        }
     
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        Main.ParaClear();
        Main.ParaAdd("@Page_Name", Page_Name.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@URL", URL.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@Notes", Notes.Text, System.Data.SqlDbType.NVarChar);
       // Main.ParaAdd("@HTML", Htmltext.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@Img01", Img01.Text, System.Data.SqlDbType.VarChar);
        Main.ParaAdd("@Img01_b", Img01_b.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@Img02_b", Img02_b.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@Img03_b", Img03_b.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@h1", h1.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@h2", h2.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@Theme_ID", Theme_ID.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@EditStat", EditStat.Text, System.Data.SqlDbType.NVarChar);
        if (Main.IsNumeric(Request.QueryString["entry"]))
        {
            //有傳值過來做修改
            str = "Update Pages SET Page_Name=@Page_Name,URL=@URL,Notes=@Notes,Html='" + HttpUtility.HtmlEncode(Htmltext.Text) + "',Img01=@Img01," +
             "Img01_b=@Img01_b,Img02_b=@Img02_b,Img03_b=@Img03_b,h1=@h1,h2=@h2,Theme_ID=@Theme_ID,EditStat=@EditStat where IDNo=" + Request.QueryString["entry"];
        }
        else {// 沒傳值做新增

            str = "insert into Pages(Page_Name,URL,Notes,Img01,Html,Img01_b,Img02_b,Img03_b,h1,h2,Theme_ID,EditStat) Values" +
                "(@Page_Name,@URL,@Notes,@Img01,'" + HttpUtility.HtmlEncode(Htmltext.Text) + "',@Img01_b,@Img02_b,@Img03_b,@h1,@h2,"
                   + "@Theme_ID,@EditStat)";
        }

        if (Main.NonQuery(str)==1)
        {
            Response.Write("<script language=javascript>alert('寫入成功');location.href='PageManager.aspx'</script>");
        }
        else { 
             Response.Write(str);
             Response.Write("<script language=javascript>alert('寫入失敗，請檢查欄位是否均已填寫');</script>");
        }
    }
}