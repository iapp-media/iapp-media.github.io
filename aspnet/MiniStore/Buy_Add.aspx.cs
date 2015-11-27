using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MiniStore
{
    public partial class Buy_Add : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            	//aaaaaaaa
                string jump = "";
                if (Comm.User_ID() == -1)
                {
                    jump = "../Login/m-login.aspx?done=" + HttpUtility.UrlEncode("../MiniStore/Buy_Add.aspx?entry=" + Request.QueryString["entry"] + "&SN=" + Request.QueryString["SN"] + "") + "&jump=store";
                    Response.Write("<Script>alert('請先登入');window.open('" + jump + "','_self')</Script>");
                    return;
                }

                if (!Comm.IsNumeric(Request.QueryString["entry"])) { Response.Redirect("Default.aspx"); }
                DataTable DT = Main.GetDataSetNoNull("select Store_ID from Product where idno='" + Request.QueryString["entry"] + "' ");
                if (DT.Rows.Count > 0)
                {
                    Main.ParaClear();
                    Main.ParaAdd("@Store_ID", Main.Cint2(DT.Rows[0]["Store_ID"]), SqlDbType.Int);
                    Main.ParaAdd("@Product_ID", Main.Cint2(Request.QueryString["entry"]), SqlDbType.Int);
                    Main.ParaAdd("@User_ID", Comm.User_ID(), SqlDbType.Int);
                    Main.ParaAdd("@qty", 1, SqlDbType.Int);
                    int c = Main.NonQuery("Insert into ShoppingCart( Store_ID,Product_ID, User_ID, qty) values( @Store_ID, @Product_ID, @User_ID, @qty)");
                    if (c > 0)
                    {
                        Response.Redirect("Buy_Ctrl.aspx?SN=" + Request.QueryString["SN"] + "");
                    }
                }
            }
        }
    }
}