﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StoreMana
{
    public partial class Setting_SInfo : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string strACC = "", strACName = "", strBankName = "", strBankNo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Main.FillDDP(CB_Payment, "select Status,Memo from def_Status where Col_Name='Payment'", "Memo", "Status");
                Main.FillDDP(CB_Delivery, "select Status,Memo from def_Status where Col_Name='Delivery'", "Memo", "Status");
                TBStoreNID.Text = Main.Scalar("select Store_NID from store where idno='" + Comm.Store_ID() + "'");
                DataTable DT = Main.GetDataSetNoNull("select * from Store_info where Store_ID='" + Comm.Store_ID() + "'");
                if (DT.Rows.Count > 0)
                {
                    string[] listPayment = DT.Rows[0]["Payment"].ToString().Substring(1).Split(',');
                    for (int i = 0; i < Main.Cint2(listPayment.Length.ToString()); i++)
                    {
                        Comm.GetDDL(CB_Payment, listPayment[i]);
                    }
                    string[] listDelivery = DT.Rows[0]["Delivery"].ToString().Substring(1).Split(',');
                    for (int i = 0; i < Main.Cint2(listDelivery.Length.ToString()); i++)
                    {
                        Comm.GetDDL(CB_Delivery, listDelivery[i]);
                    }
                    TBName.Text = DT.Rows[0]["Store_Name"].ToString();
                    TBBankName.Text = DT.Rows[0]["Bank_Name"].ToString();
                    TBBankNo.Text = DT.Rows[0]["Bank_No"].ToString();
                    TBACC.Text = DT.Rows[0]["Bank_ACC"].ToString();
                    TBACName.Text = DT.Rows[0]["Bank_ACName"].ToString();
                    TBAddr.Text = DT.Rows[0]["Addr"].ToString();
                    TBTEL.Text = DT.Rows[0]["TEL"].ToString();
                    TBCEO.Text = DT.Rows[0]["CEOName"].ToString();


                    strBankName = DT.Rows[0]["Bank_Name"].ToString();
                    strBankNo = DT.Rows[0]["Bank_No"].ToString();
                    strACC = DT.Rows[0]["Bank_ACC"].ToString();
                    strACName = DT.Rows[0]["Bank_ACName"].ToString();
                }
            }
        }

        protected void BT_Save_Click(object sender, EventArgs e)
        {
            string tmp = "";
            string strPayment = "", NotPayment = "";
            for (int i = 0; i < CB_Payment.Items.Count; i++)
            {
                if (CB_Payment.Items[i].Selected)
                {
                    strPayment += "," + CB_Payment.Items[i].Value;
                }
                else
                {
                    NotPayment += ",'" + CB_Payment.Items[i].Value + "'";
                }
            }
            string strDelivery = "", NotDelivery = "";
            for (int i = 0; i < CB_Delivery.Items.Count; i++)
            {

                if (CB_Delivery.Items[i].Selected)
                {
                    strDelivery += "," + CB_Delivery.Items[i].Value;
                }
                else
                {
                    NotDelivery += ",'" + CB_Delivery.Items[i].Value + "'";
                }
            }

            Main.ParaClear();
            Main.ParaAdd("@Store_ID", Comm.Store_ID(), System.Data.SqlDbType.Int);
            Main.ParaAdd("@Store_Name", TBName.Text, System.Data.SqlDbType.NVarChar);

            Main.ParaAdd("@Bank_Name", TBBankName.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Bank_No", TBBankNo.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Bank_ACC", TBACC.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Bank_ACName", TBACName.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Payment", strPayment, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Delivery", strDelivery, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Addr", TBAddr.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@TEL", TBTEL.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@CEOName", TBCEO.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@TBStoreNID", TBStoreNID.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@NotPayment", NotPayment, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@NotDelivery", NotDelivery, System.Data.SqlDbType.NVarChar);

            if (NotPayment != "")
            {
                if (Main.Scalar("select 1 from Orders where Payment_ID  in (" + NotPayment.Substring(1) + ") and Store_ID=@Store_ID and Status not in ('30','99')") == "1")
                {
                    tmp += ",尚有未勾選付款方式的訂單";
                }
            }
            if (NotDelivery != "")
            {
                if (Main.Scalar("select 1 from Orders where Delivery_ID  in (" + NotDelivery.Substring(1) + ") and Store_ID=@Store_ID and Status not in ('30','99')") == "1")
                {
                    tmp += ",尚有未勾選寄送方式的訂單";
                }
            }


            if ((TBACC.Text != strACC || TBACName.Text != strACName || TBBankName.Text != strBankName || TBBankNo.Text != strBankNo) &&
                Main.Scalar("select 1 from Orders where Payment_ID='3' and Store_ID=@Store_ID and Status not in ('30','99')") == "1")
            {
                tmp += ",尚有未結案的ATM訂單不可更改帳戶資訊";
            }



            //提供ATM付款 必填銀行帳戶資訊
            if (strPayment.IndexOf(",3") > 0 && (TBACC.Text == "" || TBACName.Text == "" || TBBankName.Text == "" || TBBankNo.Text == ""))
            {
                tmp += ",尚未填寫受款帳戶資訊";
            }
            if (tmp != "")
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "String", "<script>alert('儲存失敗" + tmp + "');</script>");
                return;
            }


            Main.NonQuery(" if not exists (select 1 from Store_info where Store_ID=@Store_ID ) " +
                    "insert into Store_info(Store_ID, Store_Name,Bank_Name,Bank_No, Bank_ACC, Bank_ACName, Payment, Delivery, Addr, TEL, CEOName)" +
                    "values (@Store_ID, @Store_Name,@Bank_Name,@Bank_No, @Bank_ACC, @Bank_ACName, @Payment, @Delivery, @Addr, @TEL, @CEOName) else " +
                    "update Store_info set Store_Name=@Store_Name,Bank_Name=@Bank_Name,Bank_No=@Bank_No, Bank_ACC=@Bank_ACC, Bank_ACName=@Bank_ACName, " +
                    " Payment=@Payment, Delivery=@Delivery, Addr=@Addr, TEL=@TEL, CEOName=@CEOName where  Store_ID=@Store_ID");

            Main.NonQuery("update store set Store_NID=@TBStoreNID where idno=@Store_ID ");

        }
    }
}