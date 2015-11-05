using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace AppPortal
{
    public partial class search_List : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool comm = new CommTool();
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["SN"] != null && Request.QueryString["w"] != null)
            {
                Response.Write(Querylist());
            }
            else
            { Response.Write(""); }
          
            Response.End(); 
        } 

        public string Querylist()
        {
            var x = Request.QueryString["w"].ToString();
            str = "Select top 6 a.*,b.FilePath  from Product a inner join Product_Img b on a.IDNo=b.Product_ID where Product_Name Like '%" + x + "%'";
            System.Data.DataTable dr = Main.GetDataSet(str);
            StringBuilder ss = new StringBuilder();
            ss.Append("<ul class=\"dropdown-menu dropdown-menu-right finder\" role=\"menu\" >" + "\n\r");
            for (int i = 0; i < dr.Rows.Count; i++)
            {
                string src = dr.Rows[i]["FilePath"].ToString();

                ss.Append("<li><a href=\"default.aspx?SN=" + Request.QueryString["SN"] + "&w=" + dr.Rows[i]["Product_Name"].ToString() + "\">" +
                          "" + dr.Rows[i]["Product_Name"] + "</a></li>" + "\n\r");
                // "<img class=\"finder-app\" src=\"" + src + "\">"
            }
            ss.Append("</ul>" + "\n");
            //
 

            return ss.ToString();
        }
    }
}