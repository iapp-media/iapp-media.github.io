using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;

public partial class ThemeUpload : System.Web.UI.Page
{
    JDB Main = new JDB();
    CommTool comm = new CommTool();
    string str = "";
    //string Allpath = "";
    // string SubPath = ConfigurationSettings.AppSettings.Get("SubPath");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["OK"] != "OK")
        {
          // Response.Write("<script language=javascript>alert('請重新登入');location.href='Login.aspx'</script>");
        }
        if (!Page.IsPostBack)
        {
            str = "Select FoderName from dbo.Theme where IDNo=" + Request.QueryString["entry"];
            LN.Text = Main.Scalar(str);
            LPath.Text = ConfigurationSettings.AppSettings.Get("SubPath") + Main.Scalar(str);
            LFolder.Text = "\\" + DDL1.SelectedValue;
            xDirFileList_gw(LPath.Text + LFolder.Text);
        }
      
    }

    public void xDirFileList_gw(string xdirectory)
    {
        int i = 1;
        DataTable flt = new DataTable(); //要 using System.Data;
        flt.Columns.Add("items", typeof(System.Int16));  // .Add(項目名稱,資料型別)
        flt.Columns.Add("filename", typeof(System.String));
        flt.Columns.Add("filesize", typeof(System.Int32));
        flt.Columns.Add("filetype", typeof(System.String));
        //string rootpath = Request.PhysicalApplicationPath; //抓取專案所在實際目錄路徑
        DirectoryInfo docspath = new DirectoryInfo(xdirectory); // 搭配專案相對應上傳的路徑
        FileInfo[] filelist = docspath.GetFiles();  //擷取目錄下所有檔案內容，並存到 FileInfo array
        foreach (FileInfo fl in filelist)
        {
            flt.Rows.Add(i, fl.Name, fl.Length, fl.Extension); // 把抓到的值寫到 Datatable 
            i++; //  顯示行號用之變數
            // "<A target='_blank' HREF='../" + LN.Text + "/" + LFolder.Text + "/" + fl.Name + "'>" + fl.Name + "</A>"
        }
        this.GV.DataSource = flt; // 指定 Gridview 的資料來源
        this.GV.DataBind();  // 把 Datatable 的值塞入 Gridview
    }

    protected void Button10_Click(object sender, EventArgs e)
    {

        string xdate = Convert.ToString(DateTime.Now.Year - 1911) + Convert.ToString(DateTime.Now.Month) + Convert.ToString(DateTime.Now.Day);
        xdate += Convert.ToString(DateTime.Now.Hour) + Convert.ToString(DateTime.Now.Minute) + Convert.ToString(DateTime.Now.Second);

        if (FU1.HasFile == true)
        {
            String FilePath = LPath.Text + LFolder.Text + "\\" + FU1.FileName.Replace(",", "");

            if (System.IO.Directory.Exists(LPath.Text + LFolder.Text) == false)
            {
                System.IO.Directory.CreateDirectory(LPath.Text + LFolder.Text);
            }

            if (System.IO.File.Exists(FilePath) == true)
            {        
                FileInfo Finfo = new FileInfo(FilePath); 
              
                Finfo.MoveTo(LPath.Text + LFolder.Text + "\\__" + Path.GetFileNameWithoutExtension(FilePath) + ".BAK" + xdate);
                Result.Text = "<br>更新檔案：" + LPath.Text + LFolder.Text + "\\__" + Path.GetFileNameWithoutExtension(FilePath) + ".BAK" + xdate;
            }
           
            FU1.SaveAs(FilePath);
            Result.Text += "  <br /> 上傳成功:" + FilePath + "";
        }
        xDirFileList_gw(LPath.Text + "\\" + LFolder.Text);
    }
    protected void DDL1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDL1.SelectedValue != "")
        {
            LFolder.Text = "\\" + DDL1.SelectedValue;
            xDirFileList_gw(LPath.Text + LFolder.Text);
        }
    }
    protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = comm.Cint2(e.CommandArgument);
        if (e.CommandName == "CN")
        {
            if (File.Exists(LPath.Text + LFolder.Text + "\\" + GV.DataKeys[i][0].ToString()))
            {
                File.Delete(LPath.Text + LFolder.Text + "\\" + GV.DataKeys[i][0].ToString());
                xDirFileList_gw(LPath.Text + LFolder.Text);
            }
        }
    }
    protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[1].Text = "<a target=\"_blank\" href=\"../" + LN.Text + "/" + LFolder.Text.Replace("\\", "") + "/" + GV.DataKeys[e.Row.RowIndex][0].ToString() + "\">" + GV.DataKeys[e.Row.RowIndex][0].ToString() + "</a>";
        }
    }
}


