using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Collections; 
using System.Data;
using System.Diagnostics;
using System.IO; 
using System.Text;
using System.Drawing;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;

/// <summary>
/// CommTool 的摘要描述
/// </summary>
public class CommTool: System.Web.UI.Page
{
    string str = "";
    public string FilePath = System.Configuration.ConfigurationManager.AppSettings.Get("FilePath");
    public string AppPath = System.Configuration.ConfigurationManager.AppSettings.Get("AppPath");
    public string MainPath = System.Configuration.ConfigurationSettings.AppSettings.Get("MainPath");
    public string URL = System.Configuration.ConfigurationSettings.AppSettings.Get("URL");
    public string Theme = System.Configuration.ConfigurationSettings.AppSettings.Get("Theme");
    public string Theme_ID = System.Configuration.ConfigurationSettings.AppSettings.Get("Theme_ID");
    public string MiStoreUrl = System.Configuration.ConfigurationSettings.AppSettings.Get("MiStoreUrl");
    public string MiStorePath = System.Configuration.ConfigurationSettings.AppSettings.Get("MiStorePath");

    public CommTool()
	{
		//
		// TODO: 在這裡新增建構函式邏輯
		//
	}
    public bool ChkLoginStat()
    {
        if (HttpContext.Current.Request.Cookies["iapp_uid"] == null)
        {
            return false;
        }
        else
        {
            if (HttpContext.Current.Request.Cookies["iapp_uid"].Value == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public bool ChkLoginStat(string LoginURL)
    {
        if (HttpContext.Current.Request.Cookies["iapp_uid"] == null)
        {
            HttpContext.Current.Response.Write("<script>alert('請重新登入');location.href='" + LoginURL + "';</script>");
            return false;
        }
        else
        {
            if (HttpContext.Current.Request.Cookies["iapp_uid"].Value == "")
            {
                HttpContext.Current.Response.Write("<script>alert('請重新登入');location.href='" + LoginURL + "';</script>");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public bool ChkLoginStat(string LoginURL, string Target)
    {
        if (HttpContext.Current.Request.Cookies["iapp_uid"] == null)
        {
            HttpContext.Current.Response.Write("<script>alert('請重新登入');window.open('" + LoginURL + "','" + Target + "');</script>");
            return false;
        }
        else
        {
            if (HttpContext.Current.Request.Cookies["iapp_uid"].Value == "")
            {
                HttpContext.Current.Response.Write("<script>alert('請重新登入');window.open('" + LoginURL + "','" + Target + "');</script>");
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public bool UserLogin(string uid, string pwd)
    {
        JDB Main = new JDB();
        Main.ParaClear();
        Main.ParaAdd("@Account", uid, System.Data.SqlDbType.NVarChar);
        Main.ParaAdd("@Pw", pwd, System.Data.SqlDbType.NVarChar);
        str = "Select * from Users where Account=@Account And Password=@Pw";
        DataTable d = Main.GetDataSet(str);
        if (d.Rows.Count > 0)
        {
            SaveUserCookies(d.Rows[0]["IDNo"].ToString(), d.Rows[0]["User_Name"].ToString());
            return true;
        }
        else { return false; }
    }
    public void SaveUserCookies(string UserID, string UserName, string fbId = "")
    {
        SaveCookie("iapp_uid", UserID);
        SaveCookie("iapp_uname", UserName);
        SaveCookie("iapp_fbId", fbId);
    }
    public int User_ID()
    {
        if (HttpContext.Current.Request.Cookies["iapp_uid"] != null)
        {
            //是不是要再延長cookie的期間??
            return Cint2(HttpContext.Current.Request.Cookies["iapp_uid"].Value);
        }
        else { return -1; }
    }
    public string User_Name() { 
        if (HttpContext.Current.Request.Cookies["iapp_uname"] != null)
        {
            //是不是要再延長cookie的期間??
            return HttpContext.Current.Request.Cookies["iapp_uname"].Value;
        }
        else { return "未登入的用戶"; }
    }
    public string fb_ID()
    {
        if (HttpContext.Current.Request.Cookies["iapp_fbId"] != null)
        {
            //是不是要再延長cookie的期間??
            return HttpContext.Current.Request.Cookies["iapp_fbId"].ToString();
        }
        else { return ""; }
    } 
    public int MyLastApp()
    {
        JDB Main = new JDB();
        Main.ParaClear();
        Main.ParaAdd("@User_ID", User_ID(), SqlDbType.Int);
        Main.ParaAdd("@Theme_ID", Theme_ID, SqlDbType.Int);
        str = "Select Max(IDNo) from User_App where User_ID=@User_ID And Theme_ID=@Theme_ID";
        int AppID = Cint2(Main.Scalar(str));
        //Main.WriteCMD();
        if (AppID > 0) { return AppID; } else { return CreateNewApp("我的iApp"); }
    }
    public int MyLastApp(int ThemeID)
    {
        JDB Main = new JDB();
        Main.ParaClear();
        Main.ParaAdd("@User_ID", User_ID(), SqlDbType.Int);
        Main.ParaAdd("@Theme_ID", ThemeID, SqlDbType.Int);
        str = "Select Max(IDNo) from User_App where User_ID=@User_ID And Theme_ID=@Theme_ID";
        int AppID = Cint2(Main.Scalar(str));
        //Main.WriteCMD();
        if (AppID > 0) { return AppID; } else { return CreateNewApp("我的iApp"); }
    }
    public int CreateNewApp(string AppName, int Ref_App_ID = 0)
    {
        JDB Main = new JDB();
        Main.ParaClear();
        Main.ParaAdd("@User_ID", User_ID(), SqlDbType.Int);
        Main.ParaAdd("@Theme_ID", Theme_ID, SqlDbType.Int);
        Main.ParaAdd("@App_Name", AppName, SqlDbType.NVarChar);
        Main.ParaAdd("@Ref_App_ID", Ref_App_ID, SqlDbType.NVarChar);
        Main.ParaAdd("@Folder", CheckAppFolder(), System.Data.SqlDbType.NVarChar);

        DelNoPost(User_ID().ToString());

        str = " Insert into User_App (User_ID,App_Name,Theme_ID,App_Folder,Ref_App_ID) " + 
              " Values (@User_ID,@App_Name,@Theme_ID,@Folder,@Ref_App_ID)";
        Main.NonQuery(str);
        int AppID = Cint2(Main.Scalar("Select Max(IDNo) from User_App where User_ID=@User_ID and Theme_ID=@Theme_ID"));
        return AppID;
    }

    public string DelNoPost(string UID)
    {
        string Folder = "";
        JDB Main = new JDB();
        Main.ParaClear();
        Main.ParaAdd("@UID", UID, SqlDbType.Int);
        DataTable DTUApp = Main.GetDataSetNoNull("select IDNo from User_App where User_ID=@UID and isnull(IsPosted,'0')!='1' and isnull(Share_Img,'')='' ");
        if (DTUApp.Rows.Count > 0)
        {
            for (int i = 0; i < DTUApp.Rows.Count ; i++)
            {
                Folder = Main.Scalar("select App_Folder from User_App where IDNo =" + DTUApp.Rows[i]["IDNo"].ToString());
                if (Folder !="")
                {
                    Folder = Folder + "/";
                    DataTable DT = Main.GetDataSetNoNull("select * from User_Page where User_App_ID=" + DTUApp.Rows[i]["IDNo"].ToString());
                    if (DT.Rows.Count > 0)
                    {
                        DataRow DTRow = DT.Rows[0];

                        if (System.IO.File.Exists(AppPath + Folder.Replace("/", "\\") + DTRow["Img01"].ToString().Replace(Folder, "")) == true)
                            System.IO.File.Delete(AppPath + Folder.Replace("/", "\\") + DTRow["Img01"].ToString().Replace(Folder, ""));

                        if (System.IO.File.Exists(AppPath + Folder.Replace("/", "\\") + DTRow["Img02"].ToString().Replace(Folder, "")) == true)
                            System.IO.File.Delete(AppPath + Folder.Replace("/", "\\") + DTRow["Img02"].ToString().Replace(Folder, ""));

                        if (System.IO.File.Exists(AppPath + Folder.Replace("/", "\\") + DTRow["Img03"].ToString().Replace(Folder, "")) == true)
                            System.IO.File.Delete(AppPath + Folder.Replace("/", "\\") + DTRow["Img03"].ToString().Replace(Folder, ""));

                    }
                    DataTable DT2 = Main.GetDataSetNoNull("select *  from User_App where IDNo =" + DTUApp.Rows[i]["IDNo"].ToString());
                    if (DT2.Rows.Count > 0)
                    {
                        Folder = Folder + "/pic/";
                        DataRow DTRow2 = DT2.Rows[0];
                        if (System.IO.File.Exists(AppPath + Folder.Replace("/", "\\") + DTRow2["App_Icon"].ToString()) == true)
                            System.IO.File.Delete(AppPath + Folder.Replace("/", "\\") + DTRow2["App_Icon"].ToString());

                        if (System.IO.File.Exists(AppPath + Folder.Replace("/", "\\") + DTRow2["App_Cover"].ToString().Replace(Folder, "")) == true)
                            System.IO.File.Delete(AppPath + Folder.Replace("/", "\\") + DTRow2["App_Cover"].ToString());

                        if (System.IO.File.Exists(AppPath + Folder.Replace("/", "\\") + DTRow2["Share_Img"].ToString().Replace(Folder, "")) == true)
                            System.IO.File.Delete(AppPath + Folder.Replace("/", "\\") + DTRow2["Share_Img"].ToString());

                    }
                    Main.NonQuery("Delete from User_Page where User_App_ID='" + DTUApp.Rows[i]["IDNo"].ToString() + "';delete User_App where IDNo='" + DTUApp.Rows[i]["IDNo"].ToString() + "';"); 
                }
            }
        } 
        return "";
    }

     public string CheckAppFolder()
    { 
        //檢查資料夾 是否存在 以及是否滿100筆 
        string str = "";
        int SortNum = 1;
        int i = 0;
        string MP = "";
        for (i = 0; i <= 1000; i++)
        {
            MP = AppPath + String.Format("{0:00}", SortNum);
            if (Directory.Exists(MP) == false)
            {
                Directory.CreateDirectory(MP);
                break; // TODO: might not be correct. Was : Exit For
            }
            else
            {
                DirectoryInfo dirinfo = new DirectoryInfo(MP);
                FileInfo[] sortList = dirinfo.GetFiles();
                if (sortList.Length >= 100)
                {
                    SortNum += 1;
                    i = 0;
                }
            }
        } 
        return String.Format("{0:00}", SortNum);
    }
    public string CurrentAppFolder(int AP_ID)
    {
        JDB Main = new JDB();
        string str = "";
        string MP = "";
        str = "Select App_Folder from User_App where IDNo=" + AP_ID;
        string Folder = Main.Scalar(str);
        MP = AppPath + Folder;
        return MP;
    }
    public bool ThemeConflict(int AP_ID) {
        JDB Main = new JDB();
        if (Theme_ID != Main.Scalar("Select Theme_ID from User_App where IDNo=" + AP_ID))
        {
            string NewTheme = Main.Scalar("Select FoderName from Theme where IDNo=(Select Theme_ID from User_App where IDNo=" + AP_ID + ")");
            HttpContext.Current.Response.Write("<script>alert('參數錯誤');location.href='" + URL + "';</script>");
            WriteLog("ThemeConflict:" + AP_ID.ToString() + " in " + Theme);
            return true;
        }
        else { return false; }
    }
    
    public Bitmap CutImage(Bitmap souceImage, int w, int h)
    {
        //建立新的影像, int w 
        Bitmap cropImage = new Bitmap(w, h);
        //準備繪製新的影像
        Graphics graphics2 = Graphics.FromImage(cropImage);
        //設定裁切範圍
        Rectangle cropRect = new Rectangle(souceImage.Width / 2 - (w / 2), souceImage.Height / 2 - (h / 2), w, h);
        //於座標(0,0)開始繪製裁切影像
        graphics2.DrawImage(souceImage, 0, 0, cropRect, GraphicsUnit.Point);
        graphics2.Dispose();
        //儲存新的影像
        return cropImage;
    }
    public Bitmap zoomImage(Bitmap inbmp, int boxwidth, int boxheight) //圖片縮放
    {
        float scale = 0;
        int newwidth = 0;
        int newheight = 0;
        if (inbmp.Height < boxheight & inbmp.Width < boxwidth)
        {
            scale = 1;
            newwidth = boxwidth;
            newheight = boxheight;

        }
        else
        {
            if ((inbmp.Width * boxheight / inbmp.Height) < boxwidth)
            {

                newwidth = Convert.ToInt32(inbmp.Width * boxheight / inbmp.Height);
                newheight = Convert.ToInt32(inbmp.Height * boxheight / inbmp.Height);
                newwidth = boxwidth;
                newheight = Convert.ToInt32(inbmp.Height * boxwidth / inbmp.Width);
                scale = (boxheight / inbmp.Height);
            }
            else
            {
                newwidth = Convert.ToInt32(inbmp.Width * boxwidth / inbmp.Width);
                newheight = Convert.ToInt32(inbmp.Height * boxwidth / inbmp.Width);
                newheight = boxheight;
                newwidth = Convert.ToInt32(inbmp.Width * boxheight / inbmp.Height);
                scale = (boxwidth) / inbmp.Width;
            }
        }
        Bitmap outbmp = new Bitmap(inbmp, newwidth, newheight);
        return outbmp;
    }
    public bool CheckMobile()
    {
        string u = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
        Regex b = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        if ((b.IsMatch(u) || v.IsMatch(u.Substring(0, 4))))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public Bitmap GrayImage(Bitmap inbmp)
    {
        try
        {
            int Height = inbmp.Height;
            int Width = inbmp.Width;
            Bitmap newBitmap = new Bitmap(Width, Height);
            System.Drawing.Color pixel;
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    pixel = inbmp.GetPixel(x, y);
                    int r, g, b, Result = 0;
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    //实例程序以加权平均值法产生黑白图像
                    int iType = 2;
                    switch (iType)
                    {
                        case 0://平均值法
                            Result = ((r + g + b) / 3);
                            break;
                        case 1://最大值法
                            Result = r > g ? r : g;
                            Result = Result > b ? Result : b;
                            break;
                        case 2://加权平均值法
                            Result = ((int)(0.7 * r) + (int)(0.2 * g) + (int)(0.1 * b));
                            break;
                    }
                    int whiteUp = 160;
                    Result = ((255 - whiteUp) * Result / 255) + whiteUp;
                    newBitmap.SetPixel(x, y, System.Drawing.Color.FromArgb(Result, Result, Result));
                }
            return newBitmap;
        }
        catch (Exception ex)
        {
            WriteLog("GrayImage:" + ex.Message);
            return inbmp;
        }
    }
    public string ImgSerial(int id, int Col_Num)
    {
        return GetFullNum(id, 10) + GetFullNum(Col_Num, 2);
    }

    public string FBShareImg(int AppID)
    {
        JDB Main = new JDB();
        string result = "";
        string AppImgFolder = CurrentAppFolder(AppID) + "\\pic";
        string CurrBg = MainPath + "img\\fb-bg.jpg";
        DataTable d = Main.GetDataSetNoNull("Select * from User_App where IDNo=" + AppID);
        if (d.Rows.Count > 0)
        {
            DataRow dw = d.Rows[0];
            if (Directory.Exists(AppImgFolder) == false) { Directory.CreateDirectory(AppImgFolder); }
            string AppCover = AppImgFolder + "\\" + dw["App_Cover"];
            try
            { 
                if (File.Exists(CurrBg) && File.Exists(AppCover))
                {
                    Bitmap newImage = new Bitmap(CurrBg);
                    
                    Bitmap Img1 = new Bitmap(AppCover);
                    int size = 3;
                    int ver = 4;
                
                    QRCodeEncoder QRC = new QRCodeEncoder();
                    QRC.QRCodeScale = size;
                    QRC.QRCodeVersion = ver;
                    QRC.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                    Bitmap im = QRC.Encode(dw["App_URL"].ToString());

                    Img1 = zoomImage(Img1, 222, 305);
                    //準備繪製新的影像
                    Graphics g = Graphics.FromImage(newImage);
                    g.DrawImage(Img1, 35, 124);
                   
                    g.DrawRectangle(new Pen(System.Drawing.Color.Silver, 1), 300, 300, 350, 30);
                    g.DrawImage(im, 300, 195);
                    //g.DrawRectangle(new Pen(System.Drawing.Color.Red, 2), 298, 193, 108, 108);
         
                    DrawCenter(ref g, dw["App_Name"].ToString(), new Font("微軟正黑體", 11), Brushes.White, 35, 85, 222, 40);
                    g.DrawString(dw["App_URL"].ToString(), new Font("微軟正黑體", 10), Brushes.Black, 303, 307);
                    g.Dispose();

                    result = GetFullNum(AppID, 10) + "fb.jpg";
                    newImage.Save(AppImgFolder + "\\" + result);
                }
            }
            catch (Exception e)
            {
                WriteLog("FBShareImg Error: " + e.Message);
            }
    
        } 
        return result;
    }

    public void DrawCenter(ref Graphics G, string inputString, Font FNT, Brush Bru, int leftX, int TopY, int width, int height)
    {
        PointF b1 = this.CenterString(G, inputString, FNT, leftX, TopY, width, height);
        G.DrawString(inputString, FNT, Bru, b1);
    }

    public PointF CenterString(Graphics G, string inputString, Font FNT, int leftX, int TopY, int width, int height)
    {
        PointF aa = new PointF(0, 0);
        SizeF SS = G.MeasureString(inputString, FNT);
        aa.X = leftX + (width / 2) - (SS.Width / 2);
        aa.Y = TopY + (height / 2) - (SS.Height / 2);
        return aa;
    }



    public bool IsNumeric(object Expression)
    {
        bool isNum;
        double retNum;
        isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        return isNum;
    }
     
    public bool IsDate(string sdate)
    {
        DateTime dt;
        bool isDate = true;

        try
        {
            dt = DateTime.Parse(sdate);
        }
        catch
        {
            isDate = false;
        } 
        return isDate;
    }
      
    public bool GetDDL(DropDownList DDL, string strDT)
    {
        DDL.SelectedIndex = -1;
        //解除全部
        if (strDT != null)
        {
            for (int i = 0; i <= DDL.Items.Count - 1; i++)
            {
                if (DDL.Items[i].Value == Convert.ToString(strDT))
                {
                    DDL.Items[i].Selected = true;
                    break; // TODO: might not be correct. Was : Exit For
                    //防止重複
                }
            }
        }
        return true;
    }

    public bool GetDDLtext(DropDownList DDL, string strDT)
    {
        DDL.SelectedIndex = -1;
        //解除全部
        if (strDT != null)
        {
            for (int i = 0; i <= DDL.Items.Count - 1; i++)
            {
                if (DDL.Items[i].Text.Trim() == strDT.Trim())
                {
                    DDL.Items[i].Selected = true;
                    break; // TODO: might not be correct. Was : Exit For
                    //防止重複
                }
            }
        }
        return true;
    }

    public bool GetDDL(RadioButtonList RBL, string strDT)
    {
        RBL.SelectedIndex = -1;
        if (strDT != null)
        {
            for (int i = 0; i <= RBL.Items.Count - 1; i++)
            {
                if (RBL.Items[i].Value == Convert.ToString(strDT))
                {
                    RBL.Items[i].Selected = true;
                    break; // TODO: might not be correct. Was : Exit For
                    //防止重複
                }
            }
        }
        return true;
    }

    public bool GetDDLtext(RadioButtonList RBL, string strDT)
    {
        RBL.SelectedIndex = -1;
        if (strDT != null)
        {
            for (int i = 0; i <= RBL.Items.Count - 1; i++)
            {
                if (RBL.Items[i].Text == Convert.ToString(strDT))
                {
                    RBL.Items[i].Selected = true;
                    break; // TODO: might not be correct. Was : Exit For
                    //防止重複
                }
            }
        }
        return true;
    }

    public bool GetDDL(CheckBoxList CBL, string strDT)
    {
        //CBL.SelectedIndex = -1  '複選型的 不用解除
        if (strDT != null)
        {
            for (int i = 0; i <= CBL.Items.Count - 1; i++)
            {
                if (CBL.Items[i].Value == Convert.ToString(strDT))
                {
                    CBL.Items[i].Selected = true;
                }
            }
        }
        return true;
    }

    public bool GetDDLtext(CheckBoxList CBL, string strDT)
    {
        //CBL.SelectedIndex = -1
        if (strDT != null)
        {
            for (int i = 0; i <= CBL.Items.Count - 1; i++)
            {
                if (CBL.Items[i].Text == Convert.ToString(strDT))
                {
                    CBL.Items[i].Selected = true;
                }
            }
        }
        return true;
    }

    public string ClearHTML(string inStr)
    {
        while (inStr.IndexOf("[") > 0)
        {
            inStr = inStr.Substring(0, inStr.IndexOf("[")) + inStr.Substring(inStr.IndexOf("]") + 1);
        }
        return inStr;
    }  

    public bool ChkType(HttpPostedFile xfile, string xType)
    {
        //下方應用
        string tmp = xfile.ContentType;
        if (tmp.IndexOf(xType) > -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string SaveBmp(HttpPostedFile afile, int boxwidth, int boxheight, string Img)
    {
        string MainPath = Server.MapPath("/");
        string FilePath = System.Configuration.ConfigurationManager.AppSettings.Get("FilePath");



        double scale = 0;
        string filename = "";
        string file2 = "";
        DateTime y = DateTime.Now;
        string tmp = "";
        string result = "";
        if (ChkType(afile, "image") == false)
        {
            return "";
            //return functionReturnValue;
        }
        tmp = (DateTime.Now.Year - 1911) + DateTime.Now.Month + DateTime.Now.Day + y.TimeOfDay.ToString().Replace(":", "").Substring(0, 6);

        if (afile.ContentLength != 0)
        {
            filename = MainPath + FilePath + Img + tmp + Path.GetExtension(afile.FileName);
            file2 = MainPath + FilePath + Img + tmp + "_s" + Path.GetExtension(afile.FileName);
            afile.SaveAs(filename);
            result = FilePath + Img + tmp + "_s" + Path.GetExtension(afile.FileName);
        }

        Bitmap inbmp = new Bitmap(filename);
        if (inbmp.Height < boxheight & inbmp.Width < boxwidth)
        {
            scale = 1;
        }
        else
        {
            if ((inbmp.Width * boxheight / inbmp.Height < boxwidth))
            {
                scale = (boxheight) / inbmp.Height;
            }
            else
            {
                scale = (boxwidth) / inbmp.Width;
            }
        }
        int newwidth = Convert.ToInt32(scale * inbmp.Width);
        int newheight = Convert.ToInt32(scale * inbmp.Height);
        Bitmap outbmp = new Bitmap(inbmp, newwidth, newheight);
        outbmp.Save(file2);
        outbmp.Dispose();

        //活動剪影才用
        if (Img == "Photo\\")
        {
            //做大圖
            boxwidth = 600;
            boxheight = 450;
            if (inbmp.Height < boxheight & inbmp.Width < boxwidth)
            {
                scale = 1;
            }
            else
            {
                if ((inbmp.Width * boxheight / inbmp.Height < boxwidth))
                {
                    scale = (boxheight) / inbmp.Height;
                }
                else
                {
                    scale = (boxwidth) / inbmp.Width;
                }
            }
            newwidth = Convert.ToInt32(scale * inbmp.Width);
            newheight = Convert.ToInt32(scale * inbmp.Height);
            outbmp = new Bitmap(inbmp, newwidth, newheight);
            outbmp.Save(file2.Replace("_s", "_l"));
            outbmp.Dispose();
        }

        inbmp.Dispose();
        //最後再關
        return result;
        //return functionReturnValue;
    }

    public string GetFullNum(int num, int size)
    {
        //補0
        string tmp = num.ToString();

        if (size >= tmp.Length)
        {
            while (!(tmp.Length == size))
            {
                tmp = "0" + tmp;
            }
        }

        return tmp;
    }

    public string CMoneyChinese(int cc)
    {
        string tmp = "";
        char[] aa = cc.ToString().ToCharArray();
        string[] bb = new string[aa.Length + 1];
        for (int i = 0; i <= aa.Length - 1; i++)
        {
            bb[aa.Length - 1 - i] = CNUM(aa[i]);
        }
        if (bb[0] == "零")
            bb[0] = "";
        if (bb.Length > 1)
            if (!string.IsNullOrEmpty(bb[1]))
                bb[1] += "拾";
        if (bb.Length > 2)
            if (!string.IsNullOrEmpty(bb[2]))
                bb[2] += "佰";
        if (bb.Length > 3)
            if (!string.IsNullOrEmpty(bb[3]))
                bb[3] += "仟";
        if (bb.Length > 5)
            bb[4] += "萬";

        if (bb.Length > 5)
        {
            if (!string.IsNullOrEmpty(bb[5]))
                bb[5] += "拾";
        }
        if (bb.Length > 6)
        {
            if (!string.IsNullOrEmpty(bb[6]))
                bb[6] += "佰";
        }
        if (bb.Length > 7)
        {
            if (!string.IsNullOrEmpty(bb[7]))
                bb[7] += "仟";
        }
        if (bb.Length > 8)
        {
            if (!string.IsNullOrEmpty(bb[8]))
                bb[8] += "億";
        }
        for (int i = 0; i <= bb.Length - 1; i++)
        {
            tmp = bb[i] + tmp;
        }
        return tmp;
    }

    public string CNUM(char a)
    {
        string tmp = "";
        switch (Convert.ToString(a))
        {
            case "1":
                tmp = "壹";
                break;
            case "2":
                tmp = "貳";
                break;
            case "3":
                tmp = "參";
                break;
            case "4":
                tmp = "肆";
                break;
            case "5":
                tmp = "伍";
                break;
            case "6":
                tmp = "陸";
                break;
            case "7":
                tmp = "柒";
                break;
            case "8":
                tmp = "捌";
                break;
            case "9":
                tmp = "玖";
                break;
            case "0":
                tmp = "";

                break;
        }
        return tmp;
    }

    public bool InItems(string ItemValue, CheckBoxList LIS)
    {
        bool AA = false;
        for (int k = 0; k <= LIS.Items.Count - 1; k++)
        {
            if (ItemValue == LIS.Items[k].Value)
                AA = true;
        }
        return AA;
    }

    public bool InItems(string ItemValue, DropDownList LIS)
    {
        bool AA = false;
        for (int k = 0; k <= LIS.Items.Count - 1; k++)
        {
            if (ItemValue == LIS.Items[k].Value)
                AA = true;
        }
        return AA;
    }

    public bool InItems(string ItemValue, RadioButtonList LIS)
    {
        bool AA = false;
        for (int k = 0; k <= LIS.Items.Count - 1; k++)
        {
            if (ItemValue == LIS.Items[k].Value)
                AA = true;
        }
        return AA;
    }

    public static DataTable GridViewToDataTable(GridView GV)
    {
        DataTable DT = new DataTable();
        if (GV.Rows.Count > 0)
        {
            for (int i = 0; i <= GV.Columns.Count - 1; i++)
            {
                DT.Columns.Add(GV.Columns[i].HeaderText);
            }

            for (int i = 0; i <= GV.Rows.Count - 1; i++)
            {
                DataRow rw = DT.NewRow();
                for (int j = 0; j <= GV.Columns.Count - 1; j++)
                {
                    rw[j] = GV.Rows[i].Cells[j].Text;
                }
                DT.Rows.Add(rw);
            }
        }
        return DT;
    }

    //DataTable 2 Excel CSV
    public static string DataTableToExcelCSV(ref DataTable DataTable, string separaterWord = ",")
    {
        StringBuilder buffer = new StringBuilder();
        //產出表頭
        foreach (System.Data.DataColumn column in DataTable.Columns)
        {
            //輸出表頭，但是匯出時檢查是否有 separaterWord , 因為 separaterWord 是分隔字元
            //buffer.Append(column.ColumnName.Replace(separaterWord, "") + separaterWord);
        }
        //buffer.Append("\r\n"); 
        //依照欄位格式產出表身
        foreach (DataRow row in DataTable.Rows)
        {
            //每個欄位
            for (int i = 0; i <= DataTable.Columns.Count - 1; i++)
            {
                string dat = row[i].ToString().Replace(separaterWord, "");
                //buffer.Append(dat + separaterWord); 
                //if (i != DataTable.Columns.Count - 1)
                //{
                //    buffer.Append(separaterWord);
                //}
            }
              buffer.Append("\r\n");
        }
        //傳回
        return buffer.ToString();
    }

    //自動下載某個檔案 (從文字資料)
    //需設定  <globalization requestEncoding="BIG5" responseEncoding="BIG5" /> 

    public static object DownloadFile(System.Web.UI.Page WebForm, string FileNameWhenUserDownload, string FileBody)
    {
        WebForm.Response.ClearHeaders();
        WebForm.Response.Clear();
        WebForm.Response.Expires = 0;
        WebForm.Response.Buffer = true;

        WebForm.Response.AddHeader("Accept-Language", "zh-tw");
        WebForm.Response.AddHeader("content-disposition", "attachment; filename=" + "\x1e" + System.Web.HttpUtility.UrlEncode(FileNameWhenUserDownload, System.Text.Encoding.UTF8) + "\x1e");
        WebForm.Response.ContentType = "Application/octet-stream";

        //byte [] BB = System.Text.Encoding.GetEncoding("big5").GetBytes(Content);
        byte[] buf = Encoding.GetEncoding("big5").GetBytes(FileBody);
        //直接轉big5

        //  WebForm.Response.Write(FileBody)
        WebForm.Response.BinaryWrite(buf);
        WebForm.Response.End();
        return true;
    }

    ////新的Download
    //public static bool DownloadFile(System.Web.UI.Page WebForm, string FilePath)
    //{
    //    string FileName = null;
    //    //取得檔名
    //    FileName = FilePath;
    //    //取得檔案
    //    FileStream aa = new FileStream(FileName, FileMode.Open);
    //    byte[] buf = new byte[aa.Length + 1];

    //    if (aa.Read(buf, 0, aa.Length) < 1)
    //    {
    //        WebForm.Response.Write("讀取檔案失敗 檔名：[" + FileName + "]");
    //        WebForm.Response.End();
    //    }
    //    //準備下載檔案
    //    WebForm.Response.ClearHeaders();
    //    WebForm.Response.Clear();
    //    WebForm.Response.Expires = 0;
    //    WebForm.Response.Buffer = true;
    //    //透過 Header 設定檔名
    //    FileName = Right(FileName, Strings.InStr(Strings.StrReverse(FileName), "\\") - 1);
    //    WebForm.Response.AddHeader("content-disposition", "attachment; filename=" + Strings.Chr(34) + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + Strings.Chr(34));
    //    WebForm.Response.ContentType = "Application/octet-stream";

    //    aa.Close();
    //    aa.Dispose();
    //    //傳出要讓使用者下載的內容
    //    WebForm.Response.BinaryWrite(buf);
    //    Interaction.Shell("taskkill /im EXCEL.EXE");
    //    WebForm.Response.End();
    //    return true;
    //}

    public string SendMailNew(string FromMail, string ToMail, string Subj, string Bodystr)
    {
        string MailSvr = System.Configuration.ConfigurationManager.AppSettings.Get("MailSvr");
        string MailFromName = System.Configuration.ConfigurationManager.AppSettings.Get("MailFromName");
        if (string.IsNullOrEmpty(FromMail))
            FromMail = System.Configuration.ConfigurationManager.AppSettings.Get("MailFrom");
        string MailUser = System.Configuration.ConfigurationManager.AppSettings.Get("MailUser");
        string MailPWD = System.Configuration.ConfigurationManager.AppSettings.Get("MailPWD");
        string SS = "";
        try
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new System.Net.Mail.MailAddress(FromMail, MailFromName);
            //寄件人
            msg.To.Add(new System.Net.Mail.MailAddress(ToMail));
            //收件人
            msg.Subject = Subj;
            //主旨
            msg.Body = Bodystr;
            //內容
            msg.IsBodyHtml = true;
            //格式

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(MailSvr);
            if (!string.IsNullOrEmpty(MailUser))
            {
                smtp.Credentials = new System.Net.NetworkCredential(MailUser, MailPWD);
            }
            smtp.Send(msg);
        }
        catch (Exception ex)
        {
            SS = FromMail + "," + ToMail + "<br>" + MailSvr + "<br>" + ex.Message;
        }
        return SS;
    }

    public string SendMailOld(string FromMail, string ToMail, string Subj, string Bodystr)
    {
        string MailSvr = System.Configuration.ConfigurationManager.AppSettings.Get("MailSvr");
        if (string.IsNullOrEmpty(FromMail))
            FromMail = System.Configuration.ConfigurationManager.AppSettings.Get("MailFrom");
        string SS = "";
        try
        {
            MailMessage mail = new MailMessage();
            mail.To = ToMail;
            mail.From = FromMail;
            mail.Subject = Subj;

            mail.BodyFormat = MailFormat.Html;
            mail.Body = Bodystr;

            if (!string.IsNullOrEmpty(MailSvr))
                SmtpMail.SmtpServer = MailSvr;

            SmtpMail.Send(mail);

        }
        catch (Exception ex)
        {
            SS = FromMail + "," + ToMail + "<br>" + MailSvr + "<br>" + ex.Message;
        }
        return SS;
    }
    public string GetOrdersNO(string IDNo, DateTime SDate)
    {
        JDB Main = new JDB();
        Main.ParaClear();
        Main.ParaAdd("@IDNo", IDNo, SqlDbType.VarChar);
        Main.ParaAdd("@YY", (SDate.Year - 1911).ToString(), SqlDbType.VarChar);
        string HeadNO = "A" + (SDate.Year - 1911).ToString() + "-";
        Main.ParaAdd("@HeadNO", HeadNO, SqlDbType.NVarChar);
        string tmpNO = Main.Scalar("Select Max(Cast(Replace(Order_No,@HeadNO,'') as int)) from Orders where Store_ID=@IDNo and Order_No like @HeadNO+'%'");
        string Order_No = HeadNO + "00001";
        if (tmpNO != "")
        {
            if (IsNumeric(tmpNO))
            {
                Order_No = Order_No.Substring(0, HeadNO.Length) + (GetFullNum(Cint2(tmpNO) + 1, 5));
            }
        }
        return Order_No;
    }

    public string SendMail(string FromMail, string ToMail, string Subj, string Bodystr)
    {
        string MailSvr = System.Configuration.ConfigurationManager.AppSettings.Get("MailSvr");
        if (!string.IsNullOrEmpty(MailSvr))
        {
            return SendMailNew(FromMail, ToMail, Subj, Bodystr);
        }
        else
        {
            return SendMailOld(FromMail, ToMail, Subj, Bodystr);
        }
    }

    public DataTable TurnDataTable(DataTable DTable)
    {
        DataTable ND = new DataTable();
        for (int i = 0; i <= DTable.Rows.Count - 1; i++)
        {
            ND.Columns.Add();
        }
        for (int i = 0; i <= DTable.Columns.Count - 1; i++)
        {
            DataRow rw = ND.NewRow();
            for (int j = 0; j <= DTable.Rows.Count - 1; j++)
            {
                rw[j] = DTable.Rows[j][i];
            }
            ND.Rows.Add(rw);
        }
        return ND;
    } 

    public bool GoodRequest(System.Web.UI.Page page, string RequestName, string DataType)
    {
        string[] KW = {
		"'",
		"\"",
		"?",
		"%",
		"&",
		"||"
	};
        bool tmp = true;
        if ((page.Request.QueryString[RequestName] != null))
        {
            if (!string.IsNullOrEmpty(page.Request.QueryString[RequestName]))
            {
                switch (DataType)
                {
                    case "Int":
                        try
                        {
                            int cc = Convert.ToInt32(page.Request.QueryString[RequestName]);
                            tmp = true;
                        }
                        catch (Exception ex)
                        {
                            tmp = false;
                        }
                        break;
                    case "String":

                        string ss = page.Request.QueryString[RequestName];
                        if (ss.IndexOf("and") > -1)
                            tmp = false;
                        break;
                }
            }
            else
            {
                tmp = false;
            }
        }
        else
        {
            tmp = false;
        }
        return tmp;
    }

    public string GetDateString(DateTime dd)
    {
        //抓詳細時間(到秒)
        string tmp = Convert.ToString(dd.Year - 1911);
        tmp += GetFullNum(dd.Month, 2);
        tmp += GetFullNum(dd.Day, 2);
        tmp += GetFullNum(dd.Hour, 2);
        tmp += GetFullNum(dd.Minute, 2);
        tmp += GetFullNum(dd.Second, 2);
        return tmp;
    }

    public int Cint2(object s, int defaultvalue = 0)
    {
        int tmp = defaultvalue;
        try { 
            if (s != null)
            {
                tmp = Convert.ToInt32(s);
            }
        }
        catch { }
        finally { 
        }

        return tmp;
    }

    public Int64 CInt64(object s, Int64 defaultvalue = 0) {
        Int64 tmp = defaultvalue;
        try
        {
            if (s != null)
            {
                tmp = Int64.Parse(s.ToString());
            }
        }
        catch { }
        return tmp;
    }

    public string EnCrypTo(string InputString)
    {
        //鎖碼
        string result = "";
        try
        {
            string aa = "0123456789abcdefghijklmnopqrstuvwxyz";
            char[] r1 = aa.ToCharArray();
            string[] r2 = {
			"ygsu",
			"v2zf",
			"cnj9",
			"3hko",
			"80at",
			"lr7e",
			"m4wp",
			"xi15",
			"db6q",
			"f57q",
			"lnbe",
			"vzh0",
			"a4i1",
			"wgm9",
			"8soj",
			"rtcd",
			"u2y3",
			"kp6x",
			"6n1q",
			"vkh0",
			"mydg",
			"sc38",
			"oztj",
			"ifl9",
			"2ab4",
			"p7eu",
			"5rxw",
			"a942",
			"1i0x",
			"octu",
			"f5pe",
			"dkgq",
			"vjlr",
			"bwyz",
			"73nm",
			"f68u"
		};
            char[] istr = InputString.ToLower().ToCharArray();
            for (int i = 0; i <= istr.Length - 1; i++)
            {
                for (int j = 0; j <= r1.Length - 1; j++)
                {
                    if (istr[i] == r1[j])
                    {
                        result += r2[j];
                    }
                }
            }
        }
        catch (Exception ex)
        {
            result = InputString;
        }
        return result;
    }

    public string DeCrypTo(string InputString)
    {
        //解碼
        string result = "";
        try
        {
            string aa = "0123456789abcdefghijklmnopqrstuvwxyz";
            char[] r1 = aa.ToCharArray();
            string[] r2 = {
			"ygsu",
			"v2zf",
			"cnj9",
			"3hko",
			"80at",
			"lr7e",
			"m4wp",
			"xi15",
			"db6q",
			"f57q",
			"lnbe",
			"vzh0",
			"a4i1",
			"wgm9",
			"8soj",
			"rtcd",
			"u2y3",
			"kp6x",
			"6n1q",
			"vkh0",
			"mydg",
			"sc38",
			"oztj",
			"ifl9",
			"2ab4",
			"p7eu",
			"5rxw",
			"a942",
			"1i0x",
			"octu",
			"f5pe",
			"dkgq",
			"vjlr",
			"bwyz",
			"73nm",
			"f68u"
		};
            for (int i = 0; i <= InputString.Length - 1; i += 4)
            {
                for (int j = 0; j <= r2.Length - 1; j++)
                {
                    if (InputString.Substring(i, 4) == r2[j])
                    {
                        result += r1[j];
                    }
                }
            }
        }
        catch (Exception ex)
        {
            result = InputString;
        }
        return result.ToUpper();
    }
     
    public bool Equal(object a, object b)
    {
        if (a.ToString() == b.ToString()) { return true; } else { return false; }
    }

    public bool IsNull(object a)
    {
        if (a == null) { return true; } else { return false; }
    }
     
    public void WriteLog(string Mess)
    {
        string MP = System.Configuration.ConfigurationManager.AppSettings.Get("LOGPath");
        if (string.IsNullOrEmpty(MP))
            MP = Server.MapPath("~/") + "LOGPath\\";

        MP = MP + "\\" + DateTime.Now.Year.ToString() + GetFullNum(DateTime.Now.Month, 2) + "\\";
        if (System.IO.Directory.Exists(MP) == false)
        {
            System.IO.Directory.CreateDirectory(MP);
        }

        StreamWriter SW = new StreamWriter(MP + strDate(DateTime.Today) + ".log", true, System.Text.Encoding.Default);
        string str = "";
        try
        {
            str = Mess;
            SW.WriteLine(str);
            SW.Flush();
            SW.Close();

        }
        catch (Exception ex)
        {
            SW.Flush();
            SW.Close();
        }
        finally
        {
            SW.Close();
        }
    }
 
    public string strDate(DateTime dd)
    {
        string tmp = Convert.ToString(dd.Year - 1911);
        tmp += GetFullNum(dd.Month, 2);
        tmp += GetFullNum(dd.Day, 2);
        //tmp += GetFullNum(dd.Hour, 2)
        return tmp;
    }

    public int SaveCookie(String CookieName, String CookieValue, int ExpireDays = 365)
    {
        try
        {
            HttpCookie CoKe = new HttpCookie(CookieName);
            CoKe.Value = CookieValue;
            CoKe.Expires = DateTime.Now.AddDays(ExpireDays);
            HttpContext.Current.Response.Cookies.Add(CoKe);
            return 1;
        }
        catch (Exception e)
        {
            WriteLog(e.Message);
            return 0;
        }
    }

    public int DeleCoookie(String CookieName)
    {
        try
        {
            HttpCookie CoKe = new HttpCookie(CookieName);
            CoKe.Value = "";
            CoKe.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(CoKe);
            return 1;
        }
        catch (Exception e)
        { 
            return 0;
        }
    }

    public string DoAppCover(int AppID)
    {
        JDB Main = new JDB();
        str = "select  a.IDNo as App_id,ISNULL(a.App_Cover,'') App_Cover,'Apps\\' + a.App_Folder+'\\pic\\icover_' + convert(varchar,a.IDNo) + '.jpg' as PicPath, " +
              "(case when b.Img01='img/p01.jpg'   then 'Apps\\img\\p01.jpg'  " +
              "when b.Img01='img/p02-1.jpg' then 'Apps\\img\\p02-1.jpg' " +
              "when b.Img01='img/p03-1.jpg' then 'Apps\\img\\p03-1.jpg' " +
              "when b.Img01='img/p04-1.jpg' then 'Apps\\img\\p04-1.jpg'" +
              "when b.Img01='img/p05-1.jpg' then 'Apps\\img\\p05-1.jpg' " +
              "when b.Img01='img/p06-1.jpg' then 'Apps\\img\\p06-1.jpg' else 'Apps\\' + replace(b.Img01,'/','\\') end) as img01 ," +
              "(case when  b.Img02='img/p03-2.jpg' then '\\Apps\\img\\p03-2.jpg' " +
              "when b.Img02='img/p04-2.jpg' then 'Apps\\img\\p04-2.jpg' else 'Apps\\' + replace(b.Img02,'/','\\') end) as Img02 ," +
              "(case when  b.Img03='img/p03-3.jpg' then '\\Apps\\img\\p03-3.jpg' " +
              "when b.Img03='img/p04-3.jpg' then 'Apps\\img\\p04-3.jpg' else 'Apps\\' + replace(b.Img03,'/','\\') end) as Img03 " +
              ",c.ImgNum,c.URL  from User_App a inner join User_Page b on a.IDNo=b.User_App_ID and b.Sort=1 " +
              " inner join Pages c on c.IDNo=b.Page_ID where  a.IDNo=" + AppID + " ";
        DataTable DT = Main.GetDataSetNoNull(str);
        if (DT.Rows.Count > 0)
        {
            DataRow dw = DT.Rows[0];
            if (dw["App_Cover"].ToString() == "")
            {
                try
                { 
                    Bitmap newImage = new Bitmap(640, 1136); 
                    Bitmap newImgp01 = new Bitmap(MainPath + dw["Img01"].ToString());
 
                    //準備繪製新的影像
                    Graphics g = Graphics.FromImage(newImage);
                    if (dw["ImgNum"].ToString() == "1")
                    {
                        g.DrawImage(newImgp01, 0, 0);
                    }
                    else if (dw["ImgNum"].ToString() == "3")
                    {
                        Bitmap newImgp02 = new Bitmap(MainPath + dw["Img02"].ToString());
                        Bitmap newImgp03 = new Bitmap(MainPath + dw["Img03"].ToString());

                        switch (dw["URL"].ToString())
                        {
                            case "p03.aspx":
                                g.DrawImage(newImgp01, 0, 0); 
                                g.DrawImage(newImgp02, 0, 379);
                                g.DrawImage(newImgp03, 0, 757);
                                break;
                            case "p04.aspx":
                                g.DrawImage(newImgp01, 0, 0);
                                g.DrawImage(newImgp02, 0, 569);
                                g.DrawImage(newImgp03, 321, 569);
                                break;
                        }
                    }
                    g.Dispose();
                    newImage.Save(MainPath + dw["PicPath"].ToString());
                    if (File.Exists(MainPath + dw["PicPath"].ToString()))
                    {
                        Main.NonQuery("update User_App set App_Cover='icover_" + dw["App_id"].ToString() + ".jpg' where idno=" + AppID + "");
                    }
                }
                catch (Exception)
                {
                    return MainPath + dw["PicPath"].ToString();
                    throw;
                }
                return "DoCover";
            }
            else
            {
                return "IsExist";
            }
        }
        else
        {
            return str;
        }
    }
}