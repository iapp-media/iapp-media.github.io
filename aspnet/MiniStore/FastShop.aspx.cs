using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniStore
{
    public partial class FastShop : System.Web.UI.Page
    {
        CommTool Comm = new CommTool();
        JDB Main = new JDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Comm.IsNumeric(Request.QueryString["K0"]) || !Comm.IsNumeric(Request.QueryString["K1"]))
                {
                    Response.Write("err");
                    Response.End();
                    return;
                }
                switch (Request.QueryString["K0"])
                { 
                    case "1":  //carbaby 數量加1
                        if (Comm.IsNumeric(Request.QueryString["K1"]))
                        {
                            Main.ParaClear();
                            Main.ParaAdd("@PID", Main.Cint2(Request.QueryString["K1"]), System.Data.SqlDbType.Int);
                            Main.ParaAdd("@UID", Main.Cint2(Comm.User_ID()), System.Data.SqlDbType.Int);
                            int c = Main.NonQuery("if not exists ( select '1' from ShoppingCart where Product_ID=@PID and user_id=@UID) " +
                                                  " insert into ShoppingCart (Store_ID,Product_ID,User_ID,qty) values " +
                                                  "((select Store_ID from Product where idno=@PID),@PID,@UID,1) " +
                                                  "else Update ShoppingCart set qty=qty+1 where Product_ID=@PID and user_id=@UID ");
                            if (c > 0)
                            {
                                Response.Write(Main.Scalar("select sum(qty) from ShoppingCart where Product_ID=@PID and user_id=@UID "));
                            }
                            else
                            {
                                Response.Write("err");
                            }
                        }
                        break;
                    case "2":  //carbaby 數量減1
                        if (Comm.IsNumeric(Request.QueryString["K1"]))
                        {
                            Main.ParaClear();
                            Main.ParaAdd("@PID", Main.Cint2(Request.QueryString["K1"]), System.Data.SqlDbType.Int);
                            Main.ParaAdd("@UID", Main.Cint2(Comm.User_ID()), System.Data.SqlDbType.Int);
                            int c = Main.NonQuery("if (select qty from ShoppingCart where Product_ID=@PID and user_id=@UID )=1 " +
                                                  "delete ShoppingCart where  Product_ID=@PID and user_id=@UID " +
                                                  "else Update ShoppingCart set qty=qty-1 where Product_ID=@PID and user_id=@UID  ");
                            if (c > 0)
                            {
                                Response.Write(Main.Scalar("select sum(qty) from ShoppingCart where Product_ID=@PID and user_id=@UID "));
                            }
                            else {
                                Response.Write("err");
                            }
                        }

                        break; 
                } 
                Response.End(); 
            }
        }
    }
}