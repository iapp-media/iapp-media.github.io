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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Main.FillDDP(DL_Cate, "select * from Product_Cate", "Cate_Name", "IDNO");
                Getentry();
 
            }
            //暫時 再取一次為了要讓輪播出show出來圖片 
            LPID.Text = Main.Scalar("select top 1 IDNo from product where store_ID =1 and Tmp_IDNo='-99' order by Creat_Date desc");

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
                    Comm.GetDDL(DL_Payment, DT.Rows[0]["Payment"].ToString());
                    Comm.GetDDL(DL_Delivery, DT.Rows[0]["delivery"].ToString());
                    TB_Dimension.Text = DT.Rows[0]["dimension"].ToString();
                    TB_Description.Text = DT.Rows[0]["description"].ToString();
                    TB_Memo.Text = DT.Rows[0]["Memo"].ToString();
                }
                LPID.Text = Request.QueryString["entry"].ToString();

            }
            else
            {
                //還沒改圖片流程
                // store_ID 記在 cookie?
                LPID.Text = Main.Scalar("select top 1 IDNo from product where store_ID =1 and Tmp_IDNo='-99' ");
                if (LPID.Text == "")
                {
                    str = "insert into product (Tmp_IDNo,Product_Name, Cate_ID, Price,Payment,delivery,dimension,description,Memo,store_ID,Img01,Img02,Img03,Img04)" +
                    "values ('-99','','','','','','','','','1','img\\uploadicon.png','img\\uploadicon.png','','img\\uploadicon.png')";
                    if (Main.NonQuery(str) > 0)
                    {
                        // 取 Product_ID
                        LPID.Text = Main.Scalar("select top 1 IDNo from product where store_ID =1 and Tmp_IDNo='-99' order by Creat_Date desc");
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

            if (Comm.IsNumeric(Request.QueryString["entry"]))
            {
                str = "update product set Tmp_IDNo='" + Request.QueryString["entry"] + "',qty='" + TB_qty.Text + "',Product_Name='" + TB_ProductName.Text + "',Cate_ID='" + DL_Cate.SelectedValue + "',Price='" + TB_Price.Text + "',Payment='" + DL_Payment.SelectedValue + "',delivery='" + DL_Delivery.SelectedValue + "',dimension='" + TB_Dimension.Text + "',description='" + TB_Description.Text + "',Memo='" + TB_Memo.Text + "' where store_ID=1 and idno='" + Request.QueryString["entry"] + "'";
            }
            else
            {
                str = "update product set Tmp_IDNo='" + LPID.Text + "',qty='" + TB_qty.Text + "', Product_Name='" + TB_ProductName.Text + "',Cate_ID='" + DL_Cate.SelectedValue + "',Price='" + TB_Price.Text + "',Payment='" + DL_Payment.SelectedValue + "',delivery='" + DL_Delivery.SelectedValue + "',dimension='" + TB_Dimension.Text + "',description='" + TB_Description.Text + "',Memo='" + TB_Memo.Text + "' where  idno='" + LPID.Text + "'";
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