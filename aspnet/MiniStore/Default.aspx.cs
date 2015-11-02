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
        string SID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                Main.ParaClear();
                Main.ParaAdd("@Store_NID", Request.QueryString["SN"], SqlDbType.NVarChar);
                SID = Main.Scalar("select IDNo from store where Store_NID=@Store_NID");
                if (SID != "")
                {
                    ShowData();
                }

 
            }
        }
        void ShowData()
        {
 
            Main.ParaClear();
            Main.ParaAdd("@SID", SID, SqlDbType.NVarChar); 
            str = "select a.IDNo,Product_Name,Price,b.FilePath from Product a inner join Product_Img b on a.IDNo=b.Product_ID where b.Num=1 and a.store_id=@SID ";
            if (Request.QueryString["c"] != null)
            {
                Main.ParaAdd("@cate_id", Request.QueryString["c"], SqlDbType.NVarChar); 
                str += " and cate_id=@cate_id ";
            }
            if (Request.QueryString["w"] != null)               //關鍵字
            {
                str += " and ( Product_Name Like @KW or Price like @KW )  ";
                //HL1.NavigateUrl += "&t=" + Request.QueryString["w"];
                Main.ParaAdd("@KW", "%" + HttpUtility.UrlDecode(Request.QueryString["w"]) + "%", SqlDbType.NVarChar);
            }

            StringBuilder ss = new StringBuilder();
            DataTable dr = Main.GetDataSetNoNull(str);
            if (dr.Rows.Count > 0)
            {
                for (int i = 0; i < dr.Rows.Count; i++)
                {
                    DataRow dw = dr.Rows[i]; 

                    ss.Append("<div class='item'>" + "\n\r");
                    ss.Append("  <div class='imgcenter'>\n\r");
                    ss.Append("     <div>" + "\n\r");
                    ss.Append("        <a href='Buy_detail.aspx?entry=" + dw["IDNo"].ToString() + "&SN=" + Request.QueryString["SN"] + "'><img class=\"item-pic\" src='" + dw["FilePath"].ToString() + "'/></a>" + "\n\r");
                     

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
                    ss.Append("        <button > <a href='Buy_Add.aspx?entry=" + dw["IDNo"].ToString() + "&SN=" + Request.QueryString["SN"] + "'>購買</a></button>" + "\n\r");
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