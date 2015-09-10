using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class ThemeManager: System.Web.UI.Page
{
    JDB Main = new JDB();
    CommTool Comm = new CommTool();
    string str = "";
    String SubPath = ConfigurationSettings.AppSettings.Get("SubPath");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["OK"] != "OK")
        {
            Response.Write("<script language=javascript>alert('請重新登入');location.href='Login.aspx'</script>");
        }
        if (!IsPostBack)
        {
            str = "Select * from Theme";
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
            Response.Redirect("Theme_Add.aspx?entry=" + GV.DataKeys[i][0]);

        }
        else if (e.CommandName == "UploadFiles")
        {
            Response.Redirect("ThemeUpload.aspx?entry=" + GV.DataKeys[i][0]);
        }
        else if (e.CommandName == "Del")
        {
            str = "Select FoderName from Theme where IDNo=" + GV.DataKeys[i][0];
            string delForder = SubPath + "\\" + Main.Scalar(str);
            SimpleFileDelete A = new SimpleFileDelete();
            Response.Write("<Script>alert('" + delForder + "');</Script>");
            A.delTheme(delForder);
            str = "Delete from Theme where IDNo=" + GV.DataKeys[i][0];
            Main.NonQuery(str);
        }
    }
    protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.DataItemIndex > -1)
        {
            Button delbur = (Button)(e.Row.Cells[3].Controls[0]);
            delbur.Attributes.Add("onclick", "if(confirm('這是包含刪除實體路徑，確定要刪除???')){__doPostBack('ctl00$Main_content$GV','Del$" + e.Row.RowIndex + "');}else{return false;}");
        }


    }
    protected void Btn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Theme_Add.aspx");
    }
}

public class SimpleFileDelete
{
    public void delTheme(string delForder)
    {
        // Delete a file by using File class static method... 
        if (System.IO.File.Exists(delForder))
        {
            // Use a try block to catch IOExceptions, to 
            // handle the case of the file already being 
            // opened by another process. 
            try
            {
                System.IO.File.Delete(delForder);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

    }
}