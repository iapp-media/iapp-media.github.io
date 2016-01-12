using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store_DoUnionPay : System.Web.UI.Page
{
    string SID = "";
    //交易類別 01 消費 04 退貨 31 取消(限消費當日23:00 前交易) 00 查詢
    string URL = "http://220.132.67.201:88/";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SID = TBSID.Text;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string strOrderID = TextBox1.Text;
        string IsChBonus = "0";
        Session["UpayID"] = "04"; 
        //Bonusval 沒用到?
        Session["Bonusval"] = IsChBonus + "," + SID + ",0," + strOrderID + "," + "0";
        Session["Order_Url"] = URL + "Manager/store/dounionpay.aspx?entry=" + strOrderID + "";
        Session["OrderID"] = strOrderID;
        Response.Redirect(URL + "Act/Store/Unionpay.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string strOrderID = TextBox2.Text;
        string IsChBonus = "0";
        Session["UpayID"] = "31"; 
        //Bonusval 沒用到?
        Session["Bonusval"] = IsChBonus + "," + SID + ",0," + strOrderID + "," + "0";
        Session["Order_Url"] = URL + "Manager/store/dounionpay.aspx?entry=" + strOrderID + "";
        Session["OrderID"] = strOrderID;
        Response.Redirect(URL + "Act/Store/Unionpay.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    { 
        string strOrderID = TextBox3.Text;
        string IsChBonus = "0";
        Session["UpayID"] = "00"; 
        //Bonusval 沒用到?
        Session["Bonusval"] = IsChBonus + "," + SID + ",0," + strOrderID + "," + "0";
        Session["Order_Url"] = URL + "Manager/store/dounionpay.aspx?entry=" + strOrderID + "";
        Session["OrderID"] = strOrderID;
        Response.Redirect(URL + "Act/Store/Unionpay.aspx");
    }
}