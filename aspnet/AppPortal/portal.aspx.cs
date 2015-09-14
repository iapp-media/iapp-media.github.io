using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace AppPortal
{
    public partial class portal : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str   = "";
        string url = "http://www.iapp-media.com/";
        string sql = "";
        string DefaultAppId = "144";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["fn"] == "my" || Request.QueryString["fn"] == "fv")
                {
                    if (Comm.ChkLoginStat())
                    {
                        Panel1.Visible = true;
                        Panel2.Visible = true;
                    }
                    else
                    {
                        Response.Redirect("portal.aspx");
                        return;
                    }
                } 

                ChkandBinding();
            }

        }

      
        void ChkandBinding()
        {
            JSS.Text = "";
            string loginUrl = "../Login/Login.aspx?done=" + HttpUtility.UrlEncode(Request.RawUrl) + "&open=_top";

            string Tm = "basic";
            if (Comm.IsNumeric(Request.QueryString["t"]))
            {
                Tm = Main.Scalar("Select foderName from Theme where IDNo=" + Request.QueryString["t"]);
                DefaultAppId = Main.Scalar("select DefaultAppId from Theme where IDNo=" + Request.QueryString["t"]);
            }

            if (Comm.Cint2(Request.QueryString["p"]) < 1)
            {
                if (Comm.CheckMobile() == false)
                {
                    Tile1.Text = "<div class='item'>\n\r" +
                                 "   <div class='imgcenter'>\n\r" +
                                 "      <div><a href=\"../" + Tm + "/Default.aspx\"><img class=\"item-pic\" src='img/defaultimg.jpg'/></a></div>\n\r" +
                                 "      <p class=\"tile1\"><a href=\"../" + Tm + "/Default.aspx\">微創作</a></p>" + "\n\r" + 
                                 "   </div>\n\r" +
                                 " </div>\n\r";
                }
                else
                {
                    Tile1.Text = "<div class='item'>\n\r" +
                                 "   <div class='imgcenter'>\n\r" +
                                 "      <div><a href=\"../" + Tm + "/Apps/me/capp.aspx?i=" + DefaultAppId + "\"><img class=\"item-pic\" src='img/defaultimg.jpg'/></a></div>\n\r" +
                                 "   <p class='tile1'><a href=\"../" + Tm + "/Apps/me/capp.aspx?i=" + DefaultAppId + "\">微創作</a></p>" + "\n\r" + 
                                 "   </div>\n\r" +
                                 " </div>\n\r";
                }
            }
            if (Comm.ChkLoginStat() == false)
            {
                MLogin.Text = "<button type=\"button\" id=\"m-login\" class=\"btn btn-default search2\" data-toggle=\"dropdown\" aria-expanded=\"false\">" +
                              "<a href=\"" + loginUrl + "\"><span class=\"glyphicon glyphicon-user\" aria-hidden=\"true\"></span></a></button>";
                //MLogin.Text = "<button type=\"button\" id=\"m-login\" class=\"btn btn-default search2\" data-toggle=\"dropdown\" aria-expanded=\"false\">" +
                //                          "<img class=\"circle-login\" src=\"UserIcon.ashx?i=" + Comm.User_ID() + "\" ></button>";
          
                LLogin.Text = "<div class=\"col-sm-2 col-md-1 login-box\">" +
                              "   <a class='iframe-info' href=\"" + loginUrl + "\">" +
                              "     <button type=\"button\" class=\"btn btn-default navbar-btn1\">" +
                              "         登入／註冊" +
                              "     </button>" +
                              "   </a>" +
                              "</div>";
                LDoIt.Text = "   <a class='iframe-info' href=\"" + loginUrl + "\">" +
                             "     <button type=\"button\" class=\"btn btn-default navbar-btn2\">" +
                             "         微創作" + 
                             "     </button>" +
                             "   </a>";
                //    <button type="button" class="btn btn-default navbar-btn2" >
                //        <h4 class="title">微創作
                //    <span class="glyphicon glyphicon glyphicon glyphicon-hand-right" aria-hidden="true"></span>
                //</button>  
            }
            else
            {
                MLogin.Text = "<button type=\"button\" onclick=\"toggleMy();\" id=\"user-login\" class=\"btn btn-default search2\" data-toggle=\"dropdown\" aria-expanded=\"false\">" +
                              "<img class=\"circle-login\" src=\"UserIcon.ashx?i=" + Comm.User_ID() + "\" ></button>";
                //MLogin.Text=" <div class=\"col-sm-2 col-md-1 loginHead\">" + 
                //             "<img src=\"UserIcon.ashx?i=" + Comm.User_ID() + "\" alt=\"\"></div>";

                LLogin.Text = "<div class=\"col-sm-2 col-md-1 icon-box\">\n\r" +
                             "  <img class=\"usericon\" src=\"UserIcon.ashx?i=" + Comm.User_ID() + "\">\n\r" +
                             "  <div class=\"username-icon\"><h4>" + Comm.User_Name() + "</h4></div>\n\r" +
                            " </div>\n\r";
                //JSS.Text = "<script>$('.icon-box').addClass('openlogin');$('#m-login').show();$('#m-login').addClass('openlogin');</script>";
                LDoIt.Text = "   <a href=\"../" + Tm + "/Default.aspx\">" +
                             "     <button type=\"button\" class=\"btn btn-default navbar-btn2\">" +
                             "         <h4 class=\"title\">微創作" +
                             "         <span class=\"glyphicon glyphicon-chevron-right\" aria-hidden=\"true\"></span>" +
                             "     </button>" +
                             "   </a>";

                //$.colorbox({href:"thankyou.html"});
                //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "shoow", "$('.icon-box').show();", true);
            }

            theme_li();
            GetDataList();
        }

        public void theme_li()
        {
            StringBuilder ss = new StringBuilder(); 
            sql = "Select IDNo,Theme_Name from Theme";
            System.Data.DataTable dr = Main.GetDataSet(sql);
            ss.Append("<li><a href=\"portal.aspx\">最熱門</a></li>" + "\n\r");
            ss.Append("<li><a href=\"portal.aspx?so=new\">最新進</a></li>" + "\n\r");
        
            if (dr.Rows.Count > 0)
            {
                for (int i = 0; i < dr.Rows.Count; i++)
                {
                    ss.Append("<li><a href=\"portal.aspx?t=" + dr.Rows[i]["IDNo"].ToString() + "\">" + dr.Rows[i]["Theme_Name"].ToString() + "</a></li>" + "\n");
                }
                ThemeLi.Text = ss.ToString();
            }
            ss.Clear();
        }

        protected void Search_TextChanged1(object sender, EventArgs e)
        {
            GetDataList();
        }

        void GetDataList()
        {
            int PageSize = 12;
            int Currpage = 1;
            if (Comm.IsNumeric(Request.QueryString["p"])) { Currpage = Comm.Cint2(Request.QueryString["p"]); }
            HL1.NavigateUrl = "portal.aspx?p=" + (Currpage + 1).ToString();

            StringBuilder ss = new StringBuilder(); 
            //sql = "select b.IDNo, a.Img01,c.FoderName,d.User_Name,b.App_Name,b.App_URL from User_Page a " +
            //      " inner join User_App b on a.User_App_ID=b.IDNo inner join Theme c on b.Theme_ID=c.IDNo " +
            //      " inner join Users d on b.User_ID=d.IDNo where sort=1";
            //sql = "Select a.*,c.FoderName, b.User_Name from User_App a inner join Users b on a.User_ID=b.IDNo " +
            //      "   inner join Theme c on a.Theme_ID=c.IDNo where IsPosted=1 ";

            string SortCols = "HotValue";
            if (Request.QueryString["so"] == "new") { SortCols = "Last_Update"; }

            sql = "";
            Main.ParaClear();
            Main.ParaAdd("@MyID", Comm.User_ID(), SqlDbType.Int);
            if (Comm.IsNumeric(Request.QueryString["t"]) == true)   //切換不同主題
            {
                sql += "  and c.IDNo=@ThemeID";
                HL1.NavigateUrl += "&t=" + Request.QueryString["t"];
                Main.ParaAdd("@ThemeID", Request.QueryString["t"], SqlDbType.Int); 
            }
            if (Comm.IsNumeric(Request.QueryString["u"]) == true)   //切換不同主題
            {
                sql += "  and a.User_ID=@UserID";
                HL1.NavigateUrl += "&u=" + Request.QueryString["u"];
                Main.ParaAdd("@UserID", Request.QueryString["u"], SqlDbType.Int);
                JSS.Text += "\n\r<script>$('.jumbotron').show();</script>";
                ImgUser2.ImageUrl = "UserIcon.ashx?i=" + Request.QueryString["u"];
            }
            else
            {
                ImgUser2.ImageUrl = "UserIcon.ashx?i=" + Comm.User_ID().ToString();
            }
            if (Request.QueryString["w"] != null)               //關鍵字
            {
                sql += " and (App_Name Like @KW or App_Memo like @KW or User_Name like  @KW)  ";
                HL1.NavigateUrl += "&t=" + Request.QueryString["w"];
                Main.ParaAdd("@KW", "%" + HttpUtility.UrlDecode(Request.QueryString["w"]) + "%", SqlDbType.NVarChar);
            }
           // sql += "  order by a.Last_Update desc";

            string sql3 = ",(Select Count(1) from User_App_Good where User_App_ID=AA.IDNo) as GDs " +
                          ",(Select Count(1) from User_App_Good where User_App_ID=AA.IDNo and User_ID=@MyID) as iGD " +
                          ",(Select Count(1) from User_App_Like where User_App_ID=AA.IDNo) as LKs " +
                          ",(Select Count(1) from User_App_Like where User_App_ID=AA.IDNo and User_ID=@MyID) as iLK " +
                          ",(Select Count(1) from User_App_Favor where User_App_ID=AA.IDNo and User_ID=@MyID) as iFV "; 

            str = "Select * " + sql3 + " from (" +
                      "    Select rank() OVER (ORDER BY " + SortCols + " Desc) AS RankNumber, a.* " +
                      "      ,c.FoderName, b.User_Name from User_App a inner join Users b on a.User_ID=b.IDNo " +
                      "        inner join Theme c on a.Theme_ID=c.IDNo where IsPosted=1 " + sql +
                      ") as AA where RankNumber between " + (PageSize * (Currpage - 1)) + " and " + (PageSize * Currpage);

            if (Request.QueryString["fn"] == "my" && Comm.ChkLoginStat() == true)
            {
                str = "Select * " + sql3 + " from (" +
                          "    Select rank() OVER (ORDER BY " + SortCols + " Desc) AS RankNumber, a.* " +
                          "      ,c.FoderName, b.User_Name from User_App a inner join Users b on a.User_ID=b.IDNo " +
                          "        inner join Theme c on a.Theme_ID=c.IDNo where IsPosted=1 and a.User_ID=" + Comm.User_ID().ToString() +
                          ") as AA where RankNumber between " + (PageSize * (Currpage - 1)) + " and " + (PageSize * Currpage);
                JSS.Text += "\n\r<script>$('.jumbotron').show();</script>";
                HL1.NavigateUrl += "&u=" + Request.QueryString["u"];
                sql = " and a.User_ID=" + Comm.User_ID().ToString();
            }

            if (Request.QueryString["fn"] == "fv" && Comm.ChkLoginStat() == true)
            {
                str = "Select * " + sql3 + " from (" +
                          "    Select rank() OVER (ORDER BY " + SortCols + " Desc) AS RankNumber, a.* " +
                          "      ,c.FoderName, b.User_Name from User_App a inner join Users b on a.User_ID=b.IDNo " +
                          "        inner join Theme c on a.Theme_ID=c.IDNo where IsPosted=1 " +
                          "          and a.IDNo in (Select User_App_ID from User_App_Favor where User_ID=" + Comm.User_ID().ToString() + ")" +
                          ") as AA where RankNumber between " + (PageSize * (Currpage - 1)) + " and " + (PageSize * Currpage);

                JSS.Text += "\n\r<script>$('.jumbotron').show();</script>";
                sql = "  and a.IDNo in (Select User_App_ID from User_App_Favor where User_ID=" + Comm.User_ID().ToString() + ")";
            }

            string sql2 = "Select Count(1) from User_App a inner join Users b on a.User_ID=b.IDNo " +
                          "        inner join Theme c on a.Theme_ID=c.IDNo where IsPosted=1 " + sql;
            if (Comm.Cint2(Main.Scalar(sql2)) <= (PageSize * Currpage)) { HL1.NavigateUrl = ""; }

           // Response.Write(str);

            DataTable dr = Main.GetDataSet(str);         
            if (dr.Rows.Count > 0)
            {
                for (int i = 0; i < dr.Rows.Count; i++)
                {
                    DataRow dw = dr.Rows[i];
                    string src = url + dr.Rows[i]["FoderName"] + "/Apps/";// +dw["Img01"];
                    string iGD = "";
                    string iLK = "";
                    string iFV = "";
                    if (Comm.Cint2(dw["iGD"].ToString()) > 0) { iGD = " checked"; }
                    if (Comm.Cint2(dw["iLK"].ToString()) > 0) { iLK = " checked"; }
                    if (Comm.Cint2(dw["iFV"].ToString()) > 0) { iFV = " checked"; }

                    if (!string.IsNullOrEmpty(dw["App_Cover"].ToString()))
                    {
                        src = url + dr.Rows[i]["FoderName"] + "/Apps/" + dw["App_Folder"] + "/pic/" + dw["App_Cover"];
                    }
                    else
                    {
                        src = "img/p00.jpg";
                    }
                    if (Comm.CheckMobile() == false)
                    {

                        ss.Append("<div class='item'>" + "\n\r");
                        ss.Append("   <div class='imgcenter'>\n\r");
                        ss.Append("     <div>" + "\n\r");
                        ss.Append("       <a class='apps-info' href=\"" + url + dr.Rows[i]["FoderName"] + "/" + dw["IDNo"] + "\"><img class=\"item-pic\" src='" + src + "'/></a>" + "\n\r");

                        doListItem(ref ss, iLK, iGD, iFV, dw);

                        ss.Append("   </div>\n\r");

                        ss.Append("   <p class='describe'>" + dw["App_Memo"] + "</p>" + "\n\r");
                        ss.Append("   <img class=\"circle\" src=\"UserIcon.ashx?i=" + dw["User_ID"] + "\" >" + "\n");
                        ss.Append("   <p class='iapp-name'><a href='" + url + dr.Rows[i]["FoderName"] + "' class='apps-info'>" + dw["App_Name"] + "</a></p>" + "\n\r");
                        ss.Append("   <p class='author'>by <a href='portal.aspx?u=" + dw["User_ID"] + "'>" + dw["User_Name"] + "</a></p>" + "\n\r");
                        ss.Append(" </div>" + "\n");
                        ss.Append("</div>" + "\n"); 
                    }
                    else
                    {  
                        ss.Append("<div class='item'>" + "\n\r");
                        ss.Append("   <div class='imgcenter'>\n\r");
                        ss.Append("     <div>" + "\n\r");
                        ss.Append("       <a class='#' href=\"mPrev.aspx?i=" + dw["IDNo"] + "\"><img class=\"item-pic\" src='" + src + "'/></a>" + "\n\r");

                        doListItem(ref ss, iLK, iGD, iFV, dw);

                        ss.Append("   </div>\n\r");

                        ss.Append("   <p class='describe'>" + dw["App_Memo"] + "</p>" + "\n\r");
                        ss.Append("   <img class=\"circle\" src=\"UserIcon.ashx?i=" + dw["User_ID"] + "\" >" + "\n");
                        ss.Append("   <p class='iapp-name'><a href='mPrev.aspx?i=" + dw["IDNo"] + "'>" + dw["App_Name"] + "</a></p>" + "\n\r");
                        ss.Append("   <p class='author'>by <a href='portal.aspx?u=" + dw["User_ID"] + "'>" + dw["User_Name"] + "</a></p>" + "\n\r");
                        ss.Append(" </div>" + "\n");
                        ss.Append("</div>" + "\n");
                    }

            
                }
            }
            else
            {
                ss.Clear();
            }
            L.Text = ss.ToString();
        }

        void doListItem(ref StringBuilder ss, string iLK, string iGD, string iFV, DataRow dw)
        {
            ss.Append("<div class=\"item-bar\">\n\r");
            ss.Append("    <section class=\"content\">\n\r");
            ss.Append("        <ul class=\"list\">\n\r");
            ss.Append("            <li class=\"list__item\">\n\r");
            ss.Append("                <label class=\"label--checkbox\">\n\r");
            ss.Append("                    <input type=\"checkbox\" class=\"good\" onclick=\"goodit(this)\" id=\"g" + dw["IDNo"].ToString() + "\" " + iGD + "> <p id=\"gn" + dw["IDNo"].ToString() + "\">" + dw["GDs"] + "</p>\n\r");
            ss.Append("                </label>\n\r");
            ss.Append("            </li>\n\r");
            ss.Append("            <li class=\"list__item\">\n\r");
            ss.Append("                <label class=\"label--checkbox\">\n\r");
            ss.Append("                    <input type=\"checkbox\" class=\"like\" onclick=\"likeit(this)\" id=\"k" + dw["IDNo"].ToString() + "\" " + iLK + "><p id=\"kn" + dw["IDNo"].ToString() + "\">" + dw["LKs"] + "</p>\n\r");
            ss.Append("                </label>\n\r");
            ss.Append("            </li>\n\r");
            ss.Append("           <li class=\"list__item\">\n\r");
            ss.Append("                <label class=\"label--checkbox\">\n\r");

            ss.Append("                    <input type=\"checkbox\" class=\"startoggle\" onclick=\"starit(this)\" id=\"s" + dw["IDNo"].ToString() + "\" " + iFV + "> \n\r");
            ss.Append("                </label>\n\r");
            ss.Append("            </li>\n\r");
            ss.Append("        </ul>\n\r");
            ss.Append("    </section>\n\r");
            ss.Append("</div>\n\r");
        }

        protected void LBLogout_Click(object sender, EventArgs e)
        { 
            Comm.DeleCoookie("iapp_uid");
            Comm.DeleCoookie("iapp_uname");
            Comm.DeleCoookie("iapp_fbId");
            Response.Redirect(Request.RawUrl);
        }

        protected void LBmym_Click(object sender, EventArgs e)
        { 
            if (Comm.ChkLoginStat() == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "shoow", "$.colorbox({href:'../Login/Login.aspx?done=" + HttpUtility.UrlEncode("../portal/portal.aspx?fn=my") + "&open=_top'});", true);
            }
            else
            {
                Response.Redirect("portal.aspx?fn=my");
            }
        }

        protected void LBfvm_Click(object sender, EventArgs e)
        {
            if (Comm.ChkLoginStat() == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "shoow", "$.colorbox({href:'../Login/Login.aspx?done=" + HttpUtility.UrlEncode("../portal/portal.aspx?fn=fv") + "&open=_top'});", true);
            }
            else
            {
                Response.Redirect("portal.aspx?fn=fv");
            }
        }


    }
}