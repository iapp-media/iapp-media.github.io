using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

namespace Wedding
{
    public partial class makeHtml : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["i"] != null)
                {
                    Session["Ap_id"] = Request.QueryString["i"];
                }
                string preUrl = MakeHtml();
                Response.Write(preUrl);
            } 
            Response.End();
        }
        private string MakeHtml()
        {
            string LAppPath = "Invitation\\" + Session["Ap_id"].ToString() + ".html";
            //產生App的主{{{路徑}}}
            string newUrl = LAppPath;
            //回傳javaScript AJAX !!!!網址!!!!
            string url = "Select Theme_head,Theme_foot from Theme where IDNo=3";
            //選擇主題 帶入App上下兩段HTML
            string AppUrl = Comm.URL + newUrl;
            Main.ParaClear();
            Main.ParaAdd("@User_ID", Comm.User_ID(), System.Data.SqlDbType.Int);
            Main.ParaAdd("@Couple_id", Comm.Wedding_ID(), System.Data.SqlDbType.Int);
            Main.ParaAdd("@app_id", Main.Cint2(Session["Ap_id"].ToString()), System.Data.SqlDbType.Int);

            StringBuilder ss = new StringBuilder();

            //Main.ParaAdd("@gg", AppUrl, System.Data.SqlDbType.NVarChar);
            ////產生網址之後把 路徑寫入App資料庫
            //str = "Update User_App set App_URL=@gg where IDNo=@app_id And User_ID=@User_ID And Theme_ID=@Theme_ID";
            //Main.NonQuery(str);



            DataTable themeTable = Main.GetDataSetNoNull(url);
            string TheHead = HttpUtility.HtmlDecode(themeTable.Rows[0]["Theme_head"].ToString());
            string Thefoot = HttpUtility.HtmlDecode(themeTable.Rows[0]["Theme_foot"].ToString());

            //string AppName = "iApp Mobile We-Media";
            //string AppMemo = "我的媒體我做主，行動時代，行動自媒體";
            //string ShareImg = "";
            DataTable DtApp = Main.GetDataSetNoNull("Select * from Wedding_info where IDNo=@app_id");
            if (DtApp.Rows.Count > 0)
            { 
                //AppName = DtApp.Rows[0]["w_plece"].ToString();
                //AppMemo = DtApp.Rows[0]["w_Addr"].ToString().Replace("\r\n", " ");
                //AppName = DtApp.Rows[0]["w_Tel"].ToString();
                //AppName = DtApp.Rows[0]["w_Time"].ToString();
                //AppName = DtApp.Rows[0]["w_man"].ToString();
                //AppName = DtApp.Rows[0]["w_woman"].ToString();
                //AppName = DtApp.Rows[0]["w_calender1"].ToString();
                //AppName = DtApp.Rows[0]["w_calender2"].ToString();
                //AppName = DtApp.Rows[0]["w_calender3"].ToString();
                //AppName = DtApp.Rows[0]["map_addr"].ToString();
                //AppName = DtApp.Rows[0]["Traffic_info"].ToString(); 
               // TheHead = TheHead.Replace("[AppName]", AppName).Replace("[AppMemo]", AppMemo).Replace("[ShareImg]", ShareImg).Replace("[AppUrl]", AppUrl);

                Main.ParaClear();
                Main.ParaAdd("@WID", Comm.Wedding_ID(), System.Data.SqlDbType.Int);
                Main.ParaAdd("@WInfo_ID", Main.Cint2(Session["Ap_id"].ToString()), System.Data.SqlDbType.Int);

                ss.Append(TheHead + "\r\n");

                //產生內頁
                ss.Append(" <!-- 首頁三明治 --> " + "\r\n");
                ss.Append("    <div id=\"loading\">iApp 載入中</div> " + "\r\n");
                ss.Append("    <div class=\"allMove\" id=\"allMove\"> " + "\r\n");
                ss.Append("        <a href=\"#\" class=\"sandwich\"> " + "\r\n");
                ss.Append("        </a> " + "\r\n");
                ss.Append("        <ul class=\"menu\" id=\"menu\"> " + "\r\n");
                ss.Append("            <li> " + "\r\n");
                ss.Append("                <a href=\"#\" class=\"liColor\"> " + "\r\n");
                ss.Append("                    <img src=\"../img/p7-pic.png\" alt=\"\"> " + "\r\n");
                ss.Append("                </a> " + "\r\n");
                ss.Append("            </li> " + "\r\n");
                ss.Append("            <li id=\"jump2\"><a>我要赴宴</a></li> " + "\r\n");
                ss.Append("            <li class=\"Blessing\"><a>送上祝福</a></li> " + "\r\n");
                ss.Append("            <li><a>婚禮 iApp</a></li> " + "\r\n");
                ss.Append("            <li><a>婚禮 微創作</a></li> " + "\r\n");
                ss.Append("            <li><img src=\"../QRcode.ashx?t=" + Comm.URL + newUrl.Replace("\\", "/") + " class=\"QRcode\">" + "\r\n"); 
                //ss.Append("            <li><img src=\"../img/qr-code-harley.jpg\" alt=\"\" class=\"QRcode\"> " + "\r\n");
                ss.Append("                <a href=\"http://line.naver.jp/R/msg/text/?http://www.iapp-media.net/harley/\"> " + "\r\n");
                ss.Append("                    <img src=\"../img/lineicon.png\" alt=\"用LINE傳送\" class=\"line\" /> " + "\r\n");
                ss.Append("                </a> " + "\r\n");
                ss.Append("            </li> " + "\r\n");
                ss.Append("        </ul> " + "\r\n");
                ss.Append("    </div> " + "\r\n");
                ss.Append("    <!-- 三明治 end --> " + "\r\n");
                ss.Append("    <!-- Page1 --> " + "\r\n");
                ss.Append("    <div class=\"page page-1-1 page-current\"> " + "\r\n");
                ss.Append("        <div class=\"time\"> " + "\r\n");
                ss.Append("            <p>民國<span>" + DtApp.Rows[0]["w_calender1"].ToString() + "</span>年</p> " + "\r\n");
                ss.Append("            <p>國曆<span>" + DtApp.Rows[0]["w_calender2"].ToString() + "</span></p> " + "\r\n");
                ss.Append("            <p>農曆<span>" + DtApp.Rows[0]["w_calender3"].ToString() + "</span></p> " + "\r\n");
                ss.Append("        </div> " + "\r\n");
                ss.Append("        <div class=\"page1Title\"> " + "\r\n");
                ss.Append("            <div>" + DtApp.Rows[0]["w_man"].ToString() + "</div> " + "\r\n");
                ss.Append("            <div></div> " + "\r\n");
                ss.Append("            <div>" + DtApp.Rows[0]["w_woman"].ToString() + "</div> " + "\r\n");
                ss.Append("        </div> " + "\r\n");
                ss.Append("        <div class=\"Protagonist\"> " + "\r\n");

                string tmpImg = "";
                tmpImg = Main.Scalar("select filepath from Wedding_img where Couple_ID=@WID and Num='1' and WInfo_ID=@WInfo_ID");
                if (tmpImg == "")
                {
                    tmpImg = "img/p1-photo.jpg";
                }
                ss.Append("            <img src=\"../" + tmpImg + "\" alt=\"\"> " + "\r\n");
                ss.Append("        </div> " + "\r\n");
                ss.Append("        <div class=\"inside\"> " + "\r\n");
                ss.Append("            <div> " + "\r\n");
                ss.Append("                <label for=\"\">席設 :</label> " + "\r\n");
                ss.Append("                <span>" + DtApp.Rows[0]["w_plece"].ToString() + "</span> " + "\r\n");
                ss.Append("            </div> " + "\r\n");
                ss.Append("            <div> " + "\r\n");
                ss.Append("                <label for=\"\">地點 :</label> " + "\r\n");
                ss.Append("                <span>" + DtApp.Rows[0]["w_Addr"].ToString() + "</span> " + "\r\n");
                ss.Append("                <img src=\"../img/p1-location.png\" class=\"location\" alt=\"\"> " + "\r\n");
                ss.Append("            </div> " + "\r\n");
                ss.Append("            <div> " + "\r\n");
                ss.Append("                <label for=\"\">電話 :</label> " + "\r\n");
                ss.Append("                <span>" + DtApp.Rows[0]["w_Tel"].ToString() + "</span> " + "\r\n");
                ss.Append("                <img src=\"../img/p1-callphone.png\" class=\"callphone\" alt=\"\"> " + "\r\n");
                ss.Append("            </div> " + "\r\n");
                ss.Append("            <div> " + "\r\n");
                ss.Append("                <label for=\"\">時間 :</label> " + "\r\n");
                ss.Append("                <span>" + DtApp.Rows[0]["w_Time"].ToString() + "</span> " + "\r\n");
                ss.Append("            </div> " + "\r\n");
                ss.Append("            <button class=\"carewed\">我要赴宴</button> " + "\r\n");
                ss.Append("        </div> " + "\r\n");
                ss.Append("    </div> " + "\r\n");
                ss.Append("    <!-- Page1 end --> " + "\r\n");
                ss.Append("    <!-- Page2 --> " + "\r\n");
                ss.Append("    <div class=\"page page-2-1 hide\"> " + "\r\n");
                ss.Append("        <ul class=\"Page2index\"> " + "\r\n");
                ss.Append("            <li class=\"animated fadeInDown\"> " + "\r\n");
                ss.Append("               <span>" + DtApp.Rows[0]["p2Memo"].ToString() + "</span> " + "\r\n");
                //ss.Append("                <input type=\"text\" value=\"一個意外  讓我們  相遇\" disabled=\"disabled\"> " + "\r\n");
                //ss.Append("                <input type=\"text\" value=\"一場大雨  讓我們  相知\" disabled=\"disabled\"> " + "\r\n");
                ss.Append("            </li> " + "\r\n");
                ss.Append("        </ul> " + "\r\n");

                tmpImg = "";
                tmpImg = Main.Scalar("select filepath from Wedding_img where Couple_ID=@WID and Num='2' and WInfo_ID=@WInfo_ID");
                if (tmpImg == "")
                {
                    tmpImg = "img/p2-photo2.jpg";
                }
                ss.Append("        <div class=\"page2pic\"><img src=\"../" + tmpImg + "\" alt=\"\"></div> " + "\r\n");
                ss.Append("        <div class=\"page2pic2\"><img src=\"../img/p2-photo1.jpg\" alt=\"\"></div> " + "\r\n");
                ss.Append("        <img class=\"up moveIconUp\" src=\"../img/icon_up.png\" /> " + "\r\n");
                ss.Append("    </div> " + "\r\n");
                ss.Append("    <!-- Page2 end --> " + "\r\n");
                ss.Append("    <!-- Page3 --> " + "\r\n");
                ss.Append("    <div class=\"page page-3-1 hide\"> " + "\r\n");
                ss.Append("        <ul class=\"Page3index\"> " + "\r\n");
                ss.Append("            <li class=\"animated fadeInDown\"> " + "\r\n");
                ss.Append("               <span>" + DtApp.Rows[0]["p3Memo1"].ToString() + "</span> " + "\r\n");
                //ss.Append("                <input type=\"text\" value=\"習慣了妳的聲音、妳的氣味、妳的存在...\"> " + "\r\n");
                //ss.Append("                <input type=\"text\" value=\"連思念都成了習慣\"> " + "\r\n");
                ss.Append("            </li> " + "\r\n");
                ss.Append("        </ul> " + "\r\n");
                ss.Append("        <ul class=\"Page3Insidepic\"> " + "\r\n");

                for (int i = 3; i < 8; i++)
                {
                    tmpImg = "";
                    tmpImg = Main.Scalar("select filepath from Wedding_img where Couple_ID=@WID and Num='" + i + "' and WInfo_ID=@WInfo_ID");
                    if (tmpImg == "")
                    {
                        tmpImg = "img/p3-photo" + (i - 2).ToString() + ".jpg";
                    }
                    ss.Append("            <li><img src=\"../" + tmpImg + "\" alt=\"\"></li> " + "\r\n");
                }
                //ss.Append("            <li><img src=\"../img/p3-photo2.jpg\" alt=\"\"></li> " + "\r\n");
                //ss.Append("            <li><img src=\"../img/p3-photo3.jpg\" alt=\"\"></li> " + "\r\n");
                //ss.Append("            <li><img src=\"../img/p3-photo4.jpg\" alt=\"\"></li> " + "\r\n");
                //ss.Append("            <li><img src=\"../img/p3-photo5.jpg\" alt=\"\"></li> " + "\r\n");
                ss.Append("        </ul> " + "\r\n");
                ss.Append("        <ul class=\"Page3indexBot\"> " + "\r\n");
                ss.Append("            <li class=\"animated fadeInDown\"> " + "\r\n");
                ss.Append("               <span>" + DtApp.Rows[0]["p3Memo2"].ToString() + "</span> " + "\r\n");
                //ss.Append("                <input type=\"text\" value=\"終於  我牽起你的手\"> " + "\r\n");
                //ss.Append("                <input type=\"text\" value=\"那一天起  就決定再也不放開\"> " + "\r\n");
                ss.Append("            </li> " + "\r\n");
                ss.Append("        </ul> " + "\r\n");
                ss.Append("        <img class=\"up moveIconUp\" src=\"../img/icon_up.png\" /> " + "\r\n");
                ss.Append("    </div> " + "\r\n");
                ss.Append("    <!-- Page3 end --> " + "\r\n");
                ss.Append("    <!-- Page4 --> " + "\r\n");
                ss.Append("    <div class=\"page page-4-1 hide\"> " + "\r\n");
                ss.Append("        <ul class=\"Page4Top\"> " + "\r\n");
                ss.Append("            <li class=\"animated fadeInDown\"> " + "\r\n");
                ss.Append("                <input type=\"text\" value=\"妳使我的生命得到豐富\" disabled=\"disabled\"> " + "\r\n");
                ss.Append("                <input type=\"text\" value=\"妳照亮了前方的迷霧\" disabled=\"disabled\"> " + "\r\n");
                ss.Append("                <input type=\"text\" value=\"牽著妳的手我更清楚\" disabled=\"disabled\"> " + "\r\n");
                ss.Append("                <input type=\"text\" value=\"相知與相惜\" disabled=\"disabled\"> " + "\r\n");
                ss.Append("            </li> " + "\r\n");
                ss.Append("        </ul> " + "\r\n");
                ss.Append("        <ul class=\"weddinghand\"> " + "\r\n");
                ss.Append("            <li><img src=\"../img/p4-ani01.png\" alt=\"\"></li> " + "\r\n");
                ss.Append("            <li><img src=\"../img/p4-ani02.png\" alt=\"\"></li> " + "\r\n");
                ss.Append("            <li><img src=\"../img/p4-ani03.png\" alt=\"\"></li> " + "\r\n");
                ss.Append("        </ul> " + "\r\n");
                ss.Append("        <ul class=\"Page4Bot\"> " + "\r\n");
                ss.Append("            <li class=\"animated fadeInDown\"> " + "\r\n");
                ss.Append("                <input type=\"text\" value=\"『我們結婚吧』\" disabled=\"disabled\"> " + "\r\n");
                ss.Append("                <input type=\"text\" value=\"Yes I do\" disabled=\"disabled\"> " + "\r\n");
                ss.Append("            </li> " + "\r\n");
                ss.Append("        </ul> " + "\r\n");
                ss.Append("        <img class=\"up moveIconUp\" src=\"../img/icon_up.png\" /> " + "\r\n");
                ss.Append("    </div> " + "\r\n");
                ss.Append("    <!-- Page4 end --> " + "\r\n");
                ss.Append("    <!-- Page5 --> " + "\r\n");
                ss.Append("    <div class=\"page page-5-1 flipster hide\"> " + "\r\n");
                ss.Append("        <ul> " + "\r\n");

                for (int i = 8; i < 14; i++)
                {
                    tmpImg = "";
                    tmpImg = Main.Scalar("select filepath from Wedding_img where Couple_ID=@WID and Num='" + i + "' and WInfo_ID=@WInfo_ID");
                    if (tmpImg == "")
                    {
                        tmpImg = "img/p5-photo1.jpg";
                    }
                    ss.Append("            <li> " + "\r\n");
                    ss.Append("                <a href=\"javascript:void(0)\" class=\"Button Block\"> " + "\r\n");
                    ss.Append("                    <img src=\"../" + tmpImg + "\" alt=\"\"> " + "\r\n");
                    ss.Append("                </a> " + "\r\n");
                    ss.Append("            </li> " + "\r\n");
                }
                //ss.Append("            <li> " + "\r\n");
                //ss.Append("                <a href=\"#\" class=\"Button Block\"> " + "\r\n");
                //ss.Append("                    <img src=\"../img/p5-photo1.jpg\" alt=\"\"> " + "\r\n");
                //ss.Append("                </a> " + "\r\n");
                //ss.Append("            </li> " + "\r\n");
                //ss.Append("            <li> " + "\r\n");
                //ss.Append("                <a href=\"#\" class=\"Button Block\"> " + "\r\n");
                //ss.Append("                    <img src=\"../img/p5-photo1.jpg\" alt=\"\"> " + "\r\n");
                //ss.Append("                </a> " + "\r\n");
                //ss.Append("            </li> " + "\r\n");
                //ss.Append("            <li> " + "\r\n");
                //ss.Append("                <a href=\"#\" class=\"Button Block\"> " + "\r\n");
                //ss.Append("                    <img src=\"../img/p5-photo1.jpg\" alt=\"\"> " + "\r\n");
                //ss.Append("                </a> " + "\r\n");
                //ss.Append("            </li> " + "\r\n");
                //ss.Append("            <li> " + "\r\n");
                //ss.Append("                <a href=\"#\" class=\"Button Block\"> " + "\r\n");
                //ss.Append("                    <img src=\"../img/p5-photo1.jpg\" alt=\"\"> " + "\r\n");
                //ss.Append("                </a> " + "\r\n");
                //ss.Append("            </li> " + "\r\n");
                //ss.Append("            <li> " + "\r\n");
                //ss.Append("                <a href=\"#\" class=\"Button Block\"> " + "\r\n");
                //ss.Append("                    <img src=\"../img/p5-photo1.jpg\" alt=\"\"> " + "\r\n");
                //ss.Append("                </a> " + "\r\n");
                //ss.Append("            </li> " + "\r\n");
                ss.Append("        </ul> " + "\r\n");
                ss.Append("        <img class=\"up moveIconUp\" src=\"../img/icon_up.png\" /> " + "\r\n");
                ss.Append("    </div> " + "\r\n");
                ss.Append("    <!-- Page5 end --> " + "\r\n");
                ss.Append("    <!-- Page6 --> " + "\r\n");
                ss.Append("    <div class=\"page page-6-1 hide\"> " + "\r\n");
                ss.Append("        <div class=\"wrap\"> " + "\r\n");
                ss.Append("            <img class=\"up animated moveIconUp\" src=\"../img/icon_up.png\" /> " + "\r\n");
                ss.Append("            <iframe class=\"map\" name=\"iframemap\" src=\"../map.html\"></iframe> " + "\r\n");
                ss.Append("            <a href=\"javascript: return false;\" onclick=\"iframemap.window.location.reload()\" class=\"button\"><img src=\"../img/reflash.png\" border=\"0\" onclick=\"this.src=='http://tkining.github.io/iapp-map/../img/reflash.png'?this.src='http://tkining.github.io/iapp-map/../img/reflash2.png':this.src='http://tkining.github.io/iapp-map/../img/reflash.png'\"></a> " + "\r\n");
                ss.Append("        </div> " + "\r\n");
                ss.Append("        <h1>交通資訊</h1> " + "\r\n");
                ss.Append("        <div> " + "\r\n");
                ss.Append("                <span>" + DtApp.Rows[0]["Traffic_info"].ToString() + "</span> " + "\r\n");
                ss.Append("        </div> " + "\r\n");
                //ss.Append("        <div> " + "\r\n");
                //ss.Append("            <label for=\"\">公車 :</label> " + "\r\n");
                //ss.Append("            <textarea rows=\"2\" cols=\"3\">搭台北聯營公車20.202.207.258.282.284.信義 幹線等路，在世貿下車可抵達君悅大飯店。 " + "\r\n");
                //ss.Append("            </textarea> " + "\r\n");
                //ss.Append("        </div> " + "\r\n");
                //ss.Append("        <div class=\"Carmargin\"> " + "\r\n");
                //ss.Append("            <label for=\"\">開車 :</label> " + "\r\n");
                //ss.Append("            <textarea rows=\"5\" cols=\"3\">1.下圓山(松江路)交流道，循建國高架橋南行， 於信義路出口下，轉信義路東行，再左轉基隆路可抵達君悅大飯店 2.北二高台北聯絡道，延辛亥路右轉基隆路行約3公里可抵達 " + "\r\n");
                //ss.Append("            </textarea> " + "\r\n");
                //ss.Append("        </div> " + "\r\n");
                ss.Append("    </div> " + "\r\n");
                ss.Append("    <!-- Page6 end --> " + "\r\n");
                ss.Append("    <!-- Page7 --> " + "\r\n");
                ss.Append("    <div class=\"page page-7-1 hide\"> " + "\r\n");
                ss.Append("        <ul class=\"page7pic\"> " + "\r\n");
                ss.Append("            <li><img src=\"../img/p7-pic.png\" alt=\"\"></li> " + "\r\n");
                ss.Append("            <li><img src=\"../QRcode.ashx?t=" + Comm.URL + newUrl.Replace("\\","/") + " \"></li> " + "\r\n");
                //ss.Append("            <li><img src=\"../img/p7-qr.jpg\" alt=\"\"></li> " + "\r\n");
                ss.Append("            <li><img src=\"../img/p7-create.png\" alt=\"\"></li> " + "\r\n");
                ss.Append("            <li><img src=\"../img/p7-share.png\" alt=\"\"></li> " + "\r\n");
                ss.Append("        </ul> " + "\r\n");
                ss.Append("    </div> " + "\r\n");
                ss.Append("    <input type=\"password\" value=\"" + Session["Ap_id"].ToString() + "\" id=\"carFrom\" style=\"visibility:hidden\" /> " + "\r\n");
                ss.Append("    <!-- Page7 end --> " + "\r\n");


               
                ss.Append(Thefoot + "\r\n");

            }

            //if (d.Rows.Count > 0)
            //{
            //    for (int i = 0; i <= d.Rows.Count - 1; i++)
            //    {
            //        DataRow dw = d.Rows[i];
            //        string html = HttpUtility.HtmlDecode(dw["Html"].ToString());
            //        ss.Append("<div id=\"page-" + i + 2 + "-1\" class=\"page page-" + Comm.Cint2(dw["Page_Type"]) + "-1 hide\">" + "\r\n");
            //        if (!string.IsNullOrEmpty(dw["Img01"].ToString()) & !string.IsNullOrEmpty(dw["Img02"].ToString()) & !string.IsNullOrEmpty(dw["Img03"].ToString()))
            //        {
            //            ss.Append(html.Replace("[img01]", "../" + dw["Img01"]).Replace("[img02]", "../" + dw["Img02"]).Replace("[img03]", "../" + dw["Img03"]) + "\r\n");
            //            //出來兩層賦予圖片路徑
            //        }
            //        else
            //        {
            //            ss.Append(html.Replace("[img01]", "../" + dw["Img01"].ToString()).Replace("[text1]", dw["h1"].ToString()).Replace("[text2]", dw["h2"].ToString()) + "\r\n");
            //        }
            //        ss.Append("</div>" + "\r\n");
            //    } 
            //}

 


            //If Directory.Exists(MP) = False Then Directory.CreateDirectory(MP) '沒有資料夾主動建立
            //寫成檔案存成 Encoding.UTF8 避免亂碼 

            if (System.IO.Directory.Exists(Comm.MainPath + "\\Invitation\\") == false)
            {
                System.IO.Directory.CreateDirectory(Comm.MainPath + "\\Invitation\\");
            }

            if (File.Exists(Comm.MainPath + LAppPath) == true)
                File.Delete(Comm.MainPath + LAppPath);

 
            StreamWriter SW = new StreamWriter(Comm.MainPath + LAppPath, false, System.Text.Encoding.UTF8);

            try
            {
                SW.WriteLine(ss.ToString());
                SW.Flush();
                SW.Close();
                Main.ParaClear();
                Main.ParaAdd("@App_URL", Comm.URL + newUrl.Replace("\\", "/"), SqlDbType.NVarChar);
                Main.ParaAdd("@Cardform", Main.Cint2(Request.QueryString["i"].ToString()), SqlDbType.Int);
                Main.NonQuery("Update Wedding_info set App_URL=@App_URL where IDNo=@Cardform ");
            }
            catch (Exception)
            {
                SW.Flush();
                SW.Close();
                throw;
            }
            finally
            {
                SW.Close();
            }
            return AppUrl;
        }
    }
}