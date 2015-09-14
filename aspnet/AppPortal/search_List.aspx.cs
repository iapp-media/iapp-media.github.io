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

            //JavaScriptSerializer serializer = new JavaScriptSerializer();
          
            //var result = serializer.Serialize(Querylist());
            //string a = "<ul><li>Test</li></ul>";
            Response.Write(Querylist());
            Response.End();
            //Response.Write(Querylist(Request.QueryString["word"]));
        }

        //public class App_Name
        //{
        //    public string Name { get; set; }
        //}

        public string Querylist()
        {
            var x = Request.QueryString["w"].ToString();
            str = "Select top 6 *, b.FoderName from User_App a inner join Theme b on a.Theme_ID=b.IDNo " +
                 " left join Users c on a.User_ID=c.IDNo where App_Name Like '%" + x + "%'";
            System.Data.DataTable dr = Main.GetDataSet(str);
            StringBuilder ss = new StringBuilder();
            ss.Append("<ul class=\"dropdown-menu dropdown-menu-right finder\" role=\"menu\" >" + "\n\r");
            for (int i = 0; i < dr.Rows.Count; i++)
            {
                string src = "img/iapplogo.png";
                if (dr.Rows[i]["App_Icon"].ToString() != "")
                {
                    src = comm.URL.Replace("portal/","") + dr.Rows[i]["FoderName"] + "/Apps/" + dr.Rows[i]["App_Folder"] + "/pic/" + dr.Rows[i]["App_Icon"];
                }
                ss.Append("<li><a href=\"portal.aspx?w=" + dr.Rows[i]["App_Name"].ToString() + "\">" +
                          "<img class=\"finder-app\" src=\"" + src + "\">" + dr.Rows[i]["App_Name"] + "</a></li>" + "\n\r");
            }
            ss.Append("</ul>" + "\n");

                //<ul class="dropdown-menu dropdown-menu-right finder" role="menu">
                //        <li><a href="#">最新</a></li>
                //        <li class="divider"></li>
                //        <li><a href="#">最熱門</a></li>
                //        <li class="divider"></li>
                //        <li><a href="#"><img class="finder-app" src="img/photoicon.png"
                //        > iApp</a></li>
                //    </ul>

            return ss.ToString();
        }
    }
}