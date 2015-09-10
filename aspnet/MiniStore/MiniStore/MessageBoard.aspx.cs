using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MiniStore
{
    public partial class MessageBoard : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Comm.IsNumeric(Request.QueryString["entry"]))
                {
                    str = "select * from Message where Product_ID =" + Request.QueryString["entry"] + "";
                }
            }

            DataTable d = Main.GetDataSetNoNull(str);
            if (d.Rows.Count > 0)
            {
                Literal1.Text = "";
                for (int i = 0; i < d.Rows.Count; i++)
                {
                    DataRow dw = d.Rows[i];
                    Literal1.Text += "<li class=\"list-group-item\"><div class=\"row\"><div class=\"col-xs-3\">" + 
                        dw["Leave_ID"].ToString() + "</div><div>" + dw["Cont"].ToString() + "</div></div></li>";
                }
            }
        }

        protected void Bt_Leave_Click(object sender, EventArgs e)
        {
            if (TB_Cont.Text == "") { return; }

            //if (Session["User_ID"].ToString() == null) { Response.Redirect("Login.aspx"); }

            //if (Comm.IsNumeric(Session["User_ID"].ToString())) { 
                //str = "insert into message(Product_ID,cont,leave_ID) values(" + Request.QueryString["entry"] + ",'" + TB_Cont.Text + "','" + Session["User_ID"].ToString() + "')";

                if (Main.NonQuery("insert into message(Product_ID,cont,leave_ID) values(" + Request.QueryString["entry"] + ",'" + TB_Cont.Text + "','allen')") > 0)
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入成功');</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入失敗');</script>");
                }
            //}
        }
    }
}