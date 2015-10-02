using System;
using System.IO;
using System.Collections.Generic;
using System.Linq; 
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IApp_Add : System.Web.UI.Page
{
    JDB Main = new JDB();
    CommTool Comm = new CommTool();
    string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Main.FillDDP(DL_Theme, "select idno,Theme_Name from Theme ", "Theme_Name", "idno");
            if (Comm.IsNumeric(Request.QueryString["entry"])) {
                str = "Select * from User_App where IDNo=" + Request.QueryString["entry"];
                DataTable dr = Main.GetDataSet(str);

                if (dr.Rows.Count > 0)
                {
                    DataRow dw = dr.Rows[0];

                    Comm.GetDDL(DL_Theme, dw["Theme_ID"].ToString());
                    Comm.GetDDL(DL_IsPost, dw["IsPosted"].ToString());
                    T_Name.Text = dw["App_Name"].ToString();
                    T_URL.Text = dw["App_URL"].ToString();
                    TSort.Text = dw["IsTop"].ToString();
                }
            
            }
        }
    }
    public string DoNewApp()
    {
        Main.ParaClear();
        Main.ParaAdd("@User_ID", 2, SqlDbType.Int);
        Main.ParaAdd("@Theme_ID", DL_Theme.SelectedValue, SqlDbType.Int);
        Main.ParaAdd("@App_Name", T_Name.Text, SqlDbType.NVarChar);
        Main.ParaAdd("@App_Memo", T_Memo.Text, SqlDbType.NVarChar);
        Main.ParaAdd("@Ref_App_ID", 0, SqlDbType.NVarChar);
        Main.ParaAdd("@Folder", Comm.CheckAppFolder(), System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@App_URL", T_URL.Text, SqlDbType.NVarChar);
        Main.ParaAdd("@IsPosted", DL_IsPost.SelectedValue, SqlDbType.NVarChar);
        Main.ParaAdd("@IsTop", Comm.Cint2(TSort.Text), SqlDbType.Int);
        string AppID = "";
        if (Comm.IsNumeric(Request.QueryString["entry"]))
        {
            AppID = Request.QueryString["entry"];
            Main.ParaAdd("@IDNo", Comm.Cint2(AppID), SqlDbType.Int);
            str = "Update User_App set App_Name=@App_Name,App_Memo=@App_Memo,Theme_ID=@Theme_ID,App_Folder=@Folder,App_URL=@App_URL,IsPosted=@IsPosted,IsTop=@IsTop  " +
                  " where IDNo=@IDNo";
            Main.NonQuery(str);
        }
        else
        {
            str = " Insert into User_App (User_ID,App_Name,Theme_ID,App_Folder,Ref_App_ID,App_URL,IsPosted,IsTop,App_Memo) " +
                  " Values (@User_ID,@App_Name,@Theme_ID,@Folder,@Ref_App_ID,@App_URL,@IsPosted,@IsTop,@App_Memo)";
            Main.NonQuery(str);
            AppID = Main.Scalar("Select Max(IDNo) from User_App where User_ID=@User_ID and Theme_ID=@Theme_ID"); 
        }

        return AppID;
    }
    public string url(string AID)
    { 
        str = "Select App_Folder from User_App where IDNo=" + AID + " ";
        return Main.Scalar(str); 
    }
    protected void BT_Send_Click(object sender, EventArgs e)
    {
        L_APPID.Text = DoNewApp();
        if (L_APPID.Text != "")
        {
            if (FU_cover.HasFile)
            {
                string FileName = "icover_" + L_APPID.Text + ".jpg";
                //string FileFolder = url(L_APPID.Text) + "\\pic\\" + FileName;
                string FilePath = Comm.CurrentAppFolder(Main.Cint2(L_APPID.Text)) + "\\pic\\";

                if (File.Exists(FilePath + FileName))
                {
                    File.Delete(FilePath + FileName);
                    //int x = 1;
                    //do
                    //{
                    //    FilePath = Path.Combine(Comm.FilePath, TimeString + "-" + x.ToString() + Path.GetExtension(FU_cover.FileName));
                    //    x++;
                    //} while (File.Exists(FilePath));
                }
                FU_cover.SaveAs(FilePath + FileName);
                Main.ParaClear();
                Main.ParaAdd("@App_Icover", FileName, System.Data.SqlDbType.NVarChar);
                Main.ParaAdd("@App_id", L_APPID.Text, System.Data.SqlDbType.Int);

                str = "Update User_App set App_Cover=@App_Icover where IDNo=@App_id";
                Main.NonQuery(str);

            }

            if (FU_icon.HasFile)
            {
                string FileName = "ico_" + L_APPID.Text + ".jpg";
                string FilePath = Comm.CurrentAppFolder(Main.Cint2(L_APPID.Text)) + "\\pic\\";

                if (File.Exists(FilePath + FileName))
                {
                    File.Delete(FilePath + FileName);
                }
                FU_icon.SaveAs(FilePath + FileName);
                Main.ParaClear();
                Main.ParaAdd("@App_Icon", FileName, System.Data.SqlDbType.NVarChar);
                Main.ParaAdd("@App_id", L_APPID.Text, System.Data.SqlDbType.Int);

                str = "Update User_App set App_Icon=@App_Icon where IDNo=@App_id";
                Main.NonQuery(str);
            }

            if (FU_share.HasFile)
            {
                string FileName = Comm.GetFullNum(Main.Cint2(L_APPID.Text), 10) + "fb.jpg";
                string FilePath = Comm.CurrentAppFolder(Main.Cint2(L_APPID.Text)) + "\\pic\\";

                if (File.Exists(FilePath + FileName))
                {
                    File.Delete(FilePath + FileName);
                }
                FU_share.SaveAs(FilePath + FileName);
                Main.ParaClear();
                Main.ParaAdd("@Share_Img", FileName, System.Data.SqlDbType.NVarChar);
                Main.ParaAdd("@App_id", L_APPID.Text, System.Data.SqlDbType.Int);

                str = "Update User_App set Share_Img=@Share_Img where IDNo=@App_id";
                Main.NonQuery(str);

            }
            Response.Redirect("User_App.aspx");
        }
        else {
            Response.Write("<Script>alert('新增失敗，請洽系統管理員。');</Script>");
        }
          　
    }
}