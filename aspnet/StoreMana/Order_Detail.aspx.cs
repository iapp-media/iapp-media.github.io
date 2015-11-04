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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {  
                SD1.SelectParameters.Clear();
                SD2.SelectParameters.Clear();
                 SD4.SelectParameters.Clear();
                SD1.SelectParameters.Add("IDNo", Request.QueryString["entry"]);
                SD2.SelectParameters.Add("IDNo", Request.QueryString["entry"]);
                SD4.SelectParameters.Add("IDNo", Request.QueryString["entry"]);

                if (Main.Scalar("select Payment_ID from orders where idno='" + Request.QueryString["entry"] + "'") != "3")
                {
                    Div_Store_ACInfo.Visible = false; 
                }
                else
                {
                    SD3.SelectParameters.Clear();
                    SD3.SelectParameters.Add("IDNo", Request.QueryString["entry"]);
                    L3.Text = " Select b.Bank_Name,b.Bank_No,b.Bank_ACName,b.Bank_ACC from orders a inner join Store_info b on a.Store_ID=b.Store_ID where a.IDNo=@IDNo";
                    SD3.SelectCommand = L3.Text;
                    SD3.ConnectionString = Main.ConnStr;
                    RP3.DataSourceID = SD3.ID;
                }

                L.Text = "Select (select Memo from def_Status where Col_Name='Payment' and Status=Payment_ID) Payment" +
                         ",(select Memo from def_Status where Col_Name='Delivery' and Status=Delivery_ID) Delivery,sum(b.Price) Cost " +
                         " from orders a inner join Order_Content b on a.IDNo=b.Order_ID " +
                         "where a.IDNo=@IDNo group by Payment_ID,Delivery_ID";

                L2.Text = " Select  Contact_Name,TEL,Addr from orders  where IDNo=@IDNo";

                L4.Text = " Select Item_ID,sum(qty) qty,SUM(Total) total,(select product_name from Product where IDNo=Item_ID) name " +
                          "from Order_Content  where Order_ID=@IDNo group by Item_ID";

            }
            SD1.SelectCommand = L.Text;
            SD1.ConnectionString = Main.ConnStr;
            RP1.DataSourceID = SD1.ID;

            SD2.SelectCommand = L2.Text;
            SD2.ConnectionString = Main.ConnStr;
            RP2.DataSourceID = SD2.ID;

            SD4.SelectCommand = L4.Text;
            SD4.ConnectionString = Main.ConnStr;
            RP4.DataSourceID = SD4.ID;

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