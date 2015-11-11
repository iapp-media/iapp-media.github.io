using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;


namespace Wedding
{
    public partial class Svim : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string do2 = "";
                int AA = 0;
                if (Main.IsNumeric(Request["i"]) && Main.IsNumeric(Request["d"].Replace("-", "")))
                {
                    AA = 1;
                    int CurrentId = 0;
                    string WID = Request["d"];
                    if (Comm.Wedding_ID() == -1)
                    {
                        Response.Write("Error s100");
                        Response.End();
                        return;
                    }
                    if (WID == "")
                    {
                        Response.Write("Error s101");
                        Response.End();
                        return;
                    }
                    do2 = Main.Scalar("Select isnull(sum(1),0) from Wedding_Img where num='" + Main.Cint2(Request["i"]) + "'  and WInfo_ID='" + WID + "'");

                    if (do2 != "0")
                    {
                        CurrentId = Comm.Cint2(Main.Scalar("Select IDNo from Wedding_Img where num='" + Main.Cint2(Request["i"]) + "'  and WInfo_ID='" + WID + "'"));
                        if (CurrentId == 0)
                        {
                            Response.Write("Error s102");
                            Response.End();
                            return;
                        }
                    }
                    string CoNum = Request["i"];

                    if (string.IsNullOrEmpty(Request["t"]))
                    {
                        Response.Write("Error s103");
                        Response.End();
                        return;
                    }

                    if (do2 == "0") //insert 
                    {

                        string Folder = Comm.CheckAppFolder();
                        string FileName = Comm.ImgSerial(Main.Cint2(WID), Main.Cint2(CoNum));
                        string FullPath = Comm.MainPath + "\\Itempic\\" + Folder + "\\" + FileName + ".jpg";
                        if (File.Exists(FullPath) == true)
                            File.Delete(FullPath);

                        if (System.IO.Directory.Exists(Comm.MainPath + "\\Itempic\\" + Folder + "\\") == false)
                        {
                            System.IO.Directory.CreateDirectory(Comm.MainPath + "\\Itempic\\" + Folder + "\\");
                        }
                        try
                        {
                            byte[] buf = Convert.FromBase64String(Request["t"]);
                            FileStream TYU = new FileStream(FullPath, FileMode.CreateNew);
                            TYU.Write(buf, 0, buf.Length);
                            TYU.Close();
                        }
                        catch (Exception ex)
                        {
                            Comm.WriteLog(ex.Message);
                        }
                        Main.ParaClear();
                        Main.ParaAdd("@path", "Itempic/" + Folder.Trim() + "/" + FileName + ".jpg", System.Data.SqlDbType.NVarChar);
                        Main.ParaAdd("@Folder", Folder, System.Data.SqlDbType.NVarChar);
                        Main.ParaAdd("@Num", Main.Cint2(CoNum), System.Data.SqlDbType.NVarChar);
                        Main.ParaAdd("@idno", WID, System.Data.SqlDbType.NVarChar);
                        Main.ParaAdd("@Couple_ID", Comm.Wedding_ID(), System.Data.SqlDbType.Int);
                        Main.NonQuery("insert into Wedding_Img (WInfo_ID,Couple_ID, Num, Folder, FilePath) values " +
                                      "(@idno,@Couple_ID, @Num, @Folder, @path)");
                        Response.Write("Itempic/" + Folder.Trim() + "/" + FileName + ".jpg");
                    }
                    else
                    {

                        string Folder = Comm.CheckAppFolder();
                        string FileName = Comm.ImgSerial(Main.Cint2(WID), Main.Cint2(CoNum));
                        string FullPath = Comm.MainPath + "\\Itempic\\" + Folder + "\\" + FileName + ".jpg";
                        if (File.Exists(FullPath) == true)
                            File.Delete(FullPath);

                        if (System.IO.Directory.Exists(Comm.MainPath + "\\Itempic\\" + Folder + "\\") == false)
                        {
                            System.IO.Directory.CreateDirectory(Comm.MainPath + "\\Itempic\\" + Folder + "\\");
                        }
                        try
                        {
                            byte[] buf = Convert.FromBase64String(Request["t"]);
                            FileStream TYU = new FileStream(FullPath, FileMode.CreateNew);
                            TYU.Write(buf, 0, buf.Length);
                            TYU.Close();
                        }
                        catch (Exception ex)
                        {
                            Comm.WriteLog(ex.Message);
                        }
                        Main.ParaClear();
                        Main.ParaAdd("@path", "Itempic/" + Folder.Trim() + "/" + FileName + ".jpg", System.Data.SqlDbType.NVarChar);
                        Main.ParaAdd("@PageID", Main.Cint2(CurrentId), SqlDbType.Int);
                        Main.ParaAdd("@Couple_ID", Comm.Wedding_ID(), System.Data.SqlDbType.Int);
                        Main.NonQuery("Update Wedding_Img set FilePath=@path where IDNo=@PageID and Couple_ID=@Couple_ID");
                        Response.Write("Itempic/" + Folder.Trim() + "/" + FileName + ".jpg");
                    }
                    //END IF DOTHING
                }
                Main.WriteLog("jASON='" + AA.ToString() + "'");
                Response.End();
            }
        }
    }
}