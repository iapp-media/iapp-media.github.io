using System;
using System.IO;
using System.Collections.Generic;
using System.Linq; 
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreMana
{
    public partial class Product_Img : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Comm.IsNumeric(Request.QueryString["PID"]) & Comm.IsNumeric(Request.QueryString["Img"]))
                {
                    string pimg = "";
                    if (Main.Scalar("select isnull(max(num),'') from Product_Img where Product_ID='" + Request.QueryString["PID"].ToString() + "'  and Num='" + Request.QueryString["Img"] + "'") == Request.QueryString["Img"])
                    {
                        pimg = Main.Scalar("select FilePath from Product_Img where 1=1 and Product_ID='" + Request.QueryString["PID"].ToString() + "'  and Num='" + Request.QueryString["Img"] + "'");
                    }

                    if (pimg != "")
                    {
                        L.Text = "<a id='show-upload' href='#'>" +
                                    "<label for='FU'>" +
                                        "<img   height='250' width='200'  src='" + Comm.MiStoreUrl + pimg + "' />" +
                                    " </label>" +
                                 "</a>";
                    }
                    else
                    {
                        L.Text = "<a id='show-upload'  href='#'>" +
                                    "<label for='FU'>" +
                                        "<img class='upload' src='img/uploadicon.png' />" +
                                    " </label>" +
                                 "</a>";
                    }
                }
            }
        }

        protected void BTUpload_Click(object sender, EventArgs e)
        {
            if (FU.HasFile)
            {
                string FileFolder = "", FilePath = "";
                Main.ParaClear();
                Main.ParaAdd("@idno", Main.Cint2(Request.QueryString["PID"]), System.Data.SqlDbType.Int);
                Main.ParaAdd("@Num", Main.Cint2(Request.QueryString["Img"]), System.Data.SqlDbType.Int);

                string FileName = Comm.ImgSerial(Comm.Cint2(Request.QueryString["PID"]), Comm.Cint2(Request.QueryString["Img"])) + ".jpg";

                if (Main.Scalar("select isnull(max(idno),'0') from Product_Img where Product_ID='" + Request.QueryString["PID"] + "' and Num='" + Request.QueryString["Img"] + "'") != "0")
                {
                    FileFolder = Main.Scalar("select Folder from Product_Img where Product_ID=@idno and Num=@Num");
                }
                 if (FileFolder == "")
                {
                    FileFolder = Comm.CheckAppFolder();
                    FilePath = Comm.MiStorePath + "\\Itempic\\" + FileFolder + "\\"; 

                    if (File.Exists(FilePath + FileName))
                    {
                        File.Delete(FilePath + FileName);
                    }
                    FU.SaveAs(FilePath + FileName);
                    Main.ParaAdd("@path", "Itempic/" + FileFolder.Trim() + "/" + FileName, System.Data.SqlDbType.NVarChar);
                    Main.ParaAdd("@Folder", FileFolder, System.Data.SqlDbType.NVarChar);


                    Main.NonQuery("insert into Product_Img (Product_ID, Num, Folder, FilePath) values " +
                                  "(@idno, @Num, @Folder, @path)");


                }
                else
                {
                   FilePath = Comm.MiStorePath + "\\Itempic\\" + FileFolder + "\\"; 
                    if (File.Exists(FilePath + FileName))
                    {
                        File.Delete(FilePath + FileName);
                    }
                    FU.SaveAs(FilePath + FileName);
                    Main.ParaAdd("@path", "Itempic/" + FileFolder.Trim() + "/" + FileName, System.Data.SqlDbType.NVarChar);
                    Main.ParaAdd("@Folder", FileFolder, System.Data.SqlDbType.NVarChar);

                    Main.NonQuery("update Product_Img set FilePath=@path where Product_ID=@idno and Folder=@Folder and Num=@Num ");
                    //思考如果要刪圖片的話



                    //Main.NonQuery(" update Product set img0" + Request.QueryString["Img"] + "=@ppath where idno=@idno");
                }
            }

              
        }
    }
}