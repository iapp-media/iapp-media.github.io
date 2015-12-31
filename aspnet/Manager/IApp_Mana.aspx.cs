using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IApp_Mana : System.Web.UI.Page
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
            str = "Select IDNo,(select User_Name from Users where IDNo=User_ID) User_Name, " +
                "(select Theme_Name from Theme where IDNo=Theme_ID) Theme_ID,App_Name," +
                "('Apps/'+App_Folder+'/pic/'+App_Cover) App_Cover from User_App where  IsPosted=1 ";
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
            str = " insert into User_App_DEL( IDNo, User_ID, Theme_ID, App_Name, Create_Date, SessionID, App_Icon, App_URL, App_Folder, Ref_App_ID, App_Memo, Last_Update, IsPosted, App_Cover, Share_Img) " +
                  "select IDNo, User_ID, Theme_ID, App_Name, Create_Date, SessionID, App_Icon, App_URL, App_Folder, Ref_App_ID, App_Memo, Last_Update, IsPosted, App_Cover, Share_Img from User_App where idno =" + GV.DataKeys[i][0];
            str += ";Delete from User_App where IDNo=" + GV.DataKeys[i][0];
            Main.NonQuery(str);
        }
    }
    protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
    { 
        if (e.Row.DataItemIndex > -1)
        {
            e.Row.Cells[3].Text = "<a class=\"thumbnail\" href=\"javascript:void(0)\"  ><img src=\"" + comm.URL + e.Row.Cells[3].Text + "\" alt=\" \"  width=\"180\" height=\"145\" ></a>";
            e.Row.Cells[3].Width = 145;
            e.Row.Cells[3].Height = 180;

            Button delbur = (Button)(e.Row.Cells[4].Controls[0]);
            delbur.Attributes.Add("onclick", "if(confirm('確定要刪除?')){__doPostBack('ctl00$Main_content$GV','Del$" + e.Row.RowIndex + "');}else{return false;}");
            

          
        } 
    }
}