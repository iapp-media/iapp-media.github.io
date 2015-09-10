using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniStore
{
    public partial class Product_Detail : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Comm.IsNumeric(Request.QueryString["entry"])) {
                    DataTable d = Main.GetDataSetNoNull("SELECT * FROM product,product_img where product.IDNo = product_img.Product_ID and product.idno =" + Request.QueryString["entry"]);
                    if (d.Rows.Count > 0) {
                        DataRow dw = d.Rows[0];
                        LName.Text = dw["Product_Name"].ToString();
                        LPrice.Text = string.Format("{0:#,##0}", Comm.Cint2(dw["Price"]));
                        Image1.ImageUrl = Comm.URL + dw["FilePath"].ToString();

                    }

                
                }
            
            }
        }
    }
}