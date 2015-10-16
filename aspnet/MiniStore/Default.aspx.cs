using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace MiniStore
{
    public partial class Default : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        string str = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
                if (Comm.IsNumeric(Request.QueryString["entry"]))
                {
                    ShowData();
                }
            }
        }
        void ShowData() {
            str = "select a.IDNo,Product_Name,Price,b.FilePath from Product a inner join Product_Img b on a.IDNo=b.Product_ID where b.Num=1";
            StringBuilder ss = new StringBuilder(); 
            DataTable dr = Main.GetDataSetNoNull(str);
            if (dr.Rows.Count > 0)
            {
                for (int i = 0; i < dr.Rows.Count; i++)
                {
                    DataRow dw = dr.Rows[i];
                    string src ="";// +dw["Img01"];
                    string iGD = "";
                    string iLK = "";
                    string iFV = "";
                    //if (Comm.Cint2(dw["iGD"].ToString()) > 0) { iGD = " checked"; }
                    //if (Comm.Cint2(dw["iLK"].ToString()) > 0) { iLK = " checked"; }
                    //if (Comm.Cint2(dw["iFV"].ToString()) > 0) { iFV = " checked"; }

                    //if (!string.IsNullOrEmpty(dw["App_Cover"].ToString()))
                    //{
                    //   // src = url + dr.Rows[i]["FoderName"] + "/Apps/" + dw["App_Folder"] + "/pic/" + dw["App_Cover"];
                    //}
                    //else
                    //{
                    //    src = "img/p00.jpg";
                        //}

                        // if (Comm.CheckMobile() == false)
                   
                        ss.Append("<div class='item'>" + "\n\r");
                        ss.Append("  <div class='imgcenter'>\n\r");
                        ss.Append("     <div>" + "\n\r");
                        ss.Append("       <a class='#' href=\"" + "#" + "\"><img class=\"item-pic\" src='" + dw["FilePath"].ToString() + "'/></a>" + "\n\r");

                        //doListItem(ref ss, iLK, iGD, iFV, dw);

                        ss.Append("     </div>\n\r");
                        ss.Append("     <div class='col-xs-12 description'>" + "\n\r");
                        ss.Append("         <div class='col-xs-12'>" + "\n\r");
                        ss.Append("             <div class='row'>" + "\n");
                        ss.Append("             <p class='describe'>" + dw["Product_Name"].ToString() + "</p>" + "\n\r");
                        ss.Append("             </div>" + "\n");
                        ss.Append("         </div>" + "\n");
                        ss.Append("         <div class='col-xs-12'>" + "\n\r");
                        ss.Append("             <div class='row'>" + "\n");
                        ss.Append("             <input type='checkbox'  name='CC' />" + "\n");
                        ss.Append("             <label for='c3'></label>" + "\n");
                        ss.Append("             </div>" + "\n");
                        ss.Append("         </div>" + "\n");
                        ss.Append("     </div>" + "\n");
                        ss.Append("     <div class='col-xs-12'>" + "\n\r");
                        ss.Append("         <p class='iapp-name'>NT$" + dw["Price"].ToString() + "</p>" + "\n\r");
                        ss.Append("        <button > <a href='Buy_Add.aspx?entry=" + dw["IDNo"].ToString() + "'>購買</a></button>" + "\n\r");
                        ss.Append("     </div>" + "\n");
                        ss.Append("  </div>" + "\n");
                        ss.Append("</div>" + "\n"); 
                     


                }
            }
            else
            {
                ss.Clear();
            }
            LData.Text = ss.ToString();
        }
    }
}