using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Set_defS : System.Web.UI.Page
{
    JDB Main = new JDB();
    CommTool Comm = new CommTool();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BTpay_Click(object sender, EventArgs e)
    {
        LChoose.Text = "Payment";
        L.Text = "select * from def_Status where Col_Name='Payment' union select '-1', '', '', '', '' ";
        SD.ConnectionString = Main.ConnStr;
        SD.SelectCommand = L.Text;
        GV.DataSourceID = SD.ID;

    }
    protected void BTDeli_Click(object sender, EventArgs e)
    {
        LChoose.Text = "Delivery";
        L.Text = "select * from def_Status where Col_Name='Delivery'  ";
        SD.ConnectionString = Main.ConnStr;
        SD.SelectCommand = L.Text;
        GV.DataSourceID = SD.ID;
    }
    protected void BTOrder_Click(object sender, EventArgs e)
    {
        LChoose.Text = "Order_STA";
        L.Text = " select * from def_Status where Title='Order_STA'  ";
        SD.ConnectionString = Main.ConnStr;
        SD.SelectCommand = L.Text;
        GV.DataSourceID = SD.ID;
    }
    protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}