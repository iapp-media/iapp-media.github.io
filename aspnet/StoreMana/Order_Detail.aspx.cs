using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StoreMana.Mini
{
    public partial class Order_Detail : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        DataTable d = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Comm.IsNumeric(Request.QueryString["entry"]))
                {

                    SD1.SelectParameters.Clear();
                    SD1.SelectParameters.Add("IDNo", Request.QueryString["entry"]);
                    L1.Text = " Select Item_ID,sum(qty) qty,SUM(Total) total,(select product_name from Product where IDNo=Item_ID) Product_Name " +
                              "from Order_Content where Order_ID=@IDNo group by Item_ID ";


                    SD1.SelectCommand = L1.Text;
                    SD1.ConnectionString = Main.ConnStr;
                    RP1.DataSourceID = SD1.ID; 
                }
            }
        }
        public string ShowImg(object IDNO)
        {
            if (IDNO.ToString().Length > 0)
                return Comm.MiStoreUrl + Main.Scalar("Select FilePath from Product_Img where Product_ID='" + IDNO + "' and Num=1");
            else
                return "";
        }
    }
}