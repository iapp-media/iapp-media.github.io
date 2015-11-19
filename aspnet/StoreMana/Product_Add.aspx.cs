using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace StoreMana.Mini
{
    public partial class Product_Add : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        string Product_No = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Main.ParaClear();
                Main.ParaAdd("@SID", Comm.Store_ID(), SqlDbType.Int);
                Main.FillDDP(DL_Cate, "select * from Product_Cate where store_id=@SID", "Cate_Name", "IDNO");

                Getentry();
                loadImg();
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
            ss.Append("                                <img id='p01' src='" + p1src + "' class='sliderimgH'  />    ");
            ss.Append("                             <label onclick=" + "" + "setCurrent('01','" + LPID.Text.Trim() + "')" + "" + ">");
            ss.Append("                                 <img src='img/uploadicon.png' alt='...' class='imgsize poscenter clickslider openslider Addbutton' />");
            ss.Append("                             </label> ");
            ss.Append("                         </li>");
            ss.Append("                         <li> ");
            ss.Append("                               <img id='p02' src='" + p2src + "' class='sliderimgH'  /> ");
            ss.Append("                             <label onclick=" + "" + "setCurrent('02','" + LPID.Text.Trim() + "')" + "" + ">");
            ss.Append("                                 <img src='img/uploadicon.png' alt='...' class='imgsize poscenter clickslider openslider Addbutton' />");
            ss.Append("                             </label>");
            ss.Append("                         </li>");
            ss.Append("                         <li> ");
            ss.Append("                                <img id='p03' src='" + p3src + "' class='sliderimgH'  /> ");
            ss.Append("                             <label onclick=" + "" + "setCurrent('03','" + LPID.Text.Trim() + "')" + "" + ">");
            ss.Append("                                 <img src='img/uploadicon.png' alt='...' class='imgsize poscenter clickslider openslider Addbutton' />");
            ss.Append("                             </label>");
            ss.Append("                         </li>");
            ss.Append("                         <li>");
            ss.Append("                                 <img id='p04' src='" + p4src + "' class='sliderimgH' /> ");
            ss.Append("                             <label onclick=" + "" + "setCurrent('04','" + LPID.Text.Trim() + "')" + "" + ">");
            ss.Append("                                 <img src='img/uploadicon.png' alt='...' class='imgsize poscenter clickslider openslider Addbutton' />");
            ss.Append("                              </label>");
            ss.Append("                         </li>");
            ss.Append("                      </ul> ");

            L_Img.Text = ss.ToString();

        }
        void Getentry()
        {
            if (Comm.IsNumeric(Request.QueryString["entry"]))
            {
                BT_Create.Text = "儲存更新";
                BT_Cancel.Text = "取消";

                str = "select * from product where idno=" + Request.QueryString["entry"] + "";
                DataTable DT = Main.GetDataSetNoNull(str);
                if (DT.Rows.Count > 0)
                {
                    TB_ProductName.Text = DT.Rows[0]["Product_Name"].ToString();
                    Comm.GetDDL(DL_Cate, DT.Rows[0]["Cate_ID"].ToString());
                    TB_Price.Text = DT.Rows[0]["Price"].ToString();
                    TB_qty.Text = DT.Rows[0]["qty"].ToString();
                    TB_Dimension.Text = DT.Rows[0]["dimension"].ToString();
                    TB_Description.Text = DT.Rows[0]["description"].ToString();
                    TB_Memo.Text = DT.Rows[0]["Memo"].ToString();

                }
                LPID.Text = Request.QueryString["entry"].ToString();

            }
            else
            {
                // store_ID 記在 cookie 
                Main.ParaClear();
                Main.ParaAdd("@SID", Comm.Store_ID(), System.Data.SqlDbType.Int);
                LPID.Text = Main.Scalar("select isnull(max(IDNo),'0') from product where store_ID =@SID and Tmp_IDNo='-99' ");
                if (LPID.Text == "0")
                {

                    str = "insert into product (Tmp_IDNo,Product_Name, Cate_ID, Price,dimension,description,Memo,store_ID,Product_No)" +
                    "values ('-99','','','','','','',@SID,'')";
                    if (Main.NonQuery(str) > 0)
                    {
                        LPID.Text = Main.Scalar("select max(IDNo) from product where store_ID =@SID and Tmp_IDNo='-99'  ");
                    }
                    else
                    {
                        Response.Redirect("Product_Mana.aspx");
                        //ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入失敗');</script>"); 
                    }
                }
            }
        }


        protected void BT_Create_Click(object sender, EventArgs e)
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
            Main.ParaAdd("@Memo", TB_Memo.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@SID", Comm.Store_ID(), System.Data.SqlDbType.NVarChar);



            if (Comm.IsNumeric(Request.QueryString["entry"]))
            {
                Main.ParaAdd("@Tmp_IDNo", Main.Cint2(Request.QueryString["entry"].ToString()), System.Data.SqlDbType.Int);
                str = "update product set Tmp_IDNo=@Tmp_IDNo,qty=@qty,Product_Name=@Product_Name,Cate_ID=@Cate_ID,Price=@Price " +
                    ",dimension=@dimension,description=@description,Memo=@Memo where store_ID=@SID and idno=@Tmp_IDNo";
            }
            else
            {
                Product_No = Comm.GetProductNO(Comm.Store_ID().ToString(), DL_Cate.SelectedValue.ToString(), System.DateTime.Today);
                Main.ParaAdd("@Product_No", Product_No, System.Data.SqlDbType.NVarChar);
                Main.ParaAdd("@Tmp_IDNo", Main.Cint2(LPID.Text), System.Data.SqlDbType.Int);

                str = "update product set Product_No=@Product_No,Tmp_IDNo=@Tmp_IDNo,qty=@qty, Product_Name=@Product_Name,Cate_ID=@Cate_ID" +
                    ",Price=@Price,dimension=@dimension,description=@description,Memo=@Memo where  idno=@Tmp_IDNo";
            }
            if (Main.NonQuery(str) > 0)
            {
                Response.Redirect("Product_Mana.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入失敗');</script>");
            }
        }
        protected void BT_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product_Mana.aspx");
        }

        protected void BT_DEL_Click(object sender, EventArgs e)
        {
            Main.ParaClear();
            Main.ParaAdd("@pid", Request.QueryString["entry"], System.Data.SqlDbType.NVarChar);

            if (Main.Scalar("Select distinct 1 from Order_Content where Item_ID in ( select IDNo from Product where IDNo=@pid") != "")
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(Page), "String", "alert('已有訂單，商品不可刪除');", true);
                return;
            }

            int a = Main.NonQuery("delete product where idno=@pid");
            if (a > 0)
            {
                Response.Redirect("Product_Mana.aspx");
            }
        }
    }
}