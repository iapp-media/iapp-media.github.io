using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace Wedding
{
    public partial class Maker : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Comm.Wedding_ID() == -1)
                {
                    Response.Redirect("m-Login.aspx");
                }

                Main.ParaClear();
                Main.ParaAdd("@WID", Comm.Wedding_ID(), System.Data.SqlDbType.Int);
                if (Main.Scalar("select 1 from Wedding_info where Couple_id=@WID") == "")
                {
                    Main.NonQuery("Insert into Wedding_info (Couple_id) values (@WID)");
                }

                Linfo.Text = Main.Scalar("Select IDNo from Wedding_info where Couple_id=@WID");

                loadImg();
                Main.ParaAdd("@infoid", Main.Cint2(Linfo.Text), System.Data.SqlDbType.Int);
                string APPURL = "";
                APPURL = Main.Scalar("select App_URL from Wedding_info where idno=@infoid");
                if (APPURL != "")
                {
                    menu_QR.Text = "<a href=\"" + APPURL + "\" target=\"_blank\" ><img src=\"QRcode.ashx?t=" + APPURL + "\" alt=\"\" class=\"QRcode\"> </a>";
                    L_QR.Text = "<li> <img src=\"QRcode.ashx?t=" + APPURL + "\" alt=\"\">  </li>";
                }
                else
                {
                    menu_QR.Text = "<img src=\"img/p7-qr.jpg\" alt=\"\" class=\"QRcode\">";
                    L_QR.Text = "<li>    <img src=\"img/p7-qr.jpg\" alt=\"\">  </li>";
                }

                L1.Text = " Select Name,Tel,Attendance from wedding_attn where WInfo_ID='" + Linfo.Text + "'";

                L2.Text = " Select Name,Tel,Memo  from Wedding_bless where WInfo_ID='" + Linfo.Text + "'";

                SD1.SelectCommand = L1.Text;
                SD1.ConnectionString = Main.ConnStr;
                RP_attn.DataSourceID = SD1.ID;

                SD2.SelectCommand = L2.Text;
                SD2.ConnectionString = Main.ConnStr;
                RP_bless.DataSourceID = SD2.ID;

            }
            if (Linfo.Text == "")
            {
                Response.Write("<script>alert('系統錯誤')</script>");
            }
        }

        protected void BT_Release_Click(object sender, ImageClickEventArgs e)
        {
            Main.ParaClear();
            Main.ParaAdd("@Couple_id", Comm.Wedding_ID(), System.Data.SqlDbType.Int);
            Main.ParaAdd("@w_plece", TB_plece.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@w_Addr", TB_Addr.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@w_Tel", TB_Tel.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@w_Time", TB_Time.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@w_man", TB_man.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@w_woman", TB_woman.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@w_calender1", TB_calender1.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@w_calender2", TB_calender2.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@w_calender3", TB_calender3.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@map_addr", TB_map_addr.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Traffic_info", TB_Traffic_info.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@p2Memo", TB_p2Memo.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@p3Memo1", TB_p3Memo1.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@p3Memo2", TB_p3Memo2.Text, System.Data.SqlDbType.NVarChar);


            Main.NonQuery("update Wedding_info set w_plece=@w_plece, w_Addr=@w_Addr, w_Tel=@w_Tel, w_Time=@w_Time, w_man=@w_man, w_woman=@w_woman " +
                           " , w_calender1=@w_calender1, w_calender2=@w_calender2, w_calender3=@w_calender3, map_addr=@map_addr, Traffic_info=@Traffic_info " +
                           ", p2Memo=@p2Memo,p3Memo1=@p3Memo1,p3Memo2=@p3Memo2" +
                           " where   Couple_id=@Couple_id ");


        }

        void loadImg()
        {
            StringBuilder ss = new StringBuilder();
            Main.ParaClear();
            Main.ParaAdd("@WID", Comm.Wedding_ID(), System.Data.SqlDbType.Int);
            Main.ParaAdd("@WInfo_ID", Main.Cint2(Linfo.Text), System.Data.SqlDbType.Int);
            string tmpImg = "";
            tmpImg = Main.Scalar("select filepath from Wedding_img where Couple_ID=@WID and Num='1' and WInfo_ID=@WInfo_ID");
            if (tmpImg == "")
            {
                tmpImg = "img/p1-photo.jpg";
            }


            ss.Clear();
            ss.Append("<img id='p01' src=\"" + tmpImg + "\" alt=\"\">" + "\n\r");
            ss.Append("  <div class=\"Uploadimg takeimage1\">\n\r");
            ss.Append("  <label for=\"inputImage\" onclick=\"setCurrent('01'," + Linfo.Text + ",640,435)\">\n\r");
            ss.Append("  <img src=\"img/uploadicon.png\" class=\"clickslider\">\n\r");
            ss.Append("  </label>\n\r");
            ss.Append("  </div>\n\r");
            Lp01.Text = ss.ToString();

            tmpImg = "";
            tmpImg = Main.Scalar("select filepath from Wedding_img where Couple_ID=@WID and Num='2' and WInfo_ID=@WInfo_ID");
            if (tmpImg == "")
            {
                tmpImg = "img/p2-photo2.jpg";
            }
            ss.Clear();
            ss.Append("    <img id='p02' src=\"" + tmpImg + "\" alt=\"\"> " + "\n\r");
            ss.Append("    <div class=\"Uploadimg takeimage1\">" + "\n\r");
            ss.Append("        <label for=\"inputImage\" onclick=\"setCurrent('02'," + Linfo.Text + ",432,650)\"> " + "\n\r");
            ss.Append("            <img src=\"img/uploadicon.png\" class=\"clickslider\"> " + "\n\r");
            ss.Append("        </label> " + "\n\r");
            ss.Append("    </div> " + "\n\r");
            Lp02.Text = ss.ToString();


            //----------page3----------------
            tmpImg = "";
            tmpImg = Main.Scalar("select filepath from Wedding_img where Couple_ID=@WID and Num='3' and WInfo_ID=@WInfo_ID");
            if (tmpImg == "")
            {
                tmpImg = "img/p3-photo1.jpg";
            }
            ss.Clear();

            ss.Append(" <li>  " + "\n\r");
            ss.Append("                    <img id='p03' src=\"" + tmpImg + "\" alt=\"\"> " + "\n\r");
            ss.Append("                    <div class=\"Uploadimg takeimage1\"> " + "\n\r");
            ss.Append("                        <label for=\"inputImage\" onclick=\"setCurrent('03'," + Linfo.Text + ",275,275)\"> " + "\n\r");
            ss.Append("                            <img src=\"img/uploadicon.png\" class=\"clickslider\"> " + "\n\r");
            ss.Append("                        </label> " + "\n\r");
            ss.Append("                    </div> " + "\n\r");
            ss.Append("                </li> " + "\n\r");
            ss.Append("                <li> " + "\n\r"); 
            tmpImg = "";
            tmpImg = Main.Scalar("select filepath from Wedding_img where Couple_ID=@WID and Num='4' and WInfo_ID=@WInfo_ID");
            if (tmpImg == "")
            {
                tmpImg = "img/p3-photo2.jpg";
            }
            ss.Append("                    <img id='p04' src=\"" + tmpImg + "\" alt=\"\"> " + "\n\r");
            ss.Append("                    <div class=\"Uploadimg takeimage1\"> " + "\n\r");
            ss.Append("                        <label for=\"inputImage\" onclick=\"setCurrent('04'," + Linfo.Text + ",276,317)\"> " + "\n\r");
            ss.Append("                            <img src=\"img/uploadicon.png\" class=\"clickslider\"> " + "\n\r");
            ss.Append("                        </label> " + "\n\r");
            ss.Append("                    </div> " + "\n\r");
            ss.Append("                </li> " + "\n\r");
            ss.Append("                <li> " + "\n\r"); 
            tmpImg = "";
            tmpImg = Main.Scalar("select filepath from Wedding_img where Couple_ID=@WID and Num='5' and WInfo_ID=@WInfo_ID");
            if (tmpImg == "")
            {
                tmpImg = "img/p3-photo3.jpg";
            }
            ss.Append("                    <img id='p05' src=\"" + tmpImg + "\" alt=\"\"> " + "\n\r");
            ss.Append("                    <div class=\"Uploadimg takeimage1\"> " + "\n\r");
            ss.Append("                        <label for=\"inputImage\" onclick=\"setCurrent('05'," + Linfo.Text + ",300,200)\"> " + "\n\r");
            ss.Append("                            <img src=\"img/uploadicon.png\" class=\"clickslider\"> " + "\n\r");
            ss.Append("                        </label> " + "\n\r");
            ss.Append("                    </div> " + "\n\r");
            ss.Append("                </li> " + "\n\r");
            ss.Append("                <li> " + "\n\r"); 
            tmpImg = "";
            tmpImg = Main.Scalar("select filepath from Wedding_img where Couple_ID=@WID and Num='6' and WInfo_ID=@WInfo_ID");
            if (tmpImg == "")
            {
                tmpImg = "img/p3-photo4.jpg";
            }
            ss.Append("                    <img id='p06' src=\"" + tmpImg + "\" alt=\"\"> " + "\n\r");
            ss.Append("                    <div class=\"Uploadimg takeimage1\"> " + "\n\r");
            ss.Append("                        <label for=\"inputImage\" onclick=\"setCurrent('06'," + Linfo.Text + ",300,200)\"> " + "\n\r");
            ss.Append("                            <img src=\"img/uploadicon.png\" class=\"clickslider\"> " + "\n\r");
            ss.Append("                        </label> " + "\n\r");
            ss.Append("                    </div> " + "\n\r");
            ss.Append("                </li> " + "\n\r");
            ss.Append("                <li> " + "\n\r"); 
            tmpImg = "";
            tmpImg = Main.Scalar("select filepath from Wedding_img where Couple_ID=@WID and Num='7' and WInfo_ID=@WInfo_ID");
            if (tmpImg == "")
            {
                tmpImg = "img/p3-photo5.jpg";
            }
            ss.Append("                    <img id='p07' src=\"" + tmpImg + "\" alt=\"\"> " + "\n\r");
            ss.Append("                    <div class=\"Uploadimg takeimage1\"> " + "\n\r");
            ss.Append("                        <label for=\"inputImage\" onclick=\"setCurrent('07'," + Linfo.Text + ",300,200)\"> " + "\n\r");
            ss.Append("                            <img src=\"img/uploadicon.png\" class=\"clickslider\"> " + "\n\r");
            ss.Append("                        </label> " + "\n\r");
            ss.Append("                    </div> " + "\n\r");
            ss.Append("                </li> " + "\n\r");
            Lp03.Text = ss.ToString();


            //----------page5----------------
            ss.Clear(); 
            for (int i = 8; i < 14; i++)
            {
                tmpImg = "";
                tmpImg = Main.Scalar("select filepath from Wedding_img where Couple_ID=@WID and Num='" + i + "' and WInfo_ID=@WInfo_ID");
                if (tmpImg == "")
                {
                    tmpImg = "img/p5-photo1.jpg";
                }
                ss.Append("                <li> " + "\n\r");
                ss.Append("                    <a href=\"javascript:void(0)\" class=\"Button Block\"> " + "\n\r");
                ss.Append("                        <img id='p" + i.ToString().PadLeft(2, '0') + "' src=\"" + tmpImg + "\" alt=\"\"> " + "\n\r");
                ss.Append("                        <div class=\"Uploadimg takeimage1\"> " + "\n\r");
                ss.Append("                            <label for=\"inputImage\" onclick=\"setCurrent('" + i.ToString().PadLeft(2, '0') + "'," + Linfo.Text + ",435,650)\"> " + "\n\r");
                ss.Append("                                <img src=\"img/uploadicon.png\" class=\"clickslider\"> " + "\n\r");
                ss.Append("                            </label> " + "\n\r");
                ss.Append("                        </div> " + "\n\r");
                ss.Append("                    </a> " + "\n\r");
                ss.Append("                </li> " + "\n\r"); 
            }
            
            Lp05.Text = ss.ToString();

            ss.Clear();


            Main.ParaClear();
            Main.ParaAdd("@Couple_id", Comm.Wedding_ID(), System.Data.SqlDbType.Int);
            DataTable DT = Main.GetDataSetNoNull("select * from Wedding_info where Couple_id=@Couple_id");
            if (DT.Rows.Count > 0)
            {
                TB_plece.Text = DT.Rows[0]["w_plece"].ToString();
                TB_Addr.Text = DT.Rows[0]["w_Addr"].ToString();
                TB_Tel.Text = DT.Rows[0]["w_Tel"].ToString();
                TB_Time.Text = DT.Rows[0]["w_Time"].ToString();
                TB_man.Text = DT.Rows[0]["w_man"].ToString();
                TB_woman.Text = DT.Rows[0]["w_woman"].ToString();
                TB_calender1.Text = DT.Rows[0]["w_calender1"].ToString();
                TB_calender2.Text = DT.Rows[0]["w_calender2"].ToString();
                TB_calender3.Text = DT.Rows[0]["w_calender3"].ToString();
                TB_map_addr.Text = DT.Rows[0]["map_addr"].ToString();
                TB_Traffic_info.Text = DT.Rows[0]["Traffic_info"].ToString();
            }

            //   L_map.Text = "<iframe class=\"map\" name=\"iframemap\" src=\"https://www.google.com.tw/maps/place/" + TB_map_addr.Text + "\"></iframe>";
        }
    }
}