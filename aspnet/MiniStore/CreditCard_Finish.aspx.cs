using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

namespace MiniStore
{
    public partial class CreditCard_Finish : System.Web.UI.Page
    {
        JDB Main = new JDB();
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                string CCIDNo = "";
                //Dim MACKey As String = "KOPO9UUYFUCXCVHRKKE3X17CJAO0NGWY"     '配上我們丟上去的KEY 
                string MACKey = "EEIF63Y8WECUQTTN10Z2WKOVKHJBOCVO";
                //配上我們丟上去的KEY 
                string FromURL = "http://www.nlac.org.tw/";
                string Status = "";

                if ((Request.QueryString["RC"] != null))
                {
                    LRC.Text = Request.QueryString["RC"];
                    LMID.Text = Request.QueryString["MID"];
                    LONO.Text = Request.QueryString["ONO"];


                    if ((Request.QueryString["M"] != null))
                    {
                        LLTD.Text = Request.QueryString["LTD"];
                        LLTT.Text = Request.QueryString["LTT"];
                        LRRN.Text = Request.QueryString["RRN"];
                        LAIR.Text = Request.QueryString["AIR"];
                        LAN.Text = Request.QueryString["AN"];
                        LM2.Text = Request.QueryString["M"];


                        string MD5 = LRC.Text.Trim() + "&" + LMID.Text.Trim() + "&" + LONO.Text.Trim() + "&" + LLTD.Text.Trim() + "&" + LLTT.Text.Trim() + "&" + LRRN.Text.Trim() + "&" + LAIR.Text.Trim() + "&" + LAN.Text.Trim() + "&" + MACKey;
                        LM2_chk.Text = CMD5(MD5);

                        //00才算交易成功
                        if (LRC.Text == "00")
                        {
                            Status = "交易成功";
                        }
                        else
                        {
                            Status = "交易失敗";
                        }

                        //?RC=00&MID=8089002415&ONO=128522332211222224&LTD=20140410&LTT=134518&RRN=144100000002&AIR=097196&AN=439237******0561&M=f7120be1e207b0454786521a7fbe60c3
                    }
                    else
                    {
                        Status = "交易失敗";
                    }



                    DataTable DT = Main.GetDataSetNoNull("select IDNo,MACKEY,FromURL,Bill_ID,modu from Credit_Card where MID='" + LMID.Text + "' and ONO='" + LONO.Text + "'");
                    if (DT.Rows.Count > 0)
                    {
                        CCIDNo = DT.Rows[0]["IDNo"].ToString();
                        MACKey = DT.Rows[0]["MACKEY"].ToString();
                        FromURL = DT.Rows[0]["FromURL"].ToString();

                        str = "update Credit_Card set RC_Creat_Date=getdate(),RC='" + LRC.Text + "',LTD='" + LLTD.Text + "',LTT='" + LLTT.Text + "',RRN='" + LRRN.Text + "',AIR='" + LAIR.Text + "',AN='" + LAN.Text + "',M2='" + LM2.Text + "',M2_chk='" + LM2_chk.Text + "',Status='" + Status + "' where IDNo=" + CCIDNo + "; ";


                        if (Status == "交易成功")
                        {
                            switch (DT.Rows[0]["modu"].ToString())
                            {

                                case "SignUp":
                                 //   str += "update Sign_User set Status='已登錄繳費資訊',Credit_Card='" + LAN.Text + "',Card_No='" + Strings.Right(LAN.Text, 4) + "' where IDNo=" + DT.Rows(0).Item("Bill_ID");

                                    break;
                            }
                        }

                        Main.NonQuery(str);

                    }
                    else
                    {
                        str = "insert into Credit_Card (MID,ONO,RC_Creat_Date,RC,LTD,LTT,RRN,AIR,AN,M2,M2_chk) values" + " ('" + LMID.Text + "','" + LONO.Text + "',getdate(),'" + LRC.Text + "','" + LLTD.Text + "','" + LLTT.Text + "','" + LRRN.Text + "','" + LAIR.Text + "','" + LAN.Text + "','" + LM2.Text + "','" + LM2_chk.Text + "'); ";
                        Main.NonQuery(str);
                    }



                    if (Status == "交易成功")
                    {
                        //Send Email?
                       // Comm.SendMail(Comm.MailFrom, "afh@nlac.narl.org.tw", "動物中心-信用卡交易成功", LONO.Text + "信用卡交易成功<br><br>請至系統檢查");
                    }

                    if (Session["Order_Url"] != null)
                    {
                        string turl = Session["Order_Url"].ToString();
                        Session.Remove("Order_Url");
                        Response.Redirect(turl);
                    }
                    

                   // this.ClientScript.RegisterStartupScript(this.GetType, "key", "alert('" + Status + "');top.location.href='" + FromURL + "'", true);
                }
                else
                {
                    //交易失敗
                    //this.ClientScript.RegisterStartupScript(this.GetType, "key", "alert('交易失敗，請重新操作或聯絡我們');top.location.href='" + FromURL + "'", true);
                }
            }
        }
        public string CMD5(string txt)
        {
            //using System.Web.Security 

            string Hash = FormsAuthentication.HashPasswordForStoringInConfigFile(txt, "MD5");

            return Hash.ToLower();
        }

    }
}