using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StoreMana
{
    public partial class ThreeOpen : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Main.FillDDP(DLSCate, "select IDNo,Cate_Name from Product_Cate where Store_ID=0 ", "Cate_Name", "IDNo");
                Main.FillDDP(DL_Cate, "select IDNo,Cate_Name from Product_Cate where Store_ID=0 ", "Cate_Name", "IDNo"); 
                Main.FillDDP(CB_Payment, "select Status,Memo from def_Status where Col_Name='Payment'", "Memo", "Status");
                Main.FillDDP(CB_Delivery, "select Status,Memo from def_Status where Col_Name='Delivery'", "Memo", "Status");
            }
        }

        protected void BTStep1_Click(object sender, EventArgs e)
        {
            if (DLSCate.SelectedValue == "")
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "alert('請填選商店類別');", true);
                return;
            }

            Main.ParaClear();
            Main.ParaAdd("@SID", Comm.Store_ID(), SqlDbType.Int);
            Main.ParaAdd("@Store_Cate", DLSCate.SelectedValue.ToString(), SqlDbType.NVarChar);

            Main.NonQuery(" if not exists (select 1 from Store_info where Store_ID=@SID ) " +
                          " insert into Store_info (Store_Cate,store_id) values(@Store_Cate,@SID)  else " +
                          " update Store_info set Store_Cate=@Store_Cate where Store_ID=@SID");
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "goStep(1);", true);

        }

        protected void BTStep2_Click(object sender, EventArgs e)
        {
            string strPayment = "";
            for (int i = 0; i < CB_Payment.Items.Count; i++)
            {
                if (CB_Payment.Items[i].Selected)
                {
                    strPayment += "," + CB_Payment.Items[i].Value;
                }
            }

            if (strPayment != "")
            {
                Main.ParaClear();
                Main.ParaAdd("@SID", Comm.Store_ID(), SqlDbType.Int);
                Main.ParaAdd("@payment", strPayment, SqlDbType.NVarChar);
                Main.NonQuery("update store_info set payment=@payment where Store_ID=@SID");
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "goStep(2)", true);

            }
            else
            {

                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "alert('請選擇付款方式');", true);
                return;
            }
        }

        protected void BTStep3_Click(object sender, EventArgs e)
        {
            string tmp = "";
            if (TBBankName.Text == "") { tmp += ",銀行名稱"; }
            if (TBBankNo.Text == "") { tmp += ",銀行代碼"; }
            if (TBACC.Text == "") { tmp += ",受款帳號"; }
            if (TBACName.Text == "") { tmp += ",受款戶名"; }
            if (TBCEO.Text == "") { tmp += ",聯絡人"; }
            if (TBTEL.Text == "") { tmp += ",聯絡電話"; }
            if (TBAddr.Text == "") { tmp += ",聯絡地址"; }

            if (tmp != "")
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "alert('請填寫" + tmp.Substring(1) + "');", true);
                return; 
            }

            Main.ParaClear();
            Main.ParaAdd("@Store_ID", Comm.Store_ID(), System.Data.SqlDbType.Int); 
            Main.ParaAdd("@Bank_Name", TBBankName.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Bank_No", TBBankNo.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Bank_ACC", TBACC.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Bank_ACName", TBACName.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@CEOName", TBCEO.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@TEL", TBTEL.Text, System.Data.SqlDbType.NVarChar);
             Main.ParaAdd("@Addr", TBAddr.Text, System.Data.SqlDbType.NVarChar);



             Main.NonQuery("Update Store_info set Bank_Name=@Bank_Name,Bank_No=@Bank_No,Bank_ACC=@Bank_ACC,Bank_ACName=@Bank_ACName, " +
                     "   Addr=@Addr, TEL=@TEL, CEOName=@CEOName where  Store_ID=@Store_ID");

             System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "goStep(3)", true);

        } 

        protected void BTStep4_Click(object sender, EventArgs e)
        {
            string strDelivery = "" ;
            for (int i = 0; i < CB_Delivery.Items.Count; i++)
            {

                if (CB_Delivery.Items[i].Selected)
                {
                    strDelivery += "," + CB_Delivery.Items[i].Value;
                } 
            }

            if (strDelivery != "")
            {
                Main.ParaClear();
                Main.ParaAdd("@SID", Comm.Store_ID(), SqlDbType.Int);
                Main.ParaAdd("@Delivery", strDelivery, SqlDbType.NVarChar);
                Main.NonQuery(" update store_info  set Delivery=@Delivery where Store_ID=@SID");
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "goStep(4)", true);

            }
            else
            { 
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "alert('請選擇寄送方式');", true);
                return; 
            }
        }

        protected void BTStep5_Click(object sender, EventArgs e)
        {




        }

 
    }
}