using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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
                Main.FillDDP(DL_Cate, "select * from Product_Cate", "Cate_Name", "IDNO");
                Main.FillDDP(CB_Payment, "select Status,Memo from def_Status where Col_Name='Payment'", "Memo", "Status");
                Main.FillDDP(CB_Delivery, "select Status,Memo from def_Status where Col_Name='Delivery'", "Memo", "Status");
                Getentry();
 
            }
            //暫時 再取一次為了要讓輪播出show出來圖片 
           // LPID.Text = Main.Scalar("select top 1 IDNo from product where store_ID =1 and Tmp_IDNo='-99' order by Creat_Date desc");

            CarouselPic();
        }
        void Getentry() {
            if (Comm.IsNumeric(Request.QueryString["entry"]))
            {
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

                    string[] listPayment = DT.Rows[0]["Payment"].ToString().Substring(1).Split(',');
                    for (int i = 0; i < Main.Cint2(listPayment.Length.ToString()); i++)
                    {
                        Comm.GetDDL(CB_Payment, listPayment[i]);
                    }
                    string[] listDelivery = DT.Rows[0]["delivery"].ToString().Substring(1).Split(',');
                    for (int i = 0; i < Main.Cint2(listDelivery.Length.ToString()); i++)
                    {
                        Comm.GetDDL(CB_Delivery, listDelivery[i]);
                    }
                   
                    
                }
                LPID.Text = Request.QueryString["entry"].ToString();

            }
            else
            {
                //還沒改圖片流程
                // store_ID 記在 cookie?
                LPID.Text = Main.Scalar("select isnull(max(IDNo),'0') from product where store_ID =1 and Tmp_IDNo='-99' ");
                if (LPID.Text == "0")
                {
                   
                    str = "insert into product (Tmp_IDNo,Product_Name, Cate_ID, Price,dimension,description,Memo,store_ID,Product_No)" +
                    "values ('-99','','','','','','','1','')";
                    if (Main.NonQuery(str) > 0)
                    {
                        // 取 Product_ID
                        LPID.Text = Main.Scalar("select max(IDNo) from product where store_ID =1 and Tmp_IDNo='-99'  ");
                    }
                    else { ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入失敗');</script>"); }
                }
             }
        }
        void CarouselPic()
        { 
            Main.ParaClear();
            Main.ParaAdd("@Product_ID", LPID.Text, SqlDbType.Int);

            int picNum = 0;
            picNum = Main.Cint2(Main.Scalar("select count(1)+1 from Product_Img where Product_ID=@Product_ID "));


            for (int i = 1; i <= picNum; i++)
            {
                if (i == 1)
                {
                    L.Text += "<div class=\"item active\"><iframe src=\"Product_Img.aspx?PID=" + LPID.Text + "&Img=1\" scrolling=\"no\" id=\"Iframe1\" style=\"width:100%;height:350px\"></iframe></div>";
                }
                else
                {
                    L.Text += "<div class=\"item\"><iframe src=\"Product_Img.aspx?PID=" + LPID.Text + "&Img=" + i + "\" scrolling=\"no\" id=\"Iframe" + i + "\" style=\"width:100%;height:350px\"></iframe></div>";
                }
            }
        }

        protected void BT_Create_Click(object sender, EventArgs e)
        {
            Main.ParaClear();
            Main.ParaAdd("@qty", TB_qty.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Product_Name", TB_ProductName.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Cate_ID", DL_Cate.SelectedValue, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Price", TB_Price.Text, System.Data.SqlDbType.NVarChar);

            //string strPayment = "";
            //for (int i = 0; i < CB_Payment.Items.Count; i++)
            //{ 
            //    if (CB_Payment.Items[i].Selected)
            //    {
            //        strPayment += "," + CB_Payment.Items[i].Value;
            //    }
            //}
            //string strDelivery = "";
            //for (int i = 0; i < CB_Delivery.Items.Count; i++)
            //{

            //    if (CB_Delivery.Items[i].Selected)
            //    {
            //        strDelivery += "," + CB_Delivery.Items[i].Value;
            //    }
            //}
            //Main.ParaAdd("@Payment", strPayment, System.Data.SqlDbType.NVarChar);
            //Main.ParaAdd("@Delivery", strDelivery, System.Data.SqlDbType.NVarChar);

            Main.ParaAdd("@dimension", TB_Dimension.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@description", TB_Description.Text, System.Data.SqlDbType.NVarChar);
            Main.ParaAdd("@Memo", TB_Memo.Text, System.Data.SqlDbType.NVarChar);



            if (Comm.IsNumeric(Request.QueryString["entry"]))
            {
                Main.ParaAdd("@Tmp_IDNo", Main.Cint2(Request.QueryString["entry"].ToString()), System.Data.SqlDbType.Int); 
                str = "update product set Tmp_IDNo=@Tmp_IDNo,qty=@qty,Product_Name=@Product_Name,Cate_ID=@Cate_ID,Price=@Price " +
                    ",dimension=@dimension,description=@description,Memo=@Memo where store_ID=1 and idno=@Tmp_IDNo";
            }
            else
            {
                Product_No = Comm.GetProductNO(LPID.Text, System.DateTime.Today);
                Main.ParaAdd("@Product_No", Product_No, System.Data.SqlDbType.NVarChar);
                Main.ParaAdd("@Tmp_IDNo", Main.Cint2(LPID.Text), System.Data.SqlDbType.Int);

                str = "update product set Product_No=@Product_No,Tmp_IDNo=@Tmp_IDNo,qty=@qty, Product_Name=@Product_Name,Cate_ID=@Cate_ID"+
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
    } 
}