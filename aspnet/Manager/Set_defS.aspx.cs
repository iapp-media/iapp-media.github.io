using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Set_defS : System.Web.UI.Page
{
    JDB Main = new JDB(System.Configuration.ConfigurationManager.AppSettings.Get("Database2"));
    CommTool Comm = new CommTool();
    string str = "";
    string Constr = System.Configuration.ConfigurationManager.AppSettings.Get("Database2");
    protected void Page_Load(object sender, EventArgs e)
    {
        SD.ConnectionString = Main.ConnStr;
        SD.SelectCommand = L.Text;
        GV.DataSourceID = SD.ID;
    }

    protected void BTpay_Click(object sender, EventArgs e)
    {
        
        LTitle.Text = "付款方式";
        LColName.Text = "Payment";
        L.Text = "select * from def_Status where Col_Name='Payment' union select '-1', '', '', '', '' ";
        SD.ConnectionString = Constr;
        SD.SelectCommand = L.Text;
        GV.DataSourceID = SD.ID;

    }
    protected void BTDeli_Click(object sender, EventArgs e)
    {
        LTitle.Text = "運送方式";
        LColName.Text = "Delivery";
        L.Text = "select * from def_Status where Col_Name='Delivery' union select '-1', '', '', '', '' ";
        SD.ConnectionString = Constr;
        SD.SelectCommand = L.Text;
        GV.DataSourceID = SD.ID;
    }
    protected void BTOrder_Click(object sender, EventArgs e)
    { 
        LTitle.Text = "Order_STA";
        LColName.Text = "Status";
        L.Text = " select * from def_Status where Title='Order_STA' union select '-1', '', '', '', '' ";
        SD.ConnectionString = Constr;
        SD.SelectCommand = L.Text;
        GV.DataSourceID = SD.ID;
    }
    protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = int.Parse(e.CommandArgument.ToString());
        if (e.CommandName == "CN")
        {
            TextBox T1 = (TextBox)GV.Rows[i].Cells[2].Controls[1];
            TextBox T2 = (TextBox)GV.Rows[i].Cells[3].Controls[1];


            string tmp = "";
            if (T1.Text.Trim() == "") { tmp += ",狀態"; }
            if (T2.Text.Trim() == "") { tmp += ",Memo"; }
            if (tmp != "")
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "String", "<script>alert('請填入" + tmp.Substring(1) + "');</script>");
                return;
            }
            int num1;
            if (int.TryParse(T1.Text, out num1) == false)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "String", "<script>alert('狀態請填入數字');</script>");
                return;
            }
         
            Main.ParaClear();
            Main.ParaAdd("@IDNo", Main.Cint2(GV.DataKeys[i][0].ToString()), SqlDbType.Int);
            Main.ParaAdd("@Status", T1.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@Memo", T2.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@ColName", LColName.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@Title", LTitle.Text, SqlDbType.NVarChar);

            if (Main.Scalar("select sum(1) from def_Status where Title=@Title and Col_Name=@ColName and Status=@Status and IDNo!=@IDNo") == "1")
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "String", "<script>alert('狀態重複');</script>");
                return;
            }

            int nid = Comm.Cint2(GV.DataKeys[i][0]);
            if (nid == -1)
            {

                str = "Insert into def_Status (Title, Col_Name, Status, Memo) " +
                                   " values (@Title, @ColName, @Status, @Memo)"; 
            }
            else
            {
                Main.ParaAdd("@item_id", nid, SqlDbType.Int);
                str = "Update def_Status Set Title=@Title, Col_Name=@ColName, Status=@Status, Memo=@Memo where IDNo = @IDNo";

            }

            Main.NonQuery(str);
        }
        if (e.CommandName == "DELE")
        {
            Main.ParaClear();
            Main.ParaAdd("@IDNo", Main.Cint2(GV.DataKeys[i][0].ToString()), SqlDbType.Int);
            string str = "delete from def_Status where  IDNo = @IDNo";
            Main.NonQuery(str);
        }
        SD.ConnectionString = Constr;
        SD.SelectCommand = L.Text;
        GV.DataSourceID = SD.ID;
    }
    protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex>-1)
        {
            Button B1 = (Button)e.Row.Cells[0].Controls[0];
            Button B2 = (Button)e.Row.Cells[1].Controls[0]; 

             B2.Enabled = false;
             B2.ForeColor = System.Drawing.Color.Gray;
            if (GV.DataKeys[e.Row.RowIndex][0].ToString() == "-1")
            {
                B1.Text = "新增";
                B2.Visible = false;
              
            }            
        }
    }
}