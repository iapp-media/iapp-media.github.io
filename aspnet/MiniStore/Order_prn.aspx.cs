using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniStore
{
    public partial class Order_prn : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                               SD1.SelectParameters.Clear();
                               SD2.SelectParameters.Clear();
                SD1.SelectParameters.Add("IDNo", Request.QueryString["entry"] );
                SD2.SelectParameters.Add("IDNo", Request.QueryString["entry"]);

                }


                L.Text = "Select (select Memo from def_Status where Col_Name='Payment' and Status=Payment_ID) Payment" +
                         ",(select Memo from def_Status where Col_Name='Delivery' and Status=Delivery_ID) Delivery,sum(b.Price) Cost " +
                         " from orders a inner join Order_Content b on a.IDNo=b.Order_ID " +
                         "where a.IDNo=@IDNo group by Payment_ID,Delivery_ID";

                L2.Text = " Select  Contact_Name,TEL,Addr from orders  where IDNo=@IDNo";

            SD1.SelectCommand = L.Text;
            SD1.ConnectionString = Main.ConnStr;
            RP1.DataSourceID = SD1.ID; 

            SD2.SelectCommand = L2.Text;
            SD2.ConnectionString = Main.ConnStr;
            RP2.DataSourceID = SD2.ID;
            }
        }
    }
}