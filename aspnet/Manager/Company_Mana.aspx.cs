using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Company_Mana : System.Web.UI.Page
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
            str = "select * from Company ";
                
            L.Text = str;
        }
        SD.ConnectionString = Main.ConnStr;
        SD.SelectCommand = L.Text;
        GV.DataSourceID = SD.ID;
    }

    protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "DEL")
        { 
             Main.NonQuery(" Delete from Company where IDNo=" + GV.DataKeys[i][0]);
        }

        if (e.CommandName == "CN")
        {
            Response.Redirect("Company_Add.aspx?i=" + GV.DataKeys[i][0]);
        }
    }
    protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItemIndex > -1)
        {
              
            Button delbur = (Button)(e.Row.Cells[6].Controls[0]);
            delbur.Attributes.Add("onclick", "if(confirm('確定要刪除?')){__doPostBack('ctl00$Main_content$GV','Del$" + e.Row.RowIndex + "');}else{return false;}");



        }
    }
}