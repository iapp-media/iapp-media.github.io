using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreMana
{
    public partial class ShopCarBaby : System.Web.UI.Page
    {
        CommTool Comm = new CommTool();
        JDB Main = new JDB(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Comm.IsNumeric(Request.QueryString["K0"]))
                {
                    Response.Write("ERR");
                    Response.End();
                    return;
                }
                switch (Request.QueryString["K0"])
                {
                    case "0":  //刪除carbaby
                        if (Comm.IsNumeric(Request.QueryString["K1"]) && Comm.IsNumeric(Request.QueryString["K1"]))
                        {
                            Main.ParaClear();
                            Main.ParaAdd("@SID", Main.Cint2(Request.QueryString["K1"]), System.Data.SqlDbType.Int);
                            Main.ParaAdd("@PID", Main.Cint2(Request.QueryString["K2"]), System.Data.SqlDbType.Int);
                            Main.ParaAdd("@UID", Main.Cint2(Comm.User_ID()), System.Data.SqlDbType.Int);

                            int c = Main.NonQuery("Delete ShoppingCart where IDNo=@SID and Product_ID=@PID and user_id=@UID ");
                            if (c > 0)
                            {
                                Response.Write("suc");
                            } 
                        }

                        break;
                    case "1":  //carbaby 數量加1
                        if (Comm.IsNumeric(Request.QueryString["K1"]))
                        {
                            Main.ParaClear();
                            Main.ParaAdd("@SID", Main.Cint2(Request.QueryString["K1"]), System.Data.SqlDbType.Int);
                            Main.ParaAdd("@UID", Main.Cint2(Comm.User_ID()), System.Data.SqlDbType.Int);
                            int c = Main.NonQuery("Update ShoppingCart set qty=qty+1 where IDNo=@SID and user_id=@UID");
                            if (c > 0)
                            {
                                Response.Write("suc");
                            }
                        }
                        break;
                    case "2":  //carbaby 數量減1
                        if (Comm.IsNumeric(Request.QueryString["K1"]))
                        {
                            Main.ParaClear();
                            Main.ParaAdd("@SID", Main.Cint2(Request.QueryString["K1"]), System.Data.SqlDbType.Int);
                            Main.ParaAdd("@UID", Main.Cint2(Comm.User_ID()), System.Data.SqlDbType.Int);
                            int c = Main.NonQuery("Update ShoppingCart set qty=qty-1 where IDNo=@SID and user_id=@UID");
                            if (c > 0)
                            {
                                Response.Write("suc");
                            }
                        }

                        break;
                    case "3":  //計算總金額&回傳
                        if (Request.QueryString["K3"] != null)
                        {
                            Main.ParaClear();
                            Main.ParaAdd("@SNID", Request.QueryString["K3"].ToString(), System.Data.SqlDbType.NVarChar);
                            Main.ParaAdd("@UID", Main.Cint2(Comm.User_ID()), System.Data.SqlDbType.Int);
                            int c = Main.Cint2(Main.Scalar("select sum(a.qty*b.Price) from ( " +
"select qty,Product_ID from ShoppingCart where Store_ID  in( select IDNo from Store where Store_NID=@SNID)  and User_ID=@UID " +
") a inner join Product b on a.Product_ID=b.IDNo"));

                            //Main.WriteLog("price=" + c.ToString() + "");
                            Response.Write(c);
                        }

                        break;
                }

                //Response.Write("success");
                Response.End();

                //if (Comm.IsNumeric(Request.QueryString["C"]) && Request.QueryString["N"] != null && Request.QueryString["T"] != null && Request.QueryString["M"] != null)
                //{
                //    int AppID = Comm.Cint2(Request.QueryString["C"]);


                //    Main.ParaClear();
                //    Main.ParaAdd("@AppID", AppID, System.Data.SqlDbType.Int);
                //    Main.ParaAdd("@Name", Request.QueryString["N"].ToString(), System.Data.SqlDbType.NVarChar);
                //    Main.ParaAdd("@Tel", Request.QueryString["T"].ToString(), System.Data.SqlDbType.Char);
                //    Main.ParaAdd("@Memo", Request.QueryString["M"].ToString(), System.Data.SqlDbType.NVarChar);

                //    str = "if not exists (Select 1 from Wedding_bless where User_App_ID=@AppID and Tel=@Tel) " +
                //              "Insert into Wedding_bless (User_App_ID, Name, Tel, Memo, Creat_Date) values " +
                //              " (@AppID, @Name,@Tel,@Memo,getdate()) else " +
                //    "Update Wedding_bless set Memo=@Memo where User_App_ID=@AppID and Tel=@Tel";

                //    Main.NonQuery(str);

                //    //重複送的處理??
                //    Response.Write("success");
                //    Response.End();
                //}
            }
        }
    }
}