using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace StoreMana
{
    public partial class ThreeOpen : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        string Product_No = "";
        int PayBank = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Main.FillDDP(DLSCate, "select IDNo,Cate_Name from Product_Cate where Store_ID=0 and ref=-1 ", "Cate_Name", "IDNo");
 
                Main.ParaClear();
                Main.ParaAdd("@SID", Main.Cint2(Session["Store_ID"].ToString()), System.Data.SqlDbType.Int);
                LPID.Text = Main.Scalar("select isnull(max(IDNo),'0') from product where store_ID =@SID and Tmp_IDNo='-99' ");
                if (LPID.Text == "0")
                {
                    str = "insert into product (Tmp_IDNo,Product_Name, Cate_ID, Price,dimension,description,Memo,store_ID,Product_No)" +
                    "values ('-99','','','','','','',@SID,'')";
                    if (Main.NonQuery(str) > 0)
                    {
                        LPID.Text = Main.Scalar("select max(IDNo) from product where store_ID =@SID and Tmp_IDNo='-99'  ");
                    }
                }
                loadImg();

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
            Main.ParaAdd("@SID", Main.Cint2(Session["Store_ID"].ToString()), SqlDbType.Int);
            Main.ParaAdd("@Store_Cate", DLSCate.SelectedValue.ToString(), SqlDbType.NVarChar);

            Main.NonQuery(" if not exists (select 1 from Store_info where Store_ID=@SID ) " +
                          " insert into Store_info (Store_Cate,store_id) values(@Store_Cate,@SID)  else " +
                          " update Store_info set Store_Cate=@Store_Cate where Store_ID=@SID");

            Main.FillDDP(CB_Payment, "select Status,Memo from def_Status where Col_Name='Payment' and Status in (" + Main.Scalar("select substring(Payment_STA,2,99) from Product_Cate where IDNo=@Store_Cate") + ") ", "Memo", "Status");
            Main.FillDDP(CB_Delivery, "select Status,Memo from def_Status where Col_Name='Delivery' and Status in (" + Main.Scalar("select substring(Delivery_STA,2,99) from Product_Cate where IDNo=@Store_Cate") + ") ", "Memo", "Status");

            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "goStep(1);", true);

        }

        protected void BTStep2_Click(object sender, EventArgs e)
        {
            string strPayment = "";
            PayBank = 0;
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
                Main.ParaAdd("@SID", Main.Cint2(Session["Store_ID"].ToString()), SqlDbType.Int);
                Main.ParaAdd("@payment", strPayment, SqlDbType.NVarChar);
                Main.NonQuery("update store_info set payment=@payment where Store_ID=@SID");

                PayBank = Main.Cint2(Main.Scalar("select sum(charindex(',3',Payment)) from store_info where Store_ID=@SID"));

               if (PayBank == 0)
               {
                   LStep3tip.Text = "填寫店家資訊";
                   Bank1.Visible = false;
                   Bank2.Visible = false;
                   Bank3.Visible = false;
                   Bank4.Visible = false;
               }
               else
               {
                   LStep3tip.Text = "填寫銀行帳號";
                   Bank1.Visible = true;
                   Bank2.Visible = true;
                   Bank3.Visible = true;
                   Bank4.Visible = true;
               }

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
            if (Bank1.Visible == true)
            {
                if (TBBankName.Text == "") { tmp += ",銀行名稱"; }
                if (TBBankNo.Text == "") { tmp += ",銀行代碼"; }
                if (TBACC.Text == "") { tmp += ",受款帳號"; }
                if (TBACName.Text == "") { tmp += ",受款戶名"; }
            }

            if (TBCEO.Text == "") { tmp += ",聯絡人"; }
            if (TBTEL.Text == "") { tmp += ",聯絡電話"; }
            if (TBAddr.Text == "") { tmp += ",聯絡地址"; }

            if (tmp != "")
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "alert('請填寫" + tmp.Substring(1) + "');", true);
                return;
            }

            Main.ParaClear();

            if (PayBank == 0)
            {
                Main.ParaAdd("@Bank_Name", TBBankName.Text, System.Data.SqlDbType.NVarChar);
                Main.ParaAdd("@Bank_No", TBBankNo.Text, System.Data.SqlDbType.NVarChar);
                Main.ParaAdd("@Bank_ACC", TBACC.Text, System.Data.SqlDbType.NVarChar);
                Main.ParaAdd("@Bank_ACName", TBACName.Text, System.Data.SqlDbType.NVarChar);
                str = "Bank_Name=@Bank_Name,Bank_No=@Bank_No,Bank_ACC=@Bank_ACC,Bank_ACName=@Bank_ACName,";
            }
            else {
                str = "";
            }
            Main.ParaAdd("@Store_ID", Main.Cint2(Session["Store_ID"].ToString()), System.Data.SqlDbType.Int);
            Main.ParaAdd("@CEOName", TBCEO.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@TEL", TBTEL.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Addr", TBAddr.Text, System.Data.SqlDbType.NVarChar); 

            Main.NonQuery("Update Store_info set  " + str + " " +
                    "   Addr=@Addr, TEL=@TEL, CEOName=@CEOName where  Store_ID=@Store_ID");

            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "goStep(3)", true);

        }

        protected void BTStep4_Click(object sender, EventArgs e)
        {
            string strDelivery = "";
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
                Main.ParaAdd("@SID", Main.Cint2(Session["Store_ID"].ToString()), SqlDbType.Int);
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
            string tmp = "";
            if (TB_ProductName.Text == "") { tmp += ".商品名稱"; }
            if (TB_qty.Text == "") { tmp += ".數量"; }
            if (DL_Cate.SelectedValue == "") { tmp += ".商品類別"; }
            if (TB_Price.Text == "") { tmp += ",售價"; }
            if (tmp != "")
            {
                Response.Write("<script>alert('請填選" + tmp.Substring(1) + "')</script>");
                return;
            }

            Main.ParaClear();
            Main.ParaAdd("@qty", TB_qty.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Product_Name", TB_ProductName.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Cate_ID", DL_Cate.SelectedValue, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Price", TB_Price.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@dimension", TB_Dimension.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@description", TB_Description.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@SID", Session["Store_ID"].ToString(), System.Data.SqlDbType.NVarChar);
            Product_No = Comm.GetProductNO(Session["Store_ID"].ToString(), DL_Cate.SelectedValue.ToString(), System.DateTime.Today);
            Main.ParaAdd("@Product_No", Product_No, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Tmp_IDNo", Main.Cint2(LPID.Text), System.Data.SqlDbType.Int);

            str = "update product set Product_No=@Product_No,Tmp_IDNo=@Tmp_IDNo,qty=@qty, Product_Name=@Product_Name,Cate_ID=@Cate_ID" +
                ",Price=@Price,dimension=@dimension,description=@description  where  idno=@Tmp_IDNo";
            if (Main.NonQuery(str) > 0)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "goStep(5)", true);
            }

        }
        void loadImg()
        {
            Main.ParaClear();
            Main.ParaAdd("@PID", Main.Cint2(LPID.Text), SqlDbType.Int);

            string p1src = "", p2src = "", p3src = "", p4src = "";
            string p1do = "", p2do = "", p3do = "", p4do = "";
            p1do = Main.Scalar("Select isnull(sum(1),0) from product_img where Product_ID=@PID and Num='1'");
            p2do = Main.Scalar("Select isnull(sum(1),0) from product_img where Product_ID=@PID and Num='2'");
            p3do = Main.Scalar("Select isnull(sum(1),0) from product_img where Product_ID=@PID and Num='3'");
            p4do = Main.Scalar("Select isnull(sum(1),0) from product_img where Product_ID=@PID and Num='4'");

            if (Main.Cint2(p1do) == 1)
            {
                p1src = Comm.MiStoreUrl + Main.Scalar("Select FilePath from product_img where Product_ID=@PID and Num='1'");
            }

            if (Main.Cint2(p2do) == 1)
            {
                p2src = Comm.MiStoreUrl + Main.Scalar("Select FilePath from product_img where Product_ID=@PID and Num='2'");
            }

            if (Main.Cint2(p3do) == 1)
            {
                p3src = Comm.MiStoreUrl + Main.Scalar("Select FilePath from product_img where Product_ID=@PID and Num='3'");
            }

            if (Main.Cint2(p4do) == 1)
            {
                p4src = Comm.MiStoreUrl + Main.Scalar("Select FilePath from product_img where Product_ID=@PID and Num='4'");
            }


            StringBuilder ss = new StringBuilder();

            ss.Append("                      <ul> ");
            ss.Append("                         <li> ");
            ss.Append("                                <img id='p01' src='" + p1src + "' class='PicSend'  />    ");
            ss.Append("                             <label onclick=" + "" + "setCurrent('01','" + LPID.Text.Trim() + "')" + "" + ">");
            ss.Append("                                 <img src=\"img/uploadicon.png\" alt=\"...\" class=\"PicClick\" />");
            ss.Append("                             </label> ");
            ss.Append("                         </li>");
            ss.Append("                         <li> ");
            ss.Append("                               <img id='p02' src='" + p2src + "' class='PicSend'  /> ");
            ss.Append("                             <label onclick=" + "" + "setCurrent('02','" + LPID.Text.Trim() + "')" + "" + ">");
            ss.Append("                                 <img src=\"img/uploadicon.png\" alt=\"...\" class=\"PicClick\" />");
            ss.Append("                             </label>");
            ss.Append("                         </li>");
            ss.Append("                         <li> ");
            ss.Append("                                <img id='p03' src='" + p3src + "' class='PicSend'  /> ");
            ss.Append("                             <label onclick=" + "" + "setCurrent('03','" + LPID.Text.Trim() + "')" + "" + ">");
            ss.Append("                                 <img src=\"img/uploadicon.png\" alt=\"...\" class=\"PicClick\" />");
            ss.Append("                             </label>");
            ss.Append("                         </li>");
            ss.Append("                         <li>");
            ss.Append("                                 <img id='p04' src='" + p4src + "' class='PicSend' /> ");
            ss.Append("                             <label onclick=" + "" + "setCurrent('04','" + LPID.Text.Trim() + "')" + "" + ">");
            ss.Append("                                 <img src=\"img/uploadicon.png\" alt=\"...\" class=\"PicClick\" />");
            ss.Append("                              </label>");
            ss.Append("                         </li>");
            ss.Append("                      </ul> ");

            L_Img.Text = ss.ToString();
        }

        protected void BTStep6_Click(object sender, EventArgs e)
        {
            Main.ParaClear(); 
            Main.ParaAdd("@SID", Session["Store_ID"].ToString(), System.Data.SqlDbType.NVarChar);
            Main.NonQuery("update Store_info set ckStep=1 where Store_ID=@SID");
            //要總確認嗎?
            Response.Redirect("../MiniStore/Default.aspx?SN=" + Main.Scalar("Select Store_NID from Store where idno='" + Session["Store_ID"].ToString() + "'") + "");
        }

        protected void upStep6_Click(object sender, EventArgs e)
        {
            loadImg();
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "upStep(6)", true);
        }

        protected void DLSCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DLSCate.SelectedValue.ToString() != "")
            {
                Main.FillDDP(DL_Cate, "select IDNo,Cate_Name from Product_Cate where Store_ID=0 and ref='" + DLSCate.SelectedValue.ToString() + "'", "Cate_Name", "IDNo");
            }

        } 
    }
}