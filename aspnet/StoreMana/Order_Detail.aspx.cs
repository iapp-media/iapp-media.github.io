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
                    L1.Text = "Select a.IDNo,d.Memo,c.Product_Name,b.AMT,a.Order_No,b.Total,CONVERT(varchar(12),a.Creat_Date, 111) CDate from Orders a " +
   " inner join Order_Content b on a.IDNo=b.Order_ID" +
   " inner join Product c on b.Item_ID=c.IDNo" +
   " inner join (select Memo,Status from def_Status where Title='Order_STA') d on d.Status=a.Status" +
   " Where a.IDNo=" + Request.QueryString["entry"] + " and DATEDIFF(MONTH,a.Creat_Date,getdate()) < 3 ";
                    SD1.SelectCommand = L1.Text;
                    SD1.ConnectionString = Main.ConnStr;
                    RP1.DataSourceID = SD1.ID;

                }

            }
 
        }

        protected void Bt_Leave_Click(object sender, EventArgs e)
        {

        }

        protected void RP1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            DropDownList DL_STAt = (DropDownList)e.Item.FindControl("Repeater1$ctl00$DL_STA");
        
            //DropDownList DL_STAt = (DropDownList)e.Item.FindControl("DL_STA");
            
           // Response.Write(aaa.Text);
          //  Comm.GetDDL(DL_STAt, "4");


            //  Main.FillDDP(DL_STA, "select Memo,Status from def_Status where Title='Order_STA'", "Memo", "Status");

        }
    }
}