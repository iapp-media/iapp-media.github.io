using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MiniStore
{
    public partial class Order : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str="";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Comm.IsNumeric(Request.QueryString["entry"]))
                {
                    DataTable d = Main.GetDataSetNoNull("SELECT * FROM product,product_img where product.IDNo = product_img.Product_ID and product.idno =" + Request.QueryString["entry"]);
                    if (d.Rows.Count > 0)
                    {
                        for (int i = 0; i < d.Rows.Count; i++)
                        {
                            DataRow dw = d.Rows[i];
                            if (i == 0)
                            {
                                //Literal5.Text += "<li data-target=\"#carousel-example-generic\" data-slide-to=\"" + i + "\" class=\"active\"></li>";
                                Literal6.Text += "<div class=\"item active\"><img src=\"" + Comm.URL + dw["FilePath"].ToString().Replace("\\", "/") + "\" alt=\"\" style=\"width:100%;height:250px\"><div class=\"carousel-caption\"></div></div>";
                            }
                            else
                            {
                                //Literal5.Text += "<li data-target=\"#carousel-example-generic\" data-slide-to=\"" + i + "\"></li>";
                                Literal6.Text += "<div class=\"item\"><img src=\"" + Comm.URL + dw["FilePath"].ToString().Replace("\\", "/") + "\" alt=\"\" style=\"width:100%;height:250px\"><div class=\"carousel-caption\"></div></div>";
                            }
                        }
                    }
                }
            }
        }

        protected void Bt_Buy_Click(object sender, EventArgs e)
        {

            //if (Session["User_ID"].ToString() == null) { Response.Redirect("Login.aspx"); }

            //if (Comm.IsNumeric(Session["User_ID"].ToString())) {
            //DataTable DT = Main.GetDataSet("select * from Users where Account='" + Session["User_ID"].ToString() + "'");
                DataTable DT = Main.GetDataSet("select * from Users where Account='allen'");
                if (DT.Rows.Count > 0)
                {
                    str = "insert into orders(Customer_ID,Contact_ID,Contact_Name,tel,email,city,addr,status,order_no) values('" + DT.Rows[0]["IDNo"] + 
                        "','" + DT.Rows[0]["Account"] + "','" + DT.Rows[0]["User_Name"] + "','" + DT.Rows[0]["tel"] + "','" + DT.Rows[0]["email"] +
                        "','" + DT.Rows[0]["city"] + "','" + DT.Rows[0]["addr"] + "','1','" + DateTime.Now.ToString("yyyyMMddhhmmss") + "')";

                    if (Main.NonQuery(str) > 0)
                    {
                        DataTable Order_ID = Main.GetDataSet("select top 1 * from orders where Contact_ID='" + DT.Rows[0]["Account"] + "' order by IDNo DESC");
                        str = "insert into Order_Content(Order_ID,Item_ID,Total,AMT,Price,Order_No) values('" + Order_ID.Rows[0]["IDNo"] + "','" + Request.QueryString["p"] +
                                      "','" + Literal3.Text + "','" + Literal1.Text + "','" + Literal2.Text + "','" + Order_ID.Rows[0]["Order_No"] + "')";
                        Main.NonQuery(str);
                        ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('購買成功');location.href='Product_Detail.aspx?p=" + Request.QueryString["p"] + "'</script>");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('購買失敗，請檢查欄位是否均已填寫');</script>");
                    }
                }
            //}
        }
    }
}