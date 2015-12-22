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
    public partial class CreditCard : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["OrderID"] != null)
                {
                    DataTable DT = Main.GetDataSetNoNull("Select Order_No,Total_AMT,(select Store_NID from Store where IDNo=Store_ID) SN from Orders where IDNo='" + Session["OrderID"] + "'");
                    if (DT.Rows.Count > 0)
                    {

                        Main.NonQuery("insert into Credit_Card (Customer_ID,Creat_Date,Order_no,Status) values ('" + Comm.User_ID() + "',getdate(),'" + DT.Rows[0]["Order_No"].ToString() + "','-99')");

                        string CreditNo = Main.Scalar("select max(idno) from Credit_Card where Customer_ID='" + Comm.User_ID() + "' and Order_no='" + DT.Rows[0]["Order_No"].ToString() + "' and Status='-99'");
                        //前輩說他們回傳可能會漏 所以此做session確保
                        Session["CreditNo"] = CreditNo;
                        Form.Action = "https://acqtest.esunbank.com.tw/acq_online/online/sale42.htm";
                        MID.Value = "8089011126";
                        CID.Value = "";
                        TID.Value = "EC000001";//EC000001(一般交易)、EC000002(分期)
                        ONO.Value = CreditNo.PadLeft(20, '0'); //.PadLeft(20, '0')不可重複，不可包含【_】字元，且英數限用大寫 length 20。
                        TA.Value = DT.Rows[0]["Total_AMT"].ToString();
                        U.Value = "http://220.132.67.201:88/ministore/CreditCard_Finish.aspx"; //由特約商店提供銀行端回傳授權結果所需使用的URL，URL 不可包含【#】、【?】及【&】字元。
                        string MACKey = "SWQWFWOGA5HKZFUFGPD7RYLYLC0OUWQY";
                        M.Value = CMD5(MID.Value + "&" + CID.Value + "&" + TID.Value + "&" + ONO.Value + "&" + TA.Value + "&" + U.Value + "&" + MACKey);

                        body.Attributes.Add("onload", "form1.submit()");
                    } 
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