using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
public partial class MasterPage : System.Web.UI.MasterPage
{
    JDB Main = new JDB(System.Configuration.ConfigurationManager.AppSettings.Get("Database2"));
    string str = "";

    StringBuilder ss = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["ACC"] == null) { Response.Redirect("~/login.aspx"); }
            GetMenu();
        }

    }
    void GetMenu()
    {
        DataTable DD1 = Main.GetDataSetNoNull("select * from Menu where ref= -1 order by Sort ");
        if (DD1.Rows.Count > 0)
        {
            //str = Session["AccessMenu"].ToString();
            for (int j = 0; j <= DD1.Rows.Count - 1; j++)
            {
                // DataTable DD2 = Main.GetDataSetNoNull("select * from MenuBack where idno in (" + str + ") and ref='" + DD1.Rows(j).Item("IDNo") + "' and op=0 order by Sort");

                DataTable DD2 = Main.GetDataSetNoNull("select * from Menu where   ref='" + DD1.Rows[j]["IDNo"] + "'   order by Sort");
                if (DD2.Rows.Count > 0)
                {
                    ss.Append("<li class=\"panel panel-default dropdown\">");
                    ss.Append("    <a data-toggle=\"collapse\" href=\"#DIV" + DD1.Rows[j]["IDNo"] + "\">");
                    ss.Append("        <span class=\"icon fa fa-desktop\"></span><span class=\"title\">" + DD1.Rows[j]["Title"] + "</span>");
                    ss.Append("    </a>");
                    ss.Append("    <div id=\"DIV" + DD1.Rows[j]["IDNo"] + "\" class=\"panel-collapse collapse\">");
                    ss.Append("        <div class=\"panel-body\">");
                    ss.Append("            <ul class=\"nav navbar-nav\">");

                    //L.Text += "<li><a href=\"#\"><i class=\"fa fa-angle-down fa-fw\"></i>" + DD1.Rows[j]["Name"] + "</a><ul class=\"nav nav-second-level\">";
                    for (int i = 0; i <= DD2.Rows.Count - 1; i++)
                    {
                        ss.Append("                <li><a href=\"" + ResolveUrl("~/" + DD2.Rows[i]["Href"] + "") + "\">" + DD2.Rows[i]["Title"] + "</a>");
                        ss.Append("                </li>");
                        //L.Text += "<li><a target=\"_self\" href=\"/judge_new/mana/" + DD2.Rows[i]["Url"] + "\">" + DD2.Rows[i]["Name"] + "</a></li>";
                    }
                    ss.Append("            </ul>");
                    ss.Append("        </div>");
                    ss.Append("    </div>");
                    ss.Append("</li>");

                }
                else
                {
                    ss.Append(" <li>"); 
                    ss.Append("     <a href=\"" + ResolveUrl("~/" + DD1.Rows[j]["Href"] + "") + "\">");
                    ss.Append("         <span class=\"icon fa fa-tachometer\"></span><span class=\"title\">" + DD1.Rows[j]["Title"] + "</span>");
                    ss.Append("     </a>");
                    ss.Append(" </li>");
                }
            }
            L.Text = ss.ToString();
        }
    }
}