using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniStore
{
    public partial class Index : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        int PageSize = 20;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string QueryStr = "";
                int Currpage = 1;
                if (Comm.IsNumeric(Request.QueryString["s"])) { QueryStr = " and Store_ID=" + Request.QueryString["s"]; }
                if (Comm.IsNumeric(Request.QueryString["p"])) { Currpage = Comm.Cint2(Request.QueryString["p"]); }

                L.Text = "Select *, '" + Comm.URL + "'+IMG as ImgPath from (" +
                         "    Select rank() OVER (ORDER BY IDNo Desc) AS RankNumber, * " +
                         "      , (Select top 1 FilePath from Product_img where Product_ID=a.IDNo) IMG from Product a " +
                         "      where 1=1 " + QueryStr +
                         ") as AA where RankNumber between " + (PageSize * (Currpage - 1)) + " and " + (PageSize * Currpage);


                SD.SelectCommand = L.Text;
                SD.ConnectionString = Main.ConnStr;
                RP1.DataSourceID = SD.ID;


            }
        }
    }
}