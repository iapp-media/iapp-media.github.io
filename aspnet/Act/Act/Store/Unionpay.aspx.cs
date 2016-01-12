using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

namespace Act.Store
{
    public partial class Unionpay : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                    // Form.Action = "https://acq.esunbank.com.tw/acq_online/online/sale61.htm";  //正式
                    Form.Action = "https://acqtest.esunbank.com.tw/acq_online/online/sale61.htm"; //測試
                    string CreditNo = "ABC001";
                    //特店代碼
                    MID.Value = "8089011126";
                    //子特店代號
                    CID.Value = "";
                    //訂單編號
                    ONO.Value = CreditNo.PadLeft(20, '0'); //.PadLeft(20, '0')不可重複，不可包含【_】字元，且英數限用大寫 length 20。
                    //交易金額   
                    TA.Value = "10";
                    //交易類別 01 消費 04 退貨 31 取消(限消費當日23:00 前交易) 00 查詢
                    TT.Value = "01";
                    //URL 
                    U.Value = Comm.URL + "/Act/Unionpay_Finish.aspx.aspx"; //由特約商店提供銀行端回傳授權結果所需使用的URL，URL 不可包含【#】、【?】及【&】字元。
                    //交易序號 
                    TXNNO.Value = "";

                    //押碼 
                    string MACKey = "SWQWFWOGA5HKZFUFGPD7RYLYLC0OUWQY";
                    M.Value = CMD5(MID.Value + "&" + CID.Value + "&" + ONO.Value + "&" + TA.Value + "&" + TT.Value + "&" + U.Value + "&" + TXNNO.Value + "&" + MACKey);

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