using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store_Store_Mana : System.Web.UI.Page
{
    JDB Main = new JDB(System.Configuration.ConfigurationManager.AppSettings.Get("Database2"));
    string Connstr2 = System.Configuration.ConfigurationManager.AppSettings.Get("Database2");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            L.Text = " Select b.IDNo SInfo_ID, b.Store_Name,b.Lv,(select count(1) from Orders where Orders.Store_ID=a.IDNo and Month(Creat_Date)=Month(GETDATE())) as CtOrders," +
                     "       (select count(1) from UrlRefer where UrlRefer.SN=a.Store_NID) as pageview, " +
                     "       (select count(1) from Product where Product.Store_ID=a.IDNo) as CtProduct , " +
                     "       (select Cate_Name from Product_Cate where IDNo=b.Store_Cate ) as Store_Cate " +
                     " from Store a inner join Store_info b on a.IDNo=b.Store_ID " +
                     " where b.ckStep=1          "; 
        }
        SD.ConnectionString = Connstr2;
        SD.SelectCommand = L.Text;
        GV.DataSourceID = SD.ID;
    }
    protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            switch (e.Row.Cells[1].Text)
            {
                case "0":
                    e.Row.Cells[1].Text = "一般會員";
                    break;
                case "1": 
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Orange;
                    e.Row.Cells[1].Text = "VIP會員";
                    break;
                case "9":  
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.YellowGreen;
                    e.Row.Cells[1].Text = "官方帳戶";
                     
                    break;
            }
            
        }
    }
    protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = int.Parse(e.CommandArgument.ToString());
        if (e.CommandName == "CN")
        {
            Response.Redirect("Store_Detail.aspx?entry=" + GV.DataKeys[i][0] + "");
        }
    }
}