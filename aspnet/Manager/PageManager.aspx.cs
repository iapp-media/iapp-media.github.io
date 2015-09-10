using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class PageManager : System.Web.UI.Page
{

    JDB Main = new JDB();
    CommTool Comm = new CommTool();
    string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["OK"] != "OK")
        {
            Response.Write("<script language=javascript>alert('請重新登入');location.href='Login.aspx'</script>");
        }
        if (!IsPostBack)
        {
            str = "Select * from Pages";
            L.Text = str;
        }
         SD.ConnectionString = Main.ConnStr;
        SD.SelectCommand = L.Text;
        GV.DataSourceID = SD.ID;
    }

    protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "Update")
        {
             Response.Redirect("Page_Add.aspx?entry=" + GV.DataKeys[i][0]);

        }else if(e.CommandName == "Del")
        {
            str = "Delete from Pages where IDNo=" + GV.DataKeys[i][0];
            Main.NonQuery(str);
        }
    }
    protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItemIndex > -1)
        {
            Button delbur = (Button)(e.Row.Cells[12].Controls[0]);
            delbur.Attributes.Add("onclick", "if(confirm('確定要刪除?')){__doPostBack('ctl00$Main_content$GV','Del$" + e.Row.RowIndex + "');}else{return false;}");
        }

         
    }
    protected void Btn_Click(object sender, EventArgs e)
    {

        
        Response.Redirect("Page_Add.aspx");
    }
}