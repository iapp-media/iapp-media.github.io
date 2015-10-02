using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Login
{
    public partial class m_Profile : System.Web.UI.Page
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

                    mname.Text = dr.Rows[0]["User_Name"].ToString();
                    mtel.Text = dr.Rows[0]["Tel"].ToString();
                    if (dr.Rows[0]["Uicon"].ToString() == "1")
                    {
                        p1.ImageUrl = "../UserIcon.ashx?i=" + Comm.User_ID() + "";
                    }
                }
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
            str = "";
            Main.ParaClear();
            if (mname.Text != "")
            {
                Main.ParaAdd("@TName", mname.Text, System.Data.SqlDbType.NVarChar);
                str += "Update Users Set User_name=@TName where IDNo ='" + Comm.User_ID() + "';";
            }
            if (mtel.Text != "")
            {
                Main.ParaAdd("@Tphone", mtel.Text, System.Data.SqlDbType.NVarChar);
                str += "Update Users Set Tel=@Tphone where IDNo ='" + Comm.User_ID() + "';";
            }
            if (mrepasswd.Text != "" || mckpasswd.Text != "")
            {
                if (mrepasswd.Text != mckpasswd.Text)
                {
                    Response.Write("<Script>alert('確認密碼不同!!');</Script>");
                    return;
                }
                else
                {
                    Main.ParaAdd("@pw1", mrepasswd.Text, System.Data.SqlDbType.NVarChar);
                    str += "Update Users Set Password=@pw1 where IDNo =" + Comm.User_ID() + "';";
                }
            }
            if (str != "")
            {
                Main.NonQuery(str);
                Response.Redirect("http://www.iapp-media.com/portal/");
               // Response.Write("<Script>window.parent.ref()</Script>");
            } 
        }

        protected void sended_Click(object sender, EventArgs e)
        {
            if (Main.IsNumeric(Comm.User_ID()))
            {
                Main.ParaClear();
                Main.ParaAdd("@User_ID", Comm.User_ID(), System.Data.SqlDbType.Int); 
                byte[] buf = System.Convert.FromBase64String(Tbase64.Text.Trim());
                Main.ParaAdd("@User_Icon", buf, System.Data.SqlDbType.Image);
                str = "Update Users set User_Icon=@User_Icon where IDNo=@User_ID";
                Main.NonQuery(str);
            }
        }
         
    }
}