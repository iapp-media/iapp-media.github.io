using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class Profile : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                str = "select Account,User_Name,Tel,case when User_Icon is not null then 1 else 0 end Uicon from Users where IDNo=" + Comm.User_ID();
                DataTable dr = Main.GetDataSet(str);
                if (dr.Rows.Count > 0)
                {

                    TName.Text = dr.Rows[0]["User_Name"].ToString();
                    Tphone.Text = dr.Rows[0]["Tel"].ToString();
                    if (dr.Rows[0]["Uicon"].ToString() == "1")
                    {
                        p1.ImageUrl = "UserIcon.ashx?i=" + Comm.User_ID() + "";
                    }
                }
            }
        }

        protected void BtnSend_Click(object sender, EventArgs e)
        { 
            //string Msg = "";
            str = "";
            Main.ParaClear();
            if (TName.Text != "")
            {
                Main.ParaAdd("@TName", TName.Text, System.Data.SqlDbType.NVarChar);
                str += "Update Users Set User_name=@TName where IDNo ='" + Comm.User_ID() + "';"; 
            }
            if (Tphone.Text != "")
            {
                Main.ParaAdd("@Tphone", Tphone.Text, System.Data.SqlDbType.NVarChar);
                str += "Update Users Set Tel=@Tphone where IDNo ='" + Comm.User_ID() + "';";
            }
            if (pw1.Text != "" || pw2.Text != "")
            {
                if (pw1.Text != pw2.Text)
                {
                    Response.Write("<Script>alert('確認密碼不同!!');</Script>");
                }
                else
                {
                    Main.ParaAdd("@pw1", pw1.Text, System.Data.SqlDbType.NVarChar);
                    str += "Update Users Set Password=@pw1 where IDNo =" + Comm.User_ID() + "';";
                }
            }
            if (str != "")
            {
                Main.NonQuery(str); 
                Response.Write("<Script>window.parent.ref()</Script>");
            } 
        }
    }
}