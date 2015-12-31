using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MiniStore
{
    public partial class SInfo : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["SN"] != null)
                {
                    LSinfo.Text = "<a class=\"backarrow\" href=\"Default.aspx?SN=" + Request.QueryString["SN"] + "\"></a>";
                    Main.ParaClear();
                    Main.ParaAdd("@SNID", Request.QueryString["SN"], SqlDbType.NVarChar);
                    str = " select *,(select Cate_Name from Product_Cate where IDNo=Store_Cate) SCName from Store_info where Store_ID in ( select IDNo from Store where Store_NID=@SNID) ";

                    DataTable DT = Main.GetDataSetNoNull(str);
                    if (DT.Rows.Count > 0)
                    {
                        L_DayOff.Text = DT.Rows[0]["DayOff"].ToString();
                        L_place.Text = DT.Rows[0]["Addr"].ToString();
                        L_POTime.Text = DT.Rows[0]["OPTime"].ToString();
                        L_SCate.Text = DT.Rows[0]["SCName"].ToString();
                        L_SName.Text = DT.Rows[0]["Store_Name"].ToString();
                        LTel.Text = DT.Rows[0]["TEL"].ToString();
                        Image1.ImageUrl = DT.Rows[0]["SImg"].ToString();
                    }
                } 
            }
        }
    }
}