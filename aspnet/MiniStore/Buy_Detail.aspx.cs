using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MiniStore
{
    public partial class Buy_Detail : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = ""; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
 
                    if (!Comm.IsNumeric(Request.QueryString["entry"])) { Response.Redirect("Default.aspx"); }
                    Main.ParaClear();
                    Main.ParaAdd("@Product_ID", Main.Cint2(Request.QueryString["entry"]), SqlDbType.Int);

                    if (Main.Scalar("Select 1 from Product where IDNo=@Product_ID") != "")
                    {
                        L_Mail.Text = "<a href=\"mailto:?subject=[iApp微店推薦]pname&amp;body=嗨！我想請你來看看iApp微店的商品。%0D%0A商品名稱：name%0D%0A" + Comm.URL + "Ministore/Buy_Detail.aspx?entry=" + Request.QueryString["entry"] + "&SN=" + Request.QueryString["SN"] + "" + "\" title=\"EMail\"> " +
                                      "  <img src=\"img/mail.png\" alt=\"Alternate Text\" /></a>";
                    }
                    else
                    {
                        Response.Redirect("Default.aspx?SN='" + Request.QueryString["SN"] + "'");
                    }

                    if (Comm.User_ID() != -1)
                    {
                        Main.ParaAdd("@Cust_ID", Main.Cint2(Comm.User_ID().ToString()), SqlDbType.Int); 
                    }
                    else
                    {
                        Main.ParaAdd("@Cust_ID", Main.Cint2("2"), SqlDbType.Int);
                    }

                      Main.NonQuery("	Insert product_click(Product_ID, Cust_ID, Creat_Date) values " +
                                  " ( @Product_ID, @Cust_ID, getdate())");
                    L_Back.Text = "<a href=\"Default.aspx?SN=" + Request.QueryString["SN"] + "\"><img src=\"img/backarrow.png\" alt=\"Alternate Text\" class=\"col-xs-2\" /></a> ";

                    LCarLink.Text = " <a id=\"Buycar\"  href=\"Buy_Ctrl.aspx?SN=" + Request.QueryString["SN"] + "\">" +
                        " <img class=\"back-top\" src=\"img/cart.png\" /><span/>" +
                        Main.Scalar("Select case when COUNT(1) > 99 then '99+' else Convert(varchar,COUNT(1) ) end from ShoppingCart where User_ID='" + Comm.User_ID() + "' and Store_ID in ( select IDNo from Store where Store_NID='" + Request.QueryString["SN"] + "')") +
                        "</span> </a>";
  
                CarouselPic();  
            }
        }
        void CarouselPic()
        {
            if (Comm.IsNumeric(Request.QueryString["entry"]))
            {
                Main.ParaClear();
                Main.ParaAdd("@idno", Main.Cint2(Request.QueryString["entry"]), SqlDbType.Int);
                Main.ParaAdd("@SN", Request.QueryString["SN"], SqlDbType.NVarChar); 
                Main.ParaAdd("@SID", Main.Scalar("select IDNo from Store where Store_NID=@SN"), SqlDbType.NVarChar);

                str = "select * from product a where a.idno=@idno and a.store_id=@SID";
                DataTable DT = Main.GetDataSetNoNull(str);
                if (DT.Rows.Count > 0)
                {
                    TB_Name.Text = DT.Rows[0]["Product_Name"].ToString(); 
                    TB_Dimension.Text = DT.Rows[0]["dimension"].ToString();
                    TB_Price.Text = string.Format("{0:#,##0}", Main.Cint2(DT.Rows[0]["Price"]));
                    TB_Description.Text = DT.Rows[0]["description"].ToString();
                  //  MSG_COUNT.Text = DT.Rows[0]["cmsg"].ToString();,(select COUNT(1) from Product_MSG where Product_ID=a.IDNo) cmsg
                }
                DataTable DT2 = Main.GetDataSetNoNull("Select FilePath from Product_Img where Product_ID=@idno ");
                if (DT2.Rows.Count > 0)
                {
                    for (int i = 0; i < DT2.Rows.Count; i++)
                    {
                        IMG_li.Text += "<li><img src='" + DT2.Rows[i]["FilePath"].ToString() + "' alt='Alternate Text' /></li>";
                    }
                }
            }
        }

        protected void BT_Confirm_Click(object sender, EventArgs e)
        {
            Main.ParaClear();
            Main.ParaAdd("@idno", Main.Cint2(Request.QueryString["entry"]), SqlDbType.Int);
            Main.ParaAdd("@SN", Request.QueryString["SN"], SqlDbType.NVarChar);
            Main.ParaAdd("@SID", Main.Scalar("select IDNo from Store where Store_NID=@SN"), SqlDbType.NVarChar);

            DataTable DT = Main.GetDataSetNoNull("select 1 from Product where idno=@idno and store_id=@SID ");
            if (DT.Rows.Count > 0)
            { 
                Main.ParaAdd("@User_ID", Comm.User_ID(), SqlDbType.Int);
                Main.ParaAdd("@qty", 1, SqlDbType.Int);
                int c = Main.NonQuery("Insert into ShoppingCart( Store_ID,Product_ID, User_ID, qty) values(@SID,@idno, @User_ID, @qty)");
                if (c > 0)
                {
                    Response.Redirect("Buy_Ctrl.aspx?SN=" + Request.QueryString["SN"] + "");
                }
            } 
        }

        protected void BT_InCar_Click(object sender, EventArgs e)
        {
            Main.ParaClear();
            Main.ParaAdd("@idno", Main.Cint2(Request.QueryString["entry"]), SqlDbType.Int);
            Main.ParaAdd("@SN", Request.QueryString["SN"], SqlDbType.NVarChar);
            Main.ParaAdd("@SID", Main.Scalar("select IDNo from Store where Store_NID=@SN"), SqlDbType.NVarChar);

            DataTable DT = Main.GetDataSetNoNull("select 1 from Product where idno=@idno and store_id=@SID ");
            if (DT.Rows.Count > 0)
            {
                Main.ParaClear();
                Main.ParaAdd("@Product_ID", Main.Cint2(Request.QueryString["entry"]), SqlDbType.Int);
                Main.ParaAdd("@User_ID", Comm.User_ID(), SqlDbType.Int);
                Main.ParaAdd("@qty", 1, SqlDbType.Int);
                Main.ParaAdd("@SN", Request.QueryString["SN"], SqlDbType.NVarChar);
                Main.ParaAdd("@SID", Main.Scalar("select IDNo from Store where Store_NID=@SN"), SqlDbType.NVarChar);

                int c = Main.NonQuery("Insert into ShoppingCart(store_id, Product_ID, User_ID, qty) values( @SID,@Product_ID, @User_ID, @qty)");
                if (c > 0)
                {
                    Response.Write("<script>alert('商品已加入購物車');</script>");
                    //window.open('Default.aspx','_self');
                }
            } 
        }

        protected void BT_MSG_Click(object sender, EventArgs e)
        {
            Response.Redirect("P_MSG.aspx?entry=" + Request.QueryString["entry"] + "&SN=" + Request.QueryString["SN"] + "");
        }
         

        protected void BT_FB_Click(object sender, ImageClickEventArgs e)
        {
            Uri u = Request.UrlReferrer;
            string aa = "https://www.facebook.com/sharer.php?u=" + u;
            Response.Write("<script> window.open('" + aa + "', '_blank', width=400,height=400);</script>");

        } 
    }
}