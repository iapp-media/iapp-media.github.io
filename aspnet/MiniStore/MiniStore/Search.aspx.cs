using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MiniStore
{
    public partial class Search : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //GetDataList();
        }

        protected void BT_Search_Click(object sender, EventArgs e)
        {
            if (TB_Cont.Text == "") { return; }

            Main.ParaClear();
            Main.ParaAdd("@Product_Name", TB_Cont.Text, SqlDbType.NVarChar);

            str = "SELECT top 20 * FROM product,product_img where product.IDNo = product_img.Product_ID and product_img.IDNo in(select max(idno) from product_img GROUP by Product_ID )";
            str += " and Product_Name like '%' + @Product_Name + '%'";

            GetDataList();
        }

        void GetDataList() 
        {
            DataTable d = Main.GetDataSetNoNull(str);
            if (d.Rows.Count > 0)
            {
                Literal1.Text = "";
                for (int i = 0; i < d.Rows.Count; i++)
                {
                    DataRow dw = d.Rows[i];
                    //Literal1.Text += "<li class=\"list-group-item\"><div class=\"row\"><div class=\"col-xs-4\"><img data-src=\"holder.js/50x50\" src=\"" + dw["FilePath"].ToString().Replace("\\","/") + "\" alt=\"\"></div><div>" + dw["Product_Name"].ToString() + "</div></div></li>";
                    //Literal1.Text += "<div class=\"col-sm-6 col-md-4\"><div class=\"thumbnail\"><img src=\"" + dw["FilePath"].ToString().Replace("\\", "/") + "\" data-src=\"holder.js/150x150\" alt=\"\"><div class=\"caption\"><h3>" + dw["Product_Name"].ToString() + "</h3><p>介紹</p></div></div></div>";

                    Literal1.Text += "<a href=\"Product_Detail.aspx?entry=" + dw["IDNo"].ToString() + "\" class=\"thumbnail\"><div class=\"row\"><div class=\"col-xs-4\"><img src=\"" + Comm.URL +
                        dw["FilePath"].ToString().Replace("\\", "/") + "\" style=\"width:100%;height:100%;\" alt=\"\"></div><div class=\"caption\"><h3>" +
                        dw["Product_Name"].ToString() + "</h3><p>" + dw["Description"].ToString() + "</p></div></div></a>";
                }
            }
        }
    }
}