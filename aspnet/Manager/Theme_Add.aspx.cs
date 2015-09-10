using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Configuration;

public partial class Theme_Add: System.Web.UI.Page
{
    JDB Main = new JDB();
    CommTool comm = new CommTool();
    string str = "";
    string SourcePath = ConfigurationSettings.AppSettings.Get("SourcePath");
    string SubPath = ConfigurationSettings.AppSettings.Get("SubPath");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["OK"] != "OK")
        {
            Response.Write("<script language=javascript>alert('請重新登入');location.href='Login.aspx'</script>");
        }
        if (!IsPostBack)
        {
            // Response.Write(Request.QueryString["entry"]);
            if (Main.IsNumeric(Request.QueryString["entry"]))
            {
                Label6.Text = "修改頁面";
                str = "Select Theme_Name,Theme_head,Theme_foot,FoderName from Theme where IDNo=" + Request.QueryString["entry"];
                DataTable dr = Main.GetDataSet(str);
                if (dr.Rows.Count > 0)
                {
                    //Response.Write(dr.Rows[0]["Theme_Name"].ToString());
                    Theme_Name.Text = (dr.Rows[0]["Theme_Name"].ToString());
                    Theme_head.Text = HttpUtility.HtmlDecode(dr.Rows[0]["Theme_head"].ToString());
                    Theme_foot.Text = HttpUtility.HtmlDecode(dr.Rows[0]["Theme_foot"].ToString());
                    FolderName.Text = (dr.Rows[0]["FoderName"].ToString());

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

        if (FolderName.Text == "")
        {
            Response.Write("<Script>alert('ForderName不能為空白');</Script>");
            return;
        }
        Main.ParaClear();
        Main.ParaAdd("@Theme_Name", Theme_Name.Text, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@Theme_head", Theme_head.Text, System.Data.SqlDbType.Text);
        Main.ParaAdd("@Theme_foot", Theme_foot.Text, System.Data.SqlDbType.Text);
        Main.ParaAdd("@FoderName", FolderName.Text, System.Data.SqlDbType.Text);
        if (Main.IsNumeric(Request.QueryString["entry"]))
        {
            //有傳值過來做修改
            str = "Update Theme SET Theme_Name=@Theme_Name,Theme_head='" + HttpUtility.HtmlEncode(Theme_head.Text) + "',Theme_foot='" + HttpUtility.HtmlEncode(Theme_foot.Text) + "',FoderName=@FoderName where IDNo=" + 2;
        }
        else
        {   // 沒傳值做新增

            str = "insert into Theme(Theme_Name,Theme_head,Theme_foot,FoderName) Values(@Theme_Name,'" + HttpUtility.HtmlEncode(Theme_head.Text) + "', '" + HttpUtility.HtmlEncode(Theme_foot.Text) + "',@FoderName)";
            DirectoryCopyExample a = new DirectoryCopyExample();
            string SubPath2 = SubPath + "\\" + FolderName.Text;
            a.CopTheme(SourcePath, SubPath2);
            Response.Write("<Script>alert('新增一個主題 檔案路徑:" + SubPath2 +"')</Script>");
        }

        if (Main.NonQuery(str) == 1)
        {
            Response.Write("<script language=javascript>alert('寫入成功');location.href='ThemeManager.aspx'</script>");
               
        }
        else
        {
            Response.Write(str);
            Response.Write("<script language=javascript>alert('寫入失敗，請檢查欄位是否均已填寫');</script>");
        }
    }
}

class DirectoryCopyExample
{
     public void CopTheme(string SourcePath,string SubPath)
    {
        // Copy from the current directory, include subdirectories.
        DirectoryCopy(SourcePath, SubPath, true);
    }

    private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        // Get the subdirectories for the specified directory.
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);
        DirectoryInfo[] dirs = dir.GetDirectories();

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        // If the destination directory doesn't exist, create it.
        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }

        // Get the files in the directory and copy them to the new location.
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string temppath = Path.Combine(destDirName, file.Name);
            file.CopyTo(temppath, false);
        }
        // If copying subdirectories, copy them and their contents to new location.
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            }
        }
    }
}

