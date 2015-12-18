using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


namespace MiniStore
{
    public partial class CreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Form.Action = "https://acqtest.esunbank.com.tw/acq_online/online/sale42.htm";
                MID.Value = "8089011126";
                CID.Value = "";
                TID.Value = "EC000001";//EC000001(一般交易)、EC000002(分期)
                ONO.Value = "0000000000" + "00000000A3"; //不可重複，不可包含【_】字元，且英數限用大寫。
                TA.Value = "7"; //DT.Rows(0).Item("Total");
                U.Value = "http://220.132.67.201/" + "ha/CreditCard_Finish.aspx"; //由特約商店提供銀行端回傳授權結果所需使用的URL，URL 不可包含【#】、【?】及【&】字元。

                string MACKey = "SWQWFWOGA5HKZFUFGPD7RYLYLC0OUWQY";
                M.Value = CMD5(MID.Value + "&" + CID.Value + "&" + TID.Value + "&" + ONO.Value + "&" + TA.Value + "&" + U.Value + "&" + MACKey);

                body.Attributes.Add("onload", "form1.submit()");
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