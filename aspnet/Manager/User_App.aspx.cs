using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_App : System.Web.UI.Page
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
            Main.FillDDP(DL_User, "select * from users", "user_name", "idno");

        }
        SD.ConnectionString = Main.ConnStr;
        SD.SelectCommand = L.Text;
        GV.DataSourceID = SD.ID;
    }


    protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = int.Parse(e.CommandArgument.ToString());
        if (e.CommandName == "Del")
        {
            Main.NonQuery("Delete from User_Page where IDNo=" + GV.DataKeys[i][0].ToString() + "");
        }
    }
    protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        //if (e.Row.DataItemIndex > -1)
        //{
        //    Button delbur = (Button)(e.Row.Cells[10].Controls[0]);
        //    delbur.Attributes.Add("onclick", "if(confirm('確定要刪除?')){__doPostBack('ctl00$Main_content$GV','Del$" + e.Row.RowIndex + "');}else{return false;}");
        //}

    }
    protected void DL_User_SelectedIndexChanged(object sender, EventArgs e)
    {
        select();
    }
    void select()
    {

        L.Text = "select  (select User_Name from Users where IDNo=User_App.User_ID ) User_Name" +
                 ",'' VC" +
                 ",(select count(1) from User_App_Good where User_ID=User_App.User_ID) Pfavor"  +
                 ",(select count(1) from User_App_Good where User_ID=User_App.User_ID) Pgood"   +
                 ",(select count(1) from User_App_Good where User_ID=User_App.User_ID) Plike"   +
                 ",(select count(1) from User_App_Good where User_ID=User_App.User_ID) Pshare"  +
                 ",* from User_App where 1=1";

        if (DL_User.SelectedValue.ToString() != "")
        {
            L.Text += " and User_ID='" + DL_User.SelectedValue.ToString() + "'";
        }
        SD.ConnectionString = Main.ConnStr;
        SD.SelectCommand = L.Text;
        GV.DataSourceID = SD.ID;
    }
}